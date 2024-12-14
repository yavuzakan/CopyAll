using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace CopyAll
{
    class data
    {
        public static SQLiteConnection conn;
        public static SQLiteCommand cmd;
        public static SQLiteDataReader dr;

        public static string path = ("data.db");
        public static string cs = @"URI=file:" + path;

        public static void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE file (id INTEGER, file1 TEXT UNIQUE,  file2 TEXT, file3 TEXT , file4 TEXT ,file5 TEXT , PRIMARY KEY(id AUTOINCREMENT))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();

                     sql = "CREATE TABLE folder (id INTEGER, folder1 TEXT UNIQUE,  folder2 TEXT, folder3 TEXT , folder4 TEXT ,folder5 TEXT ,  PRIMARY KEY(id AUTOINCREMENT))";
                    command = new SQLiteCommand(sql, sqlite);
                    command.ExecuteNonQuery();
                    sqlite.Close();
                }
            }
        }
        public static void FileAddSql(string file1, string file2, string file3, string file4, string file5)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);

                cmd.CommandText = "INSERT INTO file(file1,file2,file3,file4,file5) VALUES(@file1,@file2,@file3,@file4,@file5)";
                cmd.Parameters.AddWithValue("@file1", file1);
                cmd.Parameters.AddWithValue("@file2", file2);
                cmd.Parameters.AddWithValue("@file3", file3);
                cmd.Parameters.AddWithValue("@file4", file4);
                cmd.Parameters.AddWithValue("@file5", file5);

                cmd.ExecuteNonQuery();
                con.Close();
                FileAdd.sonuc = "OLUMLU";
            }
            catch (Exception e)
            {
                //   MessageBox.Show(e.Message.ToString());
            }
        }

        public static void FolderAddSql(string folder1, string folder2, string folder3, string folder4, string folder5)
        {
            try
            {
                var con = new SQLiteConnection(cs);
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO folder(folder1,folder2,folder3,folder4,folder5) VALUES(@folder1,@folder2,@folder3,@folder4,@folder5)";
                cmd.Parameters.AddWithValue("@folder1", folder1);
                cmd.Parameters.AddWithValue("@folder2", folder2);
                cmd.Parameters.AddWithValue("@folder3", folder3);
                cmd.Parameters.AddWithValue("@folder4", folder4);
                cmd.Parameters.AddWithValue("@folder5", folder5);
                cmd.ExecuteNonQuery();
                con.Close();

                FolderAdd.sonuc = "OLUMLU";
            }
            catch (Exception e)
            {
                //   MessageBox.Show(e.Message.ToString());
            }
        }




    }
}
