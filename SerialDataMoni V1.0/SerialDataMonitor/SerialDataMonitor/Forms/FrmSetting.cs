using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports; /*For serial port control setting*/

namespace SerialDataMonitor.Forms
{
    public partial class FrmSetting : Form
    {
        public DataSetting Setting { get; set; }               // Serial boject class (from SerialPortSetting.cs)
        private DialogResult L_result;
        public delegate void callback_data(DialogResult result, DataSetting setting);
        public event callback_data get_data_callback;

        public FrmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            LoadTheme();

            L_result = DialogResult.Cancel;                       // initial custom dialog result

            /*Initial setting comport get from backup data first*/
            SetComPortName();                           // Port name configuration 
            if (BackupData.Baudrate > 0) cmbSettingBaudrate.Text = BackupData.Baudrate.ToString();
            else cmbSettingBaudrate.Text = "9600";              // Baudrate init

            if (BackupData.DataBits > 0) cmbSettingDataBits.Text = BackupData.DataBits.ToString();
            else cmbSettingDataBits.Text = "8";                 // Data Bits init

            if (BackupData.Parity != Parity.None) cmbSettingParity.Text = BackupData.Parity.ToString();
            else cmbSettingParity.Text = "None";                // Parity bits init

            if (BackupData.StopBits != StopBits.None) cmbSettingStopBit.Text = BackupData.StopBits.ToString();
            else cmbSettingStopBit.Text = "One";                // Stop bit init

            if (!string.IsNullOrEmpty(BackupData.FontNumberColor))
                cmbSettingFontColor.Text = BackupData.FontNumberColor;
            else cmbSettingFontColor.Text = "Margenta";

            if (!string.IsNullOrEmpty(BackupData.FontTextColor1))
                txtTextColor1.Text = BackupData.FontTextColor1;

            if (!string.IsNullOrEmpty(BackupData.FontTextColor2))
                txtTextColor2.Text = BackupData.FontTextColor2;

            if (!string.IsNullOrEmpty(BackupData.FontTextColor3))
                txtTextColor3.Text = BackupData.FontTextColor3;

            if (!string.IsNullOrEmpty(BackupData.FontTextColor4))
                txtTextColor4.Text = BackupData.FontTextColor4;

            if (!string.IsNullOrEmpty(BackupData.FontTextColor5))
                txtTextColor5.Text = BackupData.FontTextColor5;

            if (!string.IsNullOrEmpty(BackupData.FontTextColor6))
                txtTextColor6.Text = BackupData.FontTextColor6;

            if (!string.IsNullOrEmpty(BackupData.FontTextColor7))
                txtTextColor7.Text = BackupData.FontTextColor7;

            if (!string.IsNullOrEmpty(BackupData.FontTextColor8))
                txtTextColor8.Text = BackupData.FontTextColor8;

            if (BackupData.DispScroll == true) chkDispScroll.Checked = true;
            else chkDispScroll.Checked = false;
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            btnRefreshComport.BackColor = ThemeColor.PrimaryColor;
            btnRefreshComport.ForeColor = Color.White;
            btnRefreshComport.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnResetFontStyle.BackColor = ThemeColor.PrimaryColor;
            btnResetFontStyle.ForeColor = Color.White;
            btnResetFontStyle.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            lblComport.ForeColor  = ThemeColor.PrimaryColor;
            lblBaudrate.ForeColor = ThemeColor.PrimaryColor;
            lblDatabit.ForeColor  = ThemeColor.PrimaryColor;
            lblParity.ForeColor   = ThemeColor.PrimaryColor;
            lblStopbit.ForeColor  = ThemeColor.PrimaryColor;

            lblFontNumber.ForeColor = ThemeColor.PrimaryColor;
            lblTextColor1.ForeColor = ThemeColor.PrimaryColor;
            lblTextColor2.ForeColor = ThemeColor.PrimaryColor;
            lblTextColor3.ForeColor = ThemeColor.PrimaryColor;
            lblTextColor4.ForeColor = ThemeColor.PrimaryColor;

            lblScroll.ForeColor    = ThemeColor.PrimaryColor;
            chkDispScroll.CheckedOnColor = ThemeColor.PrimaryColor;

            cmbSettingBaudrate.BackColor = ThemeColor.PrimaryColor;
            cmbSettingBaudrate.ForeColor = Color.White;

            cmbSettingComPort.BackColor = ThemeColor.PrimaryColor;
            cmbSettingComPort.ForeColor = Color.White;

            cmbSettingDataBits.BackColor = ThemeColor.PrimaryColor;
            cmbSettingDataBits.ForeColor = Color.White;

            cmbSettingParity.BackColor = ThemeColor.PrimaryColor;
            cmbSettingParity.ForeColor = Color.White;

            cmbSettingStopBit.BackColor = ThemeColor.PrimaryColor;
            cmbSettingStopBit.ForeColor = Color.White;

            cmbSettingFontColor.BackColor = Color.Magenta;
            cmbSettingFontColor.ForeColor = Color.White;

            groupBoxSerial.ForeColor     = ThemeColor.PrimaryColor;
            groupBoxFont.ForeColor       = ThemeColor.PrimaryColor;

            chkDispScroll.BackColor     = ThemeColor.PrimaryColor;
        }

        /*
        Function : SetComPortName
        Detail   : Configuration com port name
        Input    : None
        Output   : None
        History  : 2018-11-10 First written by S.Pairot
        */
        public void SetComPortName()
        {
            /*Serial Comport configuration*/
            int PortIndex = -1;
            string ComPortName = null;
            string[] ArrayComPortsNames = null;

            ArrayComPortsNames = SerialPort.GetPortNames();

            try
            {
                do
                {
                    PortIndex += 1;
                    cmbSettingComPort.Items.Add(ArrayComPortsNames[PortIndex]);  // comboBox add found items
                }
                while (!((ArrayComPortsNames[PortIndex] == ComPortName)
                || (PortIndex == ArrayComPortsNames.GetUpperBound(0))));
                Array.Sort(ArrayComPortsNames);

                /*want to get first out*/
                if (PortIndex == ArrayComPortsNames.GetUpperBound(0))
                {
                    ComPortName = ArrayComPortsNames[0];
                }

                if (BackupData.ComPortName != null)                      // comport last selected?
                {                                                        // 
                    cmbSettingComPort.Text = BackupData.ComPortName;     // display last comport select in comboBox
                }                                                        //
                else
                {                                                        //
                    cmbSettingComPort.Text = ArrayComPortsNames[0];      // First item display
                }

            }
            catch (Exception) { };
        }

        /*
        Function : btnSettingOK_Click
        Detail   : Configuration confirm setting
        Input    : object sender, EventArgs e
        Output   : None
        History  : 2018-11-10 First written by S.Pairot
        */
        private void btnSettingOK_Click(object sender, EventArgs e)
        {
            Setting.ComPortName = Convert.ToString(cmbSettingComPort.Text);                    // Port name configuration 
            Setting.Baudrate = Convert.ToInt32(cmbSettingBaudrate.Text);                       // Baudrate configuration
            Setting.DataBits = Convert.ToInt16(cmbSettingDataBits.Text);                       // Data bit configuration
            Setting.Parity = (Parity)Enum.Parse(typeof(Parity), cmbSettingParity.Text);        // Parity configuration
            Setting.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbSettingStopBit.Text); // Stop bit configuration

            Setting.FontNumberColor = cmbSettingFontColor.Text;                                // Number color
                                                      
            Setting.FontTextColor1 = txtTextColor1.Text;                                       // Font text color
            Setting.FontTextColor2 = txtTextColor2.Text;                                       //
            Setting.FontTextColor3 = txtTextColor3.Text;                                       //
            Setting.FontTextColor4 = txtTextColor4.Text;                                       //
            Setting.FontTextColor5 = txtTextColor5.Text;                                       //
            Setting.FontTextColor6 = txtTextColor6.Text;                                       //
            Setting.FontTextColor7 = txtTextColor7.Text;                                       //
            Setting.FontTextColor8 = txtTextColor8.Text;                                       //

            Setting.DispScroll = chkDispScroll.Checked;                                        //

            L_result = DialogResult.OK;                                                        // set dialog result OK
            get_data_callback(L_result, Setting);
            this.Close();
        }
        /*
        Function : btnSettingCancel_Click
        Detail   : Configuration cancel
        Input    : object sender, EventArgs e
        Output   : None
        History  : 2018-11-10 First written by S.Pairot
        */
        private void btnSettingCancel_Click_1(object sender, EventArgs e)
        {
            L_result = DialogResult.Cancel;              // set dialog result OK
            get_data_callback(L_result, null);
            this.Close();
        }
        /*
        Function : btnSettingFindComPort_Click
        Detail   : Re-scan com port name
        Input    : object sender, EventArgs e
        Output   : None
        History  : 2018-11-10 First written by S.Pairot
        */
        private void btnRefreshComport_Click(object sender, EventArgs e)
        {
            cmbSettingComPort.Items.Clear();          // Clear comport name last store
            SetComPortName();                         // Call main form for re-scan com port change
        }
        /*
        Function : btnResetFontStyle_Click
        Detail   : Reset font setting style
        Input    : object sender, EventArgs e
        Output   : None
        History  : 2018-11-10 First written by S.Pairot
        */
        private void btnResetFontStyle_Click(object sender, EventArgs e)
        {
            txtTextColor1.Text = "";
            txtTextColor2.Text = "";
            txtTextColor3.Text = "";
            txtTextColor4.Text = "";
            txtTextColor5.Text = "";
            txtTextColor6.Text = "";
            txtTextColor7.Text = "";
            txtTextColor8.Text = "";
        }
        /*
        Function : cmbSettingFontColor_SelectedIndexChanged
        Detail   : Number color setting
        Input    : object sender, EventArgs e
        Output   : None
        History  : 2018-11-10 First written by S.Pairot
        */
        private void cmbSettingFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSettingFontColor.Text == "Magenta")
            {
                cmbSettingFontColor.BackColor = Color.Magenta;
            }
            else if (cmbSettingFontColor.Text == "Red")
            {
                cmbSettingFontColor.BackColor = Color.Red;
            }
            else if (cmbSettingFontColor.Text == "Green")
            {
                cmbSettingFontColor.BackColor = Color.Green;
            }
            else if (cmbSettingFontColor.Text == "Blue")
            {
                cmbSettingFontColor.BackColor = Color.Blue;
            }
        }
    }
}
