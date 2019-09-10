using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAndAwaitDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CountCharacters()
        {
            int count = 0;
            
            using (StreamReader reader = new StreamReader(@"C:\Users\ankadam\source\repos\AsyncAndAwaitDemo\log.log"))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(3000);
            }
            return count;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();

            lblCount.Text = "File is Processing. please wait.";
            int count = await task;
            lblCount.Text = count.ToString() + " Characters in file.";
        }
    }
}
