// Fetch the Progman window
IntPtr progman = W32.FindWindow("Progman", null);

IntPtr result = IntPtr.Zero;

// Send 0x052C to Progman. This message directs Progman to spawn a 
// WorkerW behind the desktop icons. If it is already there, nothing 
// happens.
W32.SendMessageTimeout(progman, 
                       0x052C, 
                       new IntPtr(0), 
                       IntPtr.Zero, 
                       W32.SendMessageTimeoutFlags.SMTO_NORMAL, 
                       1000, 
                       out result);



// Spy++ output
// .....
// 0x00010190 "" WorkerW
//   ...
//   0x000100EE "" SHELLDLL_DefView
//     0x000100F0 "FolderView" SysListView32
// 0x00100B8A "" WorkerW       <-- This is the WorkerW instance we are after!
// 0x000100EC "Program Manager" Progman

IntPtr workerw = IntPtr.Zero;

// We enumerate all Windows, until we find one, that has the SHELLDLL_DefView 
// as a child. 
// If we found that window, we take its next sibling and assign it to workerw.
W32.EnumWindows(new W32.EnumWindowsProc((tophandle, topparamhandle) =>
{
    IntPtr p = W32.FindWindowEx(tophandle, 
                                IntPtr.Zero, 
                                "SHELLDLL_DefView", 
                                IntPtr.Zero);

    if (p != IntPtr.Zero)
    {
        // Gets the WorkerW Window after the current one.
        workerw = W32.FindWindowEx(IntPtr.Zero, 
                                   tophandle, 
                                   "WorkerW", 
                                   IntPtr.Zero);
    }

    return true;
}), IntPtr.Zero);

// Get the Device Context of the WorkerW
IntPtr dc = W32.GetDCEx(workerw, IntPtr.Zero, (W32.DeviceContextValues)0x403);
if (dc != IntPtr.Zero)
{
    // Create a Graphics instance from the Device Context
    using (Graphics g = Graphics.FromHdc(dc))
    {

        // Use the Graphics instance to draw a white rectangle in the upper 
        // left corner. In case you have more than one monitor think of the 
        // drawing area as a rectangle that spans across all monitors, and 
        // the 0,0 coordinate being in the upper left corner.
        g.FillRectangle(new SolidBrush(Color.White), 0, 0, 500, 500);

    }
    // make sure to release the device context after use.
    W32.ReleaseDC(workerw, dc);
}

Form form = new Form();
form.Text = "Test Window";

form.Load += new EventHandler((s, e) =>
{
    // Move the form right next to the in demo 1 drawn rectangle
    form.Width = 500;
    form.Height = 500;
    form.Left = 500;
    form.Top = 0;

    // Add a randomly moving button to the form
    Button button = new Button() { Text = "Catch Me" };
    form.Controls.Add(button);
    Random rnd = new Random();
    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    timer.Interval = 100;
    timer.Tick += new EventHandler((sender, eventArgs) =>
    {
        button.Left = rnd.Next(0, form.Width - button.Width);
        button.Top = rnd.Next(0, form.Height - button.Height);
    });
    timer.Start();

    // This line makes the form a child of the WorkerW window, 
    // thus putting it behind the desktop icons and out of reach 
    // for any user input. The form will just be rendered, no 
    // keyboard or mouse input will reach it. You would have to use 
    // WH_KEYBOARD_LL and WH_MOUSE_LL hooks to capture mouse and 
    // keyboard input and redirect it to the windows form manually, 
    // but that's another story, to be told at a later time.
    W32.SetParent(form.Handle, workerw);
});

// Start the Application Loop for the Form.
Application.Run(form);


W32.SendMessageTimeout(W32.FindWindow("Progman", null), 
                       0x052C, 
                       new IntPtr(0), 
                       IntPtr.Zero, 
                       W32.SendMessageTimeoutFlags.SMTO_NORMAL, 
                       1000, 
                       out result);