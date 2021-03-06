using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAPNUOCTANHOA.Forms.GNKDT{
    public partial class Progress : Form
    {
        MyProgressBar progressBar;
        Random random = new Random();
        public string text;
        public int itv = 200;
        public Progress()
        {
            InitializeComponent();
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            lbMess.Text = text;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.BackColor = Color.White;
            timer1.Interval = itv;            
            this.Show();
            progressBar = new MyProgressBar(pictureBox1, Color.FromArgb(0, 255, 0), Color.White, Color.Black);            
            progressBar.Draw();
            progressBar.Reset();
            progressBar.Draw();
            timer1.Start(); 
        }
        public void resest()
        {
            progressBar.Reset();
        }                
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] strings = new string[] { "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "98%" };
            Color[] colors = new Color[] { Color.Gray, Color.Gray };
            
            progressBar.Update(1);          

            if (progressBar.Percent < 10)
            {
                progressBar.ForeColor = colors[0];
                progressBar.Text = strings[0];
            }
            else if (progressBar.Percent < 20)
            {
                progressBar.ForeColor = colors[0];
                progressBar.Text = strings[1];
            }
            else if (progressBar.Percent < 30)
            {
                progressBar.ForeColor = colors[0];
                progressBar.Text = strings[2];
            }
            else if (progressBar.Percent < 40)
            {
                progressBar.ForeColor = colors[0];
                progressBar.Text = strings[3];
            }
            else if (progressBar.Percent < 50)
            {
                progressBar.ForeColor = colors[1];
                progressBar.Text = strings[4];
            }
            else if (progressBar.Percent < 60)
            {
                progressBar.ForeColor = colors[1];
                progressBar.Text = strings[5];
            }
            else if (progressBar.Percent < 70)
            {
                progressBar.ForeColor = colors[1];
                progressBar.Text = strings[6];
            }
            else if (progressBar.Percent < 80)
            {
                progressBar.ForeColor = colors[1];
                progressBar.Text = strings[7];
            }
            else if (progressBar.Percent < 90)
            {
                progressBar.ForeColor = colors[1];
                progressBar.Text = strings[8];
            }
            else if (progressBar.Percent < 100)
            {
                progressBar.ForeColor = colors[1];
                progressBar.Text = strings[9];
            }
            
            progressBar.Draw();
            if (progressBar.Finished)
            {
                progressBar.Reset();                
                progressBar.Draw();                
            }
        }       
        
    }    
}