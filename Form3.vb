Imports System.ComponentModel
Imports System.Drawing
Public Class Form3
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click


    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Location = New Point(0, 0)


        Dim homepath = Environment.GetEnvironmentVariable("HOMEPATH")
        Dim i = 1
        For Each file In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Desktop)

            ' MsgBox(file)
            Dim picbox As New PictureBox
            Dim labl As New Label

            picbox.Width = 20
            picbox.Height = 20
            picbox.Top = i + 10
            picbox.Left = i
            picbox.SizeMode = PictureBoxSizeMode.StretchImage
            picbox.BorderStyle = BorderStyle.FixedSingle
            Dim filelocation = file.ToString
            picbox.Image = Ico(filelocation)


            picbox.BackgroundImage = Form2.PictureBox2.Image

            i = i + 15
            picbox.BringToFront()
        Next
        Dim zero = 0

    End Sub

    Private Sub Form3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form2.Close()
    End Sub

    Public Function Ico(file As String)
        Dim filePath As String = file
        Dim TheIcon As Icon = IconFromFilePath(filePath)

        If TheIcon IsNot Nothing Then
            ''#Save it to disk, or do whatever you want with it.

        End If
        Return TheIcon.ToBitmap
    End Function


    Public Function IconFromFilePath(filePath As String) As Icon
            Dim result As Icon = Nothing
            Try
                result = Icon.ExtractAssociatedIcon(filePath)
            Catch ''# swallow and return nothing. You could supply a default Icon here as well
            End Try
            Return result


    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Interval = 500
        For Each pb As PictureBox In Me.Controls.OfType(Of PictureBox)()

            pb.BringToFront()
        Next
        Timer1.Start()
    End Sub
End Class