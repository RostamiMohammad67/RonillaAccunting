namespace RonilaAccountingSoftware.myForms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.visualStudio2022LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2022LightTheme();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.menuUnitInfo = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.menuSupplier = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem3 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.menuCustomer = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_defineStore = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_goodsGroup = new Telerik.WinControls.UI.RadMenuItem();
            this.menu_DefineGoods = new Telerik.WinControls.UI.RadMenuItem();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.radLabelElement1 = new Telerik.WinControls.UI.RadLabelElement();
            this.lbl_user_name = new Telerik.WinControls.UI.RadLabelElement();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.lbl_date = new Telerik.WinControls.UI.RadLabelElement();
            this.menu_EnteGoodsToStore = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radMenuItem1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menuUnitInfo,
            this.radMenuSeparatorItem1,
            this.menuSupplier,
            this.radMenuSeparatorItem3,
            this.menuCustomer});
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "اطلاعات پایه ای";
            this.radMenuItem1.UseCompatibleTextRendering = false;
            // 
            // menuUnitInfo
            // 
            this.menuUnitInfo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.menuUnitInfo.Name = "menuUnitInfo";
            this.menuUnitInfo.Text = "واحد های اندازه گیری";
            this.menuUnitInfo.Click += new System.EventHandler(this.menuUnitInfo_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuSupplier
            // 
            this.menuSupplier.Font = new System.Drawing.Font("Tahoma", 9F);
            this.menuSupplier.Name = "menuSupplier";
            this.menuSupplier.Text = "ثبت تامین کننده";
            this.menuSupplier.Click += new System.EventHandler(this.menuSupplier_Click);
            // 
            // radMenuSeparatorItem3
            // 
            this.radMenuSeparatorItem3.Name = "radMenuSeparatorItem3";
            this.radMenuSeparatorItem3.Text = "radMenuSeparatorItem3";
            this.radMenuSeparatorItem3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuCustomer
            // 
            this.menuCustomer.Font = new System.Drawing.Font("Tahoma", 9F);
            this.menuCustomer.Name = "menuCustomer";
            this.menuCustomer.Text = "ثبت مشتری";
            this.menuCustomer.Click += new System.EventHandler(this.menuCustomer_Click);
            // 
            // radMenu1
            // 
            this.radMenu1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radMenu1.Size = new System.Drawing.Size(859, 25);
            this.radMenu1.TabIndex = 1;
            this.radMenu1.ThemeName = "VisualStudio2022Light";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.menu_defineStore,
            this.menu_goodsGroup,
            this.menu_DefineGoods,
            this.menu_EnteGoodsToStore});
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "انبار داری";
            // 
            // menu_defineStore
            // 
            this.menu_defineStore.Font = new System.Drawing.Font("Tahoma", 9F);
            this.menu_defineStore.Name = "menu_defineStore";
            this.menu_defineStore.Text = "تعریف انبار";
            this.menu_defineStore.Click += new System.EventHandler(this.menu_defineStore_Click);
            // 
            // menu_goodsGroup
            // 
            this.menu_goodsGroup.Font = new System.Drawing.Font("Tahoma", 9F);
            this.menu_goodsGroup.Name = "menu_goodsGroup";
            this.menu_goodsGroup.Text = "گروه کالا";
            this.menu_goodsGroup.Click += new System.EventHandler(this.menu_goodsGroup_Click);
            // 
            // menu_DefineGoods
            // 
            this.menu_DefineGoods.Font = new System.Drawing.Font("Tahoma", 9F);
            this.menu_DefineGoods.Name = "menu_DefineGoods";
            this.menu_DefineGoods.Text = "تعریف کالا";
            this.menu_DefineGoods.Click += new System.EventHandler(this.menu_DefineGoods_Click);
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radLabelElement1,
            this.lbl_user_name,
            this.commandBarSeparator1,
            this.lbl_date});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 544);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radStatusStrip1.Size = new System.Drawing.Size(859, 26);
            this.radStatusStrip1.TabIndex = 2;
            this.radStatusStrip1.ThemeName = "VisualStudio2022Light";
            // 
            // radLabelElement1
            // 
            this.radLabelElement1.Name = "radLabelElement1";
            this.radStatusStrip1.SetSpring(this.radLabelElement1, false);
            this.radLabelElement1.Text = "کاربر:";
            this.radLabelElement1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.radLabelElement1.TextWrap = true;
            // 
            // lbl_user_name
            // 
            this.lbl_user_name.Name = "lbl_user_name";
            this.radStatusStrip1.SetSpring(this.lbl_user_name, false);
            this.lbl_user_name.Text = "-";
            this.lbl_user_name.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_user_name.TextWrap = true;
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.radStatusStrip1.SetSpring(this.commandBarSeparator1, false);
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // lbl_date
            // 
            this.lbl_date.Name = "lbl_date";
            this.radStatusStrip1.SetSpring(this.lbl_date, false);
            this.lbl_date.Text = "-";
            this.lbl_date.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lbl_date.TextWrap = true;
            // 
            // menu_EnteGoodsToStore
            // 
            this.menu_EnteGoodsToStore.Name = "menu_EnteGoodsToStore";
            this.menu_EnteGoodsToStore.Text = "ورود کالا به انبار";
            this.menu_EnteGoodsToStore.Click += new System.EventHandler(this.menu_EnteGoodsToStore_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 570);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.radMenu1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "نرم افزار مدیریت کسب و کار رونیلا";
            this.ThemeName = "VisualStudio2022Light";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2022LightTheme visualStudio2022LightTheme1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem menuUnitInfo;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenuItem menuSupplier;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem3;
        private Telerik.WinControls.UI.RadMenuItem menuCustomer;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadLabelElement radLabelElement1;
        private Telerik.WinControls.UI.RadLabelElement lbl_user_name;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.RadLabelElement lbl_date;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenuItem menu_defineStore;
        private Telerik.WinControls.UI.RadMenuItem menu_goodsGroup;
        private Telerik.WinControls.UI.RadMenuItem menu_DefineGoods;
        private Telerik.WinControls.UI.RadMenuItem menu_EnteGoodsToStore;
    }
}
