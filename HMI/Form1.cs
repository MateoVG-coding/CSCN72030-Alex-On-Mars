using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using ComfortPanel;
using EssentialsPanel;
using PlantsPanel;
using PowerPanel;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace HMI
{
    public partial class Form1 : Form
    {
        PlantsPanel.PlantsPanel plantsPanel = new PlantsPanel.PlantsPanel();

        CancellationTokenSource cts;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private async void roundButton4_Click(object sender, EventArgs e)
        {
            double desiredTemperature = Convert.ToDouble(numericUpDownTemperaturePlants.Text);

            plantsPanel.setTemperaturePlants(plantsPanel, desiredTemperature);

            plantsPanel.createFileTemperature(plantsPanel);

            int counter = 0;

            using (StreamReader sr = new StreamReader("FileTemperature.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    label11.Text = sr.ReadLine();
                    await Task.Delay(2000);
                    counter++;
                }
            }

            return;
        }
        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }
    }

    public class RoundButton : Button
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
    }
}