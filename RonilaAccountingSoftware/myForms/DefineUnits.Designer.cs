namespace RonilaAccountingSoftware.myForms
{
    partial class DefineUnits
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.visualStudio2022LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2022LightTheme();
            this.lbl_unit = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btn_refresh = new Telerik.WinControls.UI.RadButton();
            this.txt_unit = new Telerik.WinControls.UI.RadTextBox();
            this.btn_edit = new Telerik.WinControls.UI.RadButton();
            this.btn_save = new Telerik.WinControls.UI.RadButton();
            this.btn_delete = new Telerik.WinControls.UI.RadButton();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_unit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_unit
            // 
            this.lbl_unit.AutoSize = true;
            this.lbl_unit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lbl_unit.Location = new System.Drawing.Point(695, 32);
            this.lbl_unit.Name = "lbl_unit";
            this.lbl_unit.Size = new System.Drawing.Size(55, 14);
            this.lbl_unit.TabIndex = 1;
            this.lbl_unit.Text = "واحد کالا:";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btn_refresh);
            this.radGroupBox1.Controls.Add(this.txt_unit);
            this.radGroupBox1.Controls.Add(this.btn_edit);
            this.radGroupBox1.Controls.Add(this.btn_save);
            this.radGroupBox1.Controls.Add(this.btn_delete);
            this.radGroupBox1.Controls.Add(this.lbl_unit);
            this.radGroupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radGroupBox1.HeaderMargin = new System.Windows.Forms.Padding(1);
            this.radGroupBox1.HeaderText = "ورود اطلاعات";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGroupBox1.Size = new System.Drawing.Size(788, 79);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "ورود اطلاعات";
            this.radGroupBox1.ThemeName = "VisualStudio2022Light";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_refresh.Image = global::RonilaAccountingSoftware.Properties.Resources.refresh;
            this.btn_refresh.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_refresh.Location = new System.Drawing.Point(303, 23);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(92, 30);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.Text = "رفرش";
            this.btn_refresh.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_refresh.ThemeName = "VisualStudio2022Light";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // txt_unit
            // 
            this.txt_unit.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_unit.Location = new System.Drawing.Point(404, 28);
            this.txt_unit.Name = "txt_unit";
            this.txt_unit.Size = new System.Drawing.Size(285, 23);
            this.txt_unit.TabIndex = 0;
            this.txt_unit.ThemeName = "VisualStudio2022Light";
            this.txt_unit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_unit_KeyDown);
            // 
            // btn_edit
            // 
            this.btn_edit.Enabled = false;
            this.btn_edit.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_edit.Image = global::RonilaAccountingSoftware.Properties.Resources.edit;
            this.btn_edit.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_edit.Location = new System.Drawing.Point(107, 23);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(92, 30);
            this.btn_edit.TabIndex = 2;
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
            this.btn_save.Location = new System.Drawing.Point(205, 23);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(92, 30);
            this.btn_save.TabIndex = 1;
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
            this.btn_delete.Location = new System.Drawing.Point(11, 23);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(92, 30);
            this.btn_delete.TabIndex = 3;
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
            this.radGridView1.Location = new System.Drawing.Point(12, 97);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "id";
            gridViewTextBoxColumn3.HeaderText = "شناسه";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "id";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "unitName";
            gridViewTextBoxColumn4.HeaderText = "نام واحد فروش";
            gridViewTextBoxColumn4.Name = "unitName";
            gridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn4.Width = 200;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.ReadOnly = true;
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radGridView1.Size = new System.Drawing.Size(788, 406);
            this.radGridView1.TabIndex = 4;
            this.radGridView1.ThemeName = "VisualStudio2022Light";
            this.radGridView1.DoubleClick += new System.EventHandler(this.radGridView1_DoubleClick);
            // 
            // DefineUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 515);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radGroupBox1);
            this.MaximizeBox = false;
            this.Name = "DefineUnits";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف واحد های کالا";
            this.ThemeName = "VisualStudio2022Light";
            this.Load += new System.EventHandler(this.DefineUnits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_unit)).EndInit();
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
        private System.Windows.Forms.Label lbl_unit;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btn_edit;
        private Telerik.WinControls.UI.RadButton btn_save;
        private Telerik.WinControls.UI.RadTextBox txt_unit;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadButton btn_refresh;
    }
}
