<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        vReader.Close()
        Try

            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pbPreview = New System.Windows.Forms.PictureBox()
        Me.lblFrameIndex = New System.Windows.Forms.Label()
        Me.pbOscilograph = New System.Windows.Forms.PictureBox()
        Me.pbSignal = New System.Windows.Forms.PictureBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.from = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.upto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.rbOut6 = New System.Windows.Forms.RadioButton()
        Me.rbOut15 = New System.Windows.Forms.RadioButton()
        Me.rbOut30 = New System.Windows.Forms.RadioButton()
        Me.lblTotalScenes = New System.Windows.Forms.Label()
        Me.vAPT = New VisioForge.Controls.WinForms.VideoEdit()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.axWait = New AxShockwaveFlashObjects.AxShockwaveFlash()
        Me.pBar = New System.Windows.Forms.ProgressBar()
        Me.cbFX = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbBG = New System.Windows.Forms.ComboBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.tbIntro1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbOpening = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbIntro2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbIntro3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbClosing = New System.Windows.Forms.TextBox()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.bGetYoutube = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.chk800 = New System.Windows.Forms.CheckBox()
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbOscilograph, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSignal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vAPT.SuspendLayout()
        CType(Me.axWait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(959, 383)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 25)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Export"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(689, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 25)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Import File..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pbPreview
        '
        Me.pbPreview.Location = New System.Drawing.Point(9, 12)
        Me.pbPreview.Name = "pbPreview"
        Me.pbPreview.Size = New System.Drawing.Size(320, 240)
        Me.pbPreview.TabIndex = 3
        Me.pbPreview.TabStop = False
        '
        'lblFrameIndex
        '
        Me.lblFrameIndex.AutoSize = True
        Me.lblFrameIndex.Location = New System.Drawing.Point(15, 230)
        Me.lblFrameIndex.Name = "lblFrameIndex"
        Me.lblFrameIndex.Size = New System.Drawing.Size(56, 13)
        Me.lblFrameIndex.TabIndex = 4
        Me.lblFrameIndex.Text = "Frame 0/0"
        '
        'pbOscilograph
        '
        Me.pbOscilograph.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pbOscilograph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbOscilograph.Location = New System.Drawing.Point(9, 274)
        Me.pbOscilograph.Name = "pbOscilograph"
        Me.pbOscilograph.Size = New System.Drawing.Size(320, 132)
        Me.pbOscilograph.TabIndex = 5
        Me.pbOscilograph.TabStop = False
        '
        'pbSignal
        '
        Me.pbSignal.BackColor = System.Drawing.Color.Red
        Me.pbSignal.Image = Global.WindowsApplication1.My.Resources.Resources.ytrailer
        Me.pbSignal.Location = New System.Drawing.Point(9, 12)
        Me.pbSignal.Name = "pbSignal"
        Me.pbSignal.Size = New System.Drawing.Size(320, 240)
        Me.pbSignal.TabIndex = 6
        Me.pbSignal.TabStop = False
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.from, Me.upto})
        Me.ListView1.GridLines = True
        Me.ListView1.LabelEdit = True
        Me.ListView1.Location = New System.Drawing.Point(348, 274)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(320, 132)
        Me.ListView1.TabIndex = 7
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'from
        '
        Me.from.Text = "Segment"
        Me.from.Width = 150
        '
        'upto
        '
        Me.upto.Text = "Length"
        Me.upto.Width = 100
        '
        'rbOut6
        '
        Me.rbOut6.AutoSize = True
        Me.rbOut6.Location = New System.Drawing.Point(795, 387)
        Me.rbOut6.Name = "rbOut6"
        Me.rbOut6.Size = New System.Drawing.Size(48, 17)
        Me.rbOut6.TabIndex = 9
        Me.rbOut6.Text = "6sec"
        Me.rbOut6.UseVisualStyleBackColor = True
        '
        'rbOut15
        '
        Me.rbOut15.AutoSize = True
        Me.rbOut15.Location = New System.Drawing.Point(849, 387)
        Me.rbOut15.Name = "rbOut15"
        Me.rbOut15.Size = New System.Drawing.Size(54, 17)
        Me.rbOut15.TabIndex = 10
        Me.rbOut15.Text = "15sec"
        Me.rbOut15.UseVisualStyleBackColor = True
        '
        'rbOut30
        '
        Me.rbOut30.AutoSize = True
        Me.rbOut30.Checked = True
        Me.rbOut30.Location = New System.Drawing.Point(902, 387)
        Me.rbOut30.Name = "rbOut30"
        Me.rbOut30.Size = New System.Drawing.Size(54, 17)
        Me.rbOut30.TabIndex = 11
        Me.rbOut30.TabStop = True
        Me.rbOut30.Text = "30sec"
        Me.rbOut30.UseVisualStyleBackColor = True
        '
        'lblTotalScenes
        '
        Me.lblTotalScenes.AutoSize = True
        Me.lblTotalScenes.Location = New System.Drawing.Point(584, 389)
        Me.lblTotalScenes.Name = "lblTotalScenes"
        Me.lblTotalScenes.Size = New System.Drawing.Size(82, 13)
        Me.lblTotalScenes.TabIndex = 12
        Me.lblTotalScenes.Text = "Total Scenes: 0"
        '
        'vAPT
        '
        Me.vAPT.AForge_Motion_Detection_DetectorType = VisioForge.Types.AFMotionDetectorType.CustomFrameDifference
        Me.vAPT.AForge_Motion_Detection_DifferenceThreshold = 0
        Me.vAPT.AForge_Motion_Detection_Enabled = False
        Me.vAPT.AForge_Motion_Detection_GridHeight = 0
        Me.vAPT.AForge_Motion_Detection_GridWidth = 0
        Me.vAPT.AForge_Motion_Detection_HighlightColor = System.Drawing.Color.Empty
        Me.vAPT.AForge_Motion_Detection_HighlightMotionGrid = False
        Me.vAPT.AForge_Motion_Detection_HighlightMotionRegions = False
        Me.vAPT.AForge_Motion_Detection_KeepObjectsEdges = False
        Me.vAPT.AForge_Motion_Detection_MinObjectsHeight = 0
        Me.vAPT.AForge_Motion_Detection_MinObjectsWidth = 0
        Me.vAPT.AForge_Motion_Detection_MotionAmountToHighlight = 0.0!
        Me.vAPT.AForge_Motion_Detection_ProcessorType = VisioForge.Types.AFMotionProcessorType.None
        Me.vAPT.AForge_Motion_Detection_SuppressNoise = False
        Me.vAPT.Audio_Codec_BPS = 16
        Me.vAPT.Audio_Codec_Channels = 2
        Me.vAPT.Audio_Codec_Name = "PCM"
        Me.vAPT.Audio_Codec_SampleRate = 44100
        Me.vAPT.Audio_Effects_Enabled = False
        Me.vAPT.Audio_Enhancer_Enabled = False
        Me.vAPT.Audio_Preview_Enabled = False
        Me.vAPT.Audio_Use_Compression = True
        Me.vAPT.BackColor = System.Drawing.Color.Black
        Me.vAPT.Barcode_Reader_Enabled = False
        Me.vAPT.Barcode_Reader_Type = VisioForge.Types.VFBarcodeType.[Auto]
        Me.vAPT.ChromaKey_Color = VisioForge.Types.VFChromaColor.Green
        Me.vAPT.ChromaKey_ContrastHigh = 70
        Me.vAPT.ChromaKey_ContrastLow = 110
        Me.vAPT.ChromaKey_Enabled = False
        Me.vAPT.ChromaKey_ImageFilename = Nothing
        Me.vAPT.Controls.Add(Me.lblStatus)
        Me.vAPT.Controls.Add(Me.axWait)
        Me.vAPT.Custom_Output_Audio_Codec = "PCM"
        Me.vAPT.Custom_Output_Audio_Codec_Use_Filters_Category = False
        Me.vAPT.Custom_Output_Mux_Filter_Is_Encoder = False
        Me.vAPT.Custom_Output_Mux_Filter_Name = "AVI Mux"
        Me.vAPT.Custom_Output_Special_FileWriter_Filter_Name = ""
        Me.vAPT.Custom_Output_Special_FileWriter_Needed = False
        Me.vAPT.Custom_Output_Video_Codec = "MJPEG Compressor"
        Me.vAPT.Custom_Output_Video_Codec_Use_Filters_Category = False
        Me.vAPT.Debug_Dir = ""
        Me.vAPT.Debug_Mode = False
        Me.vAPT.Decklink_Input_Capture_Timecode_Source = VisioForge.Types.DecklinkCaptureTimecodeSource.[Auto]
        Me.vAPT.Decklink_Output_AnalogOutput = VisioForge.Types.DecklinkAnalogOutput.[Auto]
        Me.vAPT.Decklink_Output_AnalogOutputIREUSA = False
        Me.vAPT.Decklink_Output_AnalogOutputSMPTE = False
        Me.vAPT.Decklink_Output_BlackToDeckInCapture = VisioForge.Types.DecklinkBlackToDeckInCapture.[Default]
        Me.vAPT.Decklink_Output_DualLinkOutputMode = VisioForge.Types.DecklinkDualLinkMode.[Default]
        Me.vAPT.Decklink_Output_DV_Encoding = False
        Me.vAPT.Decklink_Output_Enabled = False
        Me.vAPT.Decklink_Output_HDTVPulldownOnOutput = VisioForge.Types.DecklinkHDTVPulldownOnOutput.[Default]
        Me.vAPT.Decklink_Output_SingleFieldOutputForSynchronousFrames = VisioForge.Types.DecklinkSingleFieldOutputForSynchronousFrames.[Default]
        Me.vAPT.Decklink_Output_VideoOutputDownConversionMode = VisioForge.Types.DecklinkVideoOutputDownConversionMode.[Auto]
        Me.vAPT.Decklink_Output_VideoOutputDownConversionModeAnalogUsed = False
        Me.vAPT.DV_Capture_Audio_Channels = 0
        Me.vAPT.DV_Capture_Audio_SampleRate = 0
        Me.vAPT.DV_Capture_Type2 = False
        Me.vAPT.DV_Capture_Video_Format = VisioForge.Types.VFDVVideoFormat.PAL
        Me.vAPT.Dynamic_Reconnection = False
        Me.vAPT.Encryption_Format = VisioForge.Types.VFEncryptionFormat.MP4_H264_SW_AAC
        Me.vAPT.Encryption_LicenseKey = Nothing
        Me.vAPT.Encryption_Password = Nothing
        Me.vAPT.FFMPEG_AspectRatioH = 0
        Me.vAPT.FFMPEG_AspectRatioW = 0
        Me.vAPT.FFMPEG_AudioBitrate = 0
        Me.vAPT.FFMPEG_AudioChannels = 0
        Me.vAPT.FFMPEG_AudioSampleRate = 0
        Me.vAPT.FFMPEG_Interlace = False
        Me.vAPT.FFMPEG_OutputFormat = VisioForge.Types.VFFFMPEGOutputFormat.FLV
        Me.vAPT.FFMPEG_TVSystem = VisioForge.Types.VFFFMPEGTVSystem.None
        Me.vAPT.FFMPEG_VideoBitrate = 0
        Me.vAPT.FFMPEG_VideoBufferSize = 0
        Me.vAPT.FFMPEG_VideoHeight = 0
        Me.vAPT.FFMPEG_VideoMaxBitrate = 0
        Me.vAPT.FFMPEG_VideoMinBitrate = 0
        Me.vAPT.FFMPEG_VideoWidth = 0
        Me.vAPT.FLAC_AdaptiveMidSideCoding = False
        Me.vAPT.FLAC_BlockSize = 0
        Me.vAPT.FLAC_ExhaustiveModelSearch = False
        Me.vAPT.FLAC_Level = 0
        Me.vAPT.FLAC_LPCOrder = 0
        Me.vAPT.FLAC_MidSideCoding = False
        Me.vAPT.FLAC_RiceMax = 0
        Me.vAPT.FLAC_RiceMin = 0
        Me.vAPT.Frame_Save_Resize = False
        Me.vAPT.Frame_Save_Resize_Height = 0
        Me.vAPT.Frame_Save_Resize_Width = 0
        Me.vAPT.Frame_Save_ZoomRatio = 0.0R
        Me.vAPT.Input_Images_EnableMultiImageEngine = False
        Me.vAPT.LAME_CBR_Bitrate = 192
        Me.vAPT.LAME_Channels_Mode = VisioForge.Types.VFLameChannelsMode.StandardStereo
        Me.vAPT.LAME_Copyright = False
        Me.vAPT.LAME_CRC_Protected = False
        Me.vAPT.LAME_Disable_Short_Blocks = False
        Me.vAPT.LAME_Enable_Xing_VBR_Tag = False
        Me.vAPT.LAME_Encoding_Quality = 6
        Me.vAPT.LAME_Force_Mono = False
        Me.vAPT.LAME_Keep_All_Frequencies = False
        Me.vAPT.LAME_Mode_Fixed = False
        Me.vAPT.LAME_Original = False
        Me.vAPT.LAME_Sample_Rate = 44100
        Me.vAPT.LAME_Strict_ISO_Compliance = False
        Me.vAPT.LAME_Strictly_Enforce_VBR_Min_Bitrate = False
        Me.vAPT.LAME_UseInAVI = False
        Me.vAPT.LAME_VBR_Max_Bitrate = 192
        Me.vAPT.LAME_VBR_Min_Bitrate = 96
        Me.vAPT.LAME_VBR_Mode = True
        Me.vAPT.LAME_VBR_Quality = 6
        Me.vAPT.LAME_Voice_Encoding_Mode = False
        Me.vAPT.Location = New System.Drawing.Point(348, 12)
        Me.vAPT.Mode = VisioForge.Types.VFVideoEditMode.Convert
        Me.vAPT.MotionDetection_Compare_Blue = False
        Me.vAPT.MotionDetection_Compare_Green = False
        Me.vAPT.MotionDetection_Compare_Greyscale = False
        Me.vAPT.MotionDetection_Compare_Red = False
        Me.vAPT.MotionDetection_DropFrames_Enabled = False
        Me.vAPT.MotionDetection_DropFrames_Threshold = 0
        Me.vAPT.MotionDetection_Enabled = False
        Me.vAPT.MotionDetection_FrameInterval = 0
        Me.vAPT.MotionDetection_Highlight_Color = VisioForge.Types.VFMotionCHLColor.Red
        Me.vAPT.MotionDetection_Highlight_Enabled = False
        Me.vAPT.MotionDetection_Highlight_Threshold = 0
        Me.vAPT.MotionDetection_Matrix_Height = 0
        Me.vAPT.MotionDetection_Matrix_Width = 0
        Me.vAPT.MP4_Audio_AAC_Bitrate = 0
        Me.vAPT.MP4_Audio_AAC_Object = VisioForge.Types.VFAACObject.Undefined
        Me.vAPT.MP4_Audio_AAC_Output = VisioForge.Types.VFAACOutput.RAW
        Me.vAPT.MP4_Audio_AAC_Version = VisioForge.Types.VFAACVersion.MPEG4
        Me.vAPT.MP4_Audio_Format = VisioForge.Types.VFMP4AudioEncoder.AAC
        Me.vAPT.MP4_CUDA_Audio_AAC_Bitrate = 0
        Me.vAPT.MP4_CUDA_Audio_AAC_Object = VisioForge.Types.VFAACObject.Low
        Me.vAPT.MP4_CUDA_Audio_AAC_Output = VisioForge.Types.VFAACOutput.RAW
        Me.vAPT.MP4_CUDA_Audio_AAC_Version = VisioForge.Types.VFAACVersion.MPEG4
        Me.vAPT.MP4_CUDA_Audio_Format = VisioForge.Types.VFMP4AudioEncoder.AAC
        Me.vAPT.MP4_CUDA_Video_Bitrate = 2000
        Me.vAPT.MP4_CUDA_Video_BitrateAuto = False
        Me.vAPT.MP4_CUDA_Video_Deblocking = True
        Me.vAPT.MP4_CUDA_Video_Deinterlace = False
        Me.vAPT.MP4_CUDA_Video_Encoder = VisioForge.Types.VFCUDAVideoEncoder.Legacy
        Me.vAPT.MP4_CUDA_Video_FieldEncoding = VisioForge.Types.VFCUDAH264FieldEncoding.[Auto]
        Me.vAPT.MP4_CUDA_Video_ForceGPU_ID = -1
        Me.vAPT.MP4_CUDA_Video_ForceIDR = False
        Me.vAPT.MP4_CUDA_Video_ForceIntra = False
        Me.vAPT.MP4_CUDA_Video_GOP = False
        Me.vAPT.MP4_CUDA_Video_IDR_Period = 0
        Me.vAPT.MP4_CUDA_Video_Level = VisioForge.Types.VFCUDAH264LevelIDC.LevelAuto
        Me.vAPT.MP4_CUDA_Video_MBEncoding = VisioForge.Types.VFCUDAH264MBEncoding.CABAC
        Me.vAPT.MP4_CUDA_Video_MultiGPU = True
        Me.vAPT.MP4_CUDA_Video_P_Period = 0
        Me.vAPT.MP4_CUDA_Video_Peak_Bitrate = 6000
        Me.vAPT.MP4_CUDA_Video_Profile = VisioForge.Types.VFCUDAH264ProfileIDC.ProfileAuto
        Me.vAPT.MP4_CUDA_Video_QPLevel_InterB = 28
        Me.vAPT.MP4_CUDA_Video_QPLevel_InterP = 28
        Me.vAPT.MP4_CUDA_Video_QPLevel_Intra = 28
        Me.vAPT.MP4_CUDA_Video_RateControl = VisioForge.Types.VFCUDAH264RateControl.VBR
        Me.vAPT.MP4_LegacyCodecs = True
        Me.vAPT.MP4_Video_Bitrate = 0
        Me.vAPT.MP4_Video_BitrateAuto = False
        Me.vAPT.MP4_Video_Deblocking = False
        Me.vAPT.MP4_Video_GOP = False
        Me.vAPT.MP4_Video_IDR_Period = 0
        Me.vAPT.MP4_Video_Level = VisioForge.Types.VFH264Level.LevelAuto
        Me.vAPT.MP4_Video_MaxBitrate = 6000
        Me.vAPT.MP4_Video_MBEncoding = VisioForge.Types.VFH264MBEncoding.CAVLC
        Me.vAPT.MP4_Video_MinBitrate = 1500
        Me.vAPT.MP4_Video_P_Period = 0
        Me.vAPT.MP4_Video_PictureType = VisioForge.Types.VFH264PictureType.[Auto]
        Me.vAPT.MP4_Video_Profile = VisioForge.Types.VFH264Profile.ProfileAuto
        Me.vAPT.MP4_Video_RateControl = VisioForge.Types.VFH264RateControl.CBR
        Me.vAPT.MP4_Video_Sequential_Timing = VisioForge.Types.VFH264TimeType.[Default]
        Me.vAPT.MP4_Video_Target_Usage = VisioForge.Types.VFH264TargetUsage.[Auto]
        Me.vAPT.MP4_Video_VBV_Buffer_Size = 0
        Me.vAPT.Name = "vAPT"
        Me.vAPT.Network_Streaming_Audio_Enabled = False
        Me.vAPT.Network_Streaming_Enabled = False
        Me.vAPT.Network_Streaming_Format = VisioForge.Types.VFNetworkStreamingFormat.WMV
        Me.vAPT.Network_Streaming_Network_Port = 0
        Me.vAPT.Network_Streaming_URL = Nothing
        Me.vAPT.Network_Streaming_WMV_Maximum_Clients = 0
        Me.vAPT.Network_Streaming_WMV_Profile_FileName = Nothing
        Me.vAPT.Network_Streaming_WMV_UseMain_WMV_Settings = False
        Me.vAPT.OggVorbis_AvgBitRate = 128
        Me.vAPT.OggVorbis_MaxBitRate = 192
        Me.vAPT.OggVorbis_MinBitRate = 64
        Me.vAPT.OggVorbis_Mode = VisioForge.Types.VFVorbisMode.Bitrate
        Me.vAPT.OggVorbis_Quality = 80
        Me.vAPT.Output_Filename = "c:\dev\apt\output.wmv"
        Me.vAPT.Output_Format = VisioForge.Types.VFVideoEditOutputFormat.WMV
        Me.vAPT.Size = New System.Drawing.Size(320, 240)
        Me.vAPT.Speex_BitRate = 48
        Me.vAPT.Speex_BitrateControl = VisioForge.Types.SpeexBitrateControl.CBRQuality
        Me.vAPT.Speex_Complexity = 3
        Me.vAPT.Speex_MaxBitRate = 96
        Me.vAPT.Speex_Mode = VisioForge.Types.SpeexEncodeMode.[Auto]
        Me.vAPT.Speex_Quality = 8
        Me.vAPT.Speex_UseAGC = False
        Me.vAPT.Speex_UseDenoise = False
        Me.vAPT.Speex_UseDTX = False
        Me.vAPT.Speex_UseVAD = False
        Me.vAPT.TabIndex = 13
        Me.vAPT.UseLibMediaInfo = False
        Me.vAPT.Video_AVI_10_Compatibility = False
        Me.vAPT.Video_AVI_Interleaving = VisioForge.Types.VFAVIInterleaving.None
        Me.vAPT.Video_Codec = "MJPEG Compressor"
        Me.vAPT.Video_Crop_Bottom = 0
        Me.vAPT.Video_Crop_Enabled = False
        Me.vAPT.Video_Crop_Left = 0
        Me.vAPT.Video_Crop_Right = 0
        Me.vAPT.Video_Crop_Top = 0
        Me.vAPT.Video_Custom_Resizer_CLSID = New System.Guid("00000000-0000-0000-0000-000000000000")
        Me.vAPT.Video_Effects_Enabled = False
        Me.vAPT.Video_FrameRate = 25.0R
        Me.vAPT.Video_Preview_Enabled = True
        Me.vAPT.Video_Renderer = VisioForge.Types.VFVideoRenderer.VideoRenderer
        Me.vAPT.Video_Renderer_Aspect_Ratio_Override = False
        Me.vAPT.Video_Renderer_Aspect_Ratio_X = 16
        Me.vAPT.Video_Renderer_Aspect_Ratio_Y = 9
        Me.vAPT.Video_Renderer_BackgroundColor = System.Drawing.Color.Empty
        Me.vAPT.Video_Renderer_Deinterlace_Mode = ""
        Me.vAPT.Video_Renderer_Deinterlace_UseDefault = False
        Me.vAPT.Video_Renderer_Flip_Horizontal = False
        Me.vAPT.Video_Renderer_Flip_Vertical = False
        Me.vAPT.Video_Renderer_RotationAngle = 0
        Me.vAPT.Video_Renderer_Stretch = False
        Me.vAPT.Video_Renderer_Zoom_Ratio = 0
        Me.vAPT.Video_Renderer_Zoom_ShiftX = 0
        Me.vAPT.Video_Renderer_Zoom_ShiftY = 0
        Me.vAPT.Video_Resize = False
        Me.vAPT.Video_Resize_Height = 480
        Me.vAPT.Video_Resize_Width = 640
        Me.vAPT.Video_Rotation = VisioForge.Types.VFRotateMode.RotateNone
        Me.vAPT.Video_Use_Compression = True
        Me.vAPT.Video_Use_Compression_DecodeUncompressedToRGB = True
        Me.vAPT.Virtual_Camera_Output_Enabled = False
        Me.vAPT.WebM_Audio_Quality = 0
        Me.vAPT.WebM_Video_ARNR_MaxFrames = -1
        Me.vAPT.WebM_Video_ARNR_Strength = -1
        Me.vAPT.WebM_Video_ARNR_Type = -1
        Me.vAPT.WebM_Video_AutoAltRef = False
        Me.vAPT.WebM_Video_Bitrate = 0
        Me.vAPT.WebM_Video_CPUUsed = -17
        Me.vAPT.WebM_Video_Decimate = 1
        Me.vAPT.WebM_Video_DecoderBufferInitialSize = -1
        Me.vAPT.WebM_Video_DecoderBufferOptimalSize = -1
        Me.vAPT.WebM_Video_DecoderBufferSize = -1
        Me.vAPT.WebM_Video_DropframeThreshold = -1
        Me.vAPT.WebM_Video_Encoder = VisioForge.Types.WebMVideoEncoder.VP8
        Me.vAPT.WebM_Video_EndUsage = VisioForge.Types.VP8EndUsageMode.VBR
        Me.vAPT.WebM_Video_ErrorResilient = False
        Me.vAPT.WebM_Video_FixedKeyframeInterval = -1
        Me.vAPT.WebM_Video_KeyframeMaxInterval = -1
        Me.vAPT.WebM_Video_KeyframeMinInterval = -1
        Me.vAPT.WebM_Video_KeyframeMode = VisioForge.Types.VP8KeyframeMode.Disabled
        Me.vAPT.WebM_Video_LagInFrames = -1
        Me.vAPT.WebM_Video_MaxQuantizer = -1
        Me.vAPT.WebM_Video_MinQuantizer = -1
        Me.vAPT.WebM_Video_Mode = VisioForge.Types.VP8QualityMode.BestQualityBetaDoNotUse
        Me.vAPT.WebM_Video_OvershootPct = -1
        Me.vAPT.WebM_Video_SpatialResamplingAllowed = False
        Me.vAPT.WebM_Video_SpatialResamplingDownThreshold = -1
        Me.vAPT.WebM_Video_SpatialResamplingUpThreshold = -1
        Me.vAPT.WebM_Video_StaticThreshold = -1
        Me.vAPT.WebM_Video_ThreadCount = 0
        Me.vAPT.WebM_Video_TokenPartition = -1
        Me.vAPT.WebM_Video_UndershootPct = -1
        Me.vAPT.WMV_Custom_Audio_Codec = ""
        Me.vAPT.WMV_Custom_Audio_Format = ""
        Me.vAPT.WMV_Custom_Audio_LanguageID = ""
        Me.vAPT.WMV_Custom_Audio_Mode = VisioForge.Types.VFWMVStreamMode.CBR
        Me.vAPT.WMV_Custom_Audio_PeakBitrate = 0
        Me.vAPT.WMV_Custom_Audio_PeakBufferSize = CType(0, Byte)
        Me.vAPT.WMV_Custom_Audio_Quality = CType(0, Byte)
        Me.vAPT.WMV_Custom_Audio_StreamPresent = False
        Me.vAPT.WMV_Custom_Profile_Description = ""
        Me.vAPT.WMV_Custom_Profile_Language = ""
        Me.vAPT.WMV_Custom_Profile_Name = ""
        Me.vAPT.WMV_Custom_Video_Bitrate = 0
        Me.vAPT.WMV_Custom_Video_Buffer_Size = 0
        Me.vAPT.WMV_Custom_Video_Buffer_UseDefault = False
        Me.vAPT.WMV_Custom_Video_Codec = ""
        Me.vAPT.WMV_Custom_Video_FrameRate = 0.0R
        Me.vAPT.WMV_Custom_Video_Height = 0
        Me.vAPT.WMV_Custom_Video_KeyFrameInterval = CType(0, Byte)
        Me.vAPT.WMV_Custom_Video_Mode = VisioForge.Types.VFWMVStreamMode.CBR
        Me.vAPT.WMV_Custom_Video_PeakBitRate = 0
        Me.vAPT.WMV_Custom_Video_PeakBufferSizeSeconds = CType(0, Byte)
        Me.vAPT.WMV_Custom_Video_Quality = CType(0, Byte)
        Me.vAPT.WMV_Custom_Video_SizeSameAsInput = False
        Me.vAPT.WMV_Custom_Video_Smoothness = CType(0, Byte)
        Me.vAPT.WMV_Custom_Video_StreamPresent = False
        Me.vAPT.WMV_Custom_Video_TVSystem = VisioForge.Types.VFWMVTVSystem.PAL
        Me.vAPT.WMV_Custom_Video_Width = 0
        Me.vAPT.WMV_External_Profile_File_Name = ""
        Me.vAPT.WMV_Internal_Profile_Name = ""
        Me.vAPT.WMV_Mode = VisioForge.Types.VFWMVMode.InternalProfile
        Me.vAPT.WMV_V8_Profile_Name = ""
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(177, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(36, 76)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(257, 29)
        Me.lblStatus.TabIndex = 42
        Me.lblStatus.Text = "► start by importing video"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'axWait
        '
        Me.axWait.Enabled = True
        Me.axWait.Location = New System.Drawing.Point(0, 0)
        Me.axWait.Name = "axWait"
        Me.axWait.OcxState = CType(resources.GetObject("axWait.OcxState"), System.Windows.Forms.AxHost.State)
        Me.axWait.Size = New System.Drawing.Size(320, 240)
        Me.axWait.TabIndex = 41
        Me.axWait.Visible = False
        '
        'pBar
        '
        Me.pBar.BackColor = System.Drawing.Color.Black
        Me.pBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pBar.Location = New System.Drawing.Point(9, 258)
        Me.pBar.MarqueeAnimationSpeed = 200
        Me.pBar.Name = "pBar"
        Me.pBar.Size = New System.Drawing.Size(662, 10)
        Me.pBar.Step = 1
        Me.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pBar.TabIndex = 14
        '
        'cbFX
        '
        Me.cbFX.FormattingEnabled = True
        Me.cbFX.Items.AddRange(New Object() {"style1", "style2", "style3", "style4", "horror"})
        Me.cbFX.Location = New System.Drawing.Point(938, 341)
        Me.cbFX.Name = "cbFX"
        Me.cbFX.Size = New System.Drawing.Size(85, 21)
        Me.cbFX.TabIndex = 35
        Me.cbFX.Text = "style1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(851, 343)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Titles Sound FX:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(693, 344)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Sound track:"
        '
        'cbBG
        '
        Me.cbBG.FormattingEnabled = True
        Me.cbBG.Items.AddRange(New Object() {"blockbuster1", "blockbuster2", "comedy1", "comedy2", "family1", "historic1", "romantic1"})
        Me.cbBG.Location = New System.Drawing.Point(762, 341)
        Me.cbBG.Name = "cbBG"
        Me.cbBG.Size = New System.Drawing.Size(85, 21)
        Me.cbBG.TabIndex = 37
        Me.cbBG.Text = "romantic1"
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"Template 1", "Template 2"})
        Me.ComboBox5.Location = New System.Drawing.Point(938, 283)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox5.TabIndex = 53
        Me.ComboBox5.Text = "Template 1"
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"Template 1", "Template 2"})
        Me.ComboBox4.Location = New System.Drawing.Point(938, 233)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox4.TabIndex = 52
        Me.ComboBox4.Text = "Template 1"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"Template 1", "Template 2"})
        Me.ComboBox3.Location = New System.Drawing.Point(938, 183)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox3.TabIndex = 51
        Me.ComboBox3.Text = "Template 1"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Template 1", "Template 2"})
        Me.ComboBox2.Location = New System.Drawing.Point(938, 133)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox2.TabIndex = 50
        Me.ComboBox2.Text = "Template 1"
        '
        'tbIntro1
        '
        Me.tbIntro1.Location = New System.Drawing.Point(762, 134)
        Me.tbIntro1.Multiline = True
        Me.tbIntro1.Name = "tbIntro1"
        Me.tbIntro1.Size = New System.Drawing.Size(170, 40)
        Me.tbIntro1.TabIndex = 41
        Me.tbIntro1.Text = "Only on YouTube!"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(693, 286)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Closing text:"
        '
        'tbOpening
        '
        Me.tbOpening.Location = New System.Drawing.Point(762, 84)
        Me.tbOpening.Multiline = True
        Me.tbOpening.Name = "tbOpening"
        Me.tbOpening.Size = New System.Drawing.Size(170, 40)
        Me.tbOpening.TabIndex = 39
        Me.tbOpening.Text = "YTrailer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "presents"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(693, 234)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "intro3 text:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Template 1", "Template 2"})
        Me.ComboBox1.Location = New System.Drawing.Point(938, 83)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(85, 21)
        Me.ComboBox1.TabIndex = 40
        Me.ComboBox1.Text = "Template 1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(693, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "intro2 text:"
        '
        'tbIntro2
        '
        Me.tbIntro2.Location = New System.Drawing.Point(762, 184)
        Me.tbIntro2.Multiline = True
        Me.tbIntro2.Name = "tbIntro2"
        Me.tbIntro2.Size = New System.Drawing.Size(170, 40)
        Me.tbIntro2.TabIndex = 42
        Me.tbIntro2.Text = "Watch soon..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(693, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "intro1 text:"
        '
        'tbIntro3
        '
        Me.tbIntro3.Location = New System.Drawing.Point(762, 234)
        Me.tbIntro3.Multiline = True
        Me.tbIntro3.Name = "tbIntro3"
        Me.tbIntro3.Size = New System.Drawing.Size(170, 40)
        Me.tbIntro3.TabIndex = 43
        Me.tbIntro3.Text = "Don't miss!"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(693, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Opening text:"
        '
        'tbClosing
        '
        Me.tbClosing.Location = New System.Drawing.Point(762, 284)
        Me.tbClosing.Multiline = True
        Me.tbClosing.Name = "tbClosing"
        Me.tbClosing.Size = New System.Drawing.Size(170, 40)
        Me.tbClosing.TabIndex = 44
        Me.tbClosing.Text = "Watch on our channel" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "http://youtube.com/ytrailer"
        '
        'backgroundWorker1
        '
        Me.backgroundWorker1.WorkerReportsProgress = True
        Me.backgroundWorker1.WorkerSupportsCancellation = True
        '
        'bGetYoutube
        '
        Me.bGetYoutube.Location = New System.Drawing.Point(918, 40)
        Me.bGetYoutube.Name = "bGetYoutube"
        Me.bGetYoutube.Size = New System.Drawing.Size(112, 25)
        Me.bGetYoutube.TabIndex = 54
        Me.bGetYoutube.Text = "Get from YouTube"
        Me.bGetYoutube.UseVisualStyleBackColor = True
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(689, 14)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(338, 20)
        Me.txtURL.TabIndex = 55
        Me.txtURL.Text = "http://www.youtube.com/watch?v=D-wxnID2q4A"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(688, 332)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(347, 39)
        Me.PictureBox1.TabIndex = 56
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Location = New System.Drawing.Point(689, 78)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(346, 248)
        Me.PictureBox2.TabIndex = 57
        Me.PictureBox2.TabStop = False
        '
        'chk800
        '
        Me.chk800.AccessibleDescription = "h"
        Me.chk800.AutoSize = True
        Me.chk800.Location = New System.Drawing.Point(690, 388)
        Me.chk800.Name = "chk800"
        Me.chk800.Size = New System.Drawing.Size(67, 17)
        Me.chk800.TabIndex = 58
        Me.chk800.Text = "800x600"
        Me.chk800.UseVisualStyleBackColor = True
        Me.chk800.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 414)
        Me.Controls.Add(Me.chk800)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.bGetYoutube)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.tbIntro1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbOpening)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbIntro2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbIntro3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbClosing)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbBG)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbFX)
        Me.Controls.Add(Me.lblFrameIndex)
        Me.Controls.Add(Me.pbSignal)
        Me.Controls.Add(Me.pbPreview)
        Me.Controls.Add(Me.pBar)
        Me.Controls.Add(Me.vAPT)
        Me.Controls.Add(Me.lblTotalScenes)
        Me.Controls.Add(Me.rbOut30)
        Me.Controls.Add(Me.rbOut15)
        Me.Controls.Add(Me.rbOut6)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.pbOscilograph)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APT v0.4.1.5"
        Me.TransparencyKey = System.Drawing.Color.DarkGray
        CType(Me.pbPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbOscilograph, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSignal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vAPT.ResumeLayout(False)
        CType(Me.axWait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pbPreview As System.Windows.Forms.PictureBox
    Friend WithEvents lblFrameIndex As System.Windows.Forms.Label
    Friend WithEvents pbOscilograph As System.Windows.Forms.PictureBox
    Friend WithEvents pbSignal As System.Windows.Forms.PictureBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents from As System.Windows.Forms.ColumnHeader
    Friend WithEvents upto As System.Windows.Forms.ColumnHeader
    Friend WithEvents rbOut6 As System.Windows.Forms.RadioButton
    Friend WithEvents rbOut15 As System.Windows.Forms.RadioButton
    Friend WithEvents rbOut30 As System.Windows.Forms.RadioButton
    Friend WithEvents lblTotalScenes As System.Windows.Forms.Label
    Friend WithEvents vAPT As VisioForge.Controls.WinForms.VideoEdit
    Friend WithEvents pBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cbFX As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbBG As System.Windows.Forms.ComboBox
    Friend WithEvents axWait As AxShockwaveFlashObjects.AxShockwaveFlash
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents tbIntro1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbOpening As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbIntro2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbIntro3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbClosing As System.Windows.Forms.TextBox
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents bGetYoutube As System.Windows.Forms.Button
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents chk800 As System.Windows.Forms.CheckBox

End Class
