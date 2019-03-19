Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Drawing

Namespace Tools
    Public Enum IEIFLAG As Integer
        ASYNC = &H1
        CACHE = &H2
        ASPECT = &H4
        OFFLINE = &H8
        GLEAM = &H10
        SCREEN = &H20
        ORIGSIZE = &H40
        NOSTAMP = &H80
        NOBORDER = &H100
        QUALITY = &H200
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure STRRET_CSTR
        Public uType As Integer
        <FieldOffset(4), MarshalAs(UnmanagedType.LPWStr)> _
        Public pOleStr As String
        <FieldOffset(4)> _
        Public uOffset As Integer
        <FieldOffset(4), MarshalAs(UnmanagedType.ByValArray, SizeConst:=520)> _
        Public strName As Byte()
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SIZE
        Public cx As Integer
        Public cy As Integer
    End Structure

    <ComImportAttribute(), _
     GuidAttribute("BB2E617C-0920-11d1-9A0B-00C04FC2D6C1"), _
     InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Friend Interface IExtractImage

        Function GetLocation( _
            ByVal pszPathBuffer As IntPtr, _
            ByVal cch As Integer, _
            ByRef pdwPriority As Integer, _
            ByRef prgSize As SIZE, _
            ByVal dwRecClrDepth As Integer, _
            ByRef pdwFlags As Integer) As Integer

        Sub Extract(ByRef phBmpThumbnail As IntPtr)

    End Interface

    <ComImportAttribute(), _
    GuidAttribute("000214E6-0000-0000-C000-000000000046"), _
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
    Friend Interface IShellFolder


        Sub ParseDisplayName( _
          ByVal hWnd As IntPtr, _
          ByVal pbc As IntPtr, _
          ByVal pszDisplayName As String, _
          ByRef pchEaten As Integer, _
          ByRef ppidl As System.IntPtr, _
          ByRef pdwAttributes As Integer)

        Sub EnumObjects( _
          ByVal hwndOwner As IntPtr, _
          <MarshalAs(UnmanagedType.U4)> ByVal grfFlags As Integer, _
          <Out()> ByRef ppenumIDList As IntPtr)

        Sub BindToObject( _
          ByVal pidl As IntPtr, _
          ByVal pbcReserved As IntPtr, _
          ByRef riid As Guid, _
          ByRef ppvOut As IShellFolder)

        Sub BindToStorage( _
          ByVal pidl As IntPtr, _
          ByVal pbcReserved As IntPtr, _
          ByRef riid As Guid, _
          <Out()> ByVal ppvObj As IntPtr)

        <PreserveSig()> _
        Function CompareIDs( _
          ByVal lParam As IntPtr, _
          ByVal pidl1 As IntPtr, _
          ByVal pidl2 As IntPtr) As Integer

        Sub CreateViewObject( _
          ByVal hwndOwner As IntPtr, _
          ByRef riid As Guid, _
          ByVal ppvOut As Object)

        Sub GetAttributesOf( _
          ByVal cidl As Integer, _
          ByVal apidl As IntPtr, _
          <MarshalAs(UnmanagedType.U4)> ByRef rgfInOut As Integer)

        Sub GetUIObjectOf( _
          ByVal hwndOwner As IntPtr, _
          ByVal cidl As Integer, _
          ByRef apidl As IntPtr, _
          ByRef riid As Guid, _
          <Out()> ByVal prgfInOut As Integer, _
          <Out(), MarshalAs(UnmanagedType.IUnknown)> ByRef ppvOut As Object)

        Sub GetDisplayNameOf( _
          ByVal pidl As IntPtr, _
          <MarshalAs(UnmanagedType.U4)> ByVal uFlags As Integer, _
          ByRef lpName As STRRET_CSTR)

        Sub SetNameOf( _
          ByVal hwndOwner As IntPtr, _
          ByVal pidl As IntPtr, _
          <MarshalAs(UnmanagedType.LPWStr)> ByVal lpszName As String, _
          <MarshalAs(UnmanagedType.U4)> ByVal uFlags As Integer, _
          ByRef ppidlOut As IntPtr)

    End Interface

    Friend Class ShellInterop

        Private Const MAX_PATH As Integer = 260


        <DllImport("shell32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function SHGetDesktopFolder( _
          <Out()> ByRef ppshf As IShellFolder) As Integer
        End Function

        Friend Shared Function GetThumbnailImage(ByVal fileName As String, _
      ByVal longestEdge As Integer, ByVal colorDepth As Integer) As Image


            Dim desktopFolder As IShellFolder = Nothing
            Dim someFolder As IShellFolder = Nothing
            Dim extract As IExtractImage = Nothing
            Dim pidl As IntPtr
            Dim filePidl As IntPtr

            Dim flags As IEIFLAG = IEIFLAG.ORIGSIZE Or IEIFLAG.QUALITY Or IEIFLAG.ASPECT
            Dim bmp As IntPtr
            Dim thePath As IntPtr = Marshal.AllocHGlobal(MAX_PATH)


            'Manually define the IIDs for IShellFolder and IExtractImage
            Dim IID_IShellFolder As System.Guid = New Guid("000214E6-0000-0000-C000-000000000046")
            Dim IID_IExtractImage As System.Guid = New Guid("BB2E617C-0920-11d1-9A0B-00C04FC2D6C1")
            Try
                'Divide the file name into a path and file name
                Dim folderName As String = Path.GetDirectoryName(fileName)
                Dim shortFileName As String = Path.GetFileName(fileName)

                'Get the desktop IShellFolder
                ShellInterop.SHGetDesktopFolder(desktopFolder)

                'Get the parent folder IShellFolder
                desktopFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, folderName, 0, pidl, 0)
                desktopFolder.BindToObject(pidl, IntPtr.Zero, IID_IShellFolder, someFolder)

                Dim extractObject As Object
                'Get the file's IExtractImage
                someFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, shortFileName, 0, filePidl, 0)
                someFolder.GetUIObjectOf(IntPtr.Zero, 1, filePidl, IID_IExtractImage, 0, extractObject)


                extract = CType(extractObject, IExtractImage)

                'Set the size
                Dim size As SIZE
                size.cx = 500
                size.cy = 500


                'Interop will throw an exception if one of these calls fail.
                Try

                    System.Windows.Forms.Application.DoEvents()

                    extract.GetLocation(thePath, MAX_PATH, 0, size, colorDepth, CInt(flags))

                Catch ex As Exception
                    Debug.Print(ex.Message)

                End Try

                extract.Extract(bmp)


                If Not bmp.Equals(IntPtr.Zero) Then
                    GetThumbnailImage = Image.FromHbitmap(bmp)
                Else
                    GetThumbnailImage = Nothing
                End If


            Catch ex As Exception

                Debug.Print(ex.Message)
                Return Nothing
            Finally
                'Free the global memory we allocated for the path string
                Marshal.FreeHGlobal(thePath)

                'Free the pidls. The Runtime Callable Wrappers 
                'should automatically release the COM objects
                Marshal.FreeCoTaskMem(pidl)
                Marshal.FreeCoTaskMem(filePidl)
                If extract IsNot Nothing Then
                    Marshal.ReleaseComObject(extract)
                End If
            End Try

        End Function

    End Class


End Namespace