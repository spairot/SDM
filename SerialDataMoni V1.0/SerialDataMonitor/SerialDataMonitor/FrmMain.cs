// 2020-May-19
// First writting by S.Pairot

using FastColoredTextBoxNS;
using SerialDataMonitor.Forms;
using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SerialDataMonitor
{
    public partial class FrmMain : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        SerialClient SerialSetting;
        public static DataSetting DataSet = new DataSetting();
        private string OptionDisp = "Ascii";
        private UInt16 Timer1Tick = 0;

        /*Display screen setting*/
        private string NumberColorStyle1 = "";
        private string NumberColorStyle2 = "";
        private string NumberColorStyle3 = "";
        private string NumberColorStyle4 = "";

        //Font display styles
        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle RedStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        TextStyle BlackStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));
        TextStyle DarkVioletStyle = new TextStyle(Brushes.DarkViolet, null, FontStyle.Regular);
        TextStyle GoldStyle = new TextStyle(Brushes.Gold, null, FontStyle.Regular);
        TextStyle PeruStyle = new TextStyle(Brushes.Peru, null, FontStyle.Regular);
        TextStyle OrangeStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        TextStyle TurquoiseStyle = new TextStyle(Brushes.Turquoise, null, FontStyle.Regular);

        //Text style setting
        string FontTextStyle1 = "";
        string FontTextStyle2 = "";
        string FontTextStyle3 = "";
        string FontTextStyle4 = "";
        string FontTextStyle5 = "";
        string FontTextStyle6 = "";
        string FontTextStyle7 = "";
        string FontTextStyle8 = "";

        //Constructor
        public FrmMain()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            /*Context menu write click*/
            ContextMenu cm = new ContextMenu();
            MenuItem mi = new MenuItem("Cut");
            mi.Click += new EventHandler(mi_Cut);
            cm.MenuItems.Add(mi);
            mi = new MenuItem("Copy");
            mi.Click += new EventHandler(mi_Copy);
            cm.MenuItems.Add(mi);
            mi = new MenuItem("Paste");
            mi.Click += new EventHandler(mi_Paste);
            cm.MenuItems.Add(mi);
            mi = new MenuItem("Clear");
            mi.Click += new EventHandler(mi_Clear);
            cm.MenuItems.Add(mi);
            txtDisplay.ContextMenu = cm;
        }

        // Method for drag main form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Methods
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        /// <summary>
        /// Activate Button
        /// Set button color
        /// </summary>
        /// <param></param>
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    pnlTop.BackColor = color;
                    pnlControlBar.BackColor = color;
                    pnlLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnMenu.BackColor = color;
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                    cmbDispOption.BackColor = color;
                    txtSearch.BackColor = color;
                    txtWrite.BackColor = color;
                }
            }
        }
        /// <summary>
        /// Disable Button
        /// Clear/Restore default button color
        /// </summary>
        /// <param></param>
        private void DisableButton()
        {
            foreach (Control previousBtn in pnlMenuLeft.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        /// <summary>
        /// Open Child Form
        /// </summary>
        /// <param></param>
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlDesktop.Controls.Add(childForm);
            this.pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        #region BackupUserSetting
        /// <summary>
        /// Back up user setting to RAM (Temporary)
        /// </summary>
        /// <param name="></param>
        private void backup_ram_setting(DataSetting dt)
        {
            BackupData.ComPortName = dt.ComPortName;             // PortName Back up data 
            BackupData.Baudrate = Convert.ToInt32(dt.Baudrate);  // BaudRate Back up data 
            BackupData.DataBits = Convert.ToInt16(dt.DataBits);  // DataBits Back up data 
            BackupData.Parity = dt.Parity;                       // Parity Back up data
            BackupData.StopBits = dt.StopBits;                   // StopBits Back up data

            BackupData.FontNumberColor = dt.FontNumberColor;     // Font number color
            BackupData.FontTextColor1 = dt.FontTextColor1;       // Font text color 1
            BackupData.FontTextColor2 = dt.FontTextColor2;       // Font text color 2
            BackupData.FontTextColor3 = dt.FontTextColor3;       // Font text color 3
            BackupData.FontTextColor4 = dt.FontTextColor4;       // Font text color 4
            BackupData.FontTextColor5 = dt.FontTextColor5;       // Font text color 5
            BackupData.FontTextColor6 = dt.FontTextColor6;       // Font text color 6
            BackupData.FontTextColor7 = dt.FontTextColor7;       // Font text color 7
            BackupData.FontTextColor8 = dt.FontTextColor8;       // Font text color 8

            BackupData.DispScroll = dt.DispScroll;               // Display scroll
        }

        /// <summary>
        /// Back up data to text file (ROM)
        /// </summary>
        /// <param></param>
        private void backup_rom_setting()
        {
            try
            {
                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "BackupUserSetting.txt");
                StreamWriter sw = new StreamWriter(fileName, false, Encoding.ASCII);

                sw.WriteLine("Comport,"  + BackupData.ComPortName);  // Backup last com port
                sw.WriteLine("Baudrate," + BackupData.Baudrate);     // Backup last Baudrate
                sw.WriteLine("Databit,"  + BackupData.DataBits);     // Backup last data bit
                sw.WriteLine("Parity,"   + BackupData.Parity);       // Backup last parity bit
                sw.WriteLine("Stopbit,"  + BackupData.StopBits);     // Backup last stop bit

                sw.WriteLine("NumberColor," + BackupData.FontNumberColor);  // Backup last number color setting
                sw.WriteLine("TextColor1," + BackupData.FontTextColor1);    // Backup last text color setting
                sw.WriteLine("TextColor2," + BackupData.FontTextColor2);    // Backup last text color setting
                sw.WriteLine("TextColor3," + BackupData.FontTextColor3);    // Backup last text color setting
                sw.WriteLine("TextColor4," + BackupData.FontTextColor4);    // Backup last text color setting
                sw.WriteLine("TextColor5," + BackupData.FontTextColor5);    // Backup last text color setting
                sw.WriteLine("TextColor6," + BackupData.FontTextColor6);    // Backup last text color setting
                sw.WriteLine("TextColor7," + BackupData.FontTextColor7);    // Backup last text color setting
                sw.WriteLine("TextColor8," + BackupData.FontTextColor8);    // Backup last text color setting

                sw.WriteLine("DispScroll," + BackupData.DispScroll);        // Backup last display scroll setting

                sw.Close();
            }
            catch (Exception) { };
            return;
        }
        /// <summary>
        /// Read back up data from text file
        /// Reload previous user setting
        /// </summary>
        /// <param></param>
        private static string get_rom_setting(string getType)
        {
            string readLine, ret = null;
            //Search until reach the end point of message group
            try
            {
                string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "BackupUserSetting.txt");
                StreamReader sr = new StreamReader(fileName);
                while ((readLine = sr.ReadLine()) != null)
                {
                    string[] elements = Regex.Split(readLine, ",");  // split the string
                    if (elements.Length > 1)                         // not empty array string
                    {
                        if (elements[0] == getType)
                        {
                            ret = elements[1];
                            break;
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception) { };
            return ret;
        }
        #endregion /*BackupUserSetting*/

        #region Set control

        /// <summary>
        /// Button menu hamburger click
        /// </summary>
        /// <param></param>
        private void set_user_control(String e_msg)
        {
            switch (e_msg)
            {
                case "FormLoad":
                    string UserName = Environment.UserName;
                    lblUserName.Text = "User Name: " + UserName;
                    btnDisconnect.Visible = false;
                    update_font_style();
                    lblShowSerialSetting.Text = "Serial Port:  " +
                                                 BackupData.ComPortName + "," +
                                                 BackupData.Baudrate    + "," +
                                                 BackupData.DataBits    + "," +
                                                 BackupData.Parity      + "," +
                                                 BackupData.StopBits;
                    break;
                case "Home":
                    if (activeForm != null)
                        activeForm.Close();
                    Reset();
                    lblTitle.Text = "Home";
                    break;
                case "Setting":
                    update_font_style();
                    lblShowSerialSetting.Text = "Serial Port:  " +
                                                 BackupData.ComPortName + "," +
                                                 BackupData.Baudrate    + "," +
                                                 BackupData.DataBits    + "," +
                                                 BackupData.Parity      + "," +
                                                 BackupData.StopBits;
                    break;
                case "Control":
                    lblTitle.Text = "Control";
                    break;
                case "Export":
                    lblTitle.Text = "Export";
                    break;
                case "Admin":
                    lblTitle.Text = "Admin";
                    break;
                case "Connect":
                    btnConnect.Visible = false;
                    btnDisconnect.Visible = true;
                    btnSetting.Enabled = false;
                    lblRx.BackColor = Color.Green; ;
                    break;
                case "Disconnect":
                    btnConnect.Visible = true;
                    btnDisconnect.Visible = false;
                    btnSetting.Enabled = true;
                    lblRx.BackColor = Color.LightGray;
                    lblTx.BackColor = Color.LightGray;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region LoadBackupData
        /// <summary>
        /// Form start load
        /// </summary>
        /// <param></param>
        static void load_backup_setting()
        {
            string L_StrData = null;

            L_StrData = get_rom_setting("Comport");   // Get comport from text file backup
            if (L_StrData != null)
            {
                BackupData.ComPortName = L_StrData;
                DataSet.ComPortName = BackupData.ComPortName;
            }

            L_StrData = get_rom_setting("Baudrate");     // Get baudrate from text file backup
            if (L_StrData != null)
            {
                BackupData.Baudrate = Convert.ToInt32(L_StrData);
                DataSet.Baudrate = BackupData.Baudrate;
            }

            L_StrData = get_rom_setting("Databit");      // Get data bit from text file backup
            if (L_StrData != null)
            {
                BackupData.DataBits = Convert.ToInt16(L_StrData);
                DataSet.DataBits = BackupData.DataBits;
            }

            L_StrData = get_rom_setting("Parity");         // Get parity bit from text file backup
            if (L_StrData != null)
            {
                BackupData.Parity = (Parity)Enum.Parse(typeof(Parity), L_StrData);
                DataSet.Parity = BackupData.Parity;
            }

            L_StrData = get_rom_setting("Stopbit");      // Get stop bit from text file backup
            if (L_StrData != null)
            {
                BackupData.StopBits = (StopBits)Enum.Parse(typeof(StopBits), L_StrData);
                DataSet.StopBits = BackupData.StopBits;
            }

            L_StrData = get_rom_setting("NumberColor");      // Get number from text file backup
            if (L_StrData != null)
            {
                BackupData.FontNumberColor = L_StrData;
                DataSet.FontNumberColor = BackupData.FontNumberColor;
            }

            L_StrData = get_rom_setting("TextColor1");      // Get text from text file backup
            if (L_StrData != null)
            {
                BackupData.FontTextColor1 = L_StrData;
                DataSet.FontTextColor1 = BackupData.FontTextColor1;
            }

            L_StrData = get_rom_setting("TextColor2");      // Get text from text file backup
            if (L_StrData != null)
            {
                BackupData.FontTextColor2 = L_StrData;
                DataSet.FontTextColor2 = BackupData.FontTextColor2;
            }

            L_StrData = get_rom_setting("TextColor3");      // Get text from text file backup
            if (L_StrData != null)
            {
                BackupData.FontTextColor3 = L_StrData;
                DataSet.FontTextColor3 = BackupData.FontTextColor3;
            }

            L_StrData = get_rom_setting("TextColor4");      // Get text from text file backup
            if (L_StrData != null)
            {
                BackupData.FontTextColor4 = L_StrData;
                DataSet.FontTextColor4 = BackupData.FontTextColor4;
            }

            L_StrData = get_rom_setting("TextColor5");      // Get text from text file backup
            if (L_StrData != null)
            {
                BackupData.FontTextColor5 = L_StrData;
                DataSet.FontTextColor5 = BackupData.FontTextColor5;
            }

            L_StrData = get_rom_setting("TextColor6");      // Get text from text file backup
            if (L_StrData != null)
            {
                BackupData.FontTextColor6 = L_StrData;
                DataSet.FontTextColor6 = BackupData.FontTextColor6;
            }

            L_StrData = get_rom_setting("TextColor7");      // Get text from text file backup
            if (L_StrData != null)
            {
                BackupData.FontTextColor7 = L_StrData;
                DataSet.FontTextColor7 = BackupData.FontTextColor7;
            }

            L_StrData = get_rom_setting("TextColor8");      // Get text from text file backup
            if (L_StrData != null)
            {
                BackupData.FontTextColor8 = L_StrData;
                DataSet.FontTextColor8 = BackupData.FontTextColor8;
            }

            L_StrData = get_rom_setting("DispScroll");
            if (L_StrData != null)
            {
                BackupData.DispScroll = Convert.ToBoolean(L_StrData);
                DataSet.DispScroll = BackupData.DispScroll;
            }
        }
        #endregion

        /// <summary>
        /// Form start load
        /// </summary>
        /// <param></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            pnlCursor.Height = btnHome.Height;
            pnlCursor.Top = btnHome.Top;
            pnlControlBar.Height = 0;
            pnlMenuLeft.Width = 55;
            pnlLogo.Width = 55;
            //txtDisplay.Dock = DockStyle.Fill;
            btnNotification.Visible = false;
            btnEmail.Visible = false;
            lblcopyright.Visible = false;
            lbltctc.Visible = false;
            load_backup_setting();
            set_user_control("FormLoad");
        }
        /// <summary>
        /// Button Home click
        /// </summary>
        /// <param></param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlCursor.Height = btnHome.Height;
            pnlCursor.Top = btnHome.Top;
            set_user_control("Home");
            ActivateButton(sender);
        }
        /// <summary>
        /// Setting serial port
        /// </summary>
        /// <param></param>
        private void setting_data_update(DialogResult L_result, DataSetting L_setting)
        {
            if (L_result == DialogResult.OK && L_setting != null) {
                DataSet.ComPortName = L_setting.ComPortName; // Port name get from Setting Form
                DataSet.Baudrate    = L_setting.Baudrate;    // Baudrate name get from Setting Form
                DataSet.DataBits    = L_setting.DataBits;    // DataBits get from Setting Form
                DataSet.Parity      = L_setting.Parity;      // Parity get from Setting Form
                DataSet.StopBits    = L_setting.StopBits;    // StopBit get from Setting Form

                DataSet.FontNumberColor = L_setting.FontNumberColor;  // Font number color
                DataSet.FontTextColor1 = L_setting.FontTextColor1;    // Font text color
                DataSet.FontTextColor2 = L_setting.FontTextColor2;    // Font text color
                DataSet.FontTextColor3 = L_setting.FontTextColor3;    // Font text color
                DataSet.FontTextColor4 = L_setting.FontTextColor4;    // Font text color
                DataSet.FontTextColor5 = L_setting.FontTextColor5;    // Font text color
                DataSet.FontTextColor6 = L_setting.FontTextColor6;    // Font text color
                DataSet.FontTextColor7 = L_setting.FontTextColor7;    // Font text color
                DataSet.FontTextColor8 = L_setting.FontTextColor8;    // Font text color

                DataSet.DispScroll = L_setting.DispScroll;            // Display scroll

                backup_ram_setting(L_setting);               // backup data
                set_user_control("Setting");
            }
        }

        /// <summary>
        /// Button Setting click
        /// </summary>
        /// <param></param>
        private void btnSetting_Click(object sender, EventArgs e)
        {
            pnlCursor.Height = btnSetting.Height;
            pnlCursor.Top = btnSetting.Top;
            FrmSetting Frm = new FrmSetting() { Setting = new DataSetting() };
            OpenChildForm(Frm, sender);
            Frm.get_data_callback += setting_data_update;
        }
        /// <summary>
        /// Button Control click
        /// </summary>
        /// <param></param>
        private void btnControl_Click(object sender, EventArgs e)
        {
            pnlCursor.Height = btnControl.Height;
            pnlCursor.Top = btnControl.Top;
            set_user_control("Control");
            ActivateButton(sender);

            //txtDisplay.Dock = DockStyle.Fill;
            if (pnlControlBar.Height == 47)
            {
                pnlControlBar.Height = 0;
            }
            else
            {
                pnlControlBar.Height = 47;
            }
        }
        /// <summary>
        /// Button Export click
        /// </summary>
        /// <param></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            pnlCursor.Height = btnExport.Height;
            pnlCursor.Top = btnExport.Top;
            set_user_control("Export");
            SaveDataToFile();
            ActivateButton(sender);
        }
        /// <summary>
        /// Button Admin click
        /// </summary>
        /// <param></param>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            pnlCursor.Height = btnAdmin.Height;
            pnlCursor.Top = btnAdmin.Top;
            set_user_control("Admin");
            ActivateButton(sender);

            FrmLogin Frm = new FrmLogin() {  };
            OpenChildForm(Frm, sender);
        }
        /// <summary>
        /// Button Logout click
        /// </summary>
        /// <param></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            pnlCursor.Height = btnLogout.Height;
            pnlCursor.Top = btnLogout.Top;
            set_user_control("Logout");
            Application.Exit();
        }
        /// <summary>
        /// Button Menu click
        /// </summary>
        /// <param></param>
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenuLeft.Width == 140)
            {
                pnlMenuLeft.Width = 55;
                pnlLogo.Width = 55;
                btnNotification.Visible = false;
                btnEmail.Visible = false;
                lblcopyright.Visible = false;
                lbltctc.Visible = false;
            }
            else
            {
                pnlMenuLeft.Width = 140;
                pnlLogo.Width = 140;
                btnNotification.Visible = true;
                btnEmail.Visible = true;
                lblcopyright.Visible = true;
                lbltctc.Visible = true;
            }
            ActivateButton(sender);
        }
        /// <summary>
        /// Reset theme
        /// </summary>
        /// <param></param>
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Home";
            pnlTop.BackColor = Color.FromArgb(0, 56, 99);
            pnlControlBar.BackColor = Color.FromArgb(0, 56, 99);
            pnlLogo.BackColor = Color.FromArgb(39, 39, 58);
            btnMenu.BackColor = Color.FromArgb(0, 56, 99);
            cmbDispOption.BackColor = Color.FromArgb(0, 56, 99);
            txtSearch.BackColor = Color.FromArgb(0, 56, 99);
            txtWrite.BackColor = Color.FromArgb(0, 56, 99);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }
        /// <summary>
        /// Mouse down for drag window form at Title bar
        /// </summary>
        /// <param></param>
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Close application
        /// </summary>
        /// <param></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Maximize application
        /// </summary>
        /// <param></param>
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// Maximize application by double click
        /// </summary>
        /// <param></param>
        private void pnlTop_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// Minimize application
        /// </summary>
        /// <param></param>
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Close sub form
        /// </summary>
        /// <param></param>
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        /// <summary>
        /// Hide menu bar contro
        /// </summary>
        /// <param></param>
        private void btnHideMenuBar_Click(object sender, EventArgs e)
        {
            //txtDisplay.Dock = DockStyle.Fill;
            if (pnlControlBar.Height == 47)
            {
                pnlControlBar.Height = 0;
            }
            else
            {
                pnlControlBar.Height = 47;
            }
        }
        /// <summary>
        /// Closing main form
        /// </summary>
        /// <param></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            backup_rom_setting();              // Backup user setting into ROM
            if (SerialSetting != null)
                SerialSetting.ExitConn();
        }
        /// <summary>
        /// Serial port connect function
        /// </summary>
        /// <param></param>
        private void SerialPortConnect()
        {
            SerialSetting = new SerialClient(DataSet);
            SerialSetting.OnReceiving += new EventHandler<DataStreamEventArgs>(receiveHandler);
            if (!SerialSetting.OpenConn())
            {
                MessageBox.Show("Can't Open Port!!!", "Connect Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                set_user_control("Connect");
                //btnWrite.Enabled = true;
                //txtWrite.Enabled = true;
                /*Read button control*/
                //btnStart.Visible = false;
                //btnStart.Enabled = true;
                //btnPause.Visible = true;

                //tabSearch.Enabled = false;
                //tabHelp.SelectedIndex = 2;  /*Change tab to Read/Write*/
            }
        }

        #region Read
        /// <summary>
        /// Serial port receive data handler
        /// </summary>
        /// <param></param>
        private void receiveHandler(object sender, DataStreamEventArgs e)
        {
            if (e._Datas != string.Empty)
            {
                ReceiveData(e._Datas);
            }
        }
        /// <summary>
        /// Serial port receive data manage
        /// </summary>
        /// <param></param>
        delegate void ChangeMyTextDelegate(string Text);
        public void ReceiveData(string Text)
        {
            GlobalConvert conv = new GlobalConvert();
            try
            {
                if (txtDisplay.InvokeRequired)
                {
                    ChangeMyTextDelegate del = new ChangeMyTextDelegate(ReceiveData);
                    txtDisplay.Invoke(del, Text);
                }
                else
                {
                    txtDisplay.BeginUpdate();
                    txtDisplay.Selection.BeginUpdate();
                    //remember user selection
                    var userSelection = txtDisplay.Selection.Clone();
                    //add text with predefined style
                    txtDisplay.TextSource.CurrentTB = txtDisplay;
                    txtDisplay.Text.Replace("\n", "\r\n");
                    switch (OptionDisp)
                    {
                        case "Ascii":  /*Display Ascii*/
                            //some stuffs for best performance
                            txtDisplay.AppendText(Text, BlackStyle);
                            break;
                        case "Hex":  /*Display Hex*/
                            txtDisplay.AppendText(conv.StringToHex(Text), BlackStyle);
                            break;
                        case "Ascii+TimeStamp":  /*Display Ascii+TimeStamp*/
                            txtDisplay.AppendText(DateTime.Now.ToString("HH:mm:ss") + " " + Text, BlackStyle);
                            break;
                        case "Hex+TimeStamp":  /*Display Hex+TimeStamp*/
                        default:
                            txtDisplay.AppendText(conv.StringToHex(Text), BlackStyle);
                            break;
                    }
                    //---------------------------------------------------------------------------//
                    //restore user selection
                    if (DataSet.DispScroll == false)
                    {
                        txtDisplay.GoEnd();  //scroll to end of the text
                    }
                    else
                    {
                        if (!userSelection.IsEmpty || userSelection.Start.iLine < txtDisplay.LinesCount - 2)
                        {
                            txtDisplay.Selection.Start = userSelection.Start;
                            txtDisplay.Selection.End = userSelection.End;
                        }
                        else
                        {
                            txtDisplay.GoEnd();  //scroll to end of the text
                        }
                    }

                    txtDisplay.Selection.EndUpdate();
                    txtDisplay.EndUpdate();

                    /*Tx color status*/
                    //timer1.Enabled = true;
                    //lblRx.BackColor = Color.Green;
                    //Timer1Tick = 0;
                }
            }
            catch (Exception)
            {
                Thread.ResetAbort();
                return;
            }
        }
        /// <summary>
        /// Display text change
        /// Highlight text with color setting
        /// </summary>
        /// <param></param>
        private void txtDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlackStyle,MagentaStyle, RedStyle, GreenStyle, 
                                      BlueStyle, PeruStyle, DarkVioletStyle, GoldStyle, 
                                      OrangeStyle, TurquoiseStyle);
            //number highlighting
            //e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            e.ChangedRange.SetStyle(MagentaStyle, NumberColorStyle1);  // Set number color
            e.ChangedRange.SetStyle(RedStyle,     NumberColorStyle2);  // Set number color
            e.ChangedRange.SetStyle(GreenStyle,   NumberColorStyle3);  // Set number color
            e.ChangedRange.SetStyle(BlueStyle,    NumberColorStyle4);  // Set number color

            //keyword highlighting
            e.ChangedRange.SetStyle(RedStyle,        FontTextStyle1);
            e.ChangedRange.SetStyle(GreenStyle,      FontTextStyle2);
            e.ChangedRange.SetStyle(BlueStyle,       FontTextStyle3);
            e.ChangedRange.SetStyle(PeruStyle,       FontTextStyle4);
            e.ChangedRange.SetStyle(DarkVioletStyle, FontTextStyle5);
            e.ChangedRange.SetStyle(GoldStyle,       FontTextStyle6);
            e.ChangedRange.SetStyle(OrangeStyle,     FontTextStyle7);
            e.ChangedRange.SetStyle(TurquoiseStyle,  FontTextStyle8);
        }
        /// <summary>
        /// Update font style setting
        /// </summary>
        /// <param></param>
        private void update_font_style()
        {
            NumberColorStyle1 = "";
            NumberColorStyle2 = "";
            NumberColorStyle3 = "";
            NumberColorStyle4 = "";
            switch (DataSet.FontNumberColor)
            {
                case "Magenta":
                    NumberColorStyle1 = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b";
                    break;
                case "Red":
                    NumberColorStyle2 = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b";
                    break;
                case "Green":
                    NumberColorStyle3 = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b";
                    break;
                case "Blue":
                    NumberColorStyle4 = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b";
                    break;
                default:
                    NumberColorStyle1 = @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b";
                    break;
            }
            FontTextStyle1 = @"\b(" + DataSet.FontTextColor1.Replace(',', '|') + ")\\b";
            FontTextStyle2 = @"\b(" + DataSet.FontTextColor2.Replace(',', '|') + ")\\b";
            FontTextStyle3 = @"\b(" + DataSet.FontTextColor3.Replace(',', '|') + ")\\b";
            FontTextStyle4 = @"\b(" + DataSet.FontTextColor4.Replace(',', '|') + ")\\b";
            FontTextStyle5 = @"\b(" + DataSet.FontTextColor5.Replace(',', '|') + ")\\b";
            FontTextStyle6 = @"\b(" + DataSet.FontTextColor6.Replace(',', '|') + ")\\b";
            FontTextStyle7 = @"\b(" + DataSet.FontTextColor7.Replace(',', '|') + ")\\b";
            FontTextStyle8 = @"\b(" + DataSet.FontTextColor8.Replace(',', '|') + ")\\b";
        }
        /// <summary>
        /// Serial port connect
        /// </summary>
        /// <param></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            SerialPortConnect();
        }
        /// <summary>
        /// Serial port disconnect
        /// </summary>
        /// <param></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (true == SerialSetting.CloseConn())
            {
                SerialSetting.OnReceiving -= new EventHandler<DataStreamEventArgs>(receiveHandler);
                SerialSetting.Dispose();

                /*Connect/Disconnect button control*/
                set_user_control("Disconnect");
                /*Write button control*/
                //btnWrite.Enabled = false;
                //txtWrite.Enabled = false;

                /*Read button control*/
                //btnStart.Visible = true;
                //btnStart.Enabled = false;
                //btnPause.Visible = false;

                //tabSearch.Enabled = true;
            }
            else
            {
                MessageBox.Show("Can't close Port!!!", "Connect Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Scroll display to end
        /// </summary>
        /// <param></param>
        private void btnDispScrollEnd_Click(object sender, EventArgs e)
        {
            txtDisplay.GoEnd();
        }
        /// <summary>
        /// Change display data type
        /// </summary>
        /// <param></param>
        private void cmbDispOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionDisp = cmbDispOption.Text;
        }
        /// <summary>
        /// Clear display
        /// </summary>
        /// <param></param>
        private void btnClearDisp_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
        }
        /// <summary>
        /// Timer status Rx/Tx
        /// </summary>
        /// <param></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (++Timer1Tick >= 2)
            {
                lblRx.BackColor = Color.LightGray;
                lblTx.BackColor = Color.LightGray;
                Timer1Tick = 0;
                timer1.Enabled = false;
            }
        }
        #endregion

        #region Open/Save file
        /// <summary>
        /// Export text file
        /// </summary>
        /// <param></param>
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            SaveDataToFile();
        }
        /// <summary>
        /// Save data to file sub routine
        /// </summary>
        /// <param></param>
        private void SaveDataToFile()
        {
            /*Check the file format*/
            var saveFile1 = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = string.Format("{0}Text files (*.txt)|*.txt|All files (*.*)|*.*", "ARG0"),
                RestoreDirectory = true,
                ShowHelp = true,
                CheckFileExists = false
            };

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                try
                {
                    //txtDump.Text = saveFile1.FileName;
                    txtDisplay.SaveToFile(saveFile1.FileName, Encoding.UTF32);
                    File.WriteAllText(saveFile1.FileName, txtDisplay.Text);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: Could not save file!!. Original error: " + err.Message);
                }
            }

        }
        /// <summary>
        /// Import text file
        /// </summary>
        /// <param></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            string contents = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text file..";
            theDialog.Filter = "txt files|*.txt";
            //theDialog.InitialDirectory = @"D:\";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader reader = new StreamReader(File.OpenRead(theDialog.FileName));
                    //txtDisplay.Text = theDialog.FileName;
                    while (!reader.EndOfStream)
                    {
                        contents = reader.ReadToEnd();
                    }
                    txtDisplay.Text = "";
                    txtDisplay.Text = contents;
                    reader.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: Could not read file!!. Original error: " + err.Message);
                }
            }
        }

        /// <summary>
        /// Processes a file drop into display screen
        /// </summary>
        private void txtDisplay_DragDrop(object sender, DragEventArgs e)
        {
            object oFileNames = e.Data.GetData(DataFormats.FileDrop);
            string[] fileNames = (string[])oFileNames;
            string contents = null;

            if (fileNames.Length == 1)
            {
                try
                {
                    StreamReader reader = new StreamReader(File.OpenRead(fileNames[0]));
                    //txtDisplay.Text = theDialog.FileName;
                    while (!reader.EndOfStream)
                    {
                        contents = reader.ReadToEnd();
                    }
                    txtDisplay.Text = "";
                    txtDisplay.Text = contents;
                    reader.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: Could not read file!!. Original error: " + err.Message);
                }
            }
        }

        /// <summary>
        /// Enables drag&drop
        /// </summary>
        private void txtDisplay_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        #endregion

        #region rtbDspData Righ click menu
        /// <summary>
        /// menu cut
        /// </summary>
        /// <param></param>
        void mi_Cut(object sender, EventArgs e)
        {
            txtDisplay.Cut();
        }
        /// <summary>
        /// menu copy
        /// </summary>
        /// <param></param>
        void mi_Copy(object sender, EventArgs e)
        {
            txtDisplay.Copy();
        }
        /// <summary>
        /// menu paste
        /// </summary>
        /// <param></param>
        void mi_Paste(object sender, EventArgs e)
        {
            txtDisplay.Paste();
        }
        /// <summary>
        /// menu clear
        /// </summary>
        /// <param></param>
        void mi_Clear(object sender, EventArgs e)
        {
            txtDisplay.Clear();
        }
        #endregion

        #region Search
        /// <summary>
        /// Search text
        /// </summary>
        /// <param></param>
        bool tbFindChanged = false;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtDisplay != null)
            {
                Range r = tbFindChanged? txtDisplay.Range.Clone(): txtDisplay.Selection.Clone();
                tbFindChanged = false;
                r.End = new Place(txtDisplay[txtDisplay.LinesCount - 1].Count, txtDisplay.LinesCount - 1);
                var pattern = Regex.Escape(txtSearch.Text);
                foreach (var found in r.GetRanges(pattern))
                {
                    found.Inverse();
                    txtDisplay.Selection = found;
                    txtDisplay.DoSelectionVisible();
                    return;
                }
                MessageBox.Show("Find reached the ending point!", "Search Status",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tbFindChanged = true;
            }              
        }

        /// <summary>
        /// Advanced search menu
        /// </summary>
        /// <param></param>
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            txtDisplay.ShowFindDialog();
        }
        #endregion

        #region Write
        /// <summary>
        /// Write data via serial port
        /// </summary>
        /// <param></param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            /*Send data via serial port*/
            GlobalConvert cv = new GlobalConvert();
            bool result = false;
            string ErrMsg = "";
            try
            {
                if (OptionDisp == "Ascii")
                {
                    result = SerialSetting.TransmitString(txtWrite.Text);
                }
                else if (OptionDisp == "Hex")
                {
                    //convert the message to byte array  
                    byte[] newMsg = cv.HexToByte(txtWrite.Text);
                    //send the message to the port  
                    result = SerialSetting.TransmitByte(newMsg);

                    //re-display again
                    if (txtWrite.Text != "")
                    {
                        txtWrite.Text = cv.ByteToHex(newMsg);
                    }

                }
                else
                {
                    ErrMsg = "Please select data type Ascii/Hex";
                }
            }
            catch (Exception ex) {
                ErrMsg = ex.Message;
            }

            if (result == true)
            {
                //timer1.Enabled = true;
                lblTx.BackColor = Color.Red;
                //Timer1Tick = 0;
            }
            else
            {
                if (!string.IsNullOrEmpty(ErrMsg))
                {
                    MessageBox.Show(ErrMsg, "Read/Write Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    /*Port is closed notify*/
                    MessageBox.Show("Serial Port not connect!!!", "Read/Write Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Write data via serial port by enter key
        /// </summary>
        /// <param></param>
        private void txtWrite_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (serialPort1.IsOpen != true) return;  /*check port is connected*/
            GlobalConvert cv = new GlobalConvert();
            bool result = true;
            string ErrMsg = "";

            try
            {
                if (OptionDisp == "Ascii")
                {
                    if (e.KeyChar == (char)13)  /*Enter key*/
                    {
                        // byte[] Message = System.Text.Encoding.ASCII.GetBytes(txtWrite.Text);
                        //serialPort1.Write(Message, 0, Message.Length);
                        //serialPort1.Write("\r\n");
                        result = SerialSetting.TransmitString(txtWrite.Text);

                    }
                    else if (e.KeyChar < 32 || e.KeyChar > 126)  /*check outside ascii range*/
                    {
                        e.Handled = true;
                        e.Handled = e.KeyChar != (char)Keys.Back;  /*delete last character when press Backspace*/
                    }
                    else
                    {
                        //serialPort1.Write(e.KeyChar.ToString());
                        //result = SerialSetting.TransmitString(txtWrite.Text);
                    }
                }
                else if (OptionDisp == "Hex")
                {
                    /*can input only 0-9, a-f, A-F*/
                    if (!(Regex.IsMatch(e.KeyChar.ToString(), "^[0-9a-fA-F]+$")))
                    {
                        e.Handled = true;
                        e.Handled = e.KeyChar != (char)Keys.Back;  /*delete last character when press Backspace*/
                    }
                    else if (e.KeyChar == (char)13)
                    {
                        //convert the message to byte array  
                        byte[] newMsg = cv.HexToByte(txtWrite.Text);
                        //send the message to the port  
                        result = SerialSetting.TransmitByte(newMsg);
                    }

                }
                else
                {
                    ErrMsg = "Please select data type Ascii/Hex";
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }

            if (result == true)
            {
                //timer1.Enabled = true;
                lblTx.BackColor = Color.Red;
                //Timer1Tick = 0;
            }
            else
            {
                if (!string.IsNullOrEmpty(ErrMsg))
                {
                    MessageBox.Show(ErrMsg, "Read/Write Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    /*Port is closed notify*/
                    MessageBox.Show("Serial Port not connect!!!", "Read/Write Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region Mailbox
        /// <summary>
        /// Mailbox
        /// </summary>
        /// <param></param>
        private void btnEmail_Click(object sender, EventArgs e)
        {
            string ContactInfo = "";
            ContactInfo = "Pairot Sukhirun\n";
            ContactInfo += "Software Design Engineer\n";
            ContactInfo += "Toshiba Carrier (Thailand)\n";
            ContactInfo += "Email: pairot.sukhirun@tctc.co.jp\n";
            MessageBox.Show(ContactInfo, "Contact information",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Notification message
        /// </summary>
        /// <param></param>
        private void btnNotification_Click(object sender, EventArgs e)
        {
            string ReleaseHistory = "";
            ReleaseHistory = "Serial Data Monitor V1.0\n";
            ReleaseHistory += "Release data : 09-May-2020\n";
            ReleaseHistory += "Change point : First Making\n";
            ReleaseHistory += "Author : Pairot S.\n";
            MessageBox.Show(ReleaseHistory, "Version information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Print
        /// <summary>
        /// Print
        /// </summary>
        /// <param></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        /// <summary>
        /// Print document
        /// </summary>
        /// <param></param>
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtDisplay.Text, new System.Drawing.Font("Courier New", 12.0F), Brushes.Black, new PointF(100,100));
        }
        #endregion

        // EOF
    }
}
