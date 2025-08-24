using RonilaAccountingSoftware.Models.DBServices;
using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace RonilaAccountingSoftware.myForms
{
    public partial class DefineStore : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.DefineStoreServices _services = new Models.DBServices.DefineStoreServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public DefineStore()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            radGridView1.DataSource = _services.GetAllData();
            txt_StoreName.Focus();
            txt_StoreName.Text =txt_storeDisc.Text= "";
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled=true;
        }
        public Models.DefineStore SetData()
        {
            var info = new Models.DefineStore
            {
                storeName = txt_StoreName.Text,
                storeDisc = txt_storeDisc.Text,
                timeStamp = fun.TimeStamp(),
                userName = UtilityClass.Username,
                id=id
            };
            return info;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_StoreName.Text != "")
            {
               
                if (_services.addData(SetData()))
                {
                    fun.successAlert();
                   
                    BindGrid();
                }
                else
                {
                    fun.failAlert();
                }
            }
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_StoreName.Text != "")
            {
                
                if (_services.editData(SetData()))
                {
                    fun.successAlert();
                    BindGrid();
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
                txt_StoreName.Text = radGridView1.CurrentRow.Cells["storeName"].Value.ToString();
                txt_storeDisc.Text = radGridView1.CurrentRow.Cells["storeDisc"].Value.ToString();
                btn_delete.Enabled = btn_edit.Enabled = true;
                btn_save.Enabled = false;
            }
            catch 
            {
                fun.Alert("لطفا بر روی یکی از ردیف ها کلید کنید",2);
                
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
        }
    }
}
