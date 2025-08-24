using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Keyboard;

namespace RonilaAccountingSoftware.myForms
{
    public partial class Main : Telerik.WinControls.UI.RadForm
    {
        myClass.UtilityClass fun = new myClass.UtilityClass();
        public Main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void menuUnitInfo_Click(object sender, EventArgs e)
        {
            myForms.DefineUnits f = new DefineUnits();
            f.MdiParent = this;
            f.Show();


        }

        private void menuSupplier_Click(object sender, EventArgs e)
        {
            SupplierInfo f = new SupplierInfo();
            f.MdiParent = this;
            f.Show();
        }

        private void menuCustomer_Click(object sender, EventArgs e)
        {
            CustomerInfo f = new CustomerInfo();
            f.MdiParent = this;
            f.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lbl_user_name.Text = UtilityClass.Username;
            string date = fun.today();
            string[] d = date.Split('/');
            lbl_date.Text = fun.day_of_week() + " " + Convert.ToInt32(d[2]) + " " + fun.GetPersianMonthName(Convert.ToInt32(d[1])) + " " + d[0];
        }

        private void menu_defineStore_Click(object sender, EventArgs e)
        {
            DefineStore f = new DefineStore();
            f.MdiParent = this;
            f.Show();
        }

        private void menu_goodsGroup_Click(object sender, EventArgs e)
        {
            DefineGoodsGroup f = new DefineGoodsGroup();
            f.MdiParent = this;
            f.Show();
        }

        private void menu_DefineGoods_Click(object sender, EventArgs e)
        {
            DefineGoods f = new DefineGoods();
            f.MdiParent = this;
            f.Show();
        }

        private void menu_EnteGoodsToStore_Click(object sender, EventArgs e)
        {
            StoreInput f= new StoreInput();
            f.MdiParent = this;
            f.Show();
        }
    }
}
