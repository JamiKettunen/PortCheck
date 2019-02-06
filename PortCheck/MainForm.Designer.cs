namespace PortCheck
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.picPortUL = new System.Windows.Forms.PictureBox();
            this.workerUpdateIP = new System.ComponentModel.BackgroundWorker();
            this.lblIP = new System.Windows.Forms.Label();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.workerPortChecker = new System.ComponentModel.BackgroundWorker();
            this.timerResetTitle = new System.Windows.Forms.Timer(this.components);
            this.txtEditIP = new System.Windows.Forms.TextBox();
            this.lblEditIP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPortUL)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPort.AutoSize = true;
            this.lblPort.ForeColor = System.Drawing.Color.White;
            this.lblPort.Location = new System.Drawing.Point(18, 35);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 21);
            this.lblPort.TabIndex = 99;
            this.lblPort.Text = "Port:";
            this.lblPort.UseMnemonic = false;
            this.lblPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // txtPort
            // 
            this.txtPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPort.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPort.ForeColor = System.Drawing.Color.White;
            this.txtPort.Location = new System.Drawing.Point(59, 35);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(65, 22);
            this.txtPort.TabIndex = 0;
            this.txtPort.Text = "8080";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPort.WordWrap = false;
            this.txtPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPort_KeyDown);
            // 
            // picPortUL
            // 
            this.picPortUL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picPortUL.BackColor = System.Drawing.Color.White;
            this.picPortUL.Location = new System.Drawing.Point(59, 57);
            this.picPortUL.Name = "picPortUL";
            this.picPortUL.Size = new System.Drawing.Size(65, 1);
            this.picPortUL.TabIndex = 2;
            this.picPortUL.TabStop = false;
            // 
            // workerUpdateIP
            // 
            this.workerUpdateIP.WorkerSupportsCancellation = true;
            this.workerUpdateIP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerUpdateIP_DoWork);
            this.workerUpdateIP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerUpdateIP_RunWorkerCompleted);
            // 
            // lblIP
            // 
            this.lblIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIP.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblIP.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblIP.Location = new System.Drawing.Point(32, 22);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(85, 12);
            this.lblIP.TabIndex = 99;
            this.lblIP.Text = "IP: X.X.X.X";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblIP.UseMnemonic = false;
            this.lblIP.DoubleClick += new System.EventHandler(this.lblIP_DoubleClick);
            this.lblIP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // lblStatusText
            // 
            this.lblStatusText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblStatusText.ForeColor = System.Drawing.Color.LightGray;
            this.lblStatusText.Location = new System.Drawing.Point(29, 61);
            this.lblStatusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(38, 12);
            this.lblStatusText.TabIndex = 99;
            this.lblStatusText.Text = "STATUS:";
            this.lblStatusText.UseMnemonic = false;
            this.lblStatusText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.lblStatus.Location = new System.Drawing.Point(65, 61);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 12);
            this.lblStatus.TabIndex = 99;
            this.lblStatus.Text = "UNKNOWN";
            this.lblStatus.UseMnemonic = false;
            this.lblStatus.SizeChanged += new System.EventHandler(this.lblStatus_SizeChanged);
            this.lblStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // workerPortChecker
            // 
            this.workerPortChecker.WorkerSupportsCancellation = true;
            this.workerPortChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerPortChecker_DoWork);
            this.workerPortChecker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerPortChecker_RunWorkerCompleted);
            // 
            // timerResetTitle
            // 
            this.timerResetTitle.Interval = 750;
            this.timerResetTitle.Tick += new System.EventHandler(this.timerResetTitle_Tick);
            // 
            // txtEditIP
            // 
            this.txtEditIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.txtEditIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEditIP.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEditIP.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.txtEditIP.ForeColor = System.Drawing.Color.White;
            this.txtEditIP.Location = new System.Drawing.Point(58, 22);
            this.txtEditIP.MaxLength = 15;
            this.txtEditIP.Name = "txtEditIP";
            this.txtEditIP.Size = new System.Drawing.Size(67, 13);
            this.txtEditIP.TabIndex = 1;
            this.txtEditIP.Text = "000.000.000.000";
            this.txtEditIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEditIP.Visible = false;
            this.txtEditIP.WordWrap = false;
            this.txtEditIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEditIP_KeyDown);
            // 
            // lblEditIP
            // 
            this.lblEditIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEditIP.AutoSize = true;
            this.lblEditIP.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lblEditIP.ForeColor = System.Drawing.Color.White;
            this.lblEditIP.Location = new System.Drawing.Point(23, 22);
            this.lblEditIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEditIP.Name = "lblEditIP";
            this.lblEditIP.Size = new System.Drawing.Size(35, 12);
            this.lblEditIP.TabIndex = 99;
            this.lblEditIP.Text = "Edit IP:";
            this.lblEditIP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEditIP.UseMnemonic = false;
            this.lblEditIP.Visible = false;
            this.lblEditIP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(148, 96);
            this.Controls.Add(this.lblEditIP);
            this.Controls.Add(this.txtEditIP);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.picPortUL);
            this.Controls.Add(this.lblStatusText);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPort);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(139, 95);
            this.Name = "MainForm";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PortCheck";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picPortUL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.PictureBox picPortUL;
        private System.ComponentModel.BackgroundWorker workerUpdateIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker workerPortChecker;
        private System.Windows.Forms.Timer timerResetTitle;
        private System.Windows.Forms.TextBox txtEditIP;
        private System.Windows.Forms.Label lblEditIP;
    }
}

