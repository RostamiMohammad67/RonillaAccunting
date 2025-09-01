using RonilaAccountingSoftware.Models.DBServices;
using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Sparkline;

namespace RonilaAccountingSoftware.myForms
{
    public partial class StoreInput : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.StoreInputServices _services = new Models.DBServices.StoreInputServices();
        SuppliersServices _SupplierService = new SuppliersServices();
        DefineGoodsServices _GoodsService = new DefineGoodsServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public StoreInput()
        {
            InitializeComponent();
        }
        public int CreateDocNumber()
        {
            return (_services.GetMaxDocNumber() + 1);
        }
        public void BindGrid()
        {
            int.TryParse(txt_docNumber.Text, out var doc_number);
            radGridView1.DataSource = _services.getDataByDocNumber(doc_number);
            txt_goodsCode.Focus();
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled = true;
        }
        public void ClearData()
        {
            txt_goodsCode.Text = txt_count.Text = txt_BuyPrice.Text = txt_sellPrice.Text = "";
            txt_shamsiExpireDate.Text = txt_miladiExpireDate.Text = txt_miladiProductionDate.Text = txt_shamsiProductionDate.Text = "";
        }
        public void ClearHeader()
        {
            txt_factorNumber.Text = cbx_Supplier.Text = txt_BuyDate.Text = txt_Disc.Text = "";
        }
        public bool canDo()
        {
            if (_GoodsService.getGoodsCountByCode(txt_goodsCode.Text) <= 0)
            {
                fun.Alert("کد کالای وارد شده اشتباه می باشد", 3);
                return false;
            }

            if (txt_docNumber.Text != "" && txt_factorNumber.Text != "" && cbx_Supplier.SelectedIndex > -1
                && txt_goodsCode.Text != "" && cbx_goodsName.SelectedIndex > -1)
            {

                return true;
            }
            fun.Alert("لطفا داده ها را به صورت کامل وارد کنید", 3);
            return false;
        }
        public Models.StoreInput Setdata()
        {

            int.TryParse(txt_docNumber.Text, out var docNumber);
            int.TryParse(cbx_Supplier.SelectedValue.ToString(), out var SupplierCode);
            double.TryParse(txt_count.ToString(), out var GoodsCount);
            double.TryParse(txt_BuyPrice.Text, out var BuyPrice);
            double.TryParse(txt_sellPrice.Text, out var SellPrice);
            int.TryParse(txt_alarmDay.Text, out var alarmDay);
            string alarm_date = "";
            try
            {
                alarm_date = fun.AddDate(txt_shamsiExpireDate.Text, alarmDay * (-1));
            }
            catch
            {

            }
            string shamsi_p = "", miladi_p = "", shamsi_e = "", miladi_e = "";
            if (txt_shamsiProductionDate.Text.Contains("_")) { shamsi_p = txt_shamsiProductionDate.Text.Replace("_", "").Replace("/", ""); } else { shamsi_p = txt_shamsiProductionDate.Text; }
            if (txt_miladiProductionDate.Text.Contains("_")) { miladi_p = txt_miladiProductionDate.Text.Replace("_", "").Replace("/", ""); } else { miladi_p = txt_miladiProductionDate.Text; }
            if (txt_shamsiExpireDate.Text.Contains("_")) { shamsi_e= txt_shamsiExpireDate.Text.Replace("_", "").Replace("/", ""); } else { shamsi_e = txt_shamsiExpireDate.Text; }
            if (txt_miladiExpireDate.Text.Contains("_")) { miladi_e= txt_miladiExpireDate.Text.Replace("_", "").Replace("/", ""); } else { miladi_e = txt_miladiExpireDate.Text; }
            var info = new Models.StoreInput
                {

                    storeInputDocNumber = docNumber,
                    storeInputFactorNumber = txt_factorNumber.Text,
                    storeInputSupplierCode = SupplierCode,
                    storeInputBuyDate = txt_BuyDate.Text,
                    storeInputDisc = txt_Disc.Text,
                    storeInputGoodsCode = txt_goodsCode.Text,
                    storeInputCount = GoodsCount,
                    storeInputBuyPrice = BuyPrice,
                    storeInputSellPrice = SellPrice,
                    storeInputShamsiProductionDate = shamsi_p,
                    storeInputMiladiProductionDate = miladi_p,
                    storeInputShamsiExpireDate = shamsi_e,
                    storeInputMiladiExpireDate = miladi_e,
                    storeInputAlarmDay = alarmDay,
                    storeInputAlarmDate = alarm_date,
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

                if (_services.editData(Setdata()))
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
                txt_docNumber.Text = radGridView1.CurrentRow.Cells["storeInputDocNumber"].Value.ToString();
                txt_factorNumber.Text = radGridView1.CurrentRow.Cells["storeInputFactorNumber"].Value.ToString();
                int.TryParse(radGridView1.CurrentRow.Cells["storeInputSupplierCode"].Value.ToString(),out var storeInputSupplierCode);
                cbx_Supplier.SelectedValue = storeInputSupplierCode;
                
                
                txt_BuyDate.Text = radGridView1.CurrentRow.Cells["storeInputBuyDate"].Value.ToString();
                txt_Disc.Text = radGridView1.CurrentRow.Cells["storeInputDisc"].Value.ToString();
                txt_goodsCode.Text = radGridView1.CurrentRow.Cells["storeInputGoodsCode"].Value.ToString();
                txt_goodsCode.Focus();
                txt_factorNumber.Focus();


                txt_count.Text = radGridView1.CurrentRow.Cells["storeInputCount"].Value.ToString();
                txt_BuyPrice.Text = radGridView1.CurrentRow.Cells["storeInputBuyPrice"].Value.ToString();
                txt_sellPrice.Text = radGridView1.CurrentRow.Cells["storeInputSellPrice"].Value.ToString();
                txt_shamsiProductionDate.Text = radGridView1.CurrentRow.Cells["storeInputShamsiProductionDate"].Value.ToString();
                txt_miladiProductionDate.Text = radGridView1.CurrentRow.Cells["storeInputMiladiProductionDate"].Value.ToString();
                txt_shamsiExpireDate.Text = radGridView1.CurrentRow.Cells["storeInputShamsiExpireDate"].Value.ToString();
                txt_miladiExpireDate.Text = radGridView1.CurrentRow.Cells["storeInputMiladiExpireDate"].Value.ToString();
                txt_alarmDay.Text = radGridView1.CurrentRow.Cells["storeInputAlarmDay"].Value.ToString();



                btn_delete.Enabled = btn_edit.Enabled = true;
                btn_save.Enabled = false;
            }
            catch
            {
                fun.Alert("لطفا بر روی یکی از دریف ها کلید کنید", 2);

            }

        }

        private void DefineUnits_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------
            txt_fromDate.Text = txt_toDate.Text = fun.today();
            cbx_Supplier.Focus();
            //----------------------------------------------------------------
            txt_docNumber.Text = CreateDocNumber().ToString();
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
            var goodsInfo = _GoodsService.GetspecialColumn();
            cbx_goodsName.DataSource = goodsInfo;
            cbx_goodsName.ValueMember = "id";
            cbx_goodsName.DisplayMember = "goodsName";
            cbx_goodsName.AutoFilter = true;
            FilterDescriptor goods_filer = new FilterDescriptor();
            goods_filer.PropertyName = cbx_Supplier.DisplayMember;
            goods_filer.Operator = FilterOperator.Contains;
            cbx_goodsName.EditorControl.MasterTemplate.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
            cbx_goodsName.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.Append;
            cbx_goodsName.DropDownMinSize = new Size(300, 300);
            cbx_goodsName.MultiColumnComboBoxElement.TextChanged += (s, p) =>
            {
                goods_filer.Value = cbx_Supplier.MultiColumnComboBoxElement.Text;
            };
            cbx_goodsName.EditorControl.Columns["id"].IsVisible = false;
            cbx_goodsName.EditorControl.Columns["goodsCode"].HeaderText = "کد کالا";
            cbx_goodsName.EditorControl.Columns["goodsCode"].Width = 80;
            cbx_goodsName.EditorControl.Columns["goodsName"].HeaderText = "نام فروشنده";
            cbx_goodsName.EditorControl.Columns["goodsName"].Width = 220;
            //----------------------------------------------------------------------
            txt_BuyDate.Text = fun.today();

        }


        private void btn_refresh_Click(object sender, EventArgs e)
        {
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled = true;
            ClearData();
        }

        private void NextTab(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txt_birthDate_Click(object sender, EventArgs e)
        {
            txt_BuyDate.SelectionStart = 0;
        }
        private void txt_shamsiProductionDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txt_miladiProductionDate.Text = fun.Shamsi2MiladiString(txt_shamsiProductionDate.Text).ToString();
            }
            catch
            {
            }
        }

        private void txt_miladiProductionDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_shamsiProductionDate.Text.Replace("_", "").Replace("/", "") == "")
                {
                    txt_shamsiProductionDate.Text = fun.Miladi2Shamsi(txt_miladiProductionDate.Text).ToString();
                }

            }
            catch
            {
            }
        }

        private void txt_shamsiExpireDate_Leave(object sender, EventArgs e)
        {
            try
            {
                txt_miladiExpireDate.Text = fun.Shamsi2MiladiString(txt_shamsiExpireDate.Text).ToString();
            }
            catch
            {
            }
        }

        private void txt_miladiExpireDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txt_shamsiExpireDate.Text.Replace("_", "").Replace("/", "") == "")
                {
                    txt_shamsiExpireDate.Text = fun.Miladi2Shamsi(txt_miladiExpireDate.Text).ToString();
                }

            }
            catch
            {

            }
        }
        private void cbx_Supplier_Leave(object sender, EventArgs e)
        {
            int.TryParse(cbx_Supplier.SelectedValue.ToString(), out var SupplierId);
            //txt_factorNumber.Text=(_services.GetMaxIdBySupplier(SupplierId)+1).ToString();
        }

        private void txt_goodsCode_Leave(object sender, EventArgs e)
        {
            var res = _GoodsService.getGoodsByCode(txt_goodsCode.Text);
            if (res.Count > 0)
            {
                cbx_goodsName.SelectedValue = res[0].id;
            }
        }

        private void cbx_goodsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(cbx_goodsName.SelectedValue.ToString(), out var GoodsCode);
            var res = _GoodsService.getDataById(GoodsCode);
            if (res.Count > 0)
            {
                txt_goodsCode.Text = res[0].goodsCode.ToString();
            }
        }

        private void btn_searchDocNumber_Click(object sender, EventArgs e)
        {
            int.TryParse(txt_searchDocNumber.Text, out var docNumber);
            radGridView1.DataSource = _services.getDataByDocNumber(docNumber);
        }

        private void txt_factorNumber_Leave(object sender, EventArgs e)
        {
            int.TryParse(cbx_Supplier.SelectedValue.ToString(), out var SupplierCode);
            radGridView1.DataSource = _services.getDataBySupplierFactorNumber(SupplierCode, txt_factorNumber.Text);
        }

        private void txt_addPercent_Leave(object sender, EventArgs e)
        {
            double.TryParse(txt_BuyPrice.Text, out double BuyPrice);
            double.TryParse(txt_addPercent.Text, out var addpercent);
            txt_sellPrice.Text = (BuyPrice + (BuyPrice * (addpercent / 100))).ToString();
        }

        private void btn_showData_Click(object sender, EventArgs e)
        {
            radGridView1.DataSource = _services.getDataByDate(txt_fromDate.Text, txt_toDate.Text);


        }

        private void btn_newFactor_Click(object sender, EventArgs e)
        {
            DefineUnits_Load(sender, e);
        }

        private void btn_addCheck_Click(object sender, EventArgs e)
        {
            ChakList f=new ChakList();
            f.ShowDialog();
        }
    }
}
