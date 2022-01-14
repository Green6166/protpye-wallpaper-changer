using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace protpyesharp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button2.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
             openFileDialog1.ShowDialog();
           var  filenam = openFileDialog1.FileName;
             listBox2.Items.Add(openFileDialog1.FileName);
            listBox1.Items.Add(numericUpDown1.Value);
            pictureBox1.ImageLocation = openFileDialog1.FileName;

            if (filenam is null) 
            {
                listBox2.Items.RemoveAt(-1);
                listBox1.Items.RemoveAt(-1);
                  }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.RemoveAt(-1);
            listBox1.Items.RemoveAt(-1);
        }

        private void button3_Click(object sender, EventArgs e)
        { button4.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            //setwallpaper();
        }

        private void setwallpaper()
        { int pointer = 0;
            while (button4.Enabled is true)
            {
                foreach (object item in listBox2.Items)
                {
                    pictureBox1.ImageLocation = item.ToString();
                    timer1.Start();
                    while (timer1.ToString() != listBox1.Items[pointer])
                    {

                    }
                    pointer = pointer + 1;
                    if (pointer>listBox1.Items.Count) {  button4.Enabled = false;  button1.Enabled = true;  button2.Enabled = true;  button3.Enabled = true;  }

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
