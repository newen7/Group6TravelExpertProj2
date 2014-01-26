namespace TravelExperts
{
    partial class frmPackage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboPkgName = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rtxtDesc = new System.Windows.Forms.RichTextBox();
            this.lblAgencyAdmission = new System.Windows.Forms.Label();
            this.txtAgencyAdmission = new System.Windows.Forms.TextBox();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.txtBasePrice = new System.Windows.Forms.TextBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.lblPkgName = new System.Windows.Forms.Label();
            this.lblPkgId = new System.Windows.Forms.Label();
            this.txtPkgId = new System.Windows.Forms.TextBox();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lstProduct = new System.Windows.Forms.ListBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstAllPackage = new System.Windows.Forms.ListBox();
            this.btnModPkg = new System.Windows.Forms.Button();
            this.btnAddPkg = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox1.Controls.Add(this.cboPkgName);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.rtxtDesc);
            this.groupBox1.Controls.Add(this.lblAgencyAdmission);
            this.groupBox1.Controls.Add(this.txtAgencyAdmission);
            this.groupBox1.Controls.Add(this.lblBasePrice);
            this.groupBox1.Controls.Add(this.txtBasePrice);
            this.groupBox1.Controls.Add(this.lblEndDate);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.lblStartDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.lblPkgName);
            this.groupBox1.Controls.Add(this.lblPkgId);
            this.groupBox1.Controls.Add(this.txtPkgId);
            this.groupBox1.Controls.Add(this.btnEditProduct);
            this.groupBox1.Controls.Add(this.lblDesc);
            this.groupBox1.Controls.Add(this.lstProduct);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(746, 385);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Package Information";
            // 
            // cboPkgName
            // 
            this.cboPkgName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPkgName.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.cboPkgName.FormattingEnabled = true;
            this.cboPkgName.Location = new System.Drawing.Point(167, 99);
            this.cboPkgName.Name = "cboPkgName";
            this.cboPkgName.Size = new System.Drawing.Size(213, 28);
            this.cboPkgName.TabIndex = 2;
            this.cboPkgName.SelectedIndexChanged += new System.EventHandler(this.cboPkgName_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSearch.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(273, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 34);
            this.btnSearch.TabIndex = 61;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rtxtDesc
            // 
            this.rtxtDesc.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.rtxtDesc.Location = new System.Drawing.Point(408, 54);
            this.rtxtDesc.Name = "rtxtDesc";
            this.rtxtDesc.ReadOnly = true;
            this.rtxtDesc.Size = new System.Drawing.Size(320, 96);
            this.rtxtDesc.TabIndex = 12;
            this.rtxtDesc.Text = "";
            // 
            // lblAgencyAdmission
            // 
            this.lblAgencyAdmission.AutoSize = true;
            this.lblAgencyAdmission.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgencyAdmission.Location = new System.Drawing.Point(13, 259);
            this.lblAgencyAdmission.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAgencyAdmission.Name = "lblAgencyAdmission";
            this.lblAgencyAdmission.Size = new System.Drawing.Size(146, 21);
            this.lblAgencyAdmission.TabIndex = 55;
            this.lblAgencyAdmission.Text = "Agency Admission:";
            // 
            // txtAgencyAdmission
            // 
            this.txtAgencyAdmission.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.txtAgencyAdmission.Location = new System.Drawing.Point(167, 256);
            this.txtAgencyAdmission.Name = "txtAgencyAdmission";
            this.txtAgencyAdmission.ReadOnly = true;
            this.txtAgencyAdmission.Size = new System.Drawing.Size(213, 28);
            this.txtAgencyAdmission.TabIndex = 11;
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasePrice.Location = new System.Drawing.Point(73, 219);
            this.lblBasePrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(85, 21);
            this.lblBasePrice.TabIndex = 53;
            this.lblBasePrice.Text = "Base Price:";
            // 
            // txtBasePrice
            // 
            this.txtBasePrice.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.txtBasePrice.Location = new System.Drawing.Point(167, 216);
            this.txtBasePrice.Name = "txtBasePrice";
            this.txtBasePrice.ReadOnly = true;
            this.txtBasePrice.Size = new System.Drawing.Size(213, 28);
            this.txtBasePrice.TabIndex = 10;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(81, 182);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(78, 21);
            this.lblEndDate.TabIndex = 51;
            this.lblEndDate.Text = "End Date:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.txtEndDate.Location = new System.Drawing.Point(167, 179);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(213, 28);
            this.txtEndDate.TabIndex = 9;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(74, 142);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(84, 21);
            this.lblStartDate.TabIndex = 49;
            this.lblStartDate.Text = "Start Date:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.txtStartDate.Location = new System.Drawing.Point(167, 139);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.ReadOnly = true;
            this.txtStartDate.Size = new System.Drawing.Size(213, 28);
            this.txtStartDate.TabIndex = 8;
            // 
            // lblPkgName
            // 
            this.lblPkgName.AutoSize = true;
            this.lblPkgName.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPkgName.Location = new System.Drawing.Point(104, 102);
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
            this.lblPkgId.Location = new System.Drawing.Point(67, 61);
            this.lblPkgId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPkgId.Name = "lblPkgId";
            this.lblPkgId.Size = new System.Drawing.Size(92, 21);
            this.lblPkgId.TabIndex = 45;
            this.lblPkgId.Text = "Package ID:";
            // 
            // txtPkgId
            // 
            this.txtPkgId.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.txtPkgId.Location = new System.Drawing.Point(167, 58);
            this.txtPkgId.Name = "txtPkgId";
            this.txtPkgId.Size = new System.Drawing.Size(100, 28);
            this.txtPkgId.TabIndex = 1;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEditProduct.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProduct.Location = new System.Drawing.Point(436, 334);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(264, 34);
            this.btnEditProduct.TabIndex = 3;
            this.btnEditProduct.Text = "&Edit Products";
            this.btnEditProduct.UseVisualStyleBackColor = false;
            this.btnEditProduct.Click += new System.EventHandler(this.btnEditProduct_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(405, 30);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(96, 21);
            this.lblDesc.TabIndex = 28;
            this.lblDesc.Text = "Description:";
            // 
            // lstProduct
            // 
            this.lstProduct.BackColor = System.Drawing.SystemColors.Control;
            this.lstProduct.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.lstProduct.FormattingEnabled = true;
            this.lstProduct.HorizontalScrollbar = true;
            this.lstProduct.ItemHeight = 20;
            this.lstProduct.Location = new System.Drawing.Point(409, 192);
            this.lstProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstProduct.Name = "lstProduct";
            this.lstProduct.Size = new System.Drawing.Size(320, 124);
            this.lstProduct.TabIndex = 13;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(405, 166);
            this.lblProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(179, 21);
            this.lblProduct.TabIndex = 15;
            this.lblProduct.Text = "Products and Suppliers:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCancel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(475, 646);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 43);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstAllPackage
            // 
            this.lstAllPackage.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.lstAllPackage.FormattingEnabled = true;
            this.lstAllPackage.ItemHeight = 20;
            this.lstAllPackage.Items.AddRange(new object[] {
            "1 --- Caribbean New Year",
            "2 --- Polynesian Paradise"});
            this.lstAllPackage.Location = new System.Drawing.Point(13, 410);
            this.lstAllPackage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstAllPackage.Name = "lstAllPackage";
            this.lstAllPackage.Size = new System.Drawing.Size(745, 224);
            this.lstAllPackage.TabIndex = 4;
            this.lstAllPackage.SelectedIndexChanged += new System.EventHandler(this.lstAllPackage_SelectedIndexChanged);
            // 
            // btnModPkg
            // 
            this.btnModPkg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnModPkg.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModPkg.Location = new System.Drawing.Point(295, 646);
            this.btnModPkg.Name = "btnModPkg";
            this.btnModPkg.Size = new System.Drawing.Size(143, 43);
            this.btnModPkg.TabIndex = 6;
            this.btnModPkg.Text = "&Modify";
            this.btnModPkg.UseVisualStyleBackColor = false;
            this.btnModPkg.Click += new System.EventHandler(this.btnModPkg_Click);
            // 
            // btnAddPkg
            // 
            this.btnAddPkg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAddPkg.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPkg.Location = new System.Drawing.Point(117, 646);
            this.btnAddPkg.Name = "btnAddPkg";
            this.btnAddPkg.Size = new System.Drawing.Size(143, 43);
            this.btnAddPkg.TabIndex = 5;
            this.btnAddPkg.Text = "&Add";
            this.btnAddPkg.UseVisualStyleBackColor = false;
            this.btnAddPkg.Click += new System.EventHandler(this.btnAddPkg_Click);
            // 
            // frmPackage
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDownGrid;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(770, 698);
            this.Controls.Add(this.btnAddPkg);
            this.Controls.Add(this.btnModPkg);
            this.Controls.Add(this.lstAllPackage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmPackage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Package  ";
            this.Load += new System.EventHandler(this.frmPackage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.ListBox lstProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button btnEditProduct;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RichTextBox rtxtDesc;
        private System.Windows.Forms.Label lblAgencyAdmission;
        private System.Windows.Forms.TextBox txtAgencyAdmission;
        private System.Windows.Forms.Label lblBasePrice;
        private System.Windows.Forms.TextBox txtBasePrice;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label lblPkgName;
        private System.Windows.Forms.Label lblPkgId;
        private System.Windows.Forms.TextBox txtPkgId;
        private System.Windows.Forms.ListBox lstAllPackage;
        private System.Windows.Forms.Button btnModPkg;
        private System.Windows.Forms.Button btnAddPkg;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboPkgName;
    }
}