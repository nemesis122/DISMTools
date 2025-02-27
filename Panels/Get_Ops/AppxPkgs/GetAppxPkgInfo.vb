﻿Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Dism
Imports DISMTools.Utilities

Public Class GetAppxPkgInfoDlg

    Public InstalledAppxPkgInfo As DismAppxPackageCollection
    Dim mainAsset As String = ""
    Dim assetDir As String = ""

    Public displayName As String = ""

    Private Sub GetAppxPkgInfoDlg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        Text = "Get AppX package information"
                        Label1.Text = Text
                        Label36.Text = "AppX package information"
                        Label37.Text = "Select an installed AppX package on the left to view its information here"
                        Label22.Text = "Package name:"
                        Label24.Text = "Application display name:"
                        Label26.Text = "Architecture:"
                        Label31.Text = "Resource ID:"
                        Label41.Text = "Version:"
                        Label43.Text = "Is registered to any user?"
                        Label4.Text = "Installation directory:"
                        Label6.Text = "Package manifest location:"
                        Label8.Text = "Store logo asset directory:"
                        Label9.Text = "Main store logo asset:"
                        Label10.Text = "This asset has been guessed by DISMTools based on its size, which can lead to an incorrect result. If that happens, please report an issue on the GitHub repository"
                        Button2.Text = "Save..."
                    Case "ESN"
                        Text = "Obtener información de paquetes AppX"
                        Label1.Text = Text
                        Label36.Text = "Información de paquete AppX"
                        Label37.Text = "Seleccione un paquete AppX instalado en la izquierda para ver su información aquí"
                        Label22.Text = "Nombre de paquete:"
                        Label24.Text = "Nombre de aplicación a mostrar:"
                        Label26.Text = "Arquitectura:"
                        Label31.Text = "ID de recurso:"
                        Label41.Text = "Versión:"
                        Label43.Text = "¿Está registrado a algún usuario?"
                        Label4.Text = "Directorio de instalación:"
                        Label6.Text = "Ubicación del manifiesto del paquete:"
                        Label8.Text = "Directorio de recursos de logotipos de Tienda:"
                        Label9.Text = "Recurso de logotipos de Tienda principal:"
                        Label10.Text = "Este recurso ha sido averiguado por DISMTools por su tamaño, lo que puede llevar a un resultado incorrecto. Si eso ocurre, informe de un problema en el repositorio de GitHub"
                        Button2.Text = "Guardar..."
                    Case "FRA"
                        Text = "Obtenir des informations sur les paquets AppX"
                        Label1.Text = Text
                        Label36.Text = "Informations sur le paquet AppX"
                        Label37.Text = "Sélectionnez un paquet AppX installé sur la gauche pour afficher son information ici."
                        Label22.Text = "Nom du paquet :"
                        Label24.Text = "Nom d'affichage de l'application :"
                        Label26.Text = "Architecture :"
                        Label31.Text = "ID de la ressource :"
                        Label41.Text = "Version :"
                        Label43.Text = "Est-il enregistré au nom d'un utilisateur ?"
                        Label4.Text = "Répertoire d'installation :"
                        Label6.Text = "Emplacement du manifeste du paquet :"
                        Label8.Text = "Répertoire du logo du magasin :"
                        Label9.Text = "Logo du magasin principal :"
                        Label10.Text = "Ce bien a été deviné par DISMTools sur la base de sa taille, ce qui peut conduire à un résultat incorrect. Si cela se produit, veuillez signaler un problème sur le dépôt GitHub."
                        Button2.Text = "Sauvegarder..."
                End Select
            Case 1
                Text = "Get AppX package information"
                Label1.Text = Text
                Label36.Text = "AppX package information"
                Label37.Text = "Select an installed AppX package on the left to view its information here"
                Label22.Text = "Package name:"
                Label24.Text = "Application display name:"
                Label26.Text = "Architecture:"
                Label31.Text = "Resource ID:"
                Label41.Text = "Version:"
                Label43.Text = "Is registered to any user?"
                Label4.Text = "Installation directory:"
                Label6.Text = "Package manifest location:"
                Label8.Text = "Store logo asset directory:"
                Label9.Text = "Main store logo asset:"
                Label10.Text = "This asset has been guessed by DISMTools based on its size, which can lead to an incorrect result. If that happens, please report an issue on the GitHub repository"
                Button2.Text = "Save..."
            Case 2
                Text = "Obtener información de paquetes AppX"
                Label1.Text = Text
                Label36.Text = "Información de paquete AppX"
                Label37.Text = "Seleccione un paquete AppX instalado en la izquierda para ver su información aquí"
                Label22.Text = "Nombre de paquete:"
                Label24.Text = "Nombre de aplicación a mostrar:"
                Label26.Text = "Arquitectura:"
                Label31.Text = "ID de recurso:"
                Label41.Text = "Versión:"
                Label43.Text = "¿Está registrado a algún usuario?"
                Label4.Text = "Directorio de instalación:"
                Label6.Text = "Ubicación del manifiesto del paquete:"
                Label8.Text = "Directorio de recursos de logotipos de Tienda:"
                Label9.Text = "Recurso de logotipos de Tienda principal:"
                Label10.Text = "Este recurso ha sido averiguado por DISMTools por su tamaño, lo que puede llevar a un resultado incorrecto. Si eso ocurre, informe de un problema en el repositorio de GitHub"
                Button2.Text = "Guardar..."
            Case 3
                Text = "Obtenir des informations sur les paquets AppX"
                Label1.Text = Text
                Label36.Text = "Informations sur le paquet AppX"
                Label37.Text = "Sélectionnez un paquet AppX installé sur la gauche pour afficher son information ici."
                Label22.Text = "Nom du paquet :"
                Label24.Text = "Nom d'affichage de l'application :"
                Label26.Text = "Architecture :"
                Label31.Text = "ID de la ressource :"
                Label41.Text = "Version :"
                Label43.Text = "Est-il enregistré au nom d'un utilisateur ?"
                Label4.Text = "Répertoire d'installation :"
                Label6.Text = "Emplacement du manifeste du paquet :"
                Label8.Text = "Répertoire du logo du magasin :"
                Label9.Text = "Logo du magasin principal :"
                Label10.Text = "Ce bien a été deviné par DISMTools sur la base de sa taille, ce qui peut conduire à un résultat incorrect. Si cela se produit, veuillez signaler un problème sur le dépôt GitHub."
                Button2.Text = "Sauvegarder..."
        End Select
        If MainForm.BackColor = Color.FromArgb(48, 48, 48) Then
            Win10Title.BackColor = Color.FromArgb(48, 48, 48)
            BackColor = Color.FromArgb(31, 31, 31)
            ForeColor = Color.White
            ListBox1.BackColor = Color.FromArgb(31, 31, 31)
        ElseIf MainForm.BackColor = Color.FromArgb(239, 239, 242) Then
            Win10Title.BackColor = Color.White
            BackColor = Color.FromArgb(238, 238, 242)
            ForeColor = Color.Black
            ListBox1.BackColor = Color.FromArgb(238, 238, 242)
        End If
        ListBox1.ForeColor = ForeColor
        If Environment.OSVersion.Version.Major = 10 Then
            Text = ""
            Win10Title.Visible = True
        End If
        Dim handle As IntPtr = MainForm.GetWindowHandle(Me)
        If MainForm.IsWindowsVersionOrGreater(10, 0, 18362) Then MainForm.EnableDarkTitleBar(handle, MainForm.BackColor = Color.FromArgb(48, 48, 48))
        ' Populate feature information list
        Panel4.Visible = False
        Panel7.Visible = True
        ' Populate package listing
        ListBox1.Items.Clear()
        ' The PowerShell helper may have added stuff to the MainForm arrays. Check that
        If InstalledAppxPkgInfo IsNot Nothing Then
            If MainForm.imgAppxPackageNames.Count > InstalledAppxPkgInfo.Count Then
                For Each PackageName In MainForm.imgAppxPackageNames
                    ListBox1.Items.Add(PackageName)
                Next
                ' An empty entry will appear, so remove it
                ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1)
            Else
                For Each InstalledAppxPkg As DismAppxPackage In InstalledAppxPkgInfo
                    ListBox1.Items.Add(InstalledAppxPkg.PackageName)
                Next
            End If
        Else
            ' This condition is met on Windows 8 hosts, as they can't get AppX package information with the DISM API.
            For Each PackageName In MainForm.imgAppxPackageNames
                If PackageName Is Nothing Then Continue For
                ListBox1.Items.Add(PackageName)
            Next
            ' An empty entry will appear, so remove it
            ListBox1.Items.RemoveAt(ListBox1.Items.Count - 1)
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Label10.Visible = True
        mainAsset = ""
        assetDir = ""
        ' Clear the values of Label7, Label5, and Label3; as the program can't update their text properties on some packages
        Label7.Text = ""
        Label5.Text = ""
        Label3.Text = ""

        If ListBox1.SelectedItems.Count = 1 Then
            If InstalledAppxPkgInfo IsNot Nothing Then
                If MainForm.imgAppxPackageNames.Count > InstalledAppxPkgInfo.Count Then
                    Label23.Text = MainForm.imgAppxPackageNames(ListBox1.SelectedIndex)
                    Label25.Text = MainForm.imgAppxDisplayNames(ListBox1.SelectedIndex)
                    Label35.Text = MainForm.imgAppxArchitectures(ListBox1.SelectedIndex)
                    Label32.Text = MainForm.imgAppxResourceIds(ListBox1.SelectedIndex)
                    Label40.Text = MainForm.imgAppxVersions(ListBox1.SelectedIndex)
                Else
                    Label23.Text = InstalledAppxPkgInfo(ListBox1.SelectedIndex).PackageName
                    Label25.Text = InstalledAppxPkgInfo(ListBox1.SelectedIndex).DisplayName
                    Label35.Text = Casters.CastDismArchitecture(InstalledAppxPkgInfo(ListBox1.SelectedIndex).Architecture, True)
                    Label32.Text = InstalledAppxPkgInfo(ListBox1.SelectedIndex).ResourceId
                    Label40.Text = InstalledAppxPkgInfo(ListBox1.SelectedIndex).Version.ToString()
                End If
            Else
                Label23.Text = MainForm.imgAppxPackageNames(MainForm.imgAppxPackageNames.Count - (ListBox1.Items.Count - ListBox1.SelectedIndex) - 1)
                Label25.Text = MainForm.imgAppxDisplayNames(MainForm.imgAppxPackageNames.Count - (ListBox1.Items.Count - ListBox1.SelectedIndex) - 1)
                Label35.Text = MainForm.imgAppxArchitectures(MainForm.imgAppxPackageNames.Count - (ListBox1.Items.Count - ListBox1.SelectedIndex) - 1)
                Label32.Text = MainForm.imgAppxResourceIds(MainForm.imgAppxPackageNames.Count - (ListBox1.Items.Count - ListBox1.SelectedIndex) - 1)
                Label40.Text = MainForm.imgAppxVersions(MainForm.imgAppxPackageNames.Count - (ListBox1.Items.Count - ListBox1.SelectedIndex) - 1)
            End If

            displayName = Label25.Text

            Dim packageDispName As String = MainForm.GetPackageDisplayName(Label23.Text, Label25.Text)

            Dim appDisplayName As String = ""

            If packageDispName IsNot Nothing Then
                appDisplayName = If(Not packageDispName.StartsWith("ms-resource:"), packageDispName, "")
            End If

            If appDisplayName <> "" Then Label25.Text &= " (" & appDisplayName & ")"

            ' Get exclusive things that can't be obtained with the DISM API
            If Directory.Exists(MainForm.MountDir & "\ProgramData\Microsoft\Windows\AppRepository\Packages\" & Label23.Text) Then
                If My.Computer.FileSystem.GetFiles(MainForm.MountDir & "\ProgramData\Microsoft\Windows\AppRepository\Packages\" & Label23.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.pckgdep").Count = 0 Then
                    Select Case MainForm.Language
                        Case 0
                            Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                                Case "ENU", "ENG"
                                    Label42.Text = "No"
                                Case "ESN"
                                    Label42.Text = "No"
                                Case "FRA"
                                    Label42.Text = "Non"
                            End Select
                        Case 1
                            Label42.Text = "No"
                        Case 2
                            Label42.Text = "No"
                        Case 3
                            Label42.Text = "Non"
                    End Select
                Else
                    Select Case MainForm.Language
                        Case 0
                            Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                                Case "ENU", "ENG"
                                    Label42.Text = "Yes"
                                Case "ESN"
                                    Label42.Text = "Sí"
                                Case "FRA"
                                    Label42.Text = "Oui"
                            End Select
                        Case 1
                            Label42.Text = "Yes"
                        Case 2
                            Label42.Text = "Sí"
                        Case 3
                            Label42.Text = "Oui"
                    End Select
                End If
            Else
                Select Case MainForm.Language
                    Case 0
                        Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                            Case "ENU", "ENG"
                                Label42.Text = "No"
                            Case "ESN"
                                Label42.Text = "No"
                            Case "FRA"
                                Label42.Text = "Non"
                        End Select
                    Case 1
                        Label42.Text = "No"
                    Case 2
                        Label42.Text = "No"
                    Case 3
                        Label42.Text = "Non"
                End Select
            End If
            mainAsset = MainForm.GetStoreAppMainLogo(Label23.Text)
            If mainAsset <> "" And File.Exists(mainAsset) Then
                Dim asset As Image = Image.FromFile(mainAsset)
                If (asset.Width > PictureBox2.Width) Or (asset.Height > PictureBox2.Height) Then
                    PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
                Else
                    PictureBox2.SizeMode = PictureBoxSizeMode.CenterImage
                End If
            Else
                Label10.Visible = False
                PictureBox2.SizeMode = PictureBoxSizeMode.CenterImage
            End If
            If mainAsset <> "" And File.Exists(mainAsset) Then PictureBox2.Image = Image.FromFile(mainAsset) Else PictureBox2.Image = If(MainForm.BackColor = Color.FromArgb(48, 48, 48), My.Resources.preview_unavail_dark, My.Resources.preview_unavail_light)
            Try
                assetDir = MainForm.GetSuitablePackageFolder(Label25.Text)
            Catch ex As Exception
                ' Continue
            End Try
            If assetDir <> "" Then
                If File.Exists(assetDir & "\AppxManifest.xml") Then
                    Dim ManFile As New RichTextBox() With {
                        .Text = File.ReadAllText(assetDir & "\AppxManifest.xml")
                    }
                    For Each line In ManFile.Lines
                        If line.Contains("<Logo>") Then
                            Dim SplitPaths As New List(Of String)
                            SplitPaths = line.Replace(" ", "").Trim().Replace("/", "").Trim().Replace("<Logo>", "").Trim().Split("\").ToList()
                            SplitPaths.RemoveAt(SplitPaths.Count - 1)
                            Dim newPath As String = String.Join("\", SplitPaths)
                            Label7.Text = (assetDir & "\" & newPath).Replace("\\", "\").Trim()
                            Exit For
                        End If
                    Next
                End If
            Else
                If File.Exists(If(MainForm.OnlineManagement, Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.Windows)), MainForm.MountDir) & "\Program Files\WindowsApps\" & Label23.Text & "\AppxManifest.xml") Then
                    Dim ManFile As New RichTextBox() With {
                        .Text = File.ReadAllText(If(MainForm.OnlineManagement, Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.Windows)), MainForm.MountDir) & "\Program Files\WindowsApps\" & Label23.Text & "\AppxManifest.xml")
                    }
                    For Each line In ManFile.Lines
                        If line.Contains("<Logo>") Then
                            Dim SplitPaths As New List(Of String)
                            SplitPaths = line.Replace(" ", "").Trim().Replace("/", "").Trim().Replace("<Logo>", "").Trim().Split("\").ToList()
                            SplitPaths.RemoveAt(SplitPaths.Count - 1)
                            Dim newPath As String = String.Join("\", SplitPaths)
                            Label7.Text = (If(MainForm.OnlineManagement, Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.Windows)), MainForm.MountDir) & "\Program Files\WindowsApps\" & Label23.Text & "\" & newPath).Replace("\\", "\").Trim()
                            Exit For
                        End If
                    Next
                End If
            End If
            Label3.Text = (If(MainForm.OnlineManagement, Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.Windows)), MainForm.MountDir) & "\Program Files\WindowsApps\" & Label23.Text).Replace("\\", "\").Trim()
            Dim pkgDirs() As String = Directory.GetDirectories(If(MainForm.OnlineManagement, Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.Windows)), MainForm.MountDir) & "\Program Files\WindowsApps", Label23.Text & "*", SearchOption.TopDirectoryOnly)
            For Each folder In pkgDirs
                If Not folder.Contains("neutral") Then
                    Label5.Text = (folder & "\AppxManifest.xml").Replace("\\", "\").Trim()
                End If
            Next
            If pkgDirs.Count <= 1 And Not Label5.Text.Contains(Label23.Text) Then
                If File.Exists(pkgDirs(0).Replace("\\", "\").Trim() & "\AppxMetadata\AppxBundleManifest.xml") Then
                    Label5.Text = pkgDirs(0).Replace("\\", "\").Trim() & "\AppxMetadata\AppxBundleManifest.xml"
                ElseIf File.Exists(pkgDirs(0).Replace("\\", "\").Trim() & "\AppxManifest.xml") Then
                    Label5.Text = pkgDirs(0).Replace("\\", "\").Trim() & "\AppxManifest.xml"
                Else
                    Label5.Text = ""
                End If
            End If
            Panel4.Visible = True
            Panel7.Visible = False
        Else
            Panel4.Visible = False
            Panel7.Visible = True
        End If
    End Sub

    Private Sub PictureBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseClick
        If mainAsset <> "" And File.Exists(mainAsset) Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                MainForm.AppxResCMS.Show(sender, e.Location)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MainForm.ImgInfoSFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not ImgInfoSaveDlg.IsDisposed Then ImgInfoSaveDlg.Dispose()
            ImgInfoSaveDlg.SourceImage = MainForm.SourceImg
            ImgInfoSaveDlg.ImgMountDir = If(Not MainForm.OnlineManagement, MainForm.MountDir, "")
            ImgInfoSaveDlg.SaveTarget = MainForm.ImgInfoSFD.FileName
            ImgInfoSaveDlg.OnlineMode = MainForm.OnlineManagement
            ImgInfoSaveDlg.OfflineMode = MainForm.OfflineManagement
            ImgInfoSaveDlg.SkipQuestions = MainForm.SkipQuestions
            ImgInfoSaveDlg.AutoCompleteInfo = MainForm.AutoCompleteInfo
            ImgInfoSaveDlg.SaveTask = 5
            ImgInfoSaveDlg.ShowDialog()
        End If
    End Sub
End Class
