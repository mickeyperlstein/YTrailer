
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.IO
Imports VisioForge.Types
Imports VisioForge.Controls.WinForms
Imports System.Xml
Imports VisioForge_Video_Edit
Imports AForge.Video.VFW
Imports AForge.Video.DirectShow
Imports System.Windows.Forms.ListViewItem

Public Class frmMain
    Private vReader As New AVIReader()
    Private lastAvg As Byte()

    Private lastlong As Double
    Private lasttime As Long
    Private filename As String
    Private lastInfo As Long

    Private totalScenes As Long

    Private froms As Long()
    Private tos As Long()
    Private lens As Double()

    Private OutScenes As APTScene()

    Private WithEvents fDownloader As FileDownloader
    Private timelineImage As Bitmap
    Private timelineGraph As Graphics
    Private od As OpenFileDialog = New OpenFileDialog()
    Private saveDialog As FileDialog = New SaveFileDialog

    Private origWidth As Long
    Private origHeight As Long
    Private videoUrls As String()
    'List<string> downVideoUrls = new List<string>();
    Private downVideoUrls As New List(Of YouTubeVideoQuality)()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Dim Err As VisioForge_Video_Edit.TxVFFilePlayError, ErrText As String
        Dim i As Long
        Dim f As Boolean
        Dim i2 As Long

        Dim totalcurrent As Double
        Dim totalMovie As Double
        Dim maxLength As Double
        Dim minLength As Double
        Dim targetLength As Double
        Dim maxTime As Double

        Dim intro1 As Boolean = False
        Dim intro2 As Boolean = False
        Dim intro3 As Boolean = False

        If rbOut6.Checked Then
            maxLength = 2
            minLength = 0.8

            targetLength = 6
            maxTime = 5
        End If



        If rbOut15.Checked Then
            maxLength = 3
            minLength = 1.3
            maxTime = 13.8
            targetLength = 15
        End If

        If rbOut30.Checked Then
            maxLength = 4.5
            minLength = 1.5
            targetLength = 30

            maxTime = 29
        End If


        totalcurrent = 0


        If saveDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            intro1 = False
            intro2 = False
            intro3 = False

            'setWait(True)
            lblStatus.Text = "preparing video..."
            Application.DoEvents()
            vAPT.Input_Clear_List()
            If rbOut15.Checked Or rbOut30.Checked Then
                prepareTitle(tbOpening.Text, 1500, "", "resultOpening")
                Application.DoEvents()
                vAPT.Input_AddVideoFile("c:\dev\apt\resultOpening.avi", 0, 1500, 0, 1, 1)
                Application.DoEvents()
                vAPT.Input_AddAudioFile("c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 3000, 0, "c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 0, 1)
                Application.DoEvents()
                totalMovie = 1500
                totalcurrent += 1.5
            End If

            vAPT.Input_AddAudioFile("c:\dev\apt\mp3\bgmusic\" & cbBG.Text & "-" & targetLength & "sec.wav", 0, targetLength * 1000, 0, "c:\dev\apt\mp3\bgmusic\" & cbBG.Text & "-" & targetLength & "sec.wav", 0, 0, 1)
            Application.DoEvents()

            filename = "source.mp4"
            ' vAPT.Video_Effects_Picture_Logo(1, 0, 15000, True, "C:\dev\apt\ytrailer-tr-small.png", 10, 210)
            For i = 1 To totalScenes
                f = False

                Do
                    i += 1
                    If (lens(i) < maxLength And lens(i) > minLength) And (totalcurrent + lens(i) < maxTime) Then

                        vAPT.Input_AddVideoFile(filename, Math.Round((froms(i) / 25) * 1000), Math.Round((tos(i) / 25) * 1000), totalMovie, 1, 1)
                        'vAPT.Input_AddAudioFile(filename, Math.Round((froms(i) / 25) * 1000) - 300, Math.Round((tos(i) / 25) * 1000) + 300, totalMovie - 300, filename, 0, 0, 1)
                        '  vAPT.Audio_Fades_Add(1, totalMovie, totalMovie + 300, 0, 200)
                        ' vAPT.Audio_Fades_Add(1, totalMovie + (lens(i) * 1000) - 300, totalMovie + (lens(i) * 1000), 200, 0)
                        '   vAPT.Audio_Fades_Add(0, totalMovie, totalMovie + 300, 100, 40)
                        '  vAPT.Audio_Fades_Add(0, totalMovie + (lens(i) * 1000) - 300, totalMovie + (lens(i) * 1000), 40, 100)
                        Application.DoEvents()
                        ' vAPT.Video_Transition_Add(Math.Round(totalcurrent * 1000) - 100, Math.Round(totalcurrent * 1000) + 300, 127)
                        totalcurrent += lens(i)
                        totalMovie += lens(i) * 1000
                        f = True
                        'Debug.Print(vAPT.Video_Transition_Names().Count)
                        '       For i2 = 0 To vAPT.Video_Transition_Names().Count
                        'Debug.Print(vAPT.Video_Transition_Names(i2))
                        'Next
                    End If

                Loop Until f Or i >= totalScenes Or totalcurrent >= maxTime
                If (totalcurrent > maxTime) Or i >= totalScenes Then
                    Exit For
                Else
                    If rbOut15.Checked Then
                        If (totalMovie / 1000 > targetLength / 2) And (Not intro1) Then
                            prepareTitle(tbIntro1.Text, 1500, "", "resultIntro1")
                            Application.DoEvents()
                            vAPT.Input_AddVideoFile("c:\dev\apt\resultIntro1.avi", 0, 1500, totalMovie, 1, 1)
                            Application.DoEvents()
                            vAPT.Input_AddAudioFile("c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 3000, totalMovie, "c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 0, 1)
                            Application.DoEvents()
                            totalMovie += 1500
                            totalcurrent += 1.5
                            intro1 = True

                        End If
                    End If
                    If rbOut30.Checked Then
                        If (totalMovie / 1000 > targetLength / 3) And (Not intro1) Then
                            prepareTitle(tbIntro1.Text, 1500, "", "resultIntro1")
                            Application.DoEvents()
                            vAPT.Input_AddVideoFile("c:\dev\apt\resultIntro1.avi", 0, 1500, totalMovie, 1, 1)
                            Application.DoEvents()
                            vAPT.Input_AddAudioFile("c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 3000, totalMovie, "c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 0, 1)
                            Application.DoEvents()
                            totalMovie += 1500
                            totalcurrent += 1.5
                            intro1 = True
                        ElseIf (totalMovie / 1000 > targetLength / 2) And (Not intro2) Then
                            prepareTitle(tbIntro2.Text, 1500, "", "resultIntro2")
                            Application.DoEvents()
                            vAPT.Input_AddVideoFile("c:\dev\apt\resultIntro2.avi", 0, 1500, totalMovie, 1, 1)
                            Application.DoEvents()
                            vAPT.Input_AddAudioFile("c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 3000, totalMovie, "c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 0, 1)
                            Application.DoEvents()
                            totalMovie += 1500
                            totalcurrent += 1.5
                            intro2 = True
                        ElseIf (totalMovie / 1000 > targetLength * 0.6) And (Not intro3) Then
                            prepareTitle(tbIntro3.Text, 1500, "", "resultIntro3")
                            Application.DoEvents()
                            vAPT.Input_AddVideoFile("c:\dev\apt\resultIntro3.avi", 0, 1500, totalMovie, 1, 1)
                            Application.DoEvents()
                            vAPT.Input_AddAudioFile("c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 3000, totalMovie, "c:\dev\apt\mp3\" & cbFX.Text & "\boom1.wav", 0, 0, 1)
                            Application.DoEvents()
                            totalMovie += 1500
                            totalcurrent += 1.5
                            intro3 = True
                        End If
                    End If
                    Dim nextScene As Long = Math.Round(totalScenes * (totalcurrent / (maxTime)))
                    '
                    'If nextScene > totalScenes / 2 And nextScene < totalScenes * 0.55 Then
                    'prepareTitle(tbIntro1.Text, "", "resultIntro1")
                    'vAPT.Input_AddVideoFile("c:\dev\apt\resultIntro1.avi")
                    'End If
                    If nextScene > i Then i = nextScene
                End If
            Next
            Application.DoEvents()
            prepareTitle(tbClosing.Text, (targetLength * 1000) - totalMovie, "", "resultClosing")
            Application.DoEvents()
            vAPT.Input_AddVideoFile("c:\dev\apt\resultClosing.avi", 0, (targetLength * 1000) - totalMovie, totalMovie, 1, 1)
            Application.DoEvents()
            vAPT.Input_AddAudioFile("c:\dev\apt\mp3\" & cbFX.Text & "\final.wav", 0, (targetLength * 1000) - totalMovie, totalMovie - 500, "c:\dev\apt\mp3\" & cbFX.Text & "\final.wav", 0, 0, 1)
            vAPT.Output_Format = VFVideoEditOutputFormat.AVI
            vAPT.Video_FrameRate = 23
            ''  vAPT.Video_Renderer = VFVideoRenderer.
            '  vAPT.Video_Use_Compression = True
            If (chk800.Checked) Then
                vAPT.Video_FrameRate = 60

            Else
                ' vAPT.Video_Codec = "Xvid MPEG-4 Codec"
                vAPT.Video_Resize = True
                vAPT.Video_Resize_Width = 320 ' origWidth
                vAPT.Video_Resize_Height = 240 'origHeight
            End If

            '  vAPT.Output_Format = TxVFOutputFormat.Format_WMV

            'Dim s As String
            'vAPT.Mode = TxVFMode.Mode_Convert
            'vAPT.Video_Resize = False
            'vAPT.Video_FrameRate = 25
            'vAPT.Video_Renderer = TxVFVideoRenderer.VR_VMR9
            'vAPT.Video_Renderer_Deinterlace_UseDefault = True
            'vAPT.Output_Format = TxVFOutputFormat.Format_WMV
            'vAPT.WMV_Mode = TxVFWMVMode.VF_WM_CustomSettings
            'vAPT.WMV_Custom_Audio_Codec = "Windows Media Audio 10 Professional"
            'vAPT.WMV_Custom_Audio_Format = "VBR Quality 98, 96 kHz, 5.1 channel 24 bit VBR"
            'vAPT.WMV_Custom_Audio_PeakBitrate = 384
            'vAPT.WMV_Custom_Audio_Mode = TxVFWMVStreamMode.VF_SM_VBR_Quality
            'vAPT.WMV_Custom_Audio_StreamPresent = True
            'vAPT.WMV_Custom_Video_Codec = "Windows Media Video 9 Advanced Profile"
            'vAPT.WMV_Custom_Video_Width = origWidth
            'vAPT.WMV_Custom_Video_Height = origHeight
            'vAPT.WMV_Custom_Video_SizeSameAsInput = False
            'vAPT.WMV_Custom_Video_FrameRate = 25
            'vAPT.WMV_Custom_Video_KeyFrameInterval = 1
            'vAPT.WMV_Custom_Video_Bitrate = 3000
            'vAPT.WMV_Custom_Video_Quality = 100

            '            vAPT.WMV_Custom_Video_Mode = TxVFWMVStreamMode.VF_SM_VBR_Quality
            '           vAPT.WMV_Custom_Video_TVSystem = TxVFTVSystem.VF_TS_PAL
            '          vAPT.WMV_Custom_Video_StreamPresent = True
            '         vAPT.WMV_Custom_Profile_Name = "My_Profile_1"

            vAPT.Output_Filename = saveDialog.FileName
            axWait.Visible = False
            Application.DoEvents()
            vAPT.Start()
        End If
    End Sub


    Public Shared Function ConvertToByteArray(ByVal value As Bitmap) As Byte()
        Dim bitmapBytes As Byte()

        Using stream As New System.IO.MemoryStream

            value.Save(stream, value.RawFormat)
            bitmapBytes = stream.ToArray

        End Using

        Return bitmapBytes

    End Function
    Private Function apt(ByRef b As Bitmap, frameNum As Double)
        Dim iX As Long, iY As Long
        Dim bAr As Byte()


        bAr = ImageToByte2(b)
        Dim mean As Double = 0
        Dim similar As Long
        Dim avgs As Double
        Try
            Dim sm As Long
            sm = 0
            Dim ti As Long

            For Each avg As Byte In bAr
                sm += avg

            Next
            avgs = sm / bAr.Length

            Dim targetImage As Bitmap = New Bitmap(pbOscilograph.Width, pbOscilograph.Height)
            Dim targetGraph As Graphics = Graphics.FromImage(targetImage)
            Dim iA As ImageAttributes = New ImageAttributes()
            iA.SetColorKey(Color.Yellow, Color.Yellow)
            iY = 0
            For iX = 0 To bAr.Length Step bAr.Length \ pbOscilograph.Width

                Dim a As Pen
                a = Pens.BlueViolet
                ' targetGraph.DrawRectangle(Pens.Yellow, New Rectangle(New Point(iY, pbOscilograph.Height - 30 - (bAr(iX) / 2)), New Point(iY + 1, pbOscilograph.Height - 30 - (bAr(iX) / 2))))
                targetGraph.DrawPie(Pens.YellowGreen, iY, pbOscilograph.Height - 20 - (avgs \ 3), 2, 2, 0, 360) ' .DrawLine(Pens.Yellow, New Point(iY - 1, pbOscilograph.Height - 30 - (bAr(iX - 1) / 2)), New Point(iY, pbOscilograph.Height - 30 - (bAr(iX) / 2)))
                targetGraph.DrawPie(a, iY, pbOscilograph.Height - 20 - (bAr(iX) \ 3), 2, 6, 0, 360) ' .DrawLine(Pens.Yellow, New Point(iY - 1, pbOscilograph.Height - 30 - (bAr(iX - 1) / 2)), New Point(iY, pbOscilograph.Height - 30 - (bAr(iX) / 2)))
                iY += 1
            Next
            pbOscilograph.Image = targetImage
            ' targetGraph.Draw()
            ' pbOscilograph.Refresh()


            'Math.Round(pbOscilograph.Width * (frameNum / vReader.Length))
            iY = Math.Round(pbOscilograph.Width * (frameNum / framecount))

            Debug.Print(avgs)
            If (Math.Abs(avgs - lastInfo)) > 3 And frameNum - lasttime > 25 Then ' If (Math.Abs(bAr.Length - lastAvg.Length)) > 2048 And frameNum - lasttime > 25 Then
                'pbSignal.Visible = True
                For iii = 0 To pbOscilograph.Height
                    timelineGraph.DrawPie(Pens.LightBlue, iY, iii, 1, 1, 0, 360)
                Next
                Debug.Print(Math.Abs(bAr.Length - lastAvg.Length) & " ---- " & (frameNum - lasttime))


                'Dim li As ListViewItem
                Dim d As New Func(Of String, ListViewItem)(AddressOf ListView1.Items.Add)
                Dim txt As String = "k" & ListView1.Items.Count

                Dim pp
                Dim li As New ListViewItem


                txt = (frameNum - lasttime) / 25 & "s"
                Me.Invoke(New Func(Of String, ListViewSubItem)(AddressOf li.SubItems.Add), New String() {txt})

                li.Text = lasttime & " - " & frameNum
                setText(lblTotalScenes, "Total scenes: " & ListView1.Items.Count)
                ' li.SubItems(0).Text = (frameNum - lasttime) / 25 & "s"

                pp = (Me.Invoke(New Func(Of ListViewItem, ListViewItem)(AddressOf ListView1.Items.Add), _
                                New Object() {li}))

                froms(ListView1.Items.Count - 1) = lasttime + 5

                tos(ListView1.Items.Count - 1) = frameNum - 5

                lens(ListView1.Items.Count - 1) = (frameNum - lasttime) / 25
                totalScenes = ListView1.Items.Count
                lasttime = frameNum


            Else
                If (Math.Abs(avgs - lastInfo)) > 3 Or avgs < 3 Or avgs > 250 Then
                    ' lasttime = frameNum
                    For iii = 0 To pbOscilograph.Height
                        timelineGraph.DrawPie(Pens.Red, iY, iii, 1, 1, 0, 360)
                    Next
                Else

                End If

                ' pbSignal.Visible = False
            End If
            timelineGraph.DrawPie(Pens.White, iY, pbOscilograph.Height - 20 - (avgs \ 3), 2, 2, 0, 360)
            pbOscilograph.BackgroundImage = timelineImage
            '  pbOscilograph.Refresh()
        Catch ex As Exception
            Dim x
            x = ex.Message
        End Try
        lastInfo = avgs
        lastAvg = bAr
        lastlong = avgs
    End Function




    Public Shared Function ImageToByte2(img As Image) As Byte()
        Dim byteArray As Byte() = New Byte(-1) {}
        Try
            Using stream As New MemoryStream()
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
                stream.Close()

                byteArray = stream.ToArray()

            End Using
            Return byteArray
        Catch ex As Exception
            Dim x
            x = ex.Message
        End Try
    End Function


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        od.DefaultExt = "avi"

        If od.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            'setWait(True)
            lblStatus.Text = "☼ analyzing video..."
            'vAPT.Visible = False
            'pbPreview.Visible = True


            'vReader.Open(od.FileName)
            'vReader.Close()


            timelineImage = New Bitmap(pbOscilograph.Width, pbOscilograph.Height)
            timelineGraph = Graphics.FromImage(timelineImage)
            pBar.Maximum = vReader.Length
            filename = od.FileName
            ' ListView1.Clear() ' .Items.Clear()
            ReDim froms(10000)
            ReDim tos(10000)
            ReDim lens(10000)
            pbSignal.Visible = False





            Dim vidsrc As New FileVideoSource(od.FileName)

            AddHandler vidsrc.NewFrame, AddressOf Me.New_Frame
            vidsrc.Start()

            While (vidsrc.IsRunning)

                Application.DoEvents()

            End While

            vidsrc.SignalToStop()

            'setWait(False)
            'vidsrc.Stop()

            lblStatus.Text = "☻ ready for export..."
            'Button2.Enabled = False



        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub setEnbaled(ctl As Control, bl As Boolean)
        If (ctl.InvokeRequired) Then



            'Dim d As New Action(Of Control, Boolean)(AddressOf setEnbaled)
            'Me.Invoke(d, New Object() {[ctl], bl})
        Else

            'ctl.Enabled = bl

        End If
    End Sub
    Private Sub setWait(turnOn As Boolean)
        Return
        For Each x As Control In Me.Controls
            If (PictureBox1.Name <> x.Name And PictureBox2.Name <> x.Name And _
                pbPreview.Name <> x.Name) Then

                setEnbaled(x, Not turnOn)
            End If
        Next
        axWait.Visible = turnOn
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles pbSignal.Click

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub vAPT_OnError(sender As Object, e As ErrorsEventArgs) Handles vAPT.OnError
        Debug.Print("error " & e.Message)
    End Sub

    Private Sub vAPT_OnProgress(sender As Object, e As ProgressEventArgs) Handles vAPT.OnProgress
        pBar.Value = pBar.Maximum * (e.Progress / 100)
    End Sub

    Private Sub vAPT_OnStart(sender As Object, e As EventArgs) Handles vAPT.OnStart
        Debug.Print("start")
        'pbPreview.Visible = False
        'vAPT.Visible = True
    End Sub

    Private Sub vAPT_OnStop(sender As Object, e As EventArgs) Handles vAPT.OnStop
        Debug.Print("stop")
        'setWait(False)
        'Button2.Enabled = False
        'bGetYoutube.Enabled = False
        'txtURL.Enabled = False
        lblStatus.Text = "☻ ready for export..."
        Process.Start(saveDialog.FileName)
        'pbPreview.Visible = True
        'vAPT.Visible = False
    End Sub

    Private Sub prepareTitle(inText As String, lenMS As Long, template As String, outputFile As String)

        Dim swf2vid As BytescoutSWFToVideo.SWFToVideo
        swf2vid = New BytescoutSWFToVideo.SWFToVideo


        'swf2vid.RegistrationName = "demo"
        'swf2vid.RegistrationKey = "demo"

        ''Set RGBA Mode. IMPORTANT: Set .RGBAMode = True BEFORE calling .SetMovie()
        'swf2vid.RGBAMode = True

        ''// set input SWF file
        'swf2vid.FlashVars = "t=" & Uri.EscapeUriString(inText)
        'swf2vid.FPS = 30
        'swf2vid.InputSWFFileName = "c:\dev\apt\templates\textfx1.swf"


        ''    // set output AVI video filename
        'swf2vid.OutputVideoFileName = "c:\dev\apt\" & outputFile & ".avi"

        ''	// Set output movie dimensions
        'swf2vid.OutputWidth = origWidth
        'swf2vid.OutputHeight = origHeight

        'swf2vid.SWFConversionMode = BytescoutSWFToVideo.SWFConversionModeType.SWFAnimation
        'swf2vid.ConversionTimeOut = lenMS

        'swf2vid.CurrentVideoCodecName = ""
        ''	// Run conversion
        'swf2vid.RunAndWait()
        'swf2vid = Nothing
        '// Open the result movie in default media player
        'Process.Start("c:\dev\apt\result.avi")
        'Debug.Print("bye")
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)



    End Sub


    Private Sub Button3_Click_1(sender As Object, e As EventArgs)
        ' setWait(True)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'setWait(False)
    End Sub

    Private Sub bGetYoutube_Click(sender As Object, e As EventArgs) Handles bGetYoutube.Click
        Try
            If Not Helper.isValidUrl(txtURL.Text) OrElse Not txtURL.Text.ToLower().Contains("www.youtube.com/watch?") Then
                MessageBox.Show(Me, "You enter invalid YouTube URL, Please correct it." & vbCr & vbLf & vbLf & "Note: URL should start with:" & vbCr & vbLf & "http://www.youtube.com/watch?", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                downVideoUrls.Clear()
                'txtURL.Enabled = False
                'get_Button.Enabled = False
                'timer1.Enabled = False
                'paste_Button.Enabled = False
                'progressBar1.Show()

                Me.videoUrls = New String() {txtURL.Text}
                pbPreview.ImageLocation = String.Format("http://i3.ytimg.com/vi/{0}/default.jpg", Helper.GetVideoIDFromUrl(txtURL.Text))
                'UseWaitCursor = true;
                'ShowPanel(1);
                'setWait(True)
                lblStatus.Text = "☼ Checking video..."
                backgroundWorker1.RunWorkerAsync()
                Dim xReader As XmlTextReader = New XmlTextReader("http://gdata.youtube.com/feeds/api/videos/" & Helper.GetVideoIDFromUrl(txtURL.Text) & "?v=2")
                Dim stXML As String
                stXML = ""
                Dim curNode As String

                Do While (xReader.Read())
                    Select Case xReader.NodeType
                        Case XmlNodeType.Element 'Display beginning of element.
                            stXML = stXML & ("<" + xReader.Name)
                            stXML = stXML & (">")
                            curNode = xReader.Name
                        Case XmlNodeType.Text 'Display the text in each element.
                            stXML = stXML & (xReader.Value)
                            Select Case curNode
                                Case "title"
                                    tbIntro3.Text = xReader.Value.ToString()
                                Case "name"
                                    tbOpening.Text = xReader.Value.ToString() & vbCrLf & "presents"
                                Case "uri"
                                    Dim tempAr = xReader.Value.ToString().Split("/")
                                    tbClosing.Text = "Watch on" & vbCrLf & "http://youtube.com/" & tempAr(tempAr.Count - 1)

                            End Select
                        Case XmlNodeType.EndElement 'Display end of element.
                            stXML = stXML & ("</" + xReader.Name)
                            stXML = stXML & (">")
                    End Select
                Loop
                Debug.Print(stXML)
            End If
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub





    Private Sub backgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        e.Result = YouTubeDownloader.GetYouTubeVideoUrls(videoUrls)
    End Sub

    Private Sub backgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        '   Try
        UseWaitCursor = False

        lblStatus.Text = "☼ downloading video..."
        If e.[Error] IsNot Nothing Then
            Throw e.[Error]
        End If

        Dim urls As List(Of YouTubeVideoQuality) = TryCast(e.Result, List(Of YouTubeVideoQuality))
        Debug.Print("Got info..." + urls.Count.ToString())
        If urls.Count < 1 Then
            lblStatus.Text = "! error, try again !"
            'setWait(True)
            'txtURL.Enabled = True
            'bGetYoutube.Enabled = True
            'Button2.Enabled = True
            axWait.Visible = False
            Exit Sub
        End If

        Dim videoLength As TimeSpan = TimeSpan.FromSeconds(urls(0).Length)
        If videoLength.Hours > 0 Then
            '  drawVideoLenght([String].Format("{0}:{1}:{2}", videoLength.Hours, videoLength.Minutes, videoLength.Seconds))
        Else
            ' drawVideoLenght([String].Format("{0}:{1}", videoLength.Minutes, videoLength.Seconds))
        End If
        If (System.IO.File.Exists("c:\dev\apt\source.mp4")) Then
            System.IO.File.Delete("c:\dev\apt\source.mp4")
        End If
        If (System.IO.File.Exists("c:\dev\apt\source_raw.avi")) Then
            System.IO.File.Delete("c:\dev\apt\source_raw.avi")
        End If
        origWidth = 800 'urls(0).Dimension.Width



        origHeight = urls(0).Dimension.Height * (800 / urls(0).Dimension.Width)
        fDownloader = New FileDownloader(urls(0).DownloadUrl, "c:\dev\apt\", "source.mp4")
        AddHandler fDownloader.ProgressChanged, AddressOf fDownloader_ProgressChanged
        AddHandler fDownloader.RunWorkerCompleted, AddressOf fDownloader_RunWorkerCompleted

        fDownloader.RunWorkerAsync()

        'For Each item As Object In urls
        'Dim videoExtention As String = item.Extention
        'Dim videoDimension As String = item.Dimension
        'Dim videoSize As String = item.VideoSize
        'string videoTitle = item.VideoTitle.Replace(@"\", "").Replace("'", "'").Replace(""", "'").Replace("<", "(").Replace(">", ")").Replace("+", " ");

        '     quality_ComboBox.Items.Add([String].Format("{0} ({1}) - {2}", videoExtention.ToUpper(), videoDimension, videoSize))
        '    quality_ComboBox.Text = quality_ComboBox.Items(0).ToString()
        '   quality_ComboBox.Enabled = True
        'downVideoUrls.Add(item)
        '  name_Label2.Text = FormatTitle(item.VideoTitle)
        ' url_TextBox.Enabled = True

        'progressBar1.Hide()
        'Next
        'Catch ex As Exception
        'MessageBox.Show(Me, ex.InnerException.Message, ex.InnerException.Source, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        'paste_Button.Enabled = True
        'url_TextBox.Enabled = True
        'timer1.Enabled = True
        ' progressBar1.Hide()
        'End Try
    End Sub



    Private Sub fDownloader_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles fDownloader.ProgressChanged
        pBar.Value = pBar.Maximum / 100 * e.ProgressPercentage
        Debug.Print(e.ProgressPercentage)
    End Sub

    Private Function time2sec(sTime As String) As Long
        Dim aNums As String() = sTime.Split(":")
        Return Long.Parse(aNums(2)) + (Long.Parse(aNums(1)) * 60) + (Long.Parse(aNums(0)) * 60 * 60)
    End Function
    Private Sub execthread()
        Dim nprocess As New Process()
        Dim duration As Single = 0.0F, current As Single = 0.0F

        lblStatus.Text = "☼ preparing video..."
        nprocess.StartInfo.FileName = Path.Combine("c:\dev\apt", "ffmpeg.exe")
        '    nprocess.StartInfo.Arguments = "-i c:\dev\apt\source.mp4 -s " & origWidth & "x" & origHeight & " -vcodec rawvideo c:\dev\apt\source_raw.avi"
        nprocess.StartInfo.Arguments = "-i c:\dev\apt\source.mp4 -c:v mpeg4 -s 80x60 -vtag xvid c:\dev\apt\source_raw.avi"
        ' nprocess.StartInfo.Arguments = "-i c:\dev\apt\source.mp4 -c:v mpeg4 -s " & origWidth & "x" & origHeight & " -vtag xvid c:\dev\apt\source_raw.avi"
        nprocess.EnableRaisingEvents = False
        nprocess.StartInfo.UseShellExecute = False
        nprocess.StartInfo.CreateNoWindow = True
        nprocess.StartInfo.RedirectStandardOutput = True
        nprocess.StartInfo.RedirectStandardError = True
        Application.DoEvents()

        nprocess.Start()

        Dim d As StreamReader = nprocess.StandardError

        Dim totalDur As Long, curDur As Long
        Do
            Dim s As String = d.ReadLine()
            ' Debug.Print(s)
            If s.Contains("Duration: ") Then
                totalDur = time2sec(s.Substring(12, 8))
            End If
            If s.Contains("frame=") Then
                curDur = time2sec(s.Substring(s.IndexOf("time=") + 5, 8))
            End If
            If (totalDur > 0 And curDur > 0) Then
                Debug.Print(100 / totalDur * curDur)
                pBar.Value = pBar.Maximum / totalDur * curDur
            End If
            Application.DoEvents()
            'Dim stime As String = functions.ExtractDuration(s)
            'duration = functions.TotalStringToSeconds(stime)
            'synchTotal(duration.ToString())
            'Else
            'If s.Contains("frame=") Then
            'Dim currents As String = functions.ExtractTime(s)
            'current = functions.CurrentStringToSeconds(currents)
            'synchCurrent(current.ToString())
            'synchTextOutput(s)
            'End If
            'End If
        Loop While Not d.EndOfStream

        nprocess.WaitForExit()
        nprocess.Close()

        'setWait(True)
        lblStatus.Text = "☼ analyzing video..."
        'vAPT.Visible = False
        'pbPreview.Visible = True
        vReader.Open("c:\dev\apt\source_raw.avi")
        timelineImage = New Bitmap(pbOscilograph.Width, pbOscilograph.Height)
        timelineGraph = Graphics.FromImage(timelineImage)
        pBar.Maximum = vReader.Length
        filename = "c:\dev\apt\source_raw.avi"
        ' ListView1.Clear() ' .Items.Clear()
        ReDim froms(10000)
        ReDim tos(10000)
        ReDim lens(10000)
        pbSignal.Visible = False
        Dim bmp As System.Drawing.Bitmap
        Dim i As Long
        Dim bAr As Byte()
        Try
            For i = 0 To vReader.Length - 1
                bmp = vReader.GetNextFrame(i)
                apt(bmp, i)
                pBar.Value = i
                '   For ii As Long = 0 To 0 '99999
                'Application.DoEvents()
                'Next
                '        If (i / 40 = Math.Round(i / 40)) Then
                Dim imgDest As Bitmap = New Bitmap(320, 240)
                Dim imgGr As Graphics = Graphics.FromImage(imgDest)
                imgGr.DrawImage(bmp, 0, 0, 320, 240)
                '  pbPreview.Image = bmp.GetThumbnailImage(320, 240, pbPreview.Image.GetThumbnailImageAbort, pbPreview.Image.p)
                pbPreview.Image = imgDest
                pbPreview.Refresh()

                Application.DoEvents()
                'End If
                lblFrameIndex.Text = "Frame " & (i + 1) & "/" & vReader.Length
                'lblTime.Text = i / 25 & "s / " & vReader.Length / 25

            Next
        Catch ex As Exception
            Dim x
            x = ex.Message
        End Try

        'setWait(False)
        vReader.Close()
        lblStatus.Text = "☻ ready for export..."
        'Button2.Enabled = False
        'bGetYoutube.Enabled = False
        'txtURL.Enabled = False

    End Sub

    Private Sub fDownloader_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles fDownloader.RunWorkerCompleted
        If (Not System.IO.File.Exists("c:\dev\apt\source_raw.avi")) Then
            '  Dim t As New System.Threading.Thread(AddressOf execthread)
            ' t.Start()
            execthread()
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub tbIntro3_TextChanged(sender As Object, e As EventArgs) Handles tbIntro3.TextChanged

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub

    Private Sub tbClosing_TextChanged(sender As Object, e As EventArgs) Handles tbClosing.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub rbOut6_CheckedChanged(sender As Object, e As EventArgs) Handles rbOut6.CheckedChanged

    End Sub

    Private Sub rbOut15_CheckedChanged(sender As Object, e As EventArgs) Handles rbOut15.CheckedChanged

    End Sub

    Private Sub rbOut30_CheckedChanged(sender As Object, e As EventArgs) Handles rbOut30.CheckedChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub cbFX_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFX.SelectedIndexChanged

    End Sub

    Private Sub cbBG_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBG.SelectedIndexChanged

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub lblStatus_Click(sender As Object, e As EventArgs) Handles lblStatus.Click

    End Sub


    Private Sub prPreviewRefresh()

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.pbPreview.InvokeRequired Then
            Dim d As New Action(AddressOf prPreviewRefresh)
            Me.Invoke(d)
        Else
            Me.pbPreview.Refresh()
        End If
    End Sub
    Dim framecount As Integer
    Private Sub New_Frame(sender As Object, eventArgs As AForge.Video.NewFrameEventArgs)

        Dim bmp As System.Drawing.Bitmap
        Dim i As Long
        Dim bAr As Byte()

        framecount += 1


        i = framecount

        bmp = eventArgs.Frame


        apt(bmp, i)
        pBar.Value = 0
        '   For ii As Long = 0 To 0 '99999
        'Application.DoEvents()
        'Next
        '        If (i / 40 = Math.Round(i / 40)) Then
        pbPreview.Image = bmp
        prPreviewRefresh()
        Application.DoEvents()
        'End If
        setText(lblFrameIndex, "Frame " & (i + 1) & "/" & framecount)

        'lblTime.Text = i / 25 & "s / " & vReader.Length / 25



    End Sub



    Private Sub setText(label As Control, txt As String)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If label.InvokeRequired Then
            Dim d As New Action(Of Control, String)(AddressOf setText)
            Me.Invoke(d, New Object() {[label], txt})
        Else
            label.Text = txt
        End If
    End Sub

End Class
