
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
    ReadOnly maindirec = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData




    Friend Sub SetWallpaper(ByRef img As Image)









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

        Dim lines() As String = IO.File.ReadAllLines(maindirec + "\PROTPYE\timingslist.txt")
        Listbox2.Items.AddRange(lines)
        NumericUpDown1.Value = Listbox2.Items.Item(Listbox2.Items.Count - 1)
        Dim linespics() As String = IO.File.ReadAllLines(maindirec + "\PROTPYE\picturelist.txt")
        PictureList.Items.AddRange(linespics)

        Me.Show()
        Timer1.Start()

















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
        Try
            PictureList.Items.RemoveAt(PictureList.Items.Count - 1)
            Listbox2.Items.RemoveAt(Listbox2.Items.Count - 1)
        Catch eex As Exception
            MsgBox(eex.Message & "Nothing Is there To delete. please add something now")
        End Try
    End Sub

    Public sleepersim = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        pauser = 1

        Dim Pic As Integer
        Pic = 0
        Timer1.Interval = 1
        Dim sleepersimv2 = 0
        Button3.Enabled = True
        Timer1.Start()
        Form3.Timer1.Start()


    End Sub











    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Dim SW As IO.StreamWriter = IO.File.CreateText(maindirec + "\PROTPYE\timingslist.txt")
        For Each item In Listbox2.Items
            SW.WriteLine(item.ToString)
        Next
        SW.Close()

        Dim SWpics As IO.StreamWriter = IO.File.CreateText(maindirec + "\PROTPYE\picturelist.txt")
        For Each item In PictureList.Items
            SWpics.WriteLine(item.ToString)
        Next
        SWpics.Close()

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
        Try
            Dim SW As IO.StreamWriter = IO.File.CreateText(maindirec + "\PROTPYE\timingslist.txt")
            For Each item In Listbox2.Items
                SW.WriteLine(item.ToString)
            Next
            SW.Close()

            Dim SWpics As IO.StreamWriter = IO.File.CreateText(maindirec + "\PROTPYE\picturelist.txt")
            For Each item In PictureList.Items
                SWpics.WriteLine(item.ToString)
            Next
            SWpics.Close()
        Catch
            My.Computer.FileSystem.CreateDirectory(maindirec + "\PROTPYE\")
            Dim SW As IO.StreamWriter = IO.File.CreateText(maindirec + "\PROTPYE\timingslist.txt")
            For Each item In Listbox2.Items
                SW.WriteLine(item.ToString)
            Next
            SW.Close()

            Dim SWpics As IO.StreamWriter = IO.File.CreateText(maindirec + "\PROTPYE\picturelist.txt")
            For Each item In PictureList.Items
                SWpics.WriteLine(item.ToString)
            Next
            SWpics.Close()
        End Try


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Stop()

            If sleepersim + 1 > Listbox2.Items.Count - 1 Then
                sleepersim = 0

            End If

            sleepersim = sleepersim + 1
            Timer1.Interval = Listbox2.Items.Item(sleepersim) * 1000
            NumericUpDown1.Value = Listbox2.Items.Item(sleepersim)
            Form3.PictureBox1.ImageLocation = PictureList.Items.Item(sleepersim)
            Me.PictureBox1.ImageLocation = Form3.PictureBox1.ImageLocation
            Me.PictureBox1.Refresh()

            Timer1.Start()
            Timer2.Start()
            Form3.PictureBox1.Refresh()
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message & ": are there any photos loaded?  tick.error")
        End Try

    End Sub
    Private Sub Button4_MouseClick(sender As Object, e As MouseEventArgs) Handles Button4.MouseClick
        Timer1.Stop()
        Timer2.Stop()
        NumericUpDown1.Value = Listbox2.Items.Item(Listbox2.Items.Count - 1)
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        NumericUpDown1.Value = NumericUpDown1.Value - 0.5
        Timer2.Interval = 500
        Timer2.Start()
    End Sub
End Class