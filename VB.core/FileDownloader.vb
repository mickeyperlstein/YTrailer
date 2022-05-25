Imports System.ComponentModel
Imports System.IO
Imports System.Net


Public Enum DownloadStatus
    None
    Downloading
    Paused
    Success
    Failed
    Canceled
End Enum
Public Class FileDownloader
    Inherits AbortableBackgroundWorker
    ' Block size to download is by default 1K.
    Public Shared DownloadBlockSize As Integer = 1024 * 200

    Public ReadOnly Property PathAndFile() As String
        Get
            Return downloadingTo
        End Get
    End Property
    Private downloadingTo As String
    Public Property FileUrl() As String
        Get
            Return m_FileUrl
        End Get
        Private Set(value As String)
            m_FileUrl = value
        End Set
    End Property
    Private m_FileUrl As String
    Public Property DestFolder() As String
        Get
            Return m_DestFolder
        End Get
        Private Set(value As String)
            m_DestFolder = value
        End Set
    End Property
    Private m_DestFolder As String
    Public Property DestFileName() As String
        Get
            Return m_DestFileName
        End Get
        Private Set(value As String)
            m_DestFileName = value
        End Set
    End Property
    Private m_DestFileName As String
    ''' <summary>
    ''' Gets the current DownloadStatus
    ''' </summary>
    Public Property DownloadStatus() As DownloadStatus
        Get
            Return m_DownloadStatus
        End Get
        Private Set(value As DownloadStatus)
            m_DownloadStatus = value
        End Set
    End Property
    Private m_DownloadStatus As DownloadStatus
    ''' <summary>
    ''' Gets the current DownloadData
    ''' </summary>
    Public Property DownloadData() As DownloadData
        Get
            Return m_DownloadData
        End Get
        Private Set(value As DownloadData)
            m_DownloadData = value
        End Set
    End Property
    Private m_DownloadData As DownloadData
    ''' <summary>
    ''' Gets the current DownloadSpeed
    ''' </summary>
    Public Property DownloadSpeed() As Integer
        Get
            Return m_DownloadSpeed
        End Get
        Private Set(value As Integer)
            m_DownloadSpeed = value
        End Set
    End Property
    Private m_DownloadSpeed As Integer
    ''' <summary>
    ''' Gets the estimate time to finish downloading, the time is in seconds
    ''' </summary>
    Public ReadOnly Property ETA() As Long
        Get
            If DownloadData Is Nothing OrElse DownloadSpeed = 0 Then
                Return 0
            End If
            Dim remainBytes As Long = DownloadData.FileSize - totalDownloaded
            Return remainBytes \ DownloadSpeed
        End Get
    End Property
    Public Sub New(FileUrl As String, DestFolder As String, DestFileName As String)
        Me.FileUrl = FileUrl
        Me.DestFolder = DestFolder
        Me.DestFileName = DestFileName
        If String.IsNullOrEmpty(DestFileName) Then
            Path.GetFileName(DownloadData.Response.ResponseUri.ToString())
        End If
        Me.downloadingTo = Path.Combine(DestFolder, DestFileName)

        AddHandler DoWork, AddressOf download
    End Sub

    ''' <summary>
    ''' Proxy to be used for http and ftp requests.
    ''' </summary>
    Public ReadOnly Property Proxy() As IWebProxy
        Get
            Return Helper.InitialProxy()
        End Get
    End Property
    Public Property Progress() As Integer
        Get
            Return m_Progress
        End Get
        Private Set(value As Integer)
            m_Progress = value
        End Set
    End Property
    Private m_Progress As Integer
    ''' <summary>
    ''' Make the download to Pause
    ''' </summary>
    Public Sub Pause()
        _pause = True
    End Sub
    ''' <summary>
    ''' Make the download to resume
    ''' </summary>
    Public Sub [Resume]()
        _pause = False
    End Sub
    Private _pause As Boolean
    Shared SecondTicks As Long = TimeSpan.FromSeconds(1).Ticks
    Private fileStream As FileStream
    Private totalDownloaded As Long
    ''' <summary>
    ''' Begin downloading the file at the specified url, and save it to the given folder.
    ''' </summary>
    Public Sub Download(sender As Object, e As DoWorkEventArgs)
        
        _pause = False
        DownloadStatus = DownloadStatus.Downloading
        OnProgressChanged(New ProgressChangedEventArgs(Progress, Nothing))
        DownloadData = DownloadData.Create(FileUrl, DestFolder, Me.DestFileName, Me.Proxy)
        
        Dim mode As FileMode = If(DownloadData.StartPoint > 0, FileMode.Append, FileMode.OpenOrCreate)
        fileStream = File.Open(downloadingTo, mode, FileAccess.Write)
        Dim buffer As Byte() = New Byte(DownloadBlockSize - 1) {}
        totalDownloaded = DownloadData.StartPoint
        Dim totalDownloadedInTime As Double = 0
        Dim totalDownloadedTime As Long = 0
        OnProgressChanged(New ProgressChangedEventArgs(Progress, Nothing))
        Dim callProgess As Boolean = True
        While True
            callProgess = True
            If CancellationPending Then
                DownloadSpeed = InlineAssignHelper(Progress, 0)
                e.Cancel = True
                Exit While
            End If
            If _pause Then
                DownloadSpeed = 0
                DownloadStatus = DownloadStatus.Paused
                System.Threading.Thread.Sleep(500)
            Else
                DownloadStatus = DownloadStatus.Downloading
                Dim startTime As Long = DateTime.Now.Ticks
                Dim readCount As Integer = DownloadData.DownloadStream.Read(buffer, 0, DownloadBlockSize)
                If readCount = 0 Then
                    Exit While
                End If
                totalDownloadedInTime += readCount
                totalDownloadedTime += DateTime.Now.Ticks - startTime
                If InlineAssignHelper(callProgess, totalDownloadedTime >= SecondTicks) Then
                    DownloadSpeed = CInt(Math.Truncate(totalDownloadedInTime / TimeSpan.FromTicks(totalDownloadedTime).TotalSeconds))
                    totalDownloadedInTime = 0
                    totalDownloadedTime = 0
                End If
                totalDownloaded += readCount
                fileStream.Write(buffer, 0, readCount)
                fileStream.Flush()
            End If
            Progress = CInt(Math.Truncate(100.0 * totalDownloaded / DownloadData.FileSize))
            If callProgess AndAlso DownloadData.IsProgressKnown Then
                ReportProgress(Progress)
            End If
        End While
        ReportProgress(Progress)
    End Sub
    Protected Overrides Sub OnRunWorkerCompleted(e As RunWorkerCompletedEventArgs)
        Try
            If DownloadData IsNot Nothing Then
                DownloadData.Close()
            End If
        Catch
        End Try
        Try
            If fileStream IsNot Nothing Then
                fileStream.Close()
            End If
        Catch
        End Try
        If e.Cancelled Then
            DownloadStatus = DownloadStatus.Canceled
        ElseIf e.[Error] IsNot Nothing Then
            DownloadStatus = DownloadStatus.Failed
        Else
            DownloadStatus = DownloadStatus.Success
        End If
        DownloadSpeed = 0
        MyBase.OnRunWorkerCompleted(e)
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

''' <summary>
''' Constains the connection to the file server and other statistics about a file
''' that's downloading.
''' </summary>
Public Class DownloadData
    Private m_response As WebResponse

    Private stream As Stream
    Private size As Long
    Private start As Long

    Private proxy As IWebProxy = Nothing

    Public Shared Function Create(url As String, destFolder As String, fileName As [String]) As DownloadData
        Return Create(url, destFolder, fileName, Nothing)
    End Function

    Public Shared Function Create(url As String, destFolder As String, fileName As [String], proxy As IWebProxy) As DownloadData

        ' This is what we will return
        Dim downloadData As New DownloadData()
        downloadData.proxy = proxy

        Dim urlSize As Long = downloadData.GetFileSize(url)
        downloadData.size = urlSize

        Dim req As WebRequest = downloadData.GetRequest(url)
        Try
            downloadData.Response = DirectCast(req.GetResponse(), WebResponse)
        Catch e As Exception
            Throw New ArgumentException([String].Format("Error downloading ""{0}"": {1}", url, e.Message), e)
        End Try

        ' Check to make sure the response isn't an error. If it is this method
        ' will throw exceptions.
        ValidateResponse(downloadData.Response, url)

        Dim downloadTo As [String] = Path.Combine(destFolder, fileName)

        ' If we don't know how big the file is supposed to be,
        ' we can't resume, so delete what we already have if something is on disk already.
        If Not downloadData.IsProgressKnown AndAlso File.Exists(downloadTo) Then
            File.Delete(downloadTo)
        End If

        If downloadData.IsProgressKnown AndAlso File.Exists(downloadTo) Then
            ' We only support resuming on http requests
            If Not (TypeOf downloadData.Response Is HttpWebResponse) Then
                File.Delete(downloadTo)
            Else
                ' Try and start where the file on disk left off
                downloadData.start = New FileInfo(downloadTo).Length

                ' If we have a file that's bigger than what is online, then something 
                ' strange happened. Delete it and start again.
                If downloadData.start > urlSize Then
                    File.Delete(downloadTo)
                ElseIf downloadData.start < urlSize Then
                    ' Try and resume by creating a new request with a new start position
                    downloadData.Response.Close()
                    req = downloadData.GetRequest(url)
                    DirectCast(req, HttpWebRequest).AddRange(CInt(downloadData.start))
                    downloadData.Response = req.GetResponse()

                    If DirectCast(downloadData.Response, HttpWebResponse).StatusCode <> HttpStatusCode.PartialContent Then
                        ' They didn't support our resume request. 
                        File.Delete(downloadTo)
                        downloadData.start = 0
                    End If
                End If
            End If
        End If
        Return downloadData
    End Function

    ' Used by the factory method
    Private Sub New()
    End Sub

    Private Sub New(response As WebResponse, size As Long, start As Long)
        Me.m_response = response
        Me.size = size
        Me.start = start
        Me.stream = Nothing
    End Sub

    ''' <summary>
    ''' Checks whether a WebResponse is an error.
    ''' </summary>
    ''' <param name="response"></param>
    Private Shared Sub ValidateResponse(response As WebResponse, url As String)
        If TypeOf response Is HttpWebResponse Then
            Dim httpResponse As HttpWebResponse = DirectCast(response, HttpWebResponse)
            ' If it's an HTML page, it's probably an error page. Comment this
            ' out to enable downloading of HTML pages.
            If httpResponse.ContentType.Contains("text/html") OrElse httpResponse.StatusCode = HttpStatusCode.NotFound Then
                Throw New ArgumentException([String].Format("Could not download ""{0}"" - a web page was returned from the web server.", url))
            End If
        ElseIf TypeOf response Is FtpWebResponse Then
            Dim ftpResponse As FtpWebResponse = DirectCast(response, FtpWebResponse)
            If ftpResponse.StatusCode = FtpStatusCode.ConnectionClosed Then
                Throw New ArgumentException([String].Format("Could not download ""{0}"" - FTP server closed the connection.", url))
            End If
        End If
        ' FileWebResponse doesn't have a status code to check.
    End Sub

    ''' <summary>
    ''' Checks the file size of a remote file. If size is -1, then the file size
    ''' could not be determined.
    ''' </summary>
    ''' <param name="url"></param>
    ''' <param name="progressKnown"></param>
    ''' <returns></returns>
    Public Function GetFileSize(url As String) As Long
        Dim response As WebResponse = Nothing
        Dim size As Long = -1
        Try
            response = GetRequest(url).GetResponse()
            size = response.ContentLength
        Finally
            If response IsNot Nothing Then
                response.Close()
            End If
        End Try

        Return size
    End Function

    Private Function GetRequest(url As String) As WebRequest
        'WebProxy proxy = WebProxy.GetDefaultProxy();
        Dim request As WebRequest = WebRequest.Create(url)
        If TypeOf request Is HttpWebRequest Then
            request.Credentials = CredentialCache.DefaultCredentials
            Dim result As Uri = request.Proxy.GetProxy(New Uri("http://www.google.com"))
        End If

        If Me.proxy IsNot Nothing Then
            request.Proxy = Me.proxy
        End If

        Return request
    End Function

    Public Sub Close()
        Me.m_response.Close()
    End Sub

#Region "Properties"
    Public Property Response() As WebResponse
        Get
            Return m_response
        End Get
        Set(value As WebResponse)
            m_response = value
        End Set
    End Property
    Public ReadOnly Property DownloadStream() As Stream
        Get
            If Me.start = Me.size Then
                Return stream.Null
            End If
            If Me.stream Is Nothing Then
                Me.stream = Me.m_response.GetResponseStream()
            End If
            Return Me.stream
        End Get
    End Property
    Public ReadOnly Property FileSize() As Long
        Get
            Return Me.size
        End Get
    End Property
    Public ReadOnly Property StartPoint() As Long
        Get
            Return Me.start
        End Get
    End Property
    Public ReadOnly Property IsProgressKnown() As Boolean
        Get
            ' If the size of the remote url is -1, that means we
            ' couldn't determine it, and so we don't know
            ' progress information.
            Return Me.size > -1
        End Get
    End Property
#End Region
End Class


