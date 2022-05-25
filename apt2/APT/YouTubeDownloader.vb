'Copy rights are reserved for Akram kamal qassas
'Email me, Akramnet4u@hotmail.com
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Net
Imports WindowsApplication1.My

''' <summary>
''' Contains information about the video url extension and dimension
''' </summary>
Public Class YouTubeVideoQuality
    ''' <summary>
    ''' Gets or Sets the file name
    ''' </summary>
    Public Property VideoTitle() As String
        Get
            Return m_VideoTitle
        End Get
        Set(value As String)
            m_VideoTitle = value
        End Set
    End Property
    Private m_VideoTitle As String
    ''' <summary>
    ''' Gets or Sets the file extention
    ''' </summary>
    Public Property Extention() As String
        Get
            Return m_Extention
        End Get
        Set(value As String)
            m_Extention = value
        End Set
    End Property
    Private m_Extention As String
    ''' <summary>
    ''' Gets or Sets the file url
    ''' </summary>
    Public Property DownloadUrl() As String
        Get
            Return m_DownloadUrl
        End Get
        Set(value As String)
            m_DownloadUrl = value
        End Set
    End Property
    Private m_DownloadUrl As String
    ''' <summary>
    ''' Gets or Sets the youtube video url
    ''' </summary>
    Public Property VideoUrl() As String
        Get
            Return m_VideoUrl
        End Get
        Set(value As String)
            m_VideoUrl = value
        End Set
    End Property
    Private m_VideoUrl As String
    ''' <summary>
    ''' Gets or Sets the youtube video size
    ''' </summary>
    Public Property VideoSize() As Long
        Get
            Return m_VideoSize
        End Get
        Set(value As Long)
            m_VideoSize = value
        End Set
    End Property
    Private m_VideoSize As Long
    ''' <summary>
    ''' Gets or Sets the youtube video dimension
    ''' </summary>
    Public Property Dimension() As Size
        Get
            Return m_Dimension
        End Get
        Set(value As Size)

            m_Dimension = value
        End Set
    End Property
    Private m_Dimension As Size
    ''' <summary>
    ''' Gets the youtube video length
    ''' </summary>
    Public Property Length() As Long
        Get
            Return m_Length
        End Get
        Set(value As Long)
            m_Length = value
        End Set
    End Property
    Private m_Length As Long
    Public Overrides Function ToString() As String
        Return Extention & " File " & Dimension.Width & "x" & Dimension.Height
    End Function

    Public Sub SetQuality(Extention As String, Dimension As Size)
        Me.Extention = Extention
        Me.Dimension = Dimension
    End Sub

    Public Sub SetSize(size As Long)
        Me.VideoSize = size
    End Sub
End Class
''' <summary>
''' Use this class to get youtube video urls
''' </summary>
Public Class YouTubeDownloader
    Public Shared Function GetYouTubeVideoUrls(ParamArray VideoUrls As String()) As List(Of YouTubeVideoQuality)
        Dim urls As New List(Of YouTubeVideoQuality)()
        For Each VideoUrl As Object In VideoUrls
            Dim html As String = Helper.DownloadWebPage(VideoUrl)
            Dim title As String = GetTitle(html)
            For Each videoLink As Object In ExtractUrls(html)
                Try
                    Dim q As New YouTubeVideoQuality()
                    q.VideoUrl = VideoUrl
                    q.VideoTitle = title
                    q.DownloadUrl = videoLink & "&title=" & title
                    If Not getSize(q) Then
                        Continue For
                    End If
                    Dim s As String = Resources.Youtube_length




                    'q.Length = Long.Parse(Regex.Match(html, """length_seconds\":(.+?)""", RegexOptions.Singleline).Groups(1).ToString())
                    q.Length = Long.Parse(Regex.Match(html, s, RegexOptions.Singleline).Groups(1).ToString())
                    Dim IsWide As Boolean = IsWideScreen(html)
                    If getQuality(q, IsWide) Then
                        urls.Add(q)
                    End If
                Catch ex As Exception
                    Dim d = ex.Message
                End Try
            Next
        Next
        Return urls
    End Function
    Private Shared Function GetTitle(RssDoc As String) As String
        Dim str14 As String = Helper.GetTxtBtwn(RssDoc, "'VIDEO_TITLE': '", "'", 0)
        If str14 = "" Then
            str14 = Helper.GetTxtBtwn(RssDoc, """title"" content=""", """", 0)
        End If
        If str14 = "" Then
            str14 = Helper.GetTxtBtwn(RssDoc, "&title=", "&", 0)
        End If
        str14 = str14.Replace("\", "").Replace("'", "'").Replace("""", "'").Replace("<", "<").Replace(">", ">").Replace("+", " ")
        Return str14
    End Function

    Private Shared Function ExtractUrls(originalhtml As String) As List(Of String)
        Dim urls As New List(Of String)()
        Dim DataBlockStart As String = """url_encoded_fmt_stream_map"":\S+""(.+?)&"
        ' Marks start of Javascript Data Block
        Dim html As String = Uri.UnescapeDataString(Regex.Match(originalhtml, DataBlockStart, RegexOptions.Singleline).Groups(1).ToString())

        Dim firstPatren As String = html.Substring(0, html.IndexOf("="c) + 1)
        Dim matchs = Regex.Split(html, firstPatren)
        For i As Integer = 0 To matchs.Length - 1
            matchs(i) = firstPatren & matchs(i)
        Next
        For Each match As Object In matchs
            If Not match.Contains("url=") Then
                Continue For
            End If

            Dim url As String = Helper.GetTxtBtwn(match, "url=", "\u0026", 0)
            If url = "" Then
                url = Helper.GetTxtBtwn(match, "url=", ",url", 0)
            End If
            If url = "" Then
                url = Helper.GetTxtBtwn(match, "url=", """,", 0)
            End If

            Dim sig As String = Helper.GetTxtBtwn(match, "sig=", "\u0026", 0)
            If sig = "" Then
                sig = Helper.GetTxtBtwn(match, "sig=", ",sig", 0)
            End If
            If sig = "" Then
                sig = Helper.GetTxtBtwn(match, "sig=", """,", 0)
            End If

            While (url.EndsWith(",")) OrElse (url.EndsWith(".")) OrElse (url.EndsWith(""""))
                url = url.Remove(url.Length - 1, 1)
            End While

            While (sig.EndsWith(",")) OrElse (sig.EndsWith(".")) OrElse (sig.EndsWith(""""))
                sig = sig.Remove(sig.Length - 1, 1)
            End While

            If String.IsNullOrEmpty(url) Then
                Continue For
            End If
            If Not String.IsNullOrEmpty(sig) Then
                url += "&signature=" & sig
            End If
            urls.Add(url)
        Next
        Return urls
    End Function

    Private Shared Function getQuality(q As YouTubeVideoQuality, _Wide As [Boolean]) As Boolean
        Dim iTagValue As Integer
        Dim itag As String = Regex.Match(q.DownloadUrl, "itag=([1-9]?[0-9]?[0-9])", RegexOptions.Singleline).Groups(1).ToString()
        If itag <> "" Then
            If Integer.TryParse(itag, iTagValue) = False Then
                iTagValue = 0
            End If

            Select Case iTagValue
                Case 5
                    q.SetQuality("flv", New Size(320, (If(_Wide, 180, 240))))
                    Exit Select
                Case 6
                    q.SetQuality("flv", New Size(480, (If(_Wide, 270, 360))))
                    Exit Select
                Case 17
                    q.SetQuality("3gp", New Size(176, (If(_Wide, 99, 144))))
                    Exit Select
                Case 18
                    q.SetQuality("mp4", New Size(640, (If(_Wide, 360, 480))))
                    Exit Select
                Case 22
                    q.SetQuality("mp4", New Size(1280, (If(_Wide, 720, 960))))
                    Exit Select
                Case 34
                    q.SetQuality("flv", New Size(640, (If(_Wide, 360, 480))))
                    Exit Select
                Case 35
                    q.SetQuality("flv", New Size(854, (If(_Wide, 480, 640))))
                    Exit Select
                Case 36
                    q.SetQuality("3gp", New Size(320, (If(_Wide, 180, 240))))
                    Exit Select
                Case 37
                    q.SetQuality("mp4", New Size(1920, (If(_Wide, 1080, 1440))))
                    Exit Select
                Case 38
                    q.SetQuality("mp4", New Size(2048, (If(_Wide, 1152, 1536))))
                    Exit Select
                Case 43
                    q.SetQuality("webm", New Size(640, (If(_Wide, 360, 480))))
                    Exit Select
                Case 44
                    q.SetQuality("webm", New Size(854, (If(_Wide, 480, 640))))
                    Exit Select
                Case 45
                    q.SetQuality("webm", New Size(1280, (If(_Wide, 720, 960))))
                    Exit Select
                Case 46
                    q.SetQuality("webm", New Size(1920, (If(_Wide, 1080, 1440))))
                    Exit Select
                Case 82
                    q.SetQuality("3D.mp4", New Size(480, (If(_Wide, 270, 360))))
                    Exit Select
                    ' 3D
                Case 83
                    q.SetQuality("3D.mp4", New Size(640, (If(_Wide, 360, 480))))
                    Exit Select
                    ' 3D
                Case 84
                    q.SetQuality("3D.mp4", New Size(1280, (If(_Wide, 720, 960))))
                    Exit Select
                    ' 3D
                Case 85
                    q.SetQuality("3D.mp4", New Size(1920, (If(_Wide, 1080, 1440))))
                    Exit Select
                    ' 3D
                Case 100
                    q.SetQuality("3D.webm", New Size(640, (If(_Wide, 360, 480))))
                    Exit Select
                    ' 3D
                Case 101
                    q.SetQuality("3D.webm", New Size(640, (If(_Wide, 360, 480))))
                    Exit Select
                    ' 3D
                Case 102
                    q.SetQuality("3D.webm", New Size(1280, (If(_Wide, 720, 960))))
                    Exit Select
                    ' 3D
                Case 120
                    q.SetQuality("live.flv", New Size(1280, (If(_Wide, 720, 960))))
                    Exit Select
                Case Else
                    ' Live-streaming - should be ignored?
                    q.SetQuality("itag-" & itag, New Size(1, 1))
                    Exit Select
                    ' unknown or parse error
            End Select
            Return True
        End If
        Return False
    End Function
    ''' <summary>
    ''' check whether the video is in widescreen format
    ''' </summary>
    Public Shared Function IsWideScreen(html As String) As [Boolean]
        Dim res As Boolean = False

        Dim match As String = Regex.Match(html, "'IS_WIDESCREEN':\s+(.+?)\s+", RegexOptions.Singleline).Groups(1).ToString().ToLower().Trim()
        res = ((match = "true") OrElse (match = "true,"))
        Return res
    End Function

    Private Shared Function getSize(q As YouTubeVideoQuality) As Boolean
        Try
            Dim fileInfoRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create(q.DownloadUrl), HttpWebRequest)
            Dim fileInfoResponse As HttpWebResponse = DirectCast(fileInfoRequest.GetResponse(), HttpWebResponse)
            Dim bytesLength As Long = fileInfoResponse.ContentLength
            fileInfoRequest.Abort()
            If bytesLength <> -1 Then
                q.SetSize(bytesLength)
                Return True
            Else
                Return False
            End If
        Catch generatedExceptionName As Exception
            Return False
        End Try
    End Function
End Class

