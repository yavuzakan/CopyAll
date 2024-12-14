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
    public partial class FolderList : Form
    {
        public FolderList()
        {
            InitializeComponent();
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            //dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Arial", 15);
            ara();
            button1.Enabled = false;
            this.Text = "Copy All";
            this.Icon = new Icon(Path.GetDirectoryName(Application.ExecutablePath) + "\\yca.ico");
        }
        public void ara()
        {
            string stm = "select * FROM folder";
            dataGridView1.Rows.Clear();
            var con = new SQLiteConnection(data.cs);
            SQLiteDataReader dr;
            con.Open();
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Insert(0, dr.GetValue(0).ToString(),  dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString(), dr.GetValue(5).ToString());
            }
            con.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = dataGridViewRow.Cells["folder1"].Value.ToString();
                textBox2.Text = dataGridViewRow.Cells["id"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox2.Text;
                var con = new SQLiteConnection(data.cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                string sql = "delete from folder where id =" + id;
                // stm = "delete from sqlite_sequence where name='data'";
                cmd.CommandText = sql;
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ok.");
                ara();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception exp)
            {


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string kont1 = textBox1.Text;
            if (kont1.Length > 2)
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
