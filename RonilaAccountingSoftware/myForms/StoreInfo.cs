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
    public partial class StoreInfo : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.StoreInfoServices _services = new Models.DBServices.StoreInfoServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public StoreInfo()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            radGridView1.DataSource = _services.GetAllData();
            txt_storeName.Focus();

            btn_delete.Enabled = false;
            btn_save.Enabled = true;
        }
        public Models.StoreInfo Setdata()
        {

            byte[] image = null;
            try
            {
                image = fun.ImageToByteArray(pic_storeLogo.Image);
            }
            catch
            {
            }
            var info = new Models.StoreInfo
            {
                storeName = txt_storeName.Text,
                storeAddress = txt_storeAddress.Text,
                storeSlogan = txt_storeSlogan.Text,
                storeMob = txt_storeMob.Text,
                storePhone = txt_storePhone.Text,
                logo=image,
                id = id,


            };
            return info;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_services.GetAllData().Count > 0)
            {


                if (_services.editAll(Setdata()))
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
                if (_services.add(Setdata()))
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
                txt_storeName.Text = radGridView1.CurrentRow.Cells["storeName"].Value.ToString();
                txt_storeAddress.Text = radGridView1.CurrentRow.Cells["storeAddress"].Value.ToString();
                txt_storeMob.Text = radGridView1.CurrentRow.Cells["storeMob"].Value.ToString();
                txt_storePhone.Text = radGridView1.CurrentRow.Cells["storePhone"].Value.ToString();
                txt_storeSlogan.Text = radGridView1.CurrentRow.Cells["storeSlogan"].Value.ToString();
                //-------------------------------------------
                try
                {
                    pic_storeLogo.Image = fun.ByteArrayToImage(radGridView1.CurrentRow.Cells["logo"].Value as byte[]);

                }
                catch
                {
                    pic_storeLogo.Image = null;
                }
                //---------------------------------------------------
                btn_delete.Enabled =  true;
              
            }
            catch
            {
                fun.Alert("لطفا بر روی یکی از دریف ها کلید کنید", 2);

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
            btn_delete.Enabled = false;
            btn_save.Enabled = true;

        }

        private void pic_storeLogo_Click(object sender, EventArgs e)
        {
            if (PictureSelector.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pic_storeLogo.Image = Image.FromFile(PictureSelector.FileName);

                }
                catch
                {

                    pic_storeLogo.Image = null;

                }
            }
        }
    }
}
