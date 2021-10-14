using PrimeWorkShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeWorkShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long value = long.Parse(numericUpDown1.Text);
            int numberOfThreads = Int32.Parse(numericUpDown2.Text);
            MyTask t = new MyTask(numberOfThreads, value);

            t.ExecuteThreads();

            for (int i = 0; i < numberOfThreads; i++)
            {
                textBox2.AppendText("Thread N° " + (i + 1) + ": " + t.GetMessages(i));
                textBox2.AppendText(Environment.NewLine);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            textBox2.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
