using M4vmHub;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using WeAreDevs_API;

namespace M4vmHub
{
    public partial class Form1 : Form
    {
        readonly ExploitAPI api = new ExploitAPI();

        public Form1()
        {
            InitializeComponent();
        }
        Point lastPoint;
        
        private void BtnInject_Click(object sender, EventArgs e)
        {
            api.LaunchExploit();
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            string script = inputScript1.Text;
            api.SendLuaScript(script);
        }

        private void CheckInjected()
        {
            if (api.isAPIAttached())
            {
                txtIsInjected.Text = "Is Injected: true";
            }
            else
            {
                txtIsInjected.Text = "Is Injected: false";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckInjected();
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void InjectedChecker_Tick(object sender, EventArgs e)
        {
            CheckInjected();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void inputScript_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputScript1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputScript1.Text = String.Empty;
            inputScript1.Clear();
            inputScript1.Text = "";
        }

        private void txtIsInjected_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputScript1.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                inputScript1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Process robloxProcess in Process.GetProcessesByName("RobloxPlayerBeta"))
                robloxProcess.Kill();
        }

        private void inputScript1_Load(object sender, EventArgs e)
        {

        }
    }
}