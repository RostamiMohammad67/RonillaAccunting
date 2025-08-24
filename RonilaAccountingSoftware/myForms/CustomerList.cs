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
    public partial class CustomerList : Telerik.WinControls.UI.RadForm
    {
        Models.DBServices.CustomersServices _services = new Models.DBServices.CustomersServices();
        myClass.UtilityClass fun = new myClass.UtilityClass();
        int id = 0;
        public CustomerList()
        {
            InitializeComponent();
        }
        public void BindGrid()
        {
            radGridView1.DataSource = _services.GetAllCustomer();
           
        }
        private void DefineUnits_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void radGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                UtilityClass.Help_code1 = radGridView1.CurrentRow.Cells["id"].Value.ToString();
                this.Close();
            }
            catch
            {
                fun.Alert("لطفا بر روی یکی از دریف ها کلید کنید", 2);

            }
        }
    }
}
