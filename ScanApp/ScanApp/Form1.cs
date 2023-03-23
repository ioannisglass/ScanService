using Newtonsoft.Json;
using ScanApp.BaseModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanApp
{
    public partial class Form1 : Form
    {
        private string varScanApp = "SCAN_HOME";
        public string strScanPath = string.Empty;

        public Form1()
        {
            InitializeComponent();

            strScanPath = System.Environment
                .GetEnvironmentVariable(varScanApp, EnvironmentVariableTarget.Machine);

            if (strScanPath == null || strScanPath != AppDomain.CurrentDomain.BaseDirectory)
            {
                EnvironmentPermission permissions = new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, varScanApp);
                permissions.Demand();
                Environment.SetEnvironmentVariable(varScanApp, AppDomain.CurrentDomain.BaseDirectory,
                    EnvironmentVariableTarget.Machine);
            }

            lvProcess.Columns.Add("Application Name");
            lvProcess.Columns.Add("exe Name");
            lvProcess.Columns.Add("PATH");
            lvProcess.Columns.Add("Actions");

            ListViewExtender extender = new ListViewExtender(lvProcess);
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(3);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;

            extender.AddColumn(buttonAction);
            lvProcess.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            Microsoft.Win32.RegistryKey Key;
            Key = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey("Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache");

            ProcessExts.OutputRegKey(Key);
            if (!string.IsNullOrEmpty(Program.g_strSteamPath))
            {
                DirectoryInfo info = new DirectoryInfo(Program.g_strSteamPath);
                Program.g_strSteamPath = info.Parent.FullName;

                GetListFromFolder(Program.g_strSteamPath);  // the stream game library directory
            }
        }

        private void btnGetProList_Click(object sender, EventArgs e)
        {
            lvProcess.Items.Clear();

            btnGetProList.Enabled = false;

            Process[] processList = ProcessExts.GetRunningProcessList();
            
            ImageList lstImg = new ImageList();
            lstImg.ImageSize = new Size(16, 16);

            foreach (Process theprocess in processList)
            {
                string temp = string.Empty;
                temp = ProcessExts.GetProcessName(theprocess);
                if (temp == null)
                    continue;

                ListViewItem item = new ListViewItem(temp);

                temp = ProcessExts.GetExeName(theprocess);
                if (temp == null)
                    continue;
                item.SubItems.Add(temp);

                temp = ProcessExts.GetProcessPath(theprocess);
                if (temp == null)
                    continue;
                item.SubItems.Add(temp);

                item.SubItems.Add("Delete");
                                
                lstImg.Images.Add(ProcessExts.GetProcessIcon(theprocess));

                lvProcess.Items.Add(item);
            }

            lvProcess.SmallImageList = lstImg;
            for(int idx = 0; idx < lvProcess.Items.Count; idx++)
            {
                lvProcess.Items[idx].ImageIndex = idx;
            }

            lvProcess.Columns[0].Width = lvProcess.Width / 5;
            lvProcess.Columns[1].Width = lvProcess.Width / 5;
            lvProcess.Columns[2].Width = lvProcess.Width / 5 * 3 - 45;
            lvProcess.Columns[3].Width = 40;

            btnGetProList.Enabled = true;
        }
        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e)
        {
            //MessageBox.Show(this, @"you clicked " + e.Item.SubItems[0].Text);
            lvProcess.Items.Remove(e.Item);
        }

        private void lvProcess_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvProcess.Sorting == SortOrder.Ascending)
                lvProcess.Sorting = SortOrder.Descending;
            else
                lvProcess.Sorting = SortOrder.Ascending;
            lvProcess.Sort();
        }

        #region editable listview
        ListViewItem.ListViewSubItem SelectedLSI;
        private void lvProcess_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo i = lvProcess.HitTest(e.X, e.Y);
            SelectedLSI = i.SubItem;
            if (SelectedLSI == null)
                return;

            int border = 0;
            switch (lvProcess.BorderStyle)
            {
                case BorderStyle.FixedSingle:
                    border = 1;
                    break;
                case BorderStyle.Fixed3D:
                    border = 2;
                    break;
            }

            int CellWidth = SelectedLSI.Bounds.Width;
            int CellHeight = SelectedLSI.Bounds.Height;
            int CellLeft = border + lvProcess.Left + i.SubItem.Bounds.Left;
            int CellTop = lvProcess.Top + i.SubItem.Bounds.Top;
            // First Column
            if (i.SubItem == i.Item.SubItems[0])
                CellWidth = lvProcess.Columns[0].Width;

            TxtEdit.Location = new Point(CellLeft, CellTop);
            TxtEdit.Size = new Size(CellWidth, CellHeight);
            TxtEdit.Visible = true;
            TxtEdit.BringToFront();
            TxtEdit.Text = i.SubItem.Text;
            TxtEdit.Select();
            TxtEdit.SelectAll();
        }
        private void lvProcess_MouseDown(object sender, MouseEventArgs e)
        {
            HideTextEditor();
        }

        ScrollEventType mLastScroll = ScrollEventType.EndScroll;
        private void lvProcess_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.Type == ScrollEventType.EndScroll)
                HideTextEditor();
            else if (mLastScroll == ScrollEventType.EndScroll)
                HideTextEditor();
            else
                HideTextEditor();
            mLastScroll = e.Type;
        }
        private void TxtEdit_Leave(object sender, EventArgs e)
        {
            HideTextEditor();
        }
        private void TxtEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                HideTextEditor();
        }
        private void HideTextEditor()
        {
            TxtEdit.Visible = false;
            if (SelectedLSI != null)
                SelectedLSI.Text = TxtEdit.Text;
            SelectedLSI = null;
            TxtEdit.Text = "";
        }
        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            txt_log.Text = "Load Config Clicked.";

            string path = "config.ini";
            if(!File.Exists(path))
            {
                MessageBox.Show("No app list file yet.");
                return;
            }

            try
            {
                /*OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open a configuration file";
                dlg.Filter = "INI files|*.ini";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)*/
                {
                    lvProcess.Items.Clear();
                    
                    List<ProcessInfo> lstConfig = JsonConvert.DeserializeObject<List<ProcessInfo>>(File.ReadAllText(path));

                    foreach(ProcessInfo theProcInfo in lstConfig)
                    {
                        ListViewItem item = new ListViewItem(theProcInfo.ProcessName);
                        item.SubItems.Add(Path.GetFileNameWithoutExtension(theProcInfo.ProcessPath));
                        item.SubItems.Add(theProcInfo.ProcessPath);
                        item.SubItems.Add("Delete");

                        lvProcess.Items.Add(item);
                    }
                    lvProcess.Columns[0].Width = lvProcess.Width / 5;
                    lvProcess.Columns[1].Width = lvProcess.Width / 5;
                    lvProcess.Columns[2].Width = lvProcess.Width / 5 * 3 - 45;
                    lvProcess.Columns[3].Width = 40;

                    MessageBox.Show($"Configuration File loaded successfully.", "Load Result");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace, true);
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            txt_log.Text = "Save Config Clicked.";

            List<ProcessInfo> lstConfig = new List<ProcessInfo>();

            if (lvProcess.Items.Count == 0)
                MessageBox.Show("No process to save.");

            foreach(ListViewItem item in lvProcess.Items)
            {
                ProcessInfo procItem = new ProcessInfo();

                procItem.ProcessName = item.SubItems[0].Text;
                procItem.ProcessPath = item.SubItems[2].Text;
                
                lstConfig.Add(procItem);
            }

            /*SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "INI files|*.ini";
            dialog.Title = "Save the Configuration file";

            if (dialog.ShowDialog() == DialogResult.OK)*/
            {
                string filename = "config.ini";

                try
                {
                    File.WriteAllText(filename, JsonConvert.SerializeObject(lstConfig, Formatting.Indented));
                    MessageBox.Show($"Configuration File saved successfully.", "Save Result");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Exception Error ({System.Reflection.MethodBase.GetCurrentMethod().Name}): {exception.Message}");
                    MessageBox.Show($"{exception.Message}", "Error");
                }
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            txt_log.Text = "Service Add Clicked.";

            if (ServiceExts.IsServiceInstalled())
            {
                MessageBox.Show("Service was installed already.");
                return;
            }

            if (!File.Exists("config.ini"))
            {
                MessageBox.Show("No App List file.");
                return;
            }

            ServiceExts.InstallService();
        }

        private void btnRemoveService_Click(object sender, EventArgs e)
        {
            txt_log.Text = "Service Remove Clicked.";

            if (!ServiceExts.IsServiceInstalled())
            {
                MessageBox.Show("Service is removed already.");
                return;
            }

            ServiceExts.UninstallService();
        }

        private void btnReloadService_Click(object sender, EventArgs e)
        {
            txt_log.Text = "Service Reload Clicked.";

            if (!ServiceExts.IsServiceInstalled())
            {
                MessageBox.Show("Service is not installed.");
                return;
            }

            ServiceExts.RestartService();
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            txt_log.Text = "Service Start Clicked.";

            if (!ServiceExts.IsServiceInstalled())
            {
                MessageBox.Show("Service is not installed.");
                return;
            }

            if (ServiceExts.GetWindowsServiceStatus() == "Running")
            {
                MessageBox.Show("Service is running already.");
                return;
            }

            ServiceExts.StartService();
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            txt_log.Text = "Service Stop Clicked.";

            if (!ServiceExts.IsServiceInstalled())
            {
                MessageBox.Show("Service is not installed.");
                return;
            }

            if (ServiceExts.GetWindowsServiceStatus() == "Stopped")
            {
                MessageBox.Show("Service is stopped already.");
                return;
            }

            ServiceExts.StopService();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            txt_log.Text = "SCAN NOW Clicked.";

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(dialog.SelectedPath))
                {
                    GetListFromFolder(dialog.SelectedPath);
                }
            }
        }

        public void GetListFromFolder(string folder_path)
        {
            ImageList lstImg = new ImageList();
            lstImg.ImageSize = new Size(16, 16);

            btnScan.Enabled = false;
            bool flag = true;
            foreach (string f in Directory.GetFiles(folder_path, "*.exe"))
            {
                if (flag)
                {
                    lvProcess.Items.Clear();
                    flag = false;
                }
                Icon ico = Icon.ExtractAssociatedIcon(f);
                lstImg.Images.Add(ico);

                ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(f));
                item.SubItems.Add(Path.GetFileName(f));
                item.SubItems.Add(f);
                item.SubItems.Add("Delete");

                lvProcess.Items.Add(item);
            }
            if (!flag)
            {
                lvProcess.SmallImageList = lstImg;
                for (int idx = 0; idx < lvProcess.Items.Count; idx++)
                {
                    lvProcess.Items[idx].ImageIndex = idx;
                }
                lvProcess.Columns[0].Width = lvProcess.Width / 5;
                lvProcess.Columns[1].Width = lvProcess.Width / 5;
                lvProcess.Columns[2].Width = lvProcess.Width / 5 * 3 - 45;
                lvProcess.Columns[3].Width = 40;
            }
            btnScan.Enabled = true;
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            txt_log.Text = "ADD Clicked.";

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open a configuration file";
                dlg.Filter = "EXE files|*.exe";
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string f = dlg.FileName;

                    ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(f));
                    item.SubItems.Add(Path.GetFileName(f));
                    item.SubItems.Add(f);
                    item.SubItems.Add("Delete");

                    Icon ico = Icon.ExtractAssociatedIcon(f);

                    if (lvProcess.SmallImageList == null)
                    {
                        ImageList lstImg = new ImageList();
                        lstImg.ImageSize = new Size(16, 16);
                        lvProcess.SmallImageList = lstImg;
                    }

                    lvProcess.SmallImageList.Images.Add(ico);

                    lvProcess.Items.Add(item);
                    lvProcess.Items[lvProcess.Items.Count - 1].ImageIndex = lvProcess.Items.Count - 1;

                    lvProcess.Columns[0].Width = lvProcess.Width / 5;
                    lvProcess.Columns[1].Width = lvProcess.Width / 5;
                    lvProcess.Columns[2].Width = lvProcess.Width / 5 * 3 - 45;
                    lvProcess.Columns[3].Width = 40;

                    MessageBox.Show($"App added successfully.", "Load Result");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace, true);
            }
        }

        private void btnCmdRun_Click(object sender, EventArgs e)
        {
            if (txt_cmdline.Text.Trim() == string.Empty)
                return;

            string err_msg = string.Empty;
            bool res = ProcessExts.executeCommand(txt_cmdline.Text.Trim(), out err_msg);
            if (!res)
                MessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txt_cmdline_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            
            if (txt_cmdline.Text.Trim() == string.Empty)
                return;

            string err_msg = string.Empty;
            bool res = ProcessExts.executeCommand(txt_cmdline.Text.Trim(), out err_msg);
            if (!res)
                MessageBox.Show(err_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
