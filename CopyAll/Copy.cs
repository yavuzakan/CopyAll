using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CopyAll
{
    class Copy
    {
        public static void FileCopy(string file1, string file2, string file3)
        {
            string q = "";

            try
            {
                String komut = "robocopy \"" + file1 + "\" \"" + file2 + "\" \"" + file3 + "\"";
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C " + komut;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
                while (!process.HasExited)
                {
                    q += process.StandardOutput.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                q += "error";
            }
        }

        public static void FolderCopy(string folder1, string folder2)
        {
            string q = "";

            try
            {
                String komut = "robocopy \"" + folder1 + "\" \"" + folder2 + "\"  /e /xc /xn /xo";
                //textBox1.Text = komut;
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C " + komut;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
                while (!process.HasExited)
                {
                    q += process.StandardOutput.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                q += "error";
            }

        }
    }
}
