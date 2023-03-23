using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlertStatus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            DialogResult dlg_res = new DialogResult();
            string msg = string.Empty;

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 2)
            {
                dlg_res = MessageBox.Show(args[1], "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                msg = args[1];
            }
            else if (args.Length == 1)
            {
                dlg_res = MessageBox.Show(args[0], "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                msg = args[0];
            }

            if (dlg_res == DialogResult.OK)
            {

            }
            else if(dlg_res == DialogResult.Cancel)
            {
                if (msg.Contains(": EXITED"))
                {
                    msg = msg.Substring(0, msg.IndexOf(": EXITED"));
                    Process.Start(msg);
                }
                else if(msg.Contains(": STARTED"))
                {
                    msg = msg.Substring(0, msg.IndexOf(": STARTED"));
                    foreach(Process proc in Process.GetProcesses())
                    {
                        try
                        {
                            if (proc.MainModule.FileName == msg.Trim())
                            {
                                proc.Kill();
                                break;
                            }
                        }
                        catch (Exception exception)
                        {

                        }
                    }
                }
            }
        }
    }
}
