﻿Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.VisualBasic.ControlChars
Imports System.Text.Encoding
Imports Microsoft.Dism

Public Class ImgApply

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not ProgressPanel.IsDisposed Then ProgressPanel.Dispose()
        If TextBox1.Text = "" Or Not File.Exists(TextBox1.Text) Then
            Select Case MainForm.Language
                Case 0
                    Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                        Case "ENU", "ENG"
                            MsgBox("The specified image file is not valid. Please specify a valid image and try again.", vbOKOnly + vbCritical, Label1.Text)
                        Case "ESN"
                            MsgBox("El archivo de imagen especificado no es válido. Especifique una imagen válida e inténtelo de nuevo.", vbOKOnly + vbCritical, Label1.Text)
                        Case "FRA"
                            MsgBox("Le fichier image spécifié n'est pas valide. Veuillez spécifier une image valide et réessayer.", vbOKOnly + vbCritical, Label1.Text)
                    End Select
                Case 1
                    MsgBox("The specified image file is not valid. Please specify a valid image and try again.", vbOKOnly + vbCritical, Label1.Text)
                Case 2
                    MsgBox("El archivo de imagen especificado no es válido. Especifique una imagen válida e inténtelo de nuevo.", vbOKOnly + vbCritical, Label1.Text)
                Case 3
                    MsgBox("Le fichier image spécifié n'est pas valide. Veuillez spécifier une image valide et réessayer.", vbOKOnly + vbCritical, Label1.Text)
            End Select
            Exit Sub
        End If
        ProgressPanel.ApplicationSourceImg = TextBox1.Text
        ProgressPanel.ApplicationIndex = ComboBox1.SelectedIndex + 1
        If RadioButton1.Checked Then
            ProgressPanel.ApplicationDestDir = TextBox2.Text
            ProgressPanel.ApplicationDestDrive = ""
        Else
            ProgressPanel.ApplicationDestDir = ""
            ProgressPanel.ApplicationDestDrive = TextBox3.Text
        End If
        If CheckBox1.Checked Then
            ProgressPanel.ApplicationCheckInt = True
        Else
            ProgressPanel.ApplicationCheckInt = False
        End If
        If CheckBox2.Checked Then
            ProgressPanel.ApplicationVerify = True
        Else
            ProgressPanel.ApplicationVerify = False
        End If
        If CheckBox3.Checked Then
            ProgressPanel.ApplicationReparsePt = True
        Else
            ProgressPanel.ApplicationReparsePt = False
        End If
        If CheckBox4.Checked Then
            ProgressPanel.ApplicationSWMPattern = Path.GetDirectoryName(TextBox1.Text) & "\" & TextBox4.Text & "*.swm"
        Else
            ProgressPanel.ApplicationSWMPattern = ""
        End If
        If CheckBox5.Checked Then
            ProgressPanel.ApplicationValidateForTD = True
        Else
            ProgressPanel.ApplicationValidateForTD = False
        End If
        If CheckBox6.Checked Then
            ProgressPanel.ApplicationUseWimBoot = True
        Else
            ProgressPanel.ApplicationUseWimBoot = False
        End If
        If CheckBox7.Checked Then
            ProgressPanel.ApplicationCompactMode = True
        Else
            ProgressPanel.ApplicationCompactMode = False
        End If
        If CheckBox8.Checked Then
            ProgressPanel.ApplicationUseExtAttr = True
        Else
            ProgressPanel.ApplicationUseExtAttr = False
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        ProgressPanel.OperationNum = 3
        Visible = False
        ProgressPanel.ShowDialog(MainForm)
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ApplicationDriveSpecifier.ShowDialog()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TextBox2.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = False
        Else
            TextBox2.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = True
        End If
    End Sub

    Private Sub ImgApply_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        Text = "Apply an image"
                        Label1.Text = Text
                        Label2.Text = "Source image file:"
                        Label3.Text = "Image index:"
                        Label4.Text = "Naming pattern:"
                        CheckBox1.Text = "Check image integrity"
                        CheckBox2.Text = "Verify"
                        CheckBox3.Text = "Use the reparse point tag fix"
                        CheckBox4.Text = "Reference SWM files"
                        CheckBox5.Text = "Validate image for Trusted Desktop"
                        CheckBox6.Text = "Append image with WIMBoot configuration"
                        CheckBox7.Text = "Apply image in compact mode"
                        CheckBox8.Text = "Apply extended attributes"
                        Button1.Text = "Browse..."
                        Button2.Text = "Browse..."
                        Button3.Text = "Specify..."
                        Button4.Text = "Use name of the image"
                        Button5.Text = "Scan pattern"
                        UseMountedImgBtn.Text = "Use mounted image"
                        OK_Button.Text = "OK"
                        Cancel_Button.Text = "Cancel"
                        RadioButton1.Text = "Destination directory:"
                        RadioButton2.Text = "Destination drive:"
                        GroupBox1.Text = "Source"
                        GroupBox2.Text = "Options"
                        GroupBox3.Text = "Destination"
                        GroupBox4.Text = "SWM file pattern"
                    Case "ESN"
                        Text = "Aplicar una imagen"
                        Label1.Text = Text
                        Label2.Text = "Imagen de origen:"
                        Label3.Text = "Índice:"
                        Label4.Text = "Nomenclatura:"
                        CheckBox1.Text = "Comprobar integridad de imagen"
                        CheckBox2.Text = "Verificar"
                        CheckBox3.Text = "Utilizar corrección de etiquetas de puntos de repetición de análisis"
                        CheckBox4.Text = "Hacer referencia a archivos SWM"
                        CheckBox5.Text = "Validar imagen de Trusted Desktop"
                        CheckBox6.Text = "Aplicar imagen con configuración WIMBoot"
                        CheckBox7.Text = "Aplicar imagen en modo compacto"
                        CheckBox8.Text = "Aplicar atributos extendidos"
                        Button1.Text = "Examinar..."
                        Button2.Text = "Examinar..."
                        Button3.Text = "Especificar"
                        Button4.Text = "Usar nombre de imagen"
                        Button5.Text = "Escanear patrón"
                        UseMountedImgBtn.Text = "Usar imagen montada"
                        OK_Button.Text = "Aceptar"
                        Cancel_Button.Text = "Cancelar"
                        RadioButton1.Text = "Directorio de destino:"
                        RadioButton2.Text = "Disco de destino:"
                        GroupBox1.Text = "Origen"
                        GroupBox2.Text = "Opciones"
                        GroupBox3.Text = "Destino"
                        GroupBox4.Text = "Patrón de archivos SWM"
                    Case "FRA"
                        Text = "Appliquer une image"
                        Label1.Text = Text
                        Label2.Text = "Fichier de l'image originale :"
                        Label3.Text = "Index de l'image:"
                        Label4.Text = "Modèle de dénomination :"
                        CheckBox1.Text = "Vérifier l'intégrité de l'image"
                        CheckBox2.Text = "Verifier"
                        CheckBox3.Text = "Utiliser la correction de la balise reparse"
                        CheckBox4.Text = "Référence aux fichiers SWM"
                        CheckBox5.Text = "Valider l'image pour Trusted Desktop"
                        CheckBox6.Text = "Ajouter une image avec la configuration WIMBoot"
                        CheckBox7.Text = "Appliquer l'image en mode compact"
                        CheckBox8.Text = "Appliquer des attributs étendus"
                        Button1.Text = "Parcourir..."
                        Button2.Text = "Parcourir..."
                        Button3.Text = "Spécifier..."
                        Button4.Text = "Utiliser le nom de l'image"
                        Button5.Text = "Scanner le modèle"
                        UseMountedImgBtn.Text = "Utiliser une image montée"
                        OK_Button.Text = "OK"
                        Cancel_Button.Text = "Annuler"
                        RadioButton1.Text = "Répertoire de destination :"
                        RadioButton2.Text = "Disque de destination :"
                        GroupBox1.Text = "Source"
                        GroupBox2.Text = "Paramètres"
                        GroupBox3.Text = "Destination"
                        GroupBox4.Text = "Modèle de fichier SWM"
                End Select
            Case 1
                Text = "Apply an image"
                Label1.Text = Text
                Label2.Text = "Source image file:"
                Label3.Text = "Image index:"
                Label4.Text = "Naming pattern:"
                CheckBox1.Text = "Check image integrity"
                CheckBox2.Text = "Verify"
                CheckBox3.Text = "Use the reparse point tag fix"
                CheckBox4.Text = "Reference SWM files"
                CheckBox5.Text = "Validate image for Trusted Desktop"
                CheckBox6.Text = "Append image with WIMBoot configuration"
                CheckBox7.Text = "Apply image in compact mode"
                CheckBox8.Text = "Apply extended attributes"
                Button1.Text = "Browse..."
                Button2.Text = "Browse..."
                Button3.Text = "Specify..."
                Button4.Text = "Use name of the image"
                Button5.Text = "Scan pattern"
                UseMountedImgBtn.Text = "Use mounted image"
                OK_Button.Text = "OK"
                Cancel_Button.Text = "Cancel"
                RadioButton1.Text = "Destination directory:"
                RadioButton2.Text = "Destination drive:"
                GroupBox1.Text = "Source"
                GroupBox2.Text = "Options"
                GroupBox3.Text = "Destination"
                GroupBox4.Text = "SWM file pattern"
            Case 2
                Text = "Aplicar una imagen"
                Label1.Text = Text
                Label2.Text = "Imagen de origen:"
                Label3.Text = "Índice:"
                Label4.Text = "Nomenclatura:"
                CheckBox1.Text = "Comprobar integridad de imagen"
                CheckBox2.Text = "Verificar"
                CheckBox3.Text = "Utilizar corrección de etiquetas de puntos de repetición de análisis"
                CheckBox4.Text = "Hacer referencia a archivos SWM"
                CheckBox5.Text = "Validar imagen de Trusted Desktop"
                CheckBox6.Text = "Aplicar imagen con configuración WIMBoot"
                CheckBox7.Text = "Aplicar imagen en modo compacto"
                CheckBox8.Text = "Aplicar atributos extendidos"
                Button1.Text = "Examinar..."
                Button2.Text = "Examinar..."
                Button3.Text = "Especificar"
                Button4.Text = "Usar nombre de imagen"
                Button5.Text = "Escanear patrón"
                UseMountedImgBtn.Text = "Usar imagen montada"
                OK_Button.Text = "Aceptar"
                Cancel_Button.Text = "Cancelar"
                RadioButton1.Text = "Directorio de destino:"
                RadioButton2.Text = "Disco de destino:"
                GroupBox1.Text = "Origen"
                GroupBox2.Text = "Opciones"
                GroupBox3.Text = "Destino"
                GroupBox4.Text = "Patrón de archivos SWM"
            Case 3
                Text = "Appliquer une image"
                Label1.Text = Text
                Label2.Text = "Fichier de l'image originale :"
                Label3.Text = "Index de l'image:"
                Label4.Text = "Modèle de dénomination :"
                CheckBox1.Text = "Vérifier l'intégrité de l'image"
                CheckBox2.Text = "Verifier"
                CheckBox3.Text = "Utiliser la correction de la balise reparse"
                CheckBox4.Text = "Référence aux fichiers SWM"
                CheckBox5.Text = "Valider l'image pour Trusted Desktop"
                CheckBox6.Text = "Ajouter une image avec la configuration WIMBoot"
                CheckBox7.Text = "Appliquer l'image en mode compact"
                CheckBox8.Text = "Appliquer des attributs étendus"
                Button1.Text = "Parcourir..."
                Button2.Text = "Parcourir..."
                Button3.Text = "Spécifier..."
                Button4.Text = "Utiliser le nom de l'image"
                Button5.Text = "Scanner le modèle"
                UseMountedImgBtn.Text = "Utiliser une image montée"
                OK_Button.Text = "OK"
                Cancel_Button.Text = "Annuler"
                RadioButton1.Text = "Répertoire de destination :"
                RadioButton2.Text = "Disque de destination :"
                GroupBox1.Text = "Source"
                GroupBox2.Text = "Paramètres"
                GroupBox3.Text = "Destination"
                GroupBox4.Text = "Modèle de fichier SWM"
        End Select
        If MainForm.BackColor = Color.FromArgb(48, 48, 48) Then
            Win10Title.BackColor = Color.FromArgb(48, 48, 48)
            BackColor = Color.FromArgb(31, 31, 31)
            ForeColor = Color.White
            TextBox1.BackColor = Color.FromArgb(31, 31, 31)
            TextBox2.BackColor = Color.FromArgb(31, 31, 31)
            TextBox3.BackColor = Color.FromArgb(31, 31, 31)
            TextBox4.BackColor = Color.FromArgb(31, 31, 31)
            GroupBox1.ForeColor = Color.White
            GroupBox2.ForeColor = Color.White
            GroupBox3.ForeColor = Color.White
            GroupBox4.ForeColor = Color.White
            ListBox1.BackColor = Color.FromArgb(31, 31, 31)
            StatusStrip1.BackColor = Color.FromArgb(31, 31, 31)
            ComboBox1.BackColor = Color.FromArgb(31, 31, 31)
        ElseIf MainForm.BackColor = Color.FromArgb(239, 239, 242) Then
            Win10Title.BackColor = Color.White
            BackColor = Color.FromArgb(238, 238, 242)
            ForeColor = Color.Black
            TextBox1.BackColor = Color.FromArgb(238, 238, 242)
            TextBox2.BackColor = Color.FromArgb(238, 238, 242)
            TextBox3.BackColor = Color.FromArgb(238, 238, 242)
            TextBox4.BackColor = Color.FromArgb(238, 238, 242)
            GroupBox1.ForeColor = Color.Black
            GroupBox2.ForeColor = Color.Black
            GroupBox3.ForeColor = Color.Black
            GroupBox4.ForeColor = Color.Black
            ComboBox1.BackColor = Color.FromArgb(238, 238, 242)
        End If
        ComboBox1.ForeColor = ForeColor
        TextBox1.ForeColor = ForeColor
        TextBox2.ForeColor = ForeColor
        TextBox3.ForeColor = ForeColor
        TextBox4.ForeColor = ForeColor
        ListBox1.ForeColor = ForeColor
        If Environment.OSVersion.Version.Major = 10 Then
            Text = ""
            Win10Title.Visible = True
        End If
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        ToolStripStatusLabel1.Text = "Please specify the naming pattern of the SWM files"
                    Case "ESN"
                        ToolStripStatusLabel1.Text = "Especifique la nomenclatura del patrón de los archivos SWM"
                    Case "FRA"
                        ToolStripStatusLabel1.Text = "Veuillez spécifier le modèle de dénomination des fichiers SWM"
                End Select
            Case 1
                ToolStripStatusLabel1.Text = "Please specify the naming pattern of the SWM files"
            Case 2
                ToolStripStatusLabel1.Text = "Especifique la nomenclatura del patrón de los archivos SWM"
            Case 3
                ToolStripStatusLabel1.Text = "Veuillez spécifier le modèle de dénomination des fichiers SWM"
        End Select
        If MainForm.SourceImg = "N/A" Or Not File.Exists(MainForm.SourceImg) Or MainForm.OnlineManagement Or MainForm.OfflineManagement Then
            UseMountedImgBtn.Enabled = False
        Else
            UseMountedImgBtn.Enabled = True
        End If
        Dim handle As IntPtr = MainForm.GetWindowHandle(Me)
        If MainForm.IsWindowsVersionOrGreater(10, 0, 18362) Then MainForm.EnableDarkTitleBar(handle, MainForm.BackColor = Color.FromArgb(48, 48, 48))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" And File.Exists(TextBox1.Text) Then GetIndexes(TextBox1.Text) Else Exit Sub
        If TextBox1.Text.EndsWith(".swm") Then
            CheckBox4.Checked = True
            Button4.PerformClick()
        End If
    End Sub

    Sub GetIndexes(ImgFile As String)
        If MainForm.MountedImageDetectorBW.IsBusy Then MainForm.MountedImageDetectorBW.CancelAsync()
        While MainForm.MountedImageDetectorBW.IsBusy
            Application.DoEvents()
            Threading.Thread.Sleep(100)
        End While
        Dim imgInfo As DismImageInfoCollection = Nothing
        ComboBox1.Items.Clear()
        Try
            DismApi.Initialize(DismLogLevel.LogErrors)
            imgInfo = DismApi.GetImageInfo(TextBox1.Text)
            For Each imageInfo In imgInfo
                ComboBox1.Items.Add(imageInfo.ImageIndex & " (" & imageInfo.ImageName & ")")
            Next
        Catch ex As Exception
            Dim msg As String = ""
            Select Case MainForm.Language
                Case 0
                    Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                        Case "ENU", "ENG"
                            msg = "Could not gather information of this image file. Reason:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                        Case "ESN"
                            msg = "No pudimos obtener información de este archivo de imagen. Razón:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                        Case "FRA"
                            msg = "Impossible de recueillir des informations sur ce fichier de l'image. Raison :" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                    End Select
                Case 1
                    msg = "Could not gather information of this image file. Reason:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                Case 2
                    msg = "No pudimos obtener información de este archivo de imagen. Razón:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                Case 3
                    msg = "Impossible de recueillir des informations sur ce fichier de l'image. Raison :" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
            End Select
            MsgBox(msg, vbOKOnly + vbCritical, Label1.Text)
        Finally
            DismApi.Shutdown()
        End Try
        If Not MainForm.MountedImageDetectorBW.IsBusy Then Call MainForm.MountedImageDetectorBW.RunWorkerAsync()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.ShowDialog()
        If DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        Else
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub UseMountedImgBtn_Click(sender As Object, e As EventArgs) Handles UseMountedImgBtn.Click
        TextBox1.Text = MainForm.SourceImg
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox4.Text = Path.GetFileNameWithoutExtension(TextBox1.Text)
        ScanSwmPattern(TextBox4.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ScanSwmPattern(TextBox4.Text)
    End Sub

    Sub ScanSwmPattern(PatternName As String)
        ListBox1.Items.Clear()
        If TextBox1.Text = "" Or PatternName = "" Then
            Select Case MainForm.Language
                Case 0
                    Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                        Case "ENU", "ENG"
                            MsgBox("Please specify a source WIM file. This will let you use the SWM files for later image application", vbOKOnly + vbCritical, "Apply an image")
                            ToolStripStatusLabel1.Text = "This naming pattern returns " & ListBox1.Items.Count & " SWM files"
                        Case "ESN"
                            MsgBox("Especifique el arhivo WIM de origen. Esto le permitirá usar los archivos SWM para la aplicación posterior de la imagen", vbOKOnly + vbCritical, "Aplicar una imagen")
                            ToolStripStatusLabel1.Text = "Esta nomenclatura de patrón devuelve " & ListBox1.Items.Count & " archivos SWM"
                        Case "FRA"
                            MsgBox("Veuillez indiquer un fichier WIM original. Cela vous permettra d'utiliser les fichiers SWM pour une application d'image ultérieure.", vbOKOnly + vbCritical, "Appliquer une image")
                            ToolStripStatusLabel1.Text = "Ce modèle de dénomination renvoie " & ListBox1.Items.Count & " fichiers SWM"
                    End Select
                Case 1
                    MsgBox("Please specify a source WIM file. This will let you use the SWM files for later image application", vbOKOnly + vbCritical, "Apply an image")
                    ToolStripStatusLabel1.Text = "This naming pattern returns " & ListBox1.Items.Count & " SWM files"
                Case 2
                    MsgBox("Especifique el arhivo WIM de origen. Esto le permitirá usar los archivos SWM para la aplicación posterior de la imagen", vbOKOnly + vbCritical, "Aplicar una imagen")
                    ToolStripStatusLabel1.Text = "Esta nomenclatura de patrón devuelve " & ListBox1.Items.Count & " archivos SWM"
                Case 3
                    MsgBox("Veuillez indiquer un fichier WIM original. Cela vous permettra d'utiliser les fichiers SWM pour une application d'image ultérieure.", vbOKOnly + vbCritical, "Appliquer une image")
                    ToolStripStatusLabel1.Text = "Ce modèle de dénomination renvoie " & ListBox1.Items.Count & " fichiers SWM"
            End Select
            Beep()
            Exit Sub
        End If
        For Each swmFile In My.Computer.FileSystem.GetFiles(Path.GetDirectoryName(TextBox1.Text), FileIO.SearchOption.SearchTopLevelOnly, "*.swm")
            If Path.GetFileNameWithoutExtension(swmFile).StartsWith(PatternName) Then
                ListBox1.Items.Add(Path.GetFileName(swmFile))
            End If
        Next
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        ToolStripStatusLabel1.Text = "This naming pattern returns " & ListBox1.Items.Count & " SWM files"
                    Case "ESN"
                        ToolStripStatusLabel1.Text = "Esta nomenclatura de patrón devuelve " & ListBox1.Items.Count & " archivos SWM"
                    Case "FRA"
                        ToolStripStatusLabel1.Text = "Ce modèle de dénomination renvoie " & ListBox1.Items.Count & " fichiers SWM"
                End Select
            Case 1
                ToolStripStatusLabel1.Text = "This naming pattern returns " & ListBox1.Items.Count & " SWM files"
            Case 2
                ToolStripStatusLabel1.Text = "Esta nomenclatura de patrón devuelve " & ListBox1.Items.Count & " archivos SWM"
            Case 3
                ToolStripStatusLabel1.Text = "Ce modèle de dénomination renvoie " & ListBox1.Items.Count & " fichiers SWM"
        End Select
        If ListBox1.Items.Count <= 0 Then Beep()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        SWMFilePanel.Enabled = CheckBox4.Checked = True
    End Sub
End Class
