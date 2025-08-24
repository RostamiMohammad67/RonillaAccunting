using RonilaAccountingSoftware.Models.DBServices;
using RonilaAccountingSoftware.myClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace RonilaAccountingSoftware.myForms
{
    public partial class DefineGoods : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.DefineGoodsServices _services = new Models.DBServices.DefineGoodsServices();
        Models.DBServices.DefineGoodsGroupServices GoodsGroupService = new DefineGoodsGroupServices();
        Models.DBServices.DefineStoreServices StoreServices = new DefineStoreServices();
        Models.DBServices.unitInfoServices UnitServices = new Models.DBServices.unitInfoServices();

        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public DefineGoods()
        {
            InitializeComponent();
        }
        public void CleadData()
        {
            txt_goodsCode.Text = txt_GoodsName.Text = txt_disc.Text = txt_maxMojodi.Text = "";
            txt_minMojodi.Text = txt_whight.Text = txt_order_point.Text = "";

        }
        public void BindGrid()
        {
            radGridView1.DataSource = _services.GetGoodsStoreGroupUnitInfo();
            txt_goodsCode.Focus();
            btn_delete.Enabled = btn_edit.Enabled = false;
            btn_save.Enabled = true;
            txt_goodsCode.Enabled = true;
        }
        public bool canDo()
        {
           
            if (txt_goodsCode.Text != "" && txt_GoodsName.Text != ""
                && dr_goodsUnit.SelectedIndex > -1 && dr_Store.SelectedIndex > -1
                && dr_goodsGroup.SelectedIndex > -1)
            { 
                return true;
            }
            return false;

        }

        public Models.DefineGood SetData()
        {
            int.TryParse(dr_Store.SelectedValue.ToString(), out var goodsStore);
            int.TryParse(dr_goodsGroup.SelectedValue.ToString(), out var goodsGroup);
            int.TryParse(dr_goodsUnit.SelectedValue.ToString(), out var goodsUnit);
            
            double.TryParse(txt_maxMojodi.Text, out var MaxMojodi);
            double.TryParse(txt_minMojodi.Text, out var minMojodi);
            double.TryParse(txt_order_point.Text, out var orderPoint);
            double.TryParse(txt_whight.Text, out var Weight);
            Boolean goodsActive=true;
            if(!ch_active.Checked)
            {
                goodsActive = false;
            }
            byte[] image=null;
            try
            {
                image = fun.ImageToByteArray(pic_goodsPic.Image);
            }
            catch 
            {
            }
          
            var info = new Models.DefineGood
            {
                goodsCode = txt_goodsCode.Text,
                goodsName = txt_GoodsName.Text,
                goodsDisc = txt_disc.Text,
                goodsGroup = goodsGroup,
                goodsStore = goodsStore,
                goodsUnit = goodsUnit,
                goodsMax = MaxMojodi,
                goodsMin = minMojodi,
                goodsWeight = Weight,
                goosOrderPoint = orderPoint,
                goodsPic = image,
                isActive = goodsActive,
                timeStamp = fun.TimeStamp(),
                userName = UtilityClass.Username,

                id = id
            };
            return info;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (canDo())
            {
                if (_services.getGoodsCountByCode(txt_goodsCode.Text) >= 1)
                {
                    if (fun.Q_message("کد وارد شده تکراری است آیا می خواهید یک کد خودکار به کالا اختصاص داده شود یا خیر؟") == DialogResult.Yes)
                    {
                        Random r=new Random();
                        txt_goodsCode.Text = r.Next(9999,9999999).ToString();
                    }
                    else
                    {
                        fun.Alert("لطفا یک کد غیر تکراری وارد کنید",3);
                        return;
                    }
                }
              else if (_services.addData(SetData()))
                {
                    fun.successAlert();

                    BindGrid();
                }
                else
                {
                    fun.failAlert();
                }
            }
            else
            {
                fun.Alert("لطفا اطلاعات را به صورت کامل وارد کنید", 3);
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (canDo())
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
            else
            {
                fun.Alert("لطفا اطلاعات را به صورت کامل وارد کنید", 3);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == fun.Delete_Question())
            {
                //ToDo: باید بررسی شود که کالا ورود به انبار نداشته باشد
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
                txt_goodsCode.Text = radGridView1.CurrentRow.Cells["goodsCode"].Value.ToString();
                txt_GoodsName.Text = radGridView1.CurrentRow.Cells["goodsName"].Value.ToString();
                dr_goodsGroup.SelectedValue =Convert.ToInt32( radGridView1.CurrentRow.Cells["goodsGroup"].Value.ToString());
                dr_Store.SelectedValue = Convert.ToInt32(radGridView1.CurrentRow.Cells["goodsStore"].Value.ToString());
                dr_goodsUnit.SelectedValue =Convert.ToInt32(radGridView1.CurrentRow.Cells["goodsUnit"].Value.ToString());
                txt_disc.Text = radGridView1.CurrentRow.Cells["goodsDisc"].Value.ToString();
                txt_maxMojodi.Text = radGridView1.CurrentRow.Cells["goodsMin"].Value.ToString();
                txt_minMojodi.Text = radGridView1.CurrentRow.Cells["goodsMax"].Value.ToString();
                txt_order_point.Text = radGridView1.CurrentRow.Cells["goosOrderPoint"].Value.ToString();
                txt_whight.Text = radGridView1.CurrentRow.Cells["goodsWeight"].Value.ToString();
                bool.TryParse( radGridView1.CurrentRow.Cells["isActive"].Value.ToString(),out var isActive);
                ch_active.Checked= isActive;
                try
                {
                    pic_goodsPic.Image = fun.ByteArrayToImage(radGridView1.CurrentRow.Cells["goodsPic"].Value as byte[]);

                }
                catch
                {
                    pic_goodsPic.Image = null;
                }


                btn_delete.Enabled = btn_edit.Enabled = true;
                btn_save.Enabled = false;
                txt_goodsCode.Enabled=false;
            }
            catch
            {
                fun.Alert("لطفا بر روی یکی از ردیف ها کلید کنید", 2);

            }

        }

        private void DefineUnits_Load(object sender, EventArgs e)
        {
            BindGrid();
            //-------------------------------
            var goods_Unit=UnitServices.GetAllData();
            dr_goodsUnit.DataSource = goods_Unit;
            dr_goodsUnit.AutoCompleteDataSource = goods_Unit;
            dr_goodsUnit.ValueMember = "id";
            dr_goodsUnit.AutoCompleteValueMember = "id";
            dr_goodsUnit.DisplayMember = "unitName";
            dr_goodsUnit.AutoCompleteDisplayMember = "unitName";



            //---------------------------------------------------
            var goodsGroup = GoodsGroupService.GetAllData();
            dr_goodsGroup.DataSource = goodsGroup;
            dr_goodsGroup.AutoCompleteDataSource = goodsGroup;
            dr_goodsGroup.ValueMember = "id";
            dr_goodsGroup.AutoCompleteValueMember = "id";
            dr_goodsGroup.DisplayMember = "goodsGroupName";
            dr_goodsGroup.AutoCompleteDisplayMember = "goodsGroupName";
            
            //---------------------------------------------------
            var Store = StoreServices.GetAllData();
            dr_Store.DataSource = Store;
            dr_Store.AutoCompleteDataSource = Store;
            dr_Store.ValueMember = "id";
            dr_Store.AutoCompleteValueMember = "id";
            dr_Store.DisplayMember = "storeName";
            dr_Store.AutoCompleteDisplayMember = "storeName";
           



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
         

        }

        private void pic_goodsPic_Click(object sender, EventArgs e)
        {
            if (PictureSelector.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    pic_goodsPic.Image = Image.FromFile(PictureSelector.FileName);

                }
                catch 
                {

                    pic_goodsPic.Image=null;

                }
            }
        }
    }
}
