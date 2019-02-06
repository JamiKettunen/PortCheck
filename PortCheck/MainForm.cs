using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using PortCheck.Properties;

namespace PortCheck
{
    public partial class MainForm : Form
    {
        private int _status = 0;
        private int Status
        {
            get => _status;
            set
            {
                _status = value;

                switch (_status)
                {
                    case 1: // Checking
                        lblStatus.ForeColor = Color.DeepSkyBlue; // Gold
                        lblStatus.Text = "CHECKING";
                        break;
                    case 2: // Open
                        lblStatus.ForeColor = Color.Lime;
                        lblStatus.Text = "OPEN";
                        break;
                    case 3: // Closed
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "CLOSED";
                        break;
                    default: // Unknown (0)
                        lblStatus.ForeColor = Color.DarkGray;
                        lblStatus.Text = "UNKNOWN";
                        break;
                }
            }
        }

        private bool _ipEditMode = false;
        private bool IPEditMode
        {
            get => _ipEditMode;
            set
            {
                if (!workerPortChecker.IsBusy && !workerUpdateIP.IsBusy)
                {
                    _ipEditMode = value;

                    txtEditIP.Text = this.IPv4.ToString();
                    lblIP.Visible = !_ipEditMode;
                    lblEditIP.Visible = _ipEditMode;
                    txtEditIP.Visible = _ipEditMode;
                    txtPort.TabStop = !_ipEditMode;

                    if (_ipEditMode)
                    {
                        txtEditIP.Select();
                        txtEditIP.Select(0, txtEditIP.Text.Length);
                    }
                    else { this.PortLocked = false; }
                }
            }
        }

        private IPAddress _ipv4 = IPAddress.Parse("0.0.0.0");
        private IPAddress IPv4
        {
            get => _ipv4;
            set
            {
                _ipv4 = value;
                
                lblIP.Text = "IP: " + IPv4;
            }
        }

        private ushort _port = 80;
        private ushort Port
        {
            get => _port;
            set
            {
                if(!workerPortChecker.IsBusy) // !PortLocked
                {
                    _port = value;

                    txtPort.Text = _port.ToString();
                }
            }
        }

        private bool PortLocked
        {
            get => txtPort.ReadOnly; // txtPort.Enabled
            set
            {
                txtPort.ReadOnly = value;

                txtPort.ForeColor = !txtPort.ReadOnly ? Color.White : Color.FromArgb(109, 109, 109);
                lblPort.ForeColor = !txtPort.ReadOnly ? Color.White : Color.FromArgb(109, 109, 109);
                picPortUL.BackColor = !txtPort.ReadOnly ? Color.White : Color.FromArgb(109, 109, 109);
            }
        }

        private int _connTimeout = 3000;
        private int ConnTimeout
        {
            get => _connTimeout;
            set
            {
                if (!workerPortChecker.IsBusy)
                {
                    _connTimeout = value;
                    
                    if (timerResetTitle.Enabled) { timerResetTitle.Stop(); }
                    this.Text = "Timeout: " + _connTimeout;
                    timerResetTitle.Start();
                }
            }
        }

        #region MainForm

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load last values etc.
            try
            {
                this.IPv4 = IPAddress.Parse(Settings.Default.CachedIP);
                this.Port = Settings.Default.LastPort;
                this.Status = 0;
                this.ConnTimeout = Settings.Default.ConnTimeout;
            }
            catch { }
            
            // Fetch public IP
            if (!workerUpdateIP.IsBusy && Settings.Default.CachedIP == "0.0.0.0") { lblIP.Text = "IP: FETCHING..."; workerUpdateIP.RunWorkerAsync(); }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save last values for next application start
            try
            {
                Settings.Default.CachedIP = this._ipv4.ToString();
                Settings.Default.LastPort = this._port;
                Settings.Default.ConnTimeout = this.ConnTimeout;
                Settings.Default.Save();
            }
            catch { }
        }
        
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lblPort.Select();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1) { ConnTimeout = 100; return true; }
            else if (keyData == Keys.F2 && ConnTimeout > 100) { ConnTimeout -= 50; return true; }
            else if (keyData == Keys.F3 && ConnTimeout < 25000) { ConnTimeout += 50; return true; }
            else if (keyData == Keys.F4) { ConnTimeout = 25000; return true; }
            else if (keyData == Keys.F5 && !workerUpdateIP.IsBusy) { lblIP.Text = "IP: FETCHING..."; workerUpdateIP.RunWorkerAsync(); return true; }
            else if (keyData == Keys.Escape && IPEditMode) { IPEditMode = false; return true; }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region workerUpdateIP

        private void workerUpdateIP_DoWork(object sender, DoWorkEventArgs e)
        {
            try { e.Result = new WebClient().DownloadString("https://api.ipify.org"); } // Get public IPv4 address
            catch { e.Result = "0.0.0.0"; }
        }

        private void workerUpdateIP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try { this.IPv4 = IPAddress.Parse(e.Result.ToString()); }
            catch { MessageBox.Show("IP Address parsing failure!", "PortCheck", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion
        
        #region workerPortChecker

        private void workerPortChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = null;

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    Stopwatch watch = Stopwatch.StartNew();
                    e.Result = client.ConnectAsync(IPv4, Port).Wait(ConnTimeout) ? 1 : 0;
                    watch.Stop();
                    Console.WriteLine($"<= workerPortChecker_DoWork(): Connection took {watch.ElapsedMilliseconds}ms w/ result: port {((int)e.Result == 1 ? "open" : "closed")}");
                    watch = null;
                }
            }
            catch { e.Result = 0; }
        }

        private void workerPortChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Status = (int)e.Result == 1 ? 2 : 3;

            this.PortLocked = false;

            txtPort.Select();
            txtPort.Select(0, txtPort.Text.Length);
        }

        #endregion

        #region UI controls

        private void lblIP_DoubleClick(object sender, EventArgs e)
        {
            if (!IPEditMode) { this.PortLocked = true; IPEditMode = true; }
        }

        private void lblStatus_SizeChanged(object sender, EventArgs e)
        {
            // Center 'lblStatusText' and 'lblStatus' together on the X axis
            int deltaX = ((this.Width - (lblStatusText.Width + lblStatus.Width) - 2) / 2) - lblStatusText.Location.X - 5;
            lblStatusText.Location = new Point(lblStatusText.Location.X + deltaX, lblStatusText.Location.Y);
            lblStatus.Location = new Point(lblStatusText.Location.X + lblStatusText.Width - 2, lblStatus.Location.Y);
        }

        private void txtEditIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                e.Handled = e.SuppressKeyPress = true;

                if (e.KeyCode == Keys.Escape) { return; }

                IPAddress.TryParse(txtEditIP.Text, out IPAddress tmpIP);

                if (tmpIP != null)
                {
                    this.IPv4 = tmpIP;
                    IPEditMode = false;
                }
                else { txtEditIP.Select(); txtEditIP.Select(0, txtEditIP.Text.Length); SystemSounds.Asterisk.Play(); }
            }
        }

        private void txtPort_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !workerPortChecker.IsBusy)
            {
                e.Handled = e.SuppressKeyPress = true;

                RunPortCheck();
            }
            else if(e.KeyCode == Keys.Escape) { e.Handled = e.SuppressKeyPress = true; lblPort.Select(); }
        }

        #endregion

        #region Functions

        private void RunPortCheck()
        {
            ushort.TryParse(txtPort.Text, out ushort tmpPort);

            if (txtPort.Text != tmpPort.ToString()) // Invalid port
            {
                txtPort.Select();
                txtPort.Select(0, txtPort.Text.Length);
                SystemSounds.Asterisk.Play();
                return;
            }
            else { this.PortLocked = true; lblPort.Select(); Port = tmpPort; }

            Console.WriteLine("Checking port " + Port + " on IP " + IPv4);
            this.Status = 1;

            workerPortChecker.RunWorkerAsync();
        }

        #endregion

        #region Other
        
        private void timerResetTitle_Tick(object sender, EventArgs e)
        {
            timerResetTitle.Stop();
            this.Text = "PortCheck";
        }
        
        #endregion
    }
}
