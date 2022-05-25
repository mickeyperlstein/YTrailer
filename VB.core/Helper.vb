'Copy rights are reserved for Akram kamal qassas
'Email me, Akramnet4u@hotmail.com
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Text.RegularExpressions


Public NotInheritable Class FormatLeftTime
    Private Sub New()
    End Sub
    Private Shared TimeUnitsNames As String() = {"Milli", "Sec", "Min", "Hour", "Day", "Month", _
        "Year", "Decade", "Century"}
    Private Shared TimeUnitsValue As Integer() = {1000, 60, 60, 24, 30, 12, _
        10, 10}
    'refrernce unit is milli
    Public Shared Function Format(millis As Long) As String
        Dim format__1 As String = ""
        For i As Integer = 0 To TimeUnitsValue.Length - 1
            Dim y As Long = millis Mod TimeUnitsValue(i)
            millis = millis \ TimeUnitsValue(i)
            If y = 0 Then
                Continue For
            End If
            format__1 = y & " " & TimeUnitsNames(i) & " , " & format__1
        Next

        format__1 = format__1.Trim(","c, " "c)
        If format__1 = "" Then
            Return "0 Sec"
        Else
            Return format__1
        End If
    End Function
End Class
Public NotInheritable Class Helper
    Private Sub New()
    End Sub


    Public Shared Function UrlDecode(str As String) As String
        Return UrlDecode(UrlDecode(str))
    End Function

    Public Shared Function isValidUrl(url As String) As Boolean
        Dim pattern As String = "^(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&:/~\+#]*[\w\-\@?^=%&/~\+#])?$"
        Dim regex As New Regex(pattern, RegexOptions.Compiled Or RegexOptions.IgnoreCase)
        Return regex.IsMatch(url)
    End Function
    ''' <summary>
    ''' Gets the txt that lies between these two strings
    ''' </summary>
    Public Shared Function GetTxtBtwn(input As String, start As String, [end] As String, startIndex As Integer) As String
        Return GetTxtBtwn(input, start, [end], startIndex, False)
    End Function
    ''' <summary>
    ''' Gets the txt that lies between these two strings
    ''' </summary>
    Public Shared Function GetLastTxtBtwn(input As String, start As String, [end] As String, startIndex As Integer) As String
        Return GetTxtBtwn(input, start, [end], startIndex, True)
    End Function
    ''' <summary>
    ''' Gets the txt that lies between these two strings
    ''' </summary>
    Private Shared Function GetTxtBtwn(input As String, start As String, [end] As String, startIndex As Integer, UseLastIndexOf As Boolean) As String
        Dim index1 As Integer = If(UseLastIndexOf, input.LastIndexOf(start, startIndex), input.IndexOf(start, startIndex))
        If index1 = -1 Then
            Return ""
        End If
        index1 += start.Length
        Dim index2 As Integer = input.IndexOf([end], index1)
        If index2 = -1 Then
            Return input.Substring(index1)
        End If
        Return input.Substring(index1, index2 - index1)
    End Function

    ''' <summary>
    ''' Split the input text for this pattren
    ''' </summary>
    Public Shared Function Split(input As String, pattren As String) As String()
        Return Regex.Split(input, pattren)
    End Function


    ''' <summary>
    ''' Returns the content of a given web adress as string.
    ''' </summary>
    ''' <param name="Url">URL of the webpage</param>
    ''' <returns>Website content</returns>
    Public Shared Function DownloadWebPage(Url As String) As String
        Return DownloadWebPage(Url, Nothing)
    End Function

    Private Shared Function DownloadWebPage(Url As String, stopLine As String) As String
        Try
            ' Open a connection
            Dim WebRequestObject As HttpWebRequest = DirectCast(HttpWebRequest.Create(Url), HttpWebRequest)
            WebRequestObject.Proxy = InitialProxy()
            ' You can also specify additional header values like 
            ' the user agent or the referer:
            WebRequestObject.UserAgent = ".NET Framework/2.0"

            ' Request response:
            Dim Response As WebResponse = WebRequestObject.GetResponse()

            ' Open data stream:
            Dim WebStream As Stream = Response.GetResponseStream()

            ' Create reader object:
            Dim Reader As New StreamReader(WebStream)
            Dim PageContent As String = "", line As String
            If stopLine Is Nothing Then
                PageContent = Reader.ReadToEnd()
            Else
                While Not Reader.EndOfStream
                    line = Reader.ReadLine()
                    PageContent += line & Environment.NewLine
                    If line.Contains(stopLine) Then
                        Exit While
                    End If
                End While
            End If
            ' Cleanup
            Reader.Close()
            WebStream.Close()
            Response.Close()

            Return PageContent
        Catch generatedExceptionName As Exception

            Throw
        End Try
    End Function
    ''' <summary>
    ''' Get the ID of a youtube video from its URL
    ''' </summary>
    ''' <param name="url"></param>
    ''' <returns></returns>
    Public Shared Function GetVideoIDFromUrl(url As String) As String
        url = url.Substring(url.IndexOf("?") + 1)
        Dim props As String() = url.Split("&"c)

        Dim videoid As String = ""
        For Each prop As String In props
            If prop.StartsWith("v=") Then
                videoid = prop.Substring(prop.IndexOf("v=") + 2)
            End If
        Next

        Return videoid
    End Function


    Public Shared Function InitialProxy() As IWebProxy
        Dim address As String = InlineAssignHelper(address, getIEProxy())
        If Not String.IsNullOrEmpty(address) Then
            Dim proxy As New WebProxy(address)
            proxy.Credentials = CredentialCache.DefaultNetworkCredentials
            Return proxy
        Else
            Return Nothing
        End If
    End Function
    Private Shared Function getIEProxy() As String
        Dim p = WebRequest.DefaultWebProxy
        If p Is Nothing Then
            Return Nothing
        End If
        Dim webProxy As WebProxy = Nothing
        If TypeOf p Is WebProxy Then
            webProxy = TryCast(p, WebProxy)
        Else
            Dim t As Type = p.[GetType]()
            Dim s = t.GetProperty("WebProxy", CType(&HFFF, BindingFlags)).GetValue(p, Nothing)
            webProxy = TryCast(s, WebProxy)
        End If
        If webProxy Is Nothing OrElse webProxy.Address Is Nothing OrElse String.IsNullOrEmpty(webProxy.Address.AbsolutePath) Then
            Return Nothing
        End If
        Return webProxy.Address.Host
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class
