namespace RonilaAccountingSoftware.myForms
{
    partial class DefineStore
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.visualStudio2022LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2022LightTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txt_storeDisc = new Telerik.WinControls.UI.RadTextBox();
            this.btn_refresh = new Telerik.WinControls.UI.RadButton();
            this.txt_StoreName = new Telerik.WinControls.UI.RadTextBox();
            this.btn_edit = new Telerik.WinControls.UI.RadButton();
            this.btn_save = new Telerik.WinControls.UI.RadButton();
            this.btn_delete = new Telerik.WinControls.UI.RadButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_storeDisc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_StoreName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txt_storeDisc);
            this.radGroupBox1.Controls.Add(this.btn_refresh);
            this.radGroupBox1.Controls.Add(this.txt_StoreName);
            this.radGroupBox1.Controls.Add(this.btn_edit);
            this.radGroupBox1.Controls.Add(this.btn_save);
            this.radGroupBox1.Controls.Add(this.btn_delete);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.radGroupBox1.HeaderText = "ورود اطلاعات";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGroupBox1.Size = new System.Drawing.Size(788, 122);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "ورود اطلاعات";
            this.radGroupBox1.ThemeName = "VisualStudio2022Light";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radLabel2.Location = new System.Drawing.Point(375, 31);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(56, 18);
            this.radLabel2.TabIndex = 7;
            this.radLabel2.Text = "توضیحات:";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radLabel1.Location = new System.Drawing.Point(729, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(48, 18);
            this.radLabel1.TabIndex = 6;
            this.radLabel1.Text = "نام انبار:";
            // 
            // txt_storeDisc
            // 
            this.txt_storeDisc.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_storeDisc.Location = new System.Drawing.Point(11, 28);
            this.txt_storeDisc.Name = "txt_storeDisc";
            this.txt_storeDisc.Size = new System.Drawing.Size(358, 23);
            this.txt_storeDisc.TabIndex = 1;
            this.txt_storeDisc.ThemeName = "VisualStudio2022Light";
            this.txt_storeDisc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_unit_KeyDown);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_refresh.Image = global::RonilaAccountingSoftware.Properties.Resources.refresh;
            this.btn_refresh.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_refresh.Location = new System.Drawing.Point(303, 87);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(92, 30);
            this.btn_refresh.TabIndex = 5;
            this.btn_refresh.Text = "رفرش";
            this.btn_refresh.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_refresh.ThemeName = "VisualStudio2022Light";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // txt_StoreName
            // 
            this.txt_StoreName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_StoreName.Location = new System.Drawing.Point(439, 28);
            this.txt_StoreName.Name = "txt_StoreName";
            this.txt_StoreName.Size = new System.Drawing.Size(285, 23);
            this.txt_StoreName.TabIndex = 0;
            this.txt_StoreName.ThemeName = "VisualStudio2022Light";
            this.txt_StoreName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_unit_KeyDown);
            // 
            // btn_edit
            // 
            this.btn_edit.Enabled = false;
            this.btn_edit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_edit.Image = global::RonilaAccountingSoftware.Properties.Resources.edit;
            this.btn_edit.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_edit.Location = new System.Drawing.Point(107, 87);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(92, 30);
            this.btn_edit.TabIndex = 3;
            this.btn_edit.Text = "ویرایش";
            this.btn_edit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_edit.ThemeName = "VisualStudio2022Light";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_save.Image = global::RonilaAccountingSoftware.Properties.Resources.save;
            this.btn_save.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_save.Location = new System.Drawing.Point(205, 87);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 30);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "ثبت";
            this.btn_save.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.ThemeName = "VisualStudio2022Light";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Enabled = false;
            this.btn_delete.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_delete.Image = global::RonilaAccountingSoftware.Properties.Resources.delete;
            this.btn_delete.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_delete.Location = new System.Drawing.Point(11, 87);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(92, 30);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "حذف";
            this.btn_delete.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.ThemeName = "VisualStudio2022Light";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // radGridView1
            // 
            this.radGridView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radGridView1.ForeColor = System.Drawing.Color.Black;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(12, 140);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "id";
            gridViewTextBoxColumn1.HeaderText = "شناسه";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "id";
            gridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "storeName";
            gridViewTextBoxColumn2.HeaderText = "نام واحد فروش";
            gridViewTextBoxColumn2.Name = "storeName";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 200;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "storeDisc";
            gridViewTextBoxColumn3.HeaderText = "توضیحات";
            gridViewTextBoxColumn3.Name = "storeDisc";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 300;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3});
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridView1.Size = new System.Drawing.Size(788, 363);
            this.radGridView1.TabIndex = 4;
            this.radGridView1.ThemeName = "VisualStudio2022Light";
            this.radGridView1.DoubleClick += new System.EventHandler(this.radGridView1_DoubleClick);
            // 
            // DefineStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 515);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radGroupBox1);
            this.MaximizeBox = false;
            this.Name = "DefineStore";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف انبار ها";
            this.ThemeName = "VisualStudio2022Light";
            this.Load += new System.EventHandler(this.DefineUnits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_storeDisc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_StoreName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_delete;
        private Telerik.WinControls.Themes.VisualStudio2022LightTheme visualStudio2022LightTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btn_edit;
        private Telerik.WinControls.UI.RadButton btn_save;
        private Telerik.WinControls.UI.RadTextBox txt_StoreName;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton btn_refresh;
        private Telerik.WinControls.UI.RadTextBox txt_storeDisc;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
