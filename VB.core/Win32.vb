Imports System.Runtime.InteropServices


''' <summary>
''' Windows API functions and structures
''' </summary>
Friend Class Win32
    ' --- AVI Functions

    ' Initialize the AVIFile library
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Sub AVIFileInit()
    End Sub

    ' Exit the AVIFile library 
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Sub AVIFileExit()
    End Sub

    ' Open an AVI file
    <DllImport("c:\windows\syswow64\avifil32.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function AVIFileOpen(ByRef ppfile As IntPtr, szFile As [String], mode As OpenFileMode, pclsidHandler As IntPtr) As Integer
    End Function

    ' Release an open AVI stream
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIFileRelease(pfile As IntPtr) As Integer
    End Function

    ' Get address of a stream interface that is associated
    ' with a specified AVI file
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIFileGetStream(pfile As IntPtr, ByRef ppavi As IntPtr, fccType As Integer, lParam As Integer) As Integer
    End Function

    ' Create a new stream in an existing file and creates an interface to the new stream
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIFileCreateStream(pfile As IntPtr, ByRef ppavi As IntPtr, ByRef psi As AVI_STREAMINFO) As Integer
    End Function

    ' Release an open AVI stream
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamRelease(pavi As IntPtr) As Integer
    End Function

    ' Set the format of a stream at the specified position
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamSetFormat(pavi As IntPtr, lPos As Integer, ByRef lpFormat As BITMAPINFOHEADER, cbFormat As Integer) As Integer
    End Function

    ' Get the starting sample number for the stream
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamStart(pavi As IntPtr) As Integer
    End Function

    ' Get the length of the stream
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamLength(pavi As IntPtr) As Integer
    End Function

    ' Obtain stream header information
    <DllImport("c:\windows\syswow64\avifil32.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function AVIStreamInfo(pavi As IntPtr, ByRef psi As AVI_STREAMINFO, lSize As Integer) As Integer
    End Function

    ' Prepare to decompress video frames from the specified video stream
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamGetFrameOpen(pavi As IntPtr, ByRef lpbiWanted As BITMAPINFOHEADER) As IntPtr
    End Function
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamGetFrameOpen(pavi As IntPtr, lpbiWanted As Integer) As IntPtr
    End Function

    ' Releases resources used to decompress video frames
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamGetFrameClose(pget As IntPtr) As Integer
    End Function

    ' Return the address of a decompressed video frame
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamGetFrame(pget As IntPtr, lPos As Integer) As IntPtr
    End Function

    ' Write data to a stream
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIStreamWrite(pavi As IntPtr, lStart As Integer, lSamples As Integer, lpBuffer As IntPtr, cbBuffer As Integer, dwFlags As Integer, _
            plSampWritten As IntPtr, plBytesWritten As IntPtr) As Integer
    End Function

    ' Retrieve the save options for a file and returns them in a buffer
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVISaveOptions(hwnd As IntPtr, flags As Integer, streams As Integer, <[In], MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)> ppavi As IntPtr(), <[In], MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)> plpOptions As IntPtr()) As Integer
    End Function

    ' Free the resources allocated by the AVISaveOptions function
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVISaveOptionsFree(streams As Integer, <[In], MarshalAs(UnmanagedType.LPArray, SizeParamIndex:=0)> plpOptions As IntPtr()) As Integer
    End Function

    ' Create a compressed stream from an uncompressed stream and a
    ' compression filter, and returns the address of a pointer to
    ' the compressed stream
    <DllImport("c:\windows\syswow64\avifil32.dll")> _
    Public Shared Function AVIMakeCompressedStream(ByRef ppsCompressed As IntPtr, psSource As IntPtr, ByRef lpOptions As AVICOMPRESSOPTIONS, pclsidHandler As IntPtr) As Integer
    End Function

    ' --- memory functions

    ' memcpy - copy a block of memery
    <DllImport("ntdll.dll")> _
    Public Shared Function memcpy(dst As Object, src As Object, count As Integer) As IntPtr
    End Function
   

    <DllImport("GdiPlus.dll", CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
    Public Shared Function GdipCreateBitmapFromGdiDib(pBIH As IntPtr, pPix As IntPtr, ByRef pBitmap As IntPtr) As Integer
    End Function

    ' --- structures

    ' Define the coordinates of the upper-left and
    ' lower-right corners of a rectangle
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure RECT
        <MarshalAs(UnmanagedType.I4)> _
        Public left As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public top As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public right As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public bottom As Integer
    End Structure

    ' Contains information for a single stream
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode, Pack:=1)> _
    Public Structure AVI_STREAMINFO
        <MarshalAs(UnmanagedType.I4)> _
        Public fccType As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public fccHandler As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwFlags As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwCaps As Integer
        <MarshalAs(UnmanagedType.I2)> _
        Public wPriority As Short
        <MarshalAs(UnmanagedType.I2)> _
        Public wLanguage As Short
        <MarshalAs(UnmanagedType.I4)> _
        Public dwScale As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwRate As Integer
        ' dwRate / dwScale == samples/second
        <MarshalAs(UnmanagedType.I4)> _
        Public dwStart As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwLength As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwInitialFrames As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwSuggestedBufferSize As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwQuality As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwSampleSize As Integer
        <MarshalAs(UnmanagedType.Struct, SizeConst:=16)> _
        Public rcFrame As RECT
        <MarshalAs(UnmanagedType.I4)> _
        Public dwEditCount As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwFormatChangeCount As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=64)> _
        Public szName As String
    End Structure

    ' Contains information about the dimensions and color format of a DIB
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure BITMAPINFOHEADER
        <MarshalAs(UnmanagedType.I4)> _
        Public biSize As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public biWidth As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public biHeight As Integer
        <MarshalAs(UnmanagedType.I2)> _
        Public biPlanes As Short
        <MarshalAs(UnmanagedType.I2)> _
        Public biBitCount As Short
        <MarshalAs(UnmanagedType.I4)> _
        Public biCompression As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public biSizeImage As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public biXPelsPerMeter As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public biYPelsPerMeter As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public biClrUsed As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public biClrImportant As Integer
    End Structure

    ' Contains information about a stream and how it is compressed and saved
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Public Structure AVICOMPRESSOPTIONS
        <MarshalAs(UnmanagedType.I4)> _
        Public fccType As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public fccHandler As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwKeyFrameEvery As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwQuality As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwBytesPerSecond As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwFlags As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public lpFormat As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public cbFormat As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public lpParms As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public cbParms As Integer
        <MarshalAs(UnmanagedType.I4)> _
        Public dwInterleaveEvery As Integer
    End Structure

    ' --- enumerations

    ' File access modes
    <Flags> _
    Public Enum OpenFileMode
        Read = &H0
        Write = &H1
        ReadWrite = &H2
        ShareCompat = &H0
        ShareExclusive = &H10
        ShareDenyWrite = &H20
        ShareDenyRead = &H30
        ShareDenyNone = &H40
        Parse = &H100
        Delete = &H200
        Verify = &H400
        Cancel = &H800
        Create = &H1000
        Prompt = &H2000
        Exist = &H4000
        Reopen = &H8000
    End Enum

    ' ---

    ' Replacement of mmioFOURCC macros
    Public Shared Function mmioFOURCC(str As String) As Integer
        Return (CInt(CByte(AscW(str(0)))) Or (CInt(CByte(AscW(str(1)))) << 8) Or (CInt(CByte(AscW(str(2)))) << 16) Or (CInt(CByte(AscW(str(3)))) << 24))
    End Function

    ' Inverse of mmioFOURCC
    Public Shared Function decode_mmioFOURCC(code As Integer) As String
        Dim chs As Char() = New Char(3) {}

        For i As Integer = 0 To 3
            chs(i) = ChrW(CByte((code >> (i << 3)) And &HFF))
            If Not Char.IsLetterOrDigit(chs(i)) Then
                chs(i) = " "c
            End If
        Next
        Return New String(chs)
    End Function

    ' --- public methods

    ' Version of AVISaveOptions for one stream only
    '
    ' I don't find a way to interop AVISaveOptions more likely, so the
    ' usage of original version is not easy. The version makes it more
    ' usefull.
    '
    Public Shared Function AVISaveOptions(stream As IntPtr, ByRef opts As AVICOMPRESSOPTIONS, owner As IntPtr) As Integer
        Dim streams As IntPtr() = New IntPtr(0) {}
        Dim infPtrs As IntPtr() = New IntPtr(0) {}
        Dim mem As IntPtr
        Dim ret As Integer

        ' alloc unmanaged memory
        mem = Marshal.AllocHGlobal(Marshal.SizeOf(GetType(AVICOMPRESSOPTIONS)))

        ' copy from managed structure to unmanaged memory
        Marshal.StructureToPtr(opts, mem, False)

        streams(0) = stream
        infPtrs(0) = mem

        ' show dialog with a list of available compresors and configuration
        ret = AVISaveOptions(IntPtr.Zero, 0, 1, streams, infPtrs)

        ' copy from unmanaged memory to managed structure
        opts = CType(Marshal.PtrToStructure(mem, GetType(AVICOMPRESSOPTIONS)), AVICOMPRESSOPTIONS)

        ' free AVI compression options
        AVISaveOptionsFree(1, infPtrs)

        ' clear it, because the information already freed by AVISaveOptionsFree
        opts.cbFormat = 0
        opts.cbParms = 0
        opts.lpFormat = 0
        opts.lpParms = 0

        ' free unmanaged memory
        Marshal.FreeHGlobal(mem)

        Return ret
    End Function
End Class

