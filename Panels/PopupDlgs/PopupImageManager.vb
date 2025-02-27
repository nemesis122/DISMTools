﻿Imports System.IO

Public Class PopupImageManager

    Public selectedMntDir As String
    Private Sub PopupImageManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        Text = "Pick image"
                        Button1.Text = "OK"
                        Button2.Text = "Cancel"
                        Label1.Text = "Pick an image from the list below:"
                        ListView1.Columns(0).Text = "Image file"
                        ListView1.Columns(1).Text = "Index"
                        ListView1.Columns(2).Text = "Mount directory"
                        ListView1.Columns(3).Text = "Status"
                        ListView1.Columns(4).Text = "Read/write permissions?"
                        ListView1.Columns(5).Text = "Version"
                    Case "ESN"
                        Text = "Escoger imagen"
                        Button1.Text = "Aceptar"
                        Button2.Text = "Cancelar"
                        Label1.Text = "Escoja una imagen de la lista de abajo:"
                        ListView1.Columns(0).Text = "Archivo de imagen"
                        ListView1.Columns(1).Text = "Índice"
                        ListView1.Columns(2).Text = "Directorio de montaje"
                        ListView1.Columns(3).Text = "Estado"
                        ListView1.Columns(4).Text = "¿Permisos de lectura y escritura?"
                        ListView1.Columns(5).Text = "Versión"
                    Case "FRA"
                        Text = "Choisir l'image"
                        Button1.Text = "OK"
                        Button2.Text = "Annuler"
                        Label1.Text = "Choisissez une image dans la liste ci-dessous :"
                        ListView1.Columns(0).Text = "Fichier de l'image"
                        ListView1.Columns(1).Text = "Index"
                        ListView1.Columns(2).Text = "Répertoire de montage"
                        ListView1.Columns(3).Text = "État"
                        ListView1.Columns(4).Text = "Droits de lecture/écriture ?"
                        ListView1.Columns(5).Text = "Version"
                End Select
            Case 1
                Text = "Pick image"
                Button1.Text = "OK"
                Button2.Text = "Cancel"
                Label1.Text = "Pick an image from the list below:"
                ListView1.Columns(0).Text = "Image file"
                ListView1.Columns(1).Text = "Index"
                ListView1.Columns(2).Text = "Mount directory"
                ListView1.Columns(3).Text = "Status"
                ListView1.Columns(4).Text = "Read/write permissions?"
                ListView1.Columns(5).Text = "Version"
            Case 2
                Text = "Escoger imagen"
                Button1.Text = "Aceptar"
                Button2.Text = "Cancelar"
                Label1.Text = "Escoja una imagen de la lista de abajo:"
                ListView1.Columns(0).Text = "Archivo de imagen"
                ListView1.Columns(1).Text = "Índice"
                ListView1.Columns(2).Text = "Directorio de montaje"
                ListView1.Columns(3).Text = "Estado"
                ListView1.Columns(4).Text = "¿Permisos de lectura y escritura?"
                ListView1.Columns(5).Text = "Versión"
            Case 3
                Text = "Choisir l'image"
                Button1.Text = "OK"
                Button2.Text = "Annuler"
                Label1.Text = "Choisissez une image dans la liste ci-dessous :"
                ListView1.Columns(0).Text = "Fichier de l'image"
                ListView1.Columns(1).Text = "Index"
                ListView1.Columns(2).Text = "Répertoire de montage"
                ListView1.Columns(3).Text = "État"
                ListView1.Columns(4).Text = "Droits de lecture/écriture ?"
                ListView1.Columns(5).Text = "Version"
        End Select
        If MainForm.BackColor = Color.FromArgb(48, 48, 48) Then
            BackColor = Color.FromArgb(31, 31, 31)
            ForeColor = Color.White
            ListView1.BackColor = Color.FromArgb(31, 31, 31)
        ElseIf MainForm.BackColor = Color.FromArgb(239, 239, 242) Then
            BackColor = Color.FromArgb(238, 238, 242)
            ForeColor = Color.Black
            ListView1.BackColor = Color.FromArgb(238, 238, 242)
        End If
        ListView1.ForeColor = ForeColor
        MountedImgMgr.Show()
        MountedImgMgr.Visible = False
        ListView1.Items.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count < 1 Then
            Select Case MainForm.Language
                Case 0
                    Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                        Case "ENU", "ENG"
                            MsgBox("Please select an image and try again.", vbOKOnly + vbInformation, Text)
                        Case "ESN"
                            MsgBox("Seleccione una imagen e inténtelo de nuevo.", vbOKOnly + vbInformation, Text)
                        Case "FRA"
                            MsgBox("Veuillez sélectionner une image et réessayer.", vbOKOnly + vbInformation, Text)
                    End Select
                Case 1
                    MsgBox("Please select an image and try again.", vbOKOnly + vbInformation, Text)
                Case 2
                    MsgBox("Seleccione una imagen e inténtelo de nuevo.", vbOKOnly + vbInformation, Text)
                Case 3
                    MsgBox("Veuillez sélectionner une image et réessayer.", vbOKOnly + vbInformation, Text)
            End Select
            Exit Sub
        End If
        selectedMntDir = ListView1.FocusedItem.SubItems(2).Text
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

    Private Sub PopupImageManager_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MountedImgMgr.Close()
    End Sub
End Class