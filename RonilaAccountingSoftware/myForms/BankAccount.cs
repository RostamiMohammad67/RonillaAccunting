using RonilaAccountingSoftware.Models.DBServices;
using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace RonilaAccountingSoftware.myForms
{
    public partial class BankAccount : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.BankAccountServices _services = new Models.DBServices.BankAccountServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public BankAccount()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            radGridView1.DataSource = _services.GetAllData();
            txt_bankName.Focus();
            
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled=true;
        }
        public void CleanData()
        {
            txt_bankName.Text = txt_cartNumber.Text = txt_acountNumber.Text = txt_shabaNumber.Text = txt_disc.Text = "";
        }
        public bool canDo()
        {
            if(txt_bankName.Text!="" && !txt_acountNumber.Text.Contains("_"))
            {
                return true;
            }
            return false;
        }
        public Models.DefineBankAccount Setdata()
        {

            var info = new Models.DefineBankAccount
            {
                bankName = txt_bankName.Text,
                bankCartNumber = txt_cartNumber.Text,
                bankAccountNumber = txt_acountNumber.Text,
                bankShabaNumber = txt_shabaNumber.Text,
                bandDisc = txt_disc.Text,
                timeStamp = fun.today(),
                userName = UtilityClass.Username,
                id = id,


            };
            return info;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (canDo())
            {
                
                if (_services.add(Setdata()))
                {
                    fun.successAlert();
                   
                    BindGrid();
                    CleanData();

                }
                else
                {
                    fun.failAlert();
                }
            }
            else
            {
                fun.Alert("لطفا نام بانک و شماره حساب را به صورت کامل وارد کنید",3);
            }
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (canDo())
            {
                
                if (_services.edit(Setdata()))
                {
                    fun.successAlert();
                    BindGrid();
                    CleanData();

                }
                else
                {
                    fun.failAlert();
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == fun.Delete_Question())
            {
                if (_services.delete(id))
                {
                    fun.successDeleteAlert();
                    BindGrid();
                }
                else
                {
                    fun.failAlert();
                }
            }
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(radGridView1.CurrentRow.Cells["id"].Value.ToString());
                txt_bankName.Text = radGridView1.CurrentRow.Cells["bankName"].Value.ToString();
                txt_cartNumber.Text = radGridView1.CurrentRow.Cells["bankCartNumber"].Value.ToString();
                txt_acountNumber.Text = radGridView1.CurrentRow.Cells["bankAccountNumber"].Value.ToString();
                txt_shabaNumber.Text = radGridView1.CurrentRow.Cells["bankShabaNumber"].Value.ToString();
                txt_disc.Text = radGridView1.CurrentRow.Cells["bandDisc"].Value.ToString();
                //-------------------------------------------
                btn_delete.Enabled = btn_edit.Enabled = true;
                btn_save.Enabled = false;
            }
            catch 
            {
                fun.Alert("لطفا بر روی یکی از دریف ها کلید کنید",2);
                
            }
            
        }

        private void DefineUnits_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        private void NextTab(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled = true;
            CleanData();
        }

        private void txt_cartNumber_Click(object sender, EventArgs e)
        {
            txt_cartNumber.SelectionStart = 0;
        }

        private void txt_shabaNumber_Click(object sender, EventArgs e)
        {
            txt_shabaNumber.SelectionStart = 0;
        }
    }
}
