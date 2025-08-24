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
    public partial class DefineUnits : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.unitInfoServices unitName = new Models.DBServices.unitInfoServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public DefineUnits()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            radGridView1.DataSource = unitName.GetAllData();
            txt_unit.Focus();
            txt_unit.Text = "";
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled=true;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_unit.Text != "")
            {
                var info = new Models.UnitInfo
                {
                    unitName = txt_unit.Text,
                    timeStamp = fun.TimeStamp(),
                    userName = UtilityClass.Username
                };
                if (unitName.addUnit(info))
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
            if (txt_unit.Text != "")
            {
                var info = new Models.UnitInfo
                {
                    unitName = txt_unit.Text,
                    timeStamp = fun.TimeStamp(),
                    userName = UtilityClass.Username,
                    id = id
                };
                if (unitName.editUnit(info))
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
                if (unitName.deleteUnit(id))
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
                txt_unit.Text = radGridView1.CurrentRow.Cells["unitName"].Value.ToString();
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
        }
    }
}
