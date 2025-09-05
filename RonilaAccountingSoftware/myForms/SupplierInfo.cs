using RonilaAccountingSoftware.Models;
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
    public partial class SupplierInfo : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.SuppliersServices _services = new Models.DBServices.SuppliersServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
       
        public SupplierInfo()
        {
            InitializeComponent();
            

        }
        public void BindGrid()
        {
            radGridView1.DataSource = _services.GetAllData();
            txt_name.Focus();
           
            
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled=true;
        }
        public void ClearData()
        {
            txt_name.Text = txt_phoneNumber.Text = txt_disc.Text = txt_address.Text = "";
        }
        public bool canDo()
        {
            if(txt_name.Text!="" || txt_name.Text!=null)
            {
                return true;
            }
            return false;
        }
        public Models.SupplierInfo Setdata()
        {
            var info = new Models.SupplierInfo
            {
                supplierName = txt_name.Text,
                supplierPhoneNumber = txt_phoneNumber.Text,
                supplierPhoneNumber2 = txt_phoneNumber2.Text,
                visitorName =txt_visitorphoneName.Text,
                visitorPhoneNumber = txt_visitorphoneNumber2.Text,
                visitorPhoneNumber2 = txt_visitorphoneNumber2.Text,
                supplierAddress = txt_address.Text,
                supplierDisc = txt_disc.Text,
                timeStamp = fun.TimeStamp(),
                userName = UtilityClass.Username,
                id= id,

            };
            return info;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (canDo())
            {
               
                if (_services.addData(Setdata()))
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
             
                if (_services.EditData(Setdata()))
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
                if (_services.deleteData(id))
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
                txt_name.Text = radGridView1.CurrentRow.Cells["supplierName"].Value.ToString();
                txt_phoneNumber.Text = radGridView1.CurrentRow.Cells["supplierPhoneNumber"].Value.ToString();
                txt_address.Text = radGridView1.CurrentRow.Cells["supplierAddress"].Value.ToString();
                txt_disc.Text = radGridView1.CurrentRow.Cells["supplierDisc"].Value.ToString();
                txt_phoneNumber2.Text = radGridView1.CurrentRow.Cells["supplierPhoneNumber2"].Value.ToString();
                txt_visitorphoneName.Text = radGridView1.CurrentRow.Cells["visitorName"].Value.ToString();
                txt_visitorphoneNumber.Text = radGridView1.CurrentRow.Cells["visitorPhoneNumber"].Value.ToString();
                txt_visitorphoneNumber2.Text = radGridView1.CurrentRow.Cells["visitorPhoneNumber2"].Value.ToString();
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
    }
}
