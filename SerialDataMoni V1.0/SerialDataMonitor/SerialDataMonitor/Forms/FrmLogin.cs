using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialDataMonitor.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load event
        /// </summary>
        /// <param></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        /// <summary>
        /// Load display theme
        /// </summary>
        /// <param></param>
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
            btnClear.BackColor = ThemeColor.PrimaryColor;
            btnClear.ForeColor = Color.White;
            btnClear.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnLogin.BackColor = ThemeColor.PrimaryColor;
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            btnRegister.BackColor = ThemeColor.PrimaryColor;
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

            pnlEmail.BackColor = ThemeColor.PrimaryColor;
            pnlPassword.BackColor = ThemeColor.PrimaryColor;
            pnlUserName.BackColor = ThemeColor.PrimaryColor;

            txtEmail.ForeColor = ThemeColor.PrimaryColor;
            txtPassword.ForeColor = ThemeColor.PrimaryColor;
            txtUserName.ForeColor = ThemeColor.PrimaryColor;

            lblLoginWith.ForeColor = ThemeColor.PrimaryColor;
        }
        /// <summary>
        /// LClrar data
        /// </summary>
        /// <param></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
        }
    }
}
