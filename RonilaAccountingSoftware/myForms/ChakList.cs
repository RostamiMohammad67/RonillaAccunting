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
using Telerik.WinControls.Data;

namespace RonilaAccountingSoftware.myForms
{
    public partial class ChakList : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.ChakServices _service = new Models.DBServices.ChakServices();
        SuppliersServices _SupplierService = new SuppliersServices();
        Models.DBServices.BankAccountServices _services = new Models.DBServices.BankAccountServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public ChakList()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            radGridView1.DataSource = _service.GetAllData();
            txt_numSayadi.Focus();
           
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled=true;
        }
        public bool canDo()
        {
            return false;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (canDo())
            {
               
                if (_service.add(null))
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
           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == fun.Delete_Question())
            {
                if (_service.delete(id))
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
                //txt_unit.Text = radGridView1.CurrentRow.Cells["unitName"].Value.ToString();
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
            //------------------------------------------------------------------
            cbx_Supplier.DataSource = _SupplierService.GetspecialColumn();
            cbx_Supplier.ValueMember = "id";
            cbx_Supplier.DisplayMember = "supplierName";
            cbx_Supplier.AutoFilter = true;
            FilterDescriptor filter = new FilterDescriptor();
            filter.PropertyName = cbx_Supplier.DisplayMember;
            filter.Operator = FilterOperator.Contains;
            cbx_Supplier.EditorControl.MasterTemplate.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
            cbx_Supplier.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbx_Supplier.DropDownMinSize = new Size(300, 300);
            cbx_Supplier.MultiColumnComboBoxElement.TextChanged += (s, p) =>
            {
                filter.Value = cbx_Supplier.MultiColumnComboBoxElement.Text;
            };
            cbx_Supplier.EditorControl.Columns["id"].HeaderText = "کد فروشنده";
            cbx_Supplier.EditorControl.Columns["id"].Width = 80;
            cbx_Supplier.EditorControl.Columns["supplierName"].HeaderText = "نام فروشنده";
            cbx_Supplier.EditorControl.Columns["supplierName"].Width = 220;
            //------------------------------------------------------------------
        }
        private void NextTab(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
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
