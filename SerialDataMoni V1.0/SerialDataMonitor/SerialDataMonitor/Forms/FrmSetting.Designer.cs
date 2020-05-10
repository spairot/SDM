namespace SerialDataMonitor.Forms
{
    partial class FrmSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.btnRefreshComport = new System.Windows.Forms.Button();
            this.cmbSettingStopBit = new System.Windows.Forms.ComboBox();
            this.cmbSettingParity = new System.Windows.Forms.ComboBox();
            this.cmbSettingDataBits = new System.Windows.Forms.ComboBox();
            this.cmbSettingBaudrate = new System.Windows.Forms.ComboBox();
            this.cmbSettingComPort = new System.Windows.Forms.ComboBox();
            this.lblStopbit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblParity = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblDatabit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblBaudrate = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblComport = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnSettingCancel = new System.Windows.Forms.Button();
            this.btnSettingOK = new System.Windows.Forms.Button();
            this.groupBoxFont = new System.Windows.Forms.GroupBox();
            this.txtTextColor8 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtTextColor7 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtTextColor6 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtTextColor5 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnResetFontStyle = new System.Windows.Forms.Button();
            this.txtTextColor4 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblTextColor4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTextColor3 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblTextColor3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTextColor2 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblTextColor2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTextColor1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.cmbSettingFontColor = new System.Windows.Forms.ComboBox();
            this.lblTextColor1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblFontNumber = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblScroll = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.chkDispScroll = new Bunifu.Framework.UI.BunifuCheckbox();
            this.groupBoxSerial.SuspendLayout();
            this.groupBoxFont.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Controls.Add(this.btnRefreshComport);
            this.groupBoxSerial.Controls.Add(this.cmbSettingStopBit);
            this.groupBoxSerial.Controls.Add(this.cmbSettingParity);
            this.groupBoxSerial.Controls.Add(this.cmbSettingDataBits);
            this.groupBoxSerial.Controls.Add(this.cmbSettingBaudrate);
            this.groupBoxSerial.Controls.Add(this.cmbSettingComPort);
            this.groupBoxSerial.Controls.Add(this.lblStopbit);
            this.groupBoxSerial.Controls.Add(this.lblParity);
            this.groupBoxSerial.Controls.Add(this.lblDatabit);
            this.groupBoxSerial.Controls.Add(this.lblBaudrate);
            this.groupBoxSerial.Controls.Add(this.lblComport);
            this.groupBoxSerial.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSerial.Location = new System.Drawing.Point(30, 12);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(342, 265);
            this.groupBoxSerial.TabIndex = 0;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "Serial port";
            // 
            // btnRefreshComport
            // 
            this.btnRefreshComport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshComport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshComport.FlatAppearance.BorderSize = 0;
            this.btnRefreshComport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshComport.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshComport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnRefreshComport.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshComport.Image")));
            this.btnRefreshComport.Location = new System.Drawing.Point(288, 50);
            this.btnRefreshComport.Name = "btnRefreshComport";
            this.btnRefreshComport.Size = new System.Drawing.Size(40, 30);
            this.btnRefreshComport.TabIndex = 4;
            this.btnRefreshComport.UseVisualStyleBackColor = true;
            this.btnRefreshComport.Click += new System.EventHandler(this.btnRefreshComport_Click);
            // 
            // cmbSettingStopBit
            // 
            this.cmbSettingStopBit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.cmbSettingStopBit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSettingStopBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSettingStopBit.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingStopBit.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbSettingStopBit.FormattingEnabled = true;
            this.cmbSettingStopBit.Items.AddRange(new object[] {
            "One",
            "OnePointFive",
            "Two"});
            this.cmbSettingStopBit.Location = new System.Drawing.Point(125, 197);
            this.cmbSettingStopBit.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSettingStopBit.Name = "cmbSettingStopBit";
            this.cmbSettingStopBit.Size = new System.Drawing.Size(150, 28);
            this.cmbSettingStopBit.TabIndex = 5;
            // 
            // cmbSettingParity
            // 
            this.cmbSettingParity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.cmbSettingParity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSettingParity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSettingParity.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingParity.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbSettingParity.FormattingEnabled = true;
            this.cmbSettingParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cmbSettingParity.Location = new System.Drawing.Point(125, 160);
            this.cmbSettingParity.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSettingParity.Name = "cmbSettingParity";
            this.cmbSettingParity.Size = new System.Drawing.Size(150, 28);
            this.cmbSettingParity.TabIndex = 4;
            // 
            // cmbSettingDataBits
            // 
            this.cmbSettingDataBits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.cmbSettingDataBits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSettingDataBits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSettingDataBits.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingDataBits.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbSettingDataBits.FormattingEnabled = true;
            this.cmbSettingDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbSettingDataBits.Location = new System.Drawing.Point(125, 123);
            this.cmbSettingDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSettingDataBits.Name = "cmbSettingDataBits";
            this.cmbSettingDataBits.Size = new System.Drawing.Size(150, 28);
            this.cmbSettingDataBits.TabIndex = 3;
            // 
            // cmbSettingBaudrate
            // 
            this.cmbSettingBaudrate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.cmbSettingBaudrate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSettingBaudrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSettingBaudrate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingBaudrate.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbSettingBaudrate.FormattingEnabled = true;
            this.cmbSettingBaudrate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cmbSettingBaudrate.Location = new System.Drawing.Point(125, 86);
            this.cmbSettingBaudrate.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSettingBaudrate.Name = "cmbSettingBaudrate";
            this.cmbSettingBaudrate.Size = new System.Drawing.Size(150, 28);
            this.cmbSettingBaudrate.TabIndex = 2;
            // 
            // cmbSettingComPort
            // 
            this.cmbSettingComPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.cmbSettingComPort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSettingComPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSettingComPort.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingComPort.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbSettingComPort.FormattingEnabled = true;
            this.cmbSettingComPort.Location = new System.Drawing.Point(125, 49);
            this.cmbSettingComPort.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSettingComPort.Name = "cmbSettingComPort";
            this.cmbSettingComPort.Size = new System.Drawing.Size(150, 28);
            this.cmbSettingComPort.TabIndex = 1;
            this.cmbSettingComPort.Text = "COM1";
            // 
            // lblStopbit
            // 
            this.lblStopbit.AutoSize = true;
            this.lblStopbit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopbit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblStopbit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStopbit.Location = new System.Drawing.Point(12, 199);
            this.lblStopbit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStopbit.Name = "lblStopbit";
            this.lblStopbit.Size = new System.Drawing.Size(92, 21);
            this.lblStopbit.TabIndex = 0;
            this.lblStopbit.Text = "Stop bits :";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblParity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblParity.Location = new System.Drawing.Point(12, 162);
            this.lblParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(65, 21);
            this.lblParity.TabIndex = 0;
            this.lblParity.Text = "Parity :";
            // 
            // lblDatabit
            // 
            this.lblDatabit.AutoSize = true;
            this.lblDatabit.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblDatabit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDatabit.Location = new System.Drawing.Point(12, 125);
            this.lblDatabit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabit.Name = "lblDatabit";
            this.lblDatabit.Size = new System.Drawing.Size(98, 21);
            this.lblDatabit.TabIndex = 0;
            this.lblDatabit.Text = "Data bits :";
            // 
            // lblBaudrate
            // 
            this.lblBaudrate.AutoSize = true;
            this.lblBaudrate.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaudrate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblBaudrate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBaudrate.Location = new System.Drawing.Point(12, 89);
            this.lblBaudrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudrate.Name = "lblBaudrate";
            this.lblBaudrate.Size = new System.Drawing.Size(99, 21);
            this.lblBaudrate.TabIndex = 0;
            this.lblBaudrate.Text = "Baudrate :";
            // 
            // lblComport
            // 
            this.lblComport.AutoSize = true;
            this.lblComport.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblComport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblComport.Location = new System.Drawing.Point(12, 52);
            this.lblComport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblComport.Name = "lblComport";
            this.lblComport.Size = new System.Drawing.Size(100, 21);
            this.lblComport.TabIndex = 0;
            this.lblComport.Text = "Com port :";
            // 
            // btnSettingCancel
            // 
            this.btnSettingCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettingCancel.FlatAppearance.BorderSize = 0;
            this.btnSettingCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingCancel.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettingCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnSettingCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnSettingCancel.Image")));
            this.btnSettingCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettingCancel.Location = new System.Drawing.Point(797, 454);
            this.btnSettingCancel.Name = "btnSettingCancel";
            this.btnSettingCancel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSettingCancel.Size = new System.Drawing.Size(150, 50);
            this.btnSettingCancel.TabIndex = 1;
            this.btnSettingCancel.Text = "      Cancel";
            this.btnSettingCancel.UseVisualStyleBackColor = true;
            this.btnSettingCancel.Click += new System.EventHandler(this.btnSettingCancel_Click_1);
            // 
            // btnSettingOK
            // 
            this.btnSettingOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettingOK.FlatAppearance.BorderSize = 0;
            this.btnSettingOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettingOK.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettingOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnSettingOK.Image = ((System.Drawing.Image)(resources.GetObject("btnSettingOK.Image")));
            this.btnSettingOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettingOK.Location = new System.Drawing.Point(957, 454);
            this.btnSettingOK.Name = "btnSettingOK";
            this.btnSettingOK.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSettingOK.Size = new System.Drawing.Size(140, 50);
            this.btnSettingOK.TabIndex = 2;
            this.btnSettingOK.Text = "      OK";
            this.btnSettingOK.UseVisualStyleBackColor = true;
            this.btnSettingOK.Click += new System.EventHandler(this.btnSettingOK_Click);
            // 
            // groupBoxFont
            // 
            this.groupBoxFont.Controls.Add(this.chkDispScroll);
            this.groupBoxFont.Controls.Add(this.lblScroll);
            this.groupBoxFont.Controls.Add(this.txtTextColor8);
            this.groupBoxFont.Controls.Add(this.txtTextColor7);
            this.groupBoxFont.Controls.Add(this.txtTextColor6);
            this.groupBoxFont.Controls.Add(this.txtTextColor5);
            this.groupBoxFont.Controls.Add(this.btnResetFontStyle);
            this.groupBoxFont.Controls.Add(this.txtTextColor4);
            this.groupBoxFont.Controls.Add(this.lblTextColor4);
            this.groupBoxFont.Controls.Add(this.txtTextColor3);
            this.groupBoxFont.Controls.Add(this.lblTextColor3);
            this.groupBoxFont.Controls.Add(this.txtTextColor2);
            this.groupBoxFont.Controls.Add(this.lblTextColor2);
            this.groupBoxFont.Controls.Add(this.txtTextColor1);
            this.groupBoxFont.Controls.Add(this.cmbSettingFontColor);
            this.groupBoxFont.Controls.Add(this.lblTextColor1);
            this.groupBoxFont.Controls.Add(this.lblFontNumber);
            this.groupBoxFont.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFont.Location = new System.Drawing.Point(378, 12);
            this.groupBoxFont.Name = "groupBoxFont";
            this.groupBoxFont.Size = new System.Drawing.Size(719, 265);
            this.groupBoxFont.TabIndex = 4;
            this.groupBoxFont.TabStop = false;
            this.groupBoxFont.Text = "Font Color";
            // 
            // txtTextColor8
            // 
            this.txtTextColor8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTextColor8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTextColor8.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTextColor8.ForeColor = System.Drawing.Color.Turquoise;
            this.txtTextColor8.HintForeColor = System.Drawing.Color.Turquoise;
            this.txtTextColor8.HintText = "";
            this.txtTextColor8.isPassword = false;
            this.txtTextColor8.LineFocusedColor = System.Drawing.Color.Turquoise;
            this.txtTextColor8.LineIdleColor = System.Drawing.Color.Turquoise;
            this.txtTextColor8.LineMouseHoverColor = System.Drawing.Color.Turquoise;
            this.txtTextColor8.LineThickness = 2;
            this.txtTextColor8.Location = new System.Drawing.Point(410, 217);
            this.txtTextColor8.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTextColor8.Name = "txtTextColor8";
            this.txtTextColor8.Size = new System.Drawing.Size(280, 34);
            this.txtTextColor8.TabIndex = 8;
            this.txtTextColor8.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtTextColor7
            // 
            this.txtTextColor7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTextColor7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTextColor7.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTextColor7.ForeColor = System.Drawing.Color.Orange;
            this.txtTextColor7.HintForeColor = System.Drawing.Color.Orange;
            this.txtTextColor7.HintText = "";
            this.txtTextColor7.isPassword = false;
            this.txtTextColor7.LineFocusedColor = System.Drawing.Color.Orange;
            this.txtTextColor7.LineIdleColor = System.Drawing.Color.Orange;
            this.txtTextColor7.LineMouseHoverColor = System.Drawing.Color.Orange;
            this.txtTextColor7.LineThickness = 2;
            this.txtTextColor7.Location = new System.Drawing.Point(410, 173);
            this.txtTextColor7.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTextColor7.Name = "txtTextColor7";
            this.txtTextColor7.Size = new System.Drawing.Size(280, 34);
            this.txtTextColor7.TabIndex = 7;
            this.txtTextColor7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtTextColor6
            // 
            this.txtTextColor6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTextColor6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTextColor6.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTextColor6.ForeColor = System.Drawing.Color.Gold;
            this.txtTextColor6.HintForeColor = System.Drawing.Color.Gold;
            this.txtTextColor6.HintText = "";
            this.txtTextColor6.isPassword = false;
            this.txtTextColor6.LineFocusedColor = System.Drawing.Color.Gold;
            this.txtTextColor6.LineIdleColor = System.Drawing.Color.Gold;
            this.txtTextColor6.LineMouseHoverColor = System.Drawing.Color.Gold;
            this.txtTextColor6.LineThickness = 2;
            this.txtTextColor6.Location = new System.Drawing.Point(410, 129);
            this.txtTextColor6.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTextColor6.Name = "txtTextColor6";
            this.txtTextColor6.Size = new System.Drawing.Size(280, 34);
            this.txtTextColor6.TabIndex = 6;
            this.txtTextColor6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtTextColor5
            // 
            this.txtTextColor5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTextColor5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTextColor5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTextColor5.ForeColor = System.Drawing.Color.DarkViolet;
            this.txtTextColor5.HintForeColor = System.Drawing.Color.DarkViolet;
            this.txtTextColor5.HintText = "";
            this.txtTextColor5.isPassword = false;
            this.txtTextColor5.LineFocusedColor = System.Drawing.Color.DarkViolet;
            this.txtTextColor5.LineIdleColor = System.Drawing.Color.DarkViolet;
            this.txtTextColor5.LineMouseHoverColor = System.Drawing.Color.DarkViolet;
            this.txtTextColor5.LineThickness = 2;
            this.txtTextColor5.Location = new System.Drawing.Point(410, 85);
            this.txtTextColor5.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTextColor5.Name = "txtTextColor5";
            this.txtTextColor5.Size = new System.Drawing.Size(280, 34);
            this.txtTextColor5.TabIndex = 5;
            this.txtTextColor5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnResetFontStyle
            // 
            this.btnResetFontStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetFontStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFontStyle.FlatAppearance.BorderSize = 0;
            this.btnResetFontStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFontStyle.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetFontStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.btnResetFontStyle.Image = ((System.Drawing.Image)(resources.GetObject("btnResetFontStyle.Image")));
            this.btnResetFontStyle.Location = new System.Drawing.Point(282, 50);
            this.btnResetFontStyle.Name = "btnResetFontStyle";
            this.btnResetFontStyle.Size = new System.Drawing.Size(40, 30);
            this.btnResetFontStyle.TabIndex = 9;
            this.btnResetFontStyle.UseVisualStyleBackColor = true;
            this.btnResetFontStyle.Click += new System.EventHandler(this.btnResetFontStyle_Click);
            // 
            // txtTextColor4
            // 
            this.txtTextColor4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTextColor4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTextColor4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTextColor4.ForeColor = System.Drawing.Color.Peru;
            this.txtTextColor4.HintForeColor = System.Drawing.Color.Peru;
            this.txtTextColor4.HintText = "";
            this.txtTextColor4.isPassword = false;
            this.txtTextColor4.LineFocusedColor = System.Drawing.Color.Peru;
            this.txtTextColor4.LineIdleColor = System.Drawing.Color.Peru;
            this.txtTextColor4.LineMouseHoverColor = System.Drawing.Color.Peru;
            this.txtTextColor4.LineThickness = 2;
            this.txtTextColor4.Location = new System.Drawing.Point(111, 217);
            this.txtTextColor4.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTextColor4.Name = "txtTextColor4";
            this.txtTextColor4.Size = new System.Drawing.Size(280, 34);
            this.txtTextColor4.TabIndex = 4;
            this.txtTextColor4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblTextColor4
            // 
            this.lblTextColor4.AutoSize = true;
            this.lblTextColor4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextColor4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblTextColor4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTextColor4.Location = new System.Drawing.Point(13, 225);
            this.lblTextColor4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextColor4.Name = "lblTextColor4";
            this.lblTextColor4.Size = new System.Drawing.Size(54, 21);
            this.lblTextColor4.TabIndex = 14;
            this.lblTextColor4.Text = "Text :";
            // 
            // txtTextColor3
            // 
            this.txtTextColor3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTextColor3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTextColor3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTextColor3.ForeColor = System.Drawing.Color.Blue;
            this.txtTextColor3.HintForeColor = System.Drawing.Color.Blue;
            this.txtTextColor3.HintText = "";
            this.txtTextColor3.isPassword = false;
            this.txtTextColor3.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtTextColor3.LineIdleColor = System.Drawing.Color.Blue;
            this.txtTextColor3.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtTextColor3.LineThickness = 2;
            this.txtTextColor3.Location = new System.Drawing.Point(111, 173);
            this.txtTextColor3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTextColor3.Name = "txtTextColor3";
            this.txtTextColor3.Size = new System.Drawing.Size(280, 34);
            this.txtTextColor3.TabIndex = 3;
            this.txtTextColor3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblTextColor3
            // 
            this.lblTextColor3.AutoSize = true;
            this.lblTextColor3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextColor3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblTextColor3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTextColor3.Location = new System.Drawing.Point(13, 181);
            this.lblTextColor3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextColor3.Name = "lblTextColor3";
            this.lblTextColor3.Size = new System.Drawing.Size(54, 21);
            this.lblTextColor3.TabIndex = 13;
            this.lblTextColor3.Text = "Text :";
            // 
            // txtTextColor2
            // 
            this.txtTextColor2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTextColor2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTextColor2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTextColor2.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtTextColor2.HintForeColor = System.Drawing.Color.LimeGreen;
            this.txtTextColor2.HintText = "";
            this.txtTextColor2.isPassword = false;
            this.txtTextColor2.LineFocusedColor = System.Drawing.Color.LimeGreen;
            this.txtTextColor2.LineIdleColor = System.Drawing.Color.LimeGreen;
            this.txtTextColor2.LineMouseHoverColor = System.Drawing.Color.LimeGreen;
            this.txtTextColor2.LineThickness = 2;
            this.txtTextColor2.Location = new System.Drawing.Point(111, 129);
            this.txtTextColor2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTextColor2.Name = "txtTextColor2";
            this.txtTextColor2.Size = new System.Drawing.Size(280, 34);
            this.txtTextColor2.TabIndex = 2;
            this.txtTextColor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblTextColor2
            // 
            this.lblTextColor2.AutoSize = true;
            this.lblTextColor2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextColor2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblTextColor2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTextColor2.Location = new System.Drawing.Point(13, 137);
            this.lblTextColor2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextColor2.Name = "lblTextColor2";
            this.lblTextColor2.Size = new System.Drawing.Size(54, 21);
            this.lblTextColor2.TabIndex = 12;
            this.lblTextColor2.Text = "Text :";
            // 
            // txtTextColor1
            // 
            this.txtTextColor1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTextColor1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtTextColor1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtTextColor1.ForeColor = System.Drawing.Color.Red;
            this.txtTextColor1.HintForeColor = System.Drawing.Color.Red;
            this.txtTextColor1.HintText = "";
            this.txtTextColor1.isPassword = false;
            this.txtTextColor1.LineFocusedColor = System.Drawing.Color.Red;
            this.txtTextColor1.LineIdleColor = System.Drawing.Color.Red;
            this.txtTextColor1.LineMouseHoverColor = System.Drawing.Color.Red;
            this.txtTextColor1.LineThickness = 2;
            this.txtTextColor1.Location = new System.Drawing.Point(111, 85);
            this.txtTextColor1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTextColor1.Name = "txtTextColor1";
            this.txtTextColor1.Size = new System.Drawing.Size(280, 34);
            this.txtTextColor1.TabIndex = 1;
            this.txtTextColor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cmbSettingFontColor
            // 
            this.cmbSettingFontColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.cmbSettingFontColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSettingFontColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSettingFontColor.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSettingFontColor.ForeColor = System.Drawing.SystemColors.Window;
            this.cmbSettingFontColor.FormattingEnabled = true;
            this.cmbSettingFontColor.Items.AddRange(new object[] {
            "Magenta",
            "Red",
            "Green",
            "Blue"});
            this.cmbSettingFontColor.Location = new System.Drawing.Point(111, 49);
            this.cmbSettingFontColor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSettingFontColor.Name = "cmbSettingFontColor";
            this.cmbSettingFontColor.Size = new System.Drawing.Size(150, 28);
            this.cmbSettingFontColor.TabIndex = 0;
            this.cmbSettingFontColor.Text = "Margenta";
            this.cmbSettingFontColor.SelectedIndexChanged += new System.EventHandler(this.cmbSettingFontColor_SelectedIndexChanged);
            // 
            // lblTextColor1
            // 
            this.lblTextColor1.AutoSize = true;
            this.lblTextColor1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextColor1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblTextColor1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTextColor1.Location = new System.Drawing.Point(13, 93);
            this.lblTextColor1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTextColor1.Name = "lblTextColor1";
            this.lblTextColor1.Size = new System.Drawing.Size(54, 21);
            this.lblTextColor1.TabIndex = 11;
            this.lblTextColor1.Text = "Text :";
            // 
            // lblFontNumber
            // 
            this.lblFontNumber.AutoSize = true;
            this.lblFontNumber.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFontNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblFontNumber.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFontNumber.Location = new System.Drawing.Point(12, 52);
            this.lblFontNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFontNumber.Name = "lblFontNumber";
            this.lblFontNumber.Size = new System.Drawing.Size(86, 21);
            this.lblFontNumber.TabIndex = 10;
            this.lblFontNumber.Text = "Number :";
            // 
            // lblScroll
            // 
            this.lblScroll.AutoSize = true;
            this.lblScroll.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.lblScroll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.lblScroll.Location = new System.Drawing.Point(407, 56);
            this.lblScroll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScroll.Name = "lblScroll";
            this.lblScroll.Size = new System.Drawing.Size(135, 21);
            this.lblScroll.TabIndex = 37;
            this.lblScroll.Text = "Freeze display :";
            // 
            // chkDispScroll
            // 
            this.chkDispScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkDispScroll.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.chkDispScroll.Checked = false;
            this.chkDispScroll.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(91)))), ((int)(((byte)(161)))));
            this.chkDispScroll.ForeColor = System.Drawing.Color.White;
            this.chkDispScroll.Location = new System.Drawing.Point(553, 57);
            this.chkDispScroll.Margin = new System.Windows.Forms.Padding(19, 16, 19, 16);
            this.chkDispScroll.Name = "chkDispScroll";
            this.chkDispScroll.Size = new System.Drawing.Size(20, 20);
            this.chkDispScroll.TabIndex = 36;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1122, 530);
            this.Controls.Add(this.groupBoxFont);
            this.Controls.Add(this.btnSettingOK);
            this.Controls.Add(this.btnSettingCancel);
            this.Controls.Add(this.groupBoxSerial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSetting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxSerial.PerformLayout();
            this.groupBoxFont.ResumeLayout(false);
            this.groupBoxFont.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.ComboBox cmbSettingStopBit;
        private System.Windows.Forms.ComboBox cmbSettingParity;
        private System.Windows.Forms.ComboBox cmbSettingDataBits;
        private System.Windows.Forms.ComboBox cmbSettingBaudrate;
        private System.Windows.Forms.ComboBox cmbSettingComPort;
        private Bunifu.Framework.UI.BunifuCustomLabel lblStopbit;
        private Bunifu.Framework.UI.BunifuCustomLabel lblParity;
        private Bunifu.Framework.UI.BunifuCustomLabel lblDatabit;
        private Bunifu.Framework.UI.BunifuCustomLabel lblBaudrate;
        private Bunifu.Framework.UI.BunifuCustomLabel lblComport;
        private System.Windows.Forms.Button btnSettingCancel;
        private System.Windows.Forms.Button btnSettingOK;
        private System.Windows.Forms.Button btnRefreshComport;
        private System.Windows.Forms.GroupBox groupBoxFont;
        private System.Windows.Forms.ComboBox cmbSettingFontColor;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTextColor1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblFontNumber;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTextColor1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTextColor4;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTextColor4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTextColor3;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTextColor3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTextColor2;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTextColor2;
        private System.Windows.Forms.Button btnResetFontStyle;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTextColor8;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTextColor7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTextColor6;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTextColor5;
        private Bunifu.Framework.UI.BunifuCustomLabel lblScroll;
        private Bunifu.Framework.UI.BunifuCheckbox chkDispScroll;
    }
}