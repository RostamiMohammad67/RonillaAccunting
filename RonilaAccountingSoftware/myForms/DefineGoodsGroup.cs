using RonilaAccountingSoftware.Models.DBServices;
using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace RonilaAccountingSoftware.myForms
{
    public partial class DefineGoodsGroup : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.DefineGoodsGroupServices _services = new Models.DBServices.DefineGoodsGroupServices();
        Models.DBServices.DefineStoreServices Store_Services = new Models.DBServices.DefineStoreServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public DefineGoodsGroup()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            radGridView1.DataSource = _services.GetAllDataWithStoreInfo();
            txt_GoodsGroup.Focus();
            txt_GoodsGroup.Text = txt_goodsGroupDisc.Text = "";
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled = true;
            rad_CDD_StoreID.Enabled = true;
        }
        public Models.DefineGoodsGroup SetData(int Store_id)
        {

            var info = new Models.DefineGoodsGroup
            {
                goodsGroupName = txt_GoodsGroup.Text,
                goodsGroupDisc = txt_goodsGroupDisc.Text,
                storeId = Store_id,
                timeStamp = fun.TimeStamp(),
                userName = UtilityClass.Username,
                id = id
            };
            return info;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            var selectedItems = rad_CDD_StoreID.CheckedItems.OfType<RadCheckedListDataItem>();
            if (txt_GoodsGroup.Text != "" && rad_CDD_StoreID.SelectedValue != null)
            {
                foreach (var item in selectedItems)
                {
                    _services.addData(SetData(Convert.ToInt32(item.Value)));
                }
                fun.successAlert();
                BindGrid();
            }
            else
            {
                fun.Alert("لطفا اطلاعات را به صورت کامل وارد کنید",3);
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            var selectedItems = rad_CDD_StoreID.CheckedItems.OfType<RadCheckedListDataItem>();

            if (txt_GoodsGroup.Text != "" && rad_CDD_StoreID.SelectedValue != null)
            {
                foreach (var item in selectedItems)
                {

                    _services.editData(SetData(Convert.ToInt32(item.Value)));
                   
                }
                fun.successAlert();
                BindGrid();
            }
            else
            {
                fun.Alert("لطفا اطلاعات را به صورت کامل وارد کنید", 3);
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
                //------------------------------------------------------------------------------------------
                int Selected_item =Convert.ToInt32( radGridView1.CurrentRow.Cells["storeId"].Value.ToString());
                foreach (RadCheckedListDataItem items in rad_CDD_StoreID.Items)
                {
                    items.Checked = false;
                    
                }
                var item = rad_CDD_StoreID.Items.OfType<RadCheckedListDataItem>().FirstOrDefault(i => i.Value != null && i.Value.Equals(Selected_item));
                if (item != null)
                {
                    item.Checked = true; // یا item.CheckState = CheckState.Checked;
                }
                //------------------------------------------------------------------------------------------
                txt_GoodsGroup.Text = radGridView1.CurrentRow.Cells["goodsGroupName"].Value.ToString();
                txt_goodsGroupDisc.Text = radGridView1.CurrentRow.Cells["goodsGroupDisc"].Value.ToString();

                rad_CDD_StoreID.Enabled = false;
                btn_delete.Enabled = btn_edit.Enabled = true;
                btn_save.Enabled = false;

            }
            catch
            {
                fun.Alert("لطفا بر روی یکی از ردیف ها کلید کنید", 2);

            }

        }

        private void DefineUnits_Load(object sender, EventArgs e)
        {
            BindGrid();
            //------------------------------------
            var info = Store_Services.GetAllData();
            rad_CDD_StoreID.DataSource = info;
            rad_CDD_StoreID.AutoCompleteDataSource = info;
            rad_CDD_StoreID.DisplayMember = "storeName";
            rad_CDD_StoreID.ValueMember = "id";
            rad_CDD_StoreID.AutoCompleteDataSource = "storeName";
            rad_CDD_StoreID.AutoCompleteValueMember = "id";
            rad_CDD_StoreID.DropDownStyle = RadDropDownStyle.DropDown;
            this.rad_CDD_StoreID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //rad_CDD_StoreID.DropDownListElement.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;


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
            rad_CDD_StoreID.Enabled = true;
        }
    }
}
