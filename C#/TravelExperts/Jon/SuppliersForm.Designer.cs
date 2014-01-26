namespace TravelExperts.Jon
{
    partial class SuppliersForm
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
            this.supplierGbx = new System.Windows.Forms.GroupBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.suppliersLbx = new System.Windows.Forms.ListBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblPkgName = new System.Windows.Forms.Label();
            this.lblPkgId = new System.Windows.Forms.Label();
            this.supplierIdTxt = new System.Windows.Forms.TextBox();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.ProductsLst = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditProductsBtn = new System.Windows.Forms.Button();
            this.supplierGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // supplierGbx
            // 
            this.supplierGbx.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.supplierGbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.supplierGbx.Controls.Add(this.EditProductsBtn);
            this.supplierGbx.Controls.Add(this.label1);
            this.supplierGbx.Controls.Add(this.ProductsLst);
            this.supplierGbx.Controls.Add(this.nameTxt);
            this.supplierGbx.Controls.Add(this.suppliersLbx);
            this.supplierGbx.Controls.Add(this.closeBtn);
            this.supplierGbx.Controls.Add(this.deleteBtn);
            this.supplierGbx.Controls.Add(this.addBtn);
            this.supplierGbx.Controls.Add(this.btnSearch);
            this.supplierGbx.Controls.Add(this.lblPkgName);
            this.supplierGbx.Controls.Add(this.lblPkgId);
            this.supplierGbx.Controls.Add(this.supplierIdTxt);
            this.supplierGbx.Controls.Add(this.modifyBtn);
            this.supplierGbx.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierGbx.Location = new System.Drawing.Point(12, 1);
            this.supplierGbx.Name = "supplierGbx";
            this.supplierGbx.Size = new System.Drawing.Size(675, 374);
            this.supplierGbx.TabIndex = 42;
            this.supplierGbx.TabStop = false;
            this.supplierGbx.Text = "Supplier Information";
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.nameTxt.Location = new System.Drawing.Point(77, 77);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.ReadOnly = true;
            this.nameTxt.Size = new System.Drawing.Size(243, 28);
            this.nameTxt.TabIndex = 66;
            // 
            // suppliersLbx
            // 
            this.suppliersLbx.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliersLbx.FormattingEnabled = true;
            this.suppliersLbx.ItemHeight = 22;
            this.suppliersLbx.Location = new System.Drawing.Point(15, 113);
            this.suppliersLbx.Name = "suppliersLbx";
            this.suppliersLbx.Size = new System.Drawing.Size(305, 202);
            this.suppliersLbx.TabIndex = 65;
            this.suppliersLbx.SelectedIndexChanged += new System.EventHandler(this.suppliersLbx_SelectedIndexChanged);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.closeBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(581, 328);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(67, 34);
            this.closeBtn.TabIndex = 64;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.deleteBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(167, 328);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 34);
            this.deleteBtn.TabIndex = 63;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.addBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(20, 328);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(58, 34);
            this.addBtn.TabIndex = 62;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearch.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(212, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 34);
            this.btnSearch.TabIndex = 61;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblPkgName
            // 
            this.lblPkgName.AutoSize = true;
            this.lblPkgName.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPkgName.Location = new System.Drawing.Point(15, 80);
            this.lblPkgName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPkgName.Name = "lblPkgName";
            this.lblPkgName.Size = new System.Drawing.Size(55, 21);
            this.lblPkgName.TabIndex = 47;
            this.lblPkgName.Text = "Name:";
            // 
            // lblPkgId
            // 
            this.lblPkgId.AutoSize = true;
            this.lblPkgId.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPkgId.Location = new System.Drawing.Point(49, 42);
            this.lblPkgId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPkgId.Name = "lblPkgId";
            this.lblPkgId.Size = new System.Drawing.Size(97, 21);
            this.lblPkgId.TabIndex = 45;
            this.lblPkgId.Text = "Supplier ID:";
            // 
            // supplierIdTxt
            // 
            this.supplierIdTxt.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.supplierIdTxt.Location = new System.Drawing.Point(149, 39);
            this.supplierIdTxt.Name = "supplierIdTxt";
            this.supplierIdTxt.Size = new System.Drawing.Size(57, 28);
            this.supplierIdTxt.TabIndex = 1;
            // 
            // modifyBtn
            // 
            this.modifyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.modifyBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.Location = new System.Drawing.Point(84, 328);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(77, 34);
            this.modifyBtn.TabIndex = 3;
            this.modifyBtn.Text = "Modify";
            this.modifyBtn.UseVisualStyleBackColor = false;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // ProductsLst
            // 
            this.ProductsLst.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsLst.FormattingEnabled = true;
            this.ProductsLst.ItemHeight = 22;
            this.ProductsLst.Location = new System.Drawing.Point(354, 69);
            this.ProductsLst.Name = "ProductsLst";
            this.ProductsLst.Size = new System.Drawing.Size(294, 246);
            this.ProductsLst.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 68;
            this.label1.Text = "Products:";
            // 
            // EditProductsBtn
            // 
            this.EditProductsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.EditProductsBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditProductsBtn.Location = new System.Drawing.Point(450, 328);
            this.EditProductsBtn.Name = "EditProductsBtn";
            this.EditProductsBtn.Size = new System.Drawing.Size(125, 34);
            this.EditProductsBtn.TabIndex = 69;
            this.EditProductsBtn.Text = "Edit Products";
            this.EditProductsBtn.UseVisualStyleBackColor = false;
            // 
            // SuppliersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(698, 391);
            this.Controls.Add(this.supplierGbx);
            this.Name = "SuppliersForm";
            this.Text = "SuppliersForm";
            this.Load += new System.EventHandler(this.SuppliersForm_Load);
            this.supplierGbx.ResumeLayout(false);
            this.supplierGbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox supplierGbx;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblPkgName;
        private System.Windows.Forms.Label lblPkgId;
        private System.Windows.Forms.TextBox supplierIdTxt;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.ListBox suppliersLbx;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Button EditProductsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ProductsLst;
    }
}