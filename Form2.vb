
Imports Microsoft.Win32
Imports System.IO.Directory
Imports IWshRuntimeLibrary
Imports System.Threading
Imports System.Timers
Imports System.Xml

Public Class Form2
    Dim timer1completed As Boolean
    Dim ComboBox1 = PictureList
    Dim pauser = 1
    Dim item

    Private Const SPI_SETDESKWALLPAPER As Integer = &H14

    Private Const SPIF_UPDATEINIFILE As Integer = &H1

    Private Const SPIF_SENDWININICHANGE As Integer = &H2

    Private Declare Auto Function SystemParametersInfo Lib "user32.dll" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer

    Const WallpaperFile As String = "c:\wallpaper.bmp"




    Friend Sub SetWallpaper(ByRef img As Image)

        Dim imageLocation As String




        imageLocation = TextBox1.Text


        Try
            Form3.Show()
            Dim image1 = Form3.PictureBox1.Image
            ''image1.Save(imageLocation, Imaging.ImageFormat.Bmp) 
            ''SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imageLocation, SPIF_UPDATEINIFILE Or SPIF_SENDWININICHANGE)



        Catch Ex As Exception
            MsgBox("There was an error setting the wallpaper: " & Ex.Message)
        End Try
    End Sub




    Private Const V As String = "D:\Users\"
    Dim un = (Environment.UserName.ToString)

    Private Const APP_NAME As String = "SaveRestoreListBox"
    Private Const SECTION_NAME As String = "Items"



    Private Sub Form2_Load(ByVal sender As System.Object, ByVal_e As System.EventArgs) Handles MyBase.Load
        Form3.Show()

        Dim SW As IO.StreamWriter = IO.File.CreateText("C:\timingslist.txt")
        For Each item In Listbox2.Items
            SW.WriteLine(item.ToString)
        Next
        SW.Close()

        Dim SWpics As IO.StreamWriter = IO.File.CreateText("C:\picturelist.txt")
        For Each item In PictureList.Items
            SWpics.WriteLine(item.ToString)
        Next
        SWpics.Close()
        TextBox1.Text = My.Computer.FileSystem.CombinePath(My.Computer.FileSystem.SpecialDirectories.MyPictures, WallpaperFile)



        Me.Show()

















    End Sub







    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        Dim p = OpenFileDialog1

        OpenFileDialog1.ShowDialog()
        Dim Gu = OpenFileDialog1
        Dim guuu = OpenFileDialog1.ToString()



        Dim kl = OpenFileDialog1.FileName

        PictureList.Items.Add(kl)

        Dim NUD = NumericUpDown1.Value


        Listbox2.Items.Add(NUD)


        PictureBox1.ImageLocation = OpenFileDialog1.FileName

        If kl Is Nothing Then
            PictureList.Items.RemoveAt(-1)
            Listbox2.Items.RemoveAt(-1)

        End If




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        PictureList.Items.RemoveAt(PictureList.Items.Count - 1)
        Listbox2.Items.RemoveAt(Listbox2.Items.Count - 1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        pauser = 1
        Form1.Show()
        Dim Pic As Integer
        Pic = 0
        Dim sleepersim = 0
        Dim sleepersimv2 = 0
        Button3.Enabled = True
        Do
            For Each item In PictureList.Items
                Try
                    If pauser = 0 Then
                        Exit Do

                    End If
                    Me.PictureBox1.ImageLocation = item.ToString
                    PictureBox1.Refresh()
                    SetWallpaper(PictureBox1.Image)




                    Dim first As String

                    first = (Listbox2.Items(sleepersim) * 1000)


                    'sleepersim = TimingsList.Items(item) * 1000

                    Thread.Sleep(first)





                    If sleepersim + 1 > Listbox2.Items.Count - 1 Then
                        sleepersim = 0
                        Exit For
                    End If

                    sleepersim = sleepersim + 1

                Catch ex As Exception

                    '  sleepersim = (TimingsList.Items.Item(item) * 1000)







                    MsgBox("Timer error line 200 ish " & ex.Message & ex.StackTrace & ex.HelpLink & ex.Source)



                    Close()
                End Try

            Next

        Loop



    End Sub











    Private Sub Form1_FormClosing(
        sender As Object,
        e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Properties.Clear()
        For Each item In PictureList.Items



        Next

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub timingsbox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Listbox2.SelectedIndexChanged

    End Sub



    Sub Form1_closing(sender As Object, e As EventArgs) Handles MyBase.Closing

        Dim SW As IO.StreamWriter = IO.File.CreateText("C:\timingslist.txt")
        For Each item In Listbox2.Items
            SW.WriteLine(item.ToString)
        Next
        SW.Close()

        Dim SWpics As IO.StreamWriter = IO.File.CreateText("C:\picturelist.txt")
        For Each item In PictureList.Items
            SWpics.WriteLine(item.ToString)
        Next
        SWpics.Close()

    End Sub
End Class