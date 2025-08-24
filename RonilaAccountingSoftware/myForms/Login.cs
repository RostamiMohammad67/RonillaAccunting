using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.RadToastNotificationManager;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Media;
namespace RonilaAccountingSoftware
{
    public partial class Login : Telerik.WinControls.UI.RadForm
    {
        Models.dbActions.LoginServices login_functions = new Models.dbActions.LoginServices();
        myClass.UtilityClass fun=new myClass.UtilityClass();
        public Login()
        {
            InitializeComponent();

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_userName.Text != "" && txt_password.Text != "")
            {
                //بررسی نام کاربری و رمز عبور جهت ورود به نرم افزار
                if (login_functions.checkLogin(txt_userName.Text, txt_password.Text))
                {
                    this.Visible = false;
                    myForms.Main f=new myForms.Main();
                    f.Show();
                     

                }
                else
                {
                    fun.Alert("نام کاربری یا رمز عبور اشتباه است", 2);
                }
            }
            else
            {
                fun.Alert("لطفا نام کاربری و رمز عبور را وارد کنید",2);
            }
        }

        private void txt_userName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
