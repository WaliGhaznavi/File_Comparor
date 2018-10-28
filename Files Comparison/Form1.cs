using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Files_Comparison
{
    public partial class Form1 : Form
    {
        private string inputDirectory;
        private string outputDirectory;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    inputDirectory = fbd.SelectedPath;
                    label1.Text = inputDirectory;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    outputDirectory = fbd.SelectedPath;
                    label2.Text = outputDirectory;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] SourceFiles = Directory.GetFiles(inputDirectory);
            string[] ComparingFiles = Directory.GetFiles(outputDirectory);

            List<string> _souceFiles = new List<string>();
            List<string> _ComparingFiles = new List<string>();


            foreach (string file in SourceFiles)
            {
                string[] spl = file.Split('\\');
                string xspl = spl[spl.Length - 1];
                string[] ext = xspl.Split('.');
                string xfile = ext[0];
                for (int x = 1; x <= ext.Length - 2; x++)
                {
                    xfile = xfile+"."+ ext[x];
                }
                _souceFiles.Add(xfile);
            }

            foreach (string file in ComparingFiles)
            {
                string[] spl = file.Split('\\');
                string xspl = spl[spl.Length - 1];
                string[] ext = xspl.Split('.');
                string xfile = ext[0];
                for (int x = 1; x <= ext.Length - 2; x++)
                {
                    xfile = xfile + "." + ext[x];
                }
                _ComparingFiles.Add(xfile);
            }
            textBox1.Text = "";
            foreach (string file in _ComparingFiles)
            {
                if (!_souceFiles.Contains(file))
                {
                    textBox1.AppendText(file + Environment.NewLine);
                }
            }
        }
    }
}
