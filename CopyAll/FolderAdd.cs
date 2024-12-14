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
    public partial class FolderAdd : Form
    {
        public static string sonuc = "Hata";
        public FolderAdd()
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
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                    try 
                    {
                        string a1 = textBox1.Text;
                        textBox3.Text = (Path.GetDirectoryName(fbd.SelectedPath));
                        string a2 = textBox3.Text;
                        textBox4.Text = a1.Replace(a2, "");
                    }
                    catch (Exception ex)
                    {
                        textBox4.Text = "";
                    }
                
            }
        }

        private void textBox2_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = fbd.SelectedPath + textBox4.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder1 = textBox1.Text;
            string folder2 = textBox2.Text;
            string folder3 = textBox3.Text;
            string folder4 = textBox4.Text;
            string folder5 = DateTime.Now.ToString("dd/MM/yyy HH:mm:ss");
            data.FolderAddSql(folder1, folder2, folder3, folder4, folder5);

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            kont();
        }
    }
}
