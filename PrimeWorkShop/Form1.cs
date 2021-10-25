using PrimeWorkShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            //9223372036854775783
            Stopwatch stopWatch = new Stopwatch();
            Stopwatch stopWatchNT = new Stopwatch();
            stopWatch.Start();
            long value = long.Parse(numericUpDown1.Text);
            string message = "The number --> " + value + " <-- it\'s ";
            MyTask t = new MyTask(value);
           
            t.Start();

            stopWatch.Stop();

            message += !t.IsPrime() ? "Prime" : "Not Prime";
            
            label4.Text = message;

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            label5.Text = elapsedTime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            
            long value = long.Parse(numericUpDown1.Text);
            string message = "The number --> " + value + " <-- it\'s ";
            MyTaskNoThread tNt = new MyTaskNoThread(value);

            stopWatch.Start();

            tNt.IsPrime();

            stopWatch.Stop();

            message += tNt.GetIsPrime() ? "Prime" : "Not Prime";

            label4.Text = message;

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            label5.Text = elapsedTime;
        }
    }
}
