namespace ScanApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCmdRun = new System.Windows.Forms.Button();
            this.txt_cmdline = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.btnReloadService = new System.Windows.Forms.Button();
            this.btnRemoveService = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnGetProList = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtEdit = new System.Windows.Forms.TextBox();
            this.lvProcess = new ScanApp.ScrollEventListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(887, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnGetProList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 144);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddApp);
            this.groupBox4.Controls.Add(this.btnScan);
            this.groupBox4.Location = new System.Drawing.Point(24, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 59);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Applications";
            // 
            // btnAddApp
            // 
            this.btnAddApp.Location = new System.Drawing.Point(106, 22);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(75, 23);
            this.btnAddApp.TabIndex = 5;
            this.btnAddApp.Text = "Add";
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(15, 22);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(80, 23);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "SCAN NOW";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCmdRun);
            this.groupBox3.Controls.Add(this.txt_cmdline);
            this.groupBox3.Location = new System.Drawing.Point(24, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(834, 57);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Command Line Execute";
            // 
            // btnCmdRun
            // 
            this.btnCmdRun.Location = new System.Drawing.Point(762, 22);
            this.btnCmdRun.Name = "btnCmdRun";
            this.btnCmdRun.Size = new System.Drawing.Size(50, 23);
            this.btnCmdRun.TabIndex = 1;
            this.btnCmdRun.Text = "Run";
            this.btnCmdRun.UseVisualStyleBackColor = true;
            this.btnCmdRun.Click += new System.EventHandler(this.btnCmdRun_Click);
            // 
            // txt_cmdline
            // 
            this.txt_cmdline.Location = new System.Drawing.Point(20, 24);
            this.txt_cmdline.Name = "txt_cmdline";
            this.txt_cmdline.Size = new System.Drawing.Size(718, 20);
            this.txt_cmdline.TabIndex = 0;
            this.txt_cmdline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cmdline_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveConfig);
            this.groupBox2.Controls.Add(this.btnLoadConfig);
            this.groupBox2.Location = new System.Drawing.Point(227, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 59);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration File";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(99, 22);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(63, 23);
            this.btnSaveConfig.TabIndex = 1;
            this.btnSaveConfig.Text = "Save";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Location = new System.Drawing.Point(18, 22);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(63, 23);
            this.btnLoadConfig.TabIndex = 0;
            this.btnLoadConfig.Text = "Load";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStopService);
            this.groupBox1.Controls.Add(this.btnStartService);
            this.groupBox1.Controls.Add(this.btnReloadService);
            this.groupBox1.Controls.Add(this.btnRemoveService);
            this.groupBox1.Controls.Add(this.btnAddService);
            this.groupBox1.Location = new System.Drawing.Point(418, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Windows Service Configuration";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(357, 22);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(63, 23);
            this.btnStopService.TabIndex = 4;
            this.btnStopService.Text = "Stop";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(272, 22);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(63, 23);
            this.btnStartService.TabIndex = 3;
            this.btnStartService.Text = "Start";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // btnReloadService
            // 
            this.btnReloadService.Location = new System.Drawing.Point(187, 22);
            this.btnReloadService.Name = "btnReloadService";
            this.btnReloadService.Size = new System.Drawing.Size(63, 23);
            this.btnReloadService.TabIndex = 2;
            this.btnReloadService.Text = "Reload";
            this.btnReloadService.UseVisualStyleBackColor = true;
            this.btnReloadService.Click += new System.EventHandler(this.btnReloadService_Click);
            // 
            // btnRemoveService
            // 
            this.btnRemoveService.Location = new System.Drawing.Point(102, 22);
            this.btnRemoveService.Name = "btnRemoveService";
            this.btnRemoveService.Size = new System.Drawing.Size(63, 23);
            this.btnRemoveService.TabIndex = 1;
            this.btnRemoveService.Text = "Remove";
            this.btnRemoveService.UseVisualStyleBackColor = true;
            this.btnRemoveService.Click += new System.EventHandler(this.btnRemoveService_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(17, 22);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(63, 23);
            this.btnAddService.TabIndex = 0;
            this.btnAddService.Text = "Add";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnGetProList
            // 
            this.btnGetProList.Location = new System.Drawing.Point(849, 71);
            this.btnGetProList.Name = "btnGetProList";
            this.btnGetProList.Size = new System.Drawing.Size(29, 23);
            this.btnGetProList.TabIndex = 1;
            this.btnGetProList.Text = "Get All Process";
            this.btnGetProList.UseVisualStyleBackColor = true;
            this.btnGetProList.Visible = false;
            this.btnGetProList.Click += new System.EventHandler(this.btnGetProList_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtEdit);
            this.panel2.Controls.Add(this.lvProcess);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 269);
            this.panel2.TabIndex = 1;
            // 
            // TxtEdit
            // 
            this.TxtEdit.Location = new System.Drawing.Point(168, 198);
            this.TxtEdit.Name = "TxtEdit";
            this.TxtEdit.Size = new System.Drawing.Size(100, 20);
            this.TxtEdit.TabIndex = 2;
            this.TxtEdit.Visible = false;
            this.TxtEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtEdit_KeyUp);
            this.TxtEdit.Leave += new System.EventHandler(this.TxtEdit_Leave);
            // 
            // lvProcess
            // 
            this.lvProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcess.FullRowSelect = true;
            this.lvProcess.GridLines = true;
            this.lvProcess.HideSelection = false;
            this.lvProcess.LabelEdit = true;
            this.lvProcess.Location = new System.Drawing.Point(0, 0);
            this.lvProcess.Name = "lvProcess";
            this.lvProcess.Size = new System.Drawing.Size(881, 269);
            this.lvProcess.TabIndex = 0;
            this.lvProcess.UseCompatibleStateImageBehavior = false;
            this.lvProcess.View = System.Windows.Forms.View.Details;
            this.lvProcess.Scroll += new System.Windows.Forms.ScrollEventHandler(this.lvProcess_Scroll);
            this.lvProcess.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProcess_ColumnClick);
            this.lvProcess.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvProcess_MouseDown);
            this.lvProcess.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvProcess_MouseUp);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_log);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 428);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(881, 19);
            this.panel3.TabIndex = 2;
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.SystemColors.Info;
            this.txt_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_log.Location = new System.Drawing.Point(0, 0);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(881, 20);
            this.txt_log.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(903, 489);
            this.Name = "Form1";
            this.Text = "ScanApp";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGetProList;
        private System.Windows.Forms.Panel panel2;
        private ScrollEventListView lvProcess;
        private System.Windows.Forms.TextBox TxtEdit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnRemoveService;
        private System.Windows.Forms.Button btnReloadService;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCmdRun;
        private System.Windows.Forms.TextBox txt_cmdline;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAddApp;
    }
}

