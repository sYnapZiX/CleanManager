Imports Microsoft.VisualBasic.ApplicationServices
Public Class HelpForm
    Private ReadOnly Language As String = Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName
    Private IsAdmin As Boolean = My.User.IsInRole(BuiltInRole.Administrator)
    Private Sub HelpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Language = "de" Then
            Text = "Datenträgerbereinigung X"
            DescriptionLabel.Text = "Folgende Startparameter sind verfügbar:"
            mDescriptionLabel.Text = "Minimaler Modus"
            pDescriptionLabel.Text = "Vordefiniertes Profil auswählen"
            ProfileDescriptionLabel.Text = "[2 - Gründlich, 3 - Aggressiv, 4 - Alles]"
            rDescriptionLabel.Text = "Nach Beendigung neustarten"
            sDescriptionLabel.Text = "Nach Beendigung herunterfahren"
            ExampleLabel.Text = "Beispiel: cleanmgrx.exe -m -p:2 -s"
        End If

        If IsAdmin Then
            Logo.Image = My.Resources.DriveLogo
        End If
    End Sub
End Class