﻿Imports Microsoft.Win32
Public Class MigrationForm

    Dim msg As String

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Threading.Thread.Sleep(2000)
        Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
            Case "ENU", "ENG"
                msg = "Loading old settings file..."
            Case "ESN"
                msg = "Cargando archivo antiguo de configuración..."
            Case "FRA"
                msg = "Chargement d'un ancien fichier de paramètres en cours..."
        End Select
        BackgroundWorker1.ReportProgress(33.3)
        MainForm.LoadDTSettings(1)
        Threading.Thread.Sleep(250)
        Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
            Case "ENU", "ENG"
                msg = "Saving new settings file..."
            Case "ESN"
                msg = "Guardando archivo nuevo de configuración..."
            Case "FRA"
                msg = "Sauvegarder le fichier des nouveaux paramètres en cours..."
        End Select
        BackgroundWorker1.ReportProgress(66.6)
        MainForm.SaveDTSettings()
        Threading.Thread.Sleep(250)
        Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
            Case "ENU", "ENG"
                msg = "Done"
            Case "ESN"
                msg = "Terminado"
            Case "FRA"
                msg = "Terminé"
        End Select
        BackgroundWorker1.ReportProgress(100)
        Threading.Thread.Sleep(1000)
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Style = ProgressBarStyle.Blocks
        Label2.Text = msg
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub MigrationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim ColorModeRk As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Themes\Personalize")
            Select Case ColorModeRk.GetValue("AppsUseLightTheme").ToString()
                Case "0"
                    BackColor = Color.FromArgb(31, 31, 31)
                    ForeColor = Color.White
                Case "1"
                    BackColor = Color.FromArgb(238, 238, 242)
                    ForeColor = Color.Black
            End Select
            ColorModeRk.Close()
        Catch ex As Exception
            ' Continue
        End Try
        Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
            Case "ENU", "ENG"
                Label1.Text = "Please wait while DISMTools migrates your old settings file to work on this version. This may take some time."
                Label2.Text = "Please wait..."
            Case "ESN"
                Label1.Text = "Espere mientras DISMTools migra su archivo antiguo de configuración para que sea compatible con esta versión. Esto puede llevar un tiempo."
                Label2.Text = "Espere..."
            Case "FRA"
                Label1.Text = "Veuillez patienter pendant que DISMTools migre votre ancien fichier de paramètres pour qu'il fonctionne avec cette version. Cela peut prendre un certain temps."
                Label2.Text = "Veuillez patienter..."
        End Select
        Refresh()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Close()
    End Sub
End Class