Imports System.ComponentModel

Public Class Form3
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Location = New Point(0, 0)


        Dim homepath = Environment.GetEnvironmentVariable("HOMEPATH")
        Dim i = 1
        For Each file In My.Computer.FileSystem.GetFiles(My.Computer.FileSystem.SpecialDirectories.Desktop)

            MsgBox(file)
            Dim picbox As New PictureBox
            Dim v = picbox.Name = (i.ToString)
            picbox.Width = 45
            picbox.Top = 25
            picbox.Left = i
            picbox.SizeMode = PictureBoxSizeMode.StretchImage
            picbox.BorderStyle = BorderStyle.FixedSingle
            i = i + 15
        Next

    End Sub

    Private Sub Form3_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form2.Close()
    End Sub


    Public Sub ExtractIcon_1()

        Dim dInfo As New System.IO.DirectoryInfo("c:\")

        Dim lvItem As ListViewItem

        ListView2.BeginUpdate()

        ListView2.Items.Clear()

        Dim CurrFile As System.IO.FileInfo

        For Each CurrFile In dInfo.GetFiles()

            Dim iFileIcon As Icon = SystemIcons.WinLogo

            lvItem = New ListViewItem(CurrFile.Name, 1)

            If Not (ImageList2.Images.ContainsKey(CurrFile.Extension)) Then

                iFileIcon = System.Drawing.Icon.ExtractAssociatedIcon _
                   (CurrFile.FullName)

                ImageList2.Images.Add(CurrFile.Extension, iFileIcon)

            End If

            lvItem.ImageKey = CurrFile.Extension
                ListView2.Items.Add(

        Next CurrFile

        ListView2.EndUpdate()

    End Sub
End Class