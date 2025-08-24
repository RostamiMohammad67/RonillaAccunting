using RonilaAccountingSoftware.Models.DBServices;
using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Sparkline;

namespace RonilaAccountingSoftware.myForms
{
    public partial class CustomerInfo : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.CustomersServices _services = new Models.DBServices.CustomersServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public CustomerInfo()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            radGridView1.DataSource = _services.GetAllCustomerWithReagentInfo();
            txt_name.Focus();
           
            
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled=true;
        }
        public void ClearData()
        {
            txt_name.Text =txt_mobNumber.Text=txt_birthDate.Text=txt_nationalCode.Text= txt_phoneNumber.Text = txt_disc.Text = txt_address.Text = "";
        }
        public bool canDo()
        {
            if(txt_name.Text!="" || txt_name.Text!=null)
            {
                
                return true;
            }
            return false;
        }
        public Models.CustomerInfo Setdata()
        {
            int.TryParse(txt_Reagent.Text, out int ReagentCode);
            var info = new Models.CustomerInfo
            {
                customerName = txt_name.Text,
                customerPhoneNumber = txt_phoneNumber.Text.Trim().Replace("_", ""),
                customer_mobile = txt_mobNumber.Text.Trim().Replace("_", ""),
                customerNationalCode = txt_nationalCode.Text.Trim().Replace("_", ""),
                customerBirthDate = txt_birthDate.Text.Trim().Replace("_", ""),
                customerAddress = txt_address.Text,
                customerDisc = txt_disc.Text,
                ReagentCode = ReagentCode,

                timeStamp = fun.TimeStamp(),
                userName = UtilityClass.Username,
                id = id,

            };
            return info;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (canDo())
            {
               
                if (_services.addCustomer(Setdata()))
                {
                    fun.successAlert();
                   
                    BindGrid();
                    ClearData();
                }
                else
                {
                    fun.failAlert();
                }
            }
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (canDo())
            {
             
                if (_services.EditCustomer(Setdata()))
                {
                    fun.successAlert();
                    BindGrid();
                    ClearData();
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
                if (_services.deleteCustomer(id))
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
                txt_name.Text = radGridView1.CurrentRow.Cells["customerName"].Value.ToString();
                txt_phoneNumber.Text = radGridView1.CurrentRow.Cells["customerPhoneNumber"].Value.ToString();
                txt_mobNumber.Text = radGridView1.CurrentRow.Cells["customer_mobile"].Value.ToString();
                txt_address.Text = radGridView1.CurrentRow.Cells["customerAddress"].Value.ToString();
                txt_disc.Text = radGridView1.CurrentRow.Cells["customerDisc"].Value.ToString();
                txt_birthDate.Text = radGridView1.CurrentRow.Cells["customerBirthDate"].Value.ToString();
                txt_nationalCode.Text = radGridView1.CurrentRow.Cells["customerNationalCode"].Value.ToString();
               int.TryParse( radGridView1.CurrentRow.Cells["ReagentCode"].Value.ToString(),out var Reagentcode);
                txt_Reagent.Text = Reagentcode.ToString();
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

        private void txt_unit_KeyDown(object sender, KeyEventArgs e)
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
            ClearData();
        }

        private void txt_disc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_phoneNumber_Click(object sender, EventArgs e)
        {
            txt_phoneNumber.SelectionStart = 0;
        }

        private void txt_mobNumber_Click(object sender, EventArgs e)
        {
            txt_mobNumber.SelectionStart = 0;
        }

        private void txt_nationalCode_Click(object sender, EventArgs e)
        {
            txt_nationalCode.SelectionStart = 0;
        }

        private void txt_birthDate_Click(object sender, EventArgs e)
        {
            txt_birthDate.SelectionStart = 0;
        }

        private void btn_CustomerList_Click(object sender, EventArgs e)
        {
            CustomerList f = new CustomerList();
            f.ShowDialog();
            lbl_customerName.Text = UtilityClass.Help_code1;
        }

        private void txt_Reagent_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txt_Reagent.Text, out int id);
           var res= _services.getCustomerById(id);
            if(res.Count>0)
            {
                lbl_customerName.Text = res[0].customerName+" - "+ res[0].customerPhoneNumber +" - " + res[0].customer_mobile;
            }
            
        }
    }
}
