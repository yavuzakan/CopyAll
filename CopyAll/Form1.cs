using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CopyAll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "Copy";
            data.Create_db();
            this.Text = "Copy All";
            this.Icon = new Icon(Path.GetDirectoryName(Application.ExecutablePath) + "\\yca.ico");

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileAdd f = new FileAdd();
            f.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderAdd f = new FolderAdd();
            f.Show();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileList f = new FileList();
            f.Show();
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderList f = new FolderList();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            run1();
           
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            string stm = "select * FROM file";
            var con = new SQLiteConnection(data.cs);
            SQLiteDataReader dr;
            con.Open();
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();
            int i = 1;
            while (dr.Read())
            {
                Copy.FileCopy(dr.GetValue(3).ToString(), dr.GetValue(2).ToString(), dr.GetValue(4).ToString());

                i++;
                System.Threading.Thread.Sleep(1);
                //worker.ReportProgress(1);
            }
            con.Close();

            stm = "select * FROM folder";
            con.Open();
            cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Copy.FolderCopy(dr.GetValue(1).ToString(), dr.GetValue(2).ToString());
             }
            con.Close();



        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            try
            {
              
            }
            catch
            {
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Text = "Copy";
        }
        public void run1()
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
                button1.Text = "Stop";
            }
            else
            {
                backgroundWorker1.CancelAsync();
                button1.Text = "Copy";
            }
        }
        public void file1()
        {


        }
    }
}
