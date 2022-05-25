Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Reflection
''' <summary>
''' Reading AVI files using Video for Windows
''' </summary>
Public Class AVIReader
    Implements IDisposable
    Private file As IntPtr
    Private stream As IntPtr
    Private getFrame As IntPtr

    Private m_width As Integer
    Private m_height As Integer
    Private position As Integer
    Private start As Integer
    Private m_length As Integer
    Private rate As Single
    Private m_codec As String

    ' Width property
    Public ReadOnly Property Width() As Integer
        Get
            Return m_width
        End Get
    End Property




    ' Height property
    Public ReadOnly Property Height() As Integer
        Get
            Return m_height
        End Get
    End Property
    ' FramesRate property
    Public ReadOnly Property FrameRate() As Single
        Get
            Return rate
        End Get
    End Property
    ' CurrentPosition property
    Public Property CurrentPosition() As Integer
        Get
            Return position
        End Get
        Set(value As Integer)
            If (value < start) OrElse (value >= start + m_length) Then
                position = start
            Else
                position = value
            End If
        End Set
    End Property
    ' Length property
    Public ReadOnly Property Length() As Integer
        Get
            Return m_length
        End Get
    End Property
    ' Codec property
    Public ReadOnly Property Codec() As String
        Get
            Return m_codec
        End Get
    End Property


    ' Constructor
    Public Sub New()
        Win32.AVIFileInit()
    End Sub

    ' Desctructor
    Protected Overrides Sub Finalize()
        Try
            Dispose(False)
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    ' Free all unmanaged resources
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        ' Remove me from the Finalization queue 
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        ' Dispose managed resources

        ' there is nothing managed yet
        If disposing Then
        End If
        Close()
        Win32.AVIFileExit()
    End Sub

    ' Open an AVI file
    Public Sub Open(fname As String)
        ' close previous file
        Close()

        ' open file
        If Win32.AVIFileOpen(file, fname, Win32.OpenFileMode.ShareDenyWrite, IntPtr.Zero) <> 0 Then
            Throw New ApplicationException("Failed opening file")
        End If

        ' get first video stream
        If Win32.AVIFileGetStream(file, stream, Win32.mmioFOURCC("vids"), 0) <> 0 Then
            Throw New ApplicationException("Failed getting video stream")
        End If

        ' get stream info
        Dim info As New Win32.AVI_STREAMINFO()
        Win32.AVIStreamInfo(stream, info, Marshal.SizeOf(info))

        m_width = info.rcFrame.right
        m_height = info.rcFrame.bottom
        position = info.dwStart
        start = info.dwStart
        m_length = info.dwLength
        rate = CSng(info.dwRate) / CSng(info.dwScale)
        m_codec = Win32.decode_mmioFOURCC(info.fccHandler)

        ' prepare decompressor
        Dim bih As New Win32.BITMAPINFOHEADER()

        bih.biSize = Marshal.SizeOf(bih.[GetType]())
        bih.biWidth = m_width
        bih.biHeight = m_height
        bih.biPlanes = 1
        bih.biBitCount = 24
        bih.biCompression = 0
        ' BI_RGB
        ' get frame open object
        If (InlineAssignHelper(getFrame, Win32.AVIStreamGetFrameOpen(stream, bih))) = IntPtr.Zero Then
            bih.biHeight = -m_height

            If (InlineAssignHelper(getFrame, Win32.AVIStreamGetFrameOpen(stream, bih))) = IntPtr.Zero Then
                Throw New ApplicationException("Failed initializing decompressor")
            End If
        End If
    End Sub



    ' Close file
    Public Sub Close()
        ' release frame open object
        If getFrame <> IntPtr.Zero Then
            Win32.AVIStreamGetFrameClose(getFrame)
            getFrame = IntPtr.Zero
        End If
        ' release stream
        If stream <> IntPtr.Zero Then
            Win32.AVIStreamRelease(stream)
            stream = IntPtr.Zero
        End If
        ' release file
        If file <> IntPtr.Zero Then
            Win32.AVIFileRelease(file)
            file = IntPtr.Zero
        End If
    End Sub
    Public Shared Function BitmapFromDIB(pDIB As IntPtr, pPix As IntPtr) As Bitmap


        Dim mi As MethodInfo = GetType(Bitmap).GetMethod("FromGDIplus", BindingFlags.[Static] Or BindingFlags.NonPublic)

        If mi Is Nothing Then
            Return Nothing
        End If
        ' (permission problem) 
        Dim pBmp As IntPtr = IntPtr.Zero
        Dim status As Integer = Win32.GdipCreateBitmapFromGdiDib(pDIB, pPix, pBmp)

        If (status = 0) AndAlso (pBmp <> IntPtr.Zero) Then
            ' success 
            Return DirectCast(mi.Invoke(Nothing, New Object() {pBmp}), Bitmap)
        Else

            Return Nothing
        End If
        ' failure 
    End Function      ' Get next video frame
    Public Function GetNextFrame(position As Long) As Bitmap
        ' get frame at specified position
        Dim pdib As IntPtr = Win32.AVIStreamGetFrame(getFrame, position + 30)
        If pdib = IntPtr.Zero Then

            ' Throw New ApplicationException("Failed getting frame")
            GetNextFrame = New Bitmap(m_width, m_height, PixelFormat.Format24bppRgb)
            Exit Function
        End If

        Dim bih As Win32.BITMAPINFOHEADER

        ' copy BITMAPINFOHEADER from unmanaged memory
        bih = DirectCast(Marshal.PtrToStructure(pdib, GetType(Win32.BITMAPINFOHEADER)), Win32.BITMAPINFOHEADER)

        ' create new bitmap
        Dim bmp As New Bitmap(m_width, m_height, PixelFormat.Format24bppRgb)

        ' lock bitmap data
        Dim bmData As BitmapData = bmp.LockBits(New Rectangle(0, 0, m_width, m_height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)

        ' copy image data
        Dim srcStride As Integer = bmData.Stride
        ' width * 3;
        Dim dstStride As Integer = bmData.Stride


        ' check image direction
        If bih.biHeight > 0 Then
            ' it`s a bottom-top image
            Dim dst As Integer = bmData.Scan0.ToInt32() + dstStride * (m_height - 1)
            Dim src As Integer = pdib.ToInt32() + Marshal.SizeOf(GetType(Win32.BITMAPINFOHEADER))
            Return BitmapFromDIB(pdib, src)
            For y As Integer = 0 To m_height - 1
                ' Marshal.Copy(src, dstAr, 0, 320 * 240 * 3)
                Try
                    Win32.memcpy(dst, src, srcStride)
                Catch er As Exception
                    Debug.Print(er.Data)
                End Try
                '  Win32.cmem(bmData, src, srcStride)
                dst -= dstStride
                src += srcStride
            Next
        Else
            ' it`s a top bootom image
            Dim dst As Integer = bmData.Scan0.ToInt32()
            Dim src As Integer = pdib.ToInt32() + Marshal.SizeOf(GetType(Win32.BITMAPINFOHEADER))

            If srcStride <> dstStride Then
                ' copy line by line
                For y As Integer = 0 To m_height - 1
                    Win32.memcpy(dst, src, srcStride)
                    dst += dstStride
                    src += srcStride
                Next
            Else
                ' copy the whole image
                Win32.memcpy(dst, src, srcStride * m_height)
            End If
        End If

        ' unlock bitmap data
        bmp.UnlockBits(bmData)

        position += 1

        Return bmp
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class

