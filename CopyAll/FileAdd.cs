using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CopyAll
{
    public partial class FileAdd : Form
    {
        public static string sonuc = "Hata";
        public FileAdd()
        {
            InitializeComponent();
            label1.Text = "Source";
            label2.Text = "Target";
            button1.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;

            this.Text = "Copy All";
            this.Icon = new Icon(Path.GetDirectoryName(Application.ExecutablePath) + "\\yca.ico");
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = fbd.FileName;
                textBox3.Text = Path.GetDirectoryName(fbd.FileName);
                textBox4.Text = Path.GetFileName(fbd.FileName);
            }
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string file1 = textBox1.Text;
            string file2 = textBox2.Text;
            string file3 = textBox3.Text;
            string file4 = textBox4.Text;
            string file5 = DateTime.Now.ToString("dd/MM/yyy HH:mm:ss");
            data.FileAddSql(file1, file2, file3, file4, file5);
            if (sonuc == "Hata")
            {
                MessageBox.Show("Sorun Var. Tekrar deneyin.");
            }
            else
            {
                MessageBox.Show("OK.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                this.Close();
            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            kont();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            kont();
        }
        public void kont()
        {
            string kont1 = textBox1.Text;
            string kont2 = textBox2.Text;
            if (kont1.Length > 2 && kont2.Length > 2)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

    }
}
