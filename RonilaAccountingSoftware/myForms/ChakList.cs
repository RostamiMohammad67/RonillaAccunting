using RonilaAccountingSoftware.Models;
using RonilaAccountingSoftware.Models.DBServices;
using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace RonilaAccountingSoftware.myForms
{
    public partial class ChakList : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.ChakServices _service = new Models.DBServices.ChakServices();
        Models.DBServices.StoreInputServices _storeInputService = new Models.DBServices.StoreInputServices();
        SuppliersServices _SupplierService = new SuppliersServices();
        Models.DBServices.BankAccountServices _bankAccountService = new Models.DBServices.BankAccountServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        int supplierCode = 0;
        string factorNumbmnber = "";
        //---------------------------------------------------
        public ChakList()
        {
            InitializeComponent();
        }
        public ChakList(int supplierCode, string factorNumbmnber)
        {
            InitializeComponent();

            this.supplierCode = supplierCode;
            this.factorNumbmnber = factorNumbmnber;
        }
        public void clearData()
        {
            txt_Branch.Text = txt_serial.Text = txt_numSayadi.Text = txt_inFace.Text = txt_disc.Text = txt_dateSodor.Text = txt_PasDay.Text = txt_alarmDay.Text = "";
        }
        public void BindGrid()
        {
            radGridView1.DataSource = _service.getDataBySupplierAndFactorNumber(this.supplierCode, this.factorNumbmnber);
            txt_numSayadi.Focus();

            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled = true;
        }
        public bool canDo()
        {
            if (txt_PasDay.Text.Contains("_"))
            {
                fun.Alert("لطفا تاریخ سر رسید چک را به درستی وارد کنید", 3);
                return false;
            }
            if (cbx_accountNumber.SelectedIndex < 0)
            {
                fun.Alert("لطفا حداقل یک حساب بانکی معرفی کنید", 3);
                return false;
            }
            return true;


        }
        public Models.DefineChakInfo Setdata()
        {


            int.TryParse(txt_alarmDay.Text, out var alarmDay);
            int.TryParse(cbx_accountNumber.SelectedValue.ToString(), out var accountNumber);
            int.TryParse(txt_alarmDay.Text, out var chakAlarmDay);
            string alarmDate = fun.AddDate(txt_PasDay.Text, -1 * chakAlarmDay);
            double.TryParse(txt_Price.Text, out var price);
            var info = new Models.DefineChakInfo
            {


                storeInputFactorNumber = lbl_factorNumber.Text,
                storeInputSupplierCode = this.supplierCode,
                chakaccountNumberCode = accountNumber,
                chakAlarmDay = chakAlarmDay,
                chakAlarmDate = alarmDate,
                chakBranch = txt_Branch.Text,
                chakDateSodor = txt_dateSodor.Text,
                chakDisc = txt_disc.Text,
                chakInFace = txt_inFace.Text,
                chakNumSayadi = txt_numSayadi.Text,
                chakPasDay = txt_PasDay.Text,
                chakPrice = price,
                chakSerial = txt_serial.Text,
                //-------------------------------------------
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

                if (_service.add(Setdata()))
                {
                    fun.successAlert();

                    BindGrid();
                    clearData();
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

                if (_service.edit(Setdata()))
                {
                    fun.successAlert();
                    BindGrid();
                    clearData();
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
                //---------------------------------------------------------------------
                txt_numSayadi.Text = radGridView1.CurrentRow.Cells["chakNumSayadi"].Value.ToString();
                txt_serial.Text = radGridView1.CurrentRow.Cells["chakSerial"].Value.ToString();
                txt_Price.Text = radGridView1.CurrentRow.Cells["chakPrice"].Value.ToString();
                txt_dateSodor.Text = radGridView1.CurrentRow.Cells["chakDateSodor"].Value.ToString();
                txt_PasDay.Text = radGridView1.CurrentRow.Cells["chakPasDay"].Value.ToString();
                cbx_accountNumber.SelectedValue= radGridView1.CurrentRow.Cells["chakaccountNumberCode"].Value.ToString();
                txt_inFace.Text = radGridView1.CurrentRow.Cells["chakInFace"].Value.ToString();
                txt_Branch.Text = radGridView1.CurrentRow.Cells["chakBranch"].Value.ToString();
                txt_alarmDay.Text = radGridView1.CurrentRow.Cells["chakAlarmDay"].Value.ToString();
                txt_disc.Text = radGridView1.CurrentRow.Cells["chakDisc"].Value.ToString();

                //---------------------------------------------------------------------

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
            lbl_factorNumber.Text = this.factorNumbmnber;
            var res = _storeInputService.getDataBySupplierFactorNumber(this.supplierCode, this.factorNumbmnber);
            cbx_accountNumber.DataSource = _bankAccountService.GetAllData();
            cbx_accountNumber.ValueMember = "id";
            cbx_accountNumber.DisplayMember = "bankAccountNumber";
            cbx_accountNumber.AutoFilter = true;
            FilterDescriptor filter = new FilterDescriptor();
            filter.PropertyName = cbx_accountNumber.DisplayMember;
            filter.Operator = FilterOperator.Contains;
            cbx_accountNumber.EditorControl.MasterTemplate.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
            cbx_accountNumber.MultiColumnComboBoxElement.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbx_accountNumber.DropDownMinSize = new Size(300, 300);
            cbx_accountNumber.MultiColumnComboBoxElement.TextChanged += (s, p) =>
            {
                filter.Value = cbx_accountNumber.MultiColumnComboBoxElement.Text;
            };
            cbx_accountNumber.EditorControl.Columns["id"].IsVisible = false;
            cbx_accountNumber.EditorControl.Columns["bankShabaNumber"].IsVisible = false;
            cbx_accountNumber.EditorControl.Columns["bandDisc"].IsVisible = false;
            cbx_accountNumber.EditorControl.Columns["userName"].IsVisible = false;
            cbx_accountNumber.EditorControl.Columns["timeStamp"].IsVisible = false;
            cbx_accountNumber.EditorControl.Columns["bankName"].HeaderText = "نام بانک";
            cbx_accountNumber.EditorControl.Columns["bankName"].Width = 100;
            cbx_accountNumber.EditorControl.Columns["bankCartNumber"].HeaderText = "شماره کارت";
            cbx_accountNumber.EditorControl.Columns["bankCartNumber"].Width = 120;
            cbx_accountNumber.EditorControl.Columns["bankName"].HeaderText = "شماره حساب";
            cbx_accountNumber.EditorControl.Columns["bankAccountNumber"].Width = 120;
            if (res.Count > 0)
            {

                lbl_supplierName.Text = res[0].supplierName;

            }
            BindGrid();

            var suplierInfo = _SupplierService.getDataById(this.supplierCode);
            if (suplierInfo.Count > 0)
            {
                lbl_address.Text = suplierInfo[0].supplierPhoneNumber;
                lbl_address.Text = suplierInfo[0].supplierAddress;
            }
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
            clearData();
        }

        private void txt_dateSodor_Click(object sender, EventArgs e)
        {
            txt_dateSodor.SelectionStart = 0;
        }

        private void txt_PasDay_Click(object sender, EventArgs e)
        {
            txt_PasDay.SelectionStart = 0;
        }

       
    }
}
