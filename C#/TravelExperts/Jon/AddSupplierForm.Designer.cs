namespace TravelExperts.Jon
{
    partial class AddSupplierForm
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
            this.addModSupplierGbx = new System.Windows.Forms.GroupBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.lblPkgName = new System.Windows.Forms.Label();
            this.supplierIdLbl = new System.Windows.Forms.Label();
            this.supplierIdTxt = new System.Windows.Forms.TextBox();
            this.addModSupplierGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // addModSupplierGbx
            // 
            this.addModSupplierGbx.Controls.Add(this.closeBtn);
            this.addModSupplierGbx.Controls.Add(this.saveBtn);
            this.addModSupplierGbx.Controls.Add(this.nameTxt);
            this.addModSupplierGbx.Controls.Add(this.lblPkgName);
            this.addModSupplierGbx.Controls.Add(this.supplierIdLbl);
            this.addModSupplierGbx.Controls.Add(this.supplierIdTxt);
            this.addModSupplierGbx.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.addModSupplierGbx.Location = new System.Drawing.Point(13, 13);
            this.addModSupplierGbx.Name = "addModSupplierGbx";
            this.addModSupplierGbx.Size = new System.Drawing.Size(366, 248);
            this.addModSupplierGbx.TabIndex = 0;
            this.addModSupplierGbx.TabStop = false;
            this.addModSupplierGbx.Text = "Add Supplier";
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.closeBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(208, 208);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(71, 34);
            this.closeBtn.TabIndex = 72;
            this.closeBtn.Text = "Cancel";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.saveBtn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(285, 208);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 34);
            this.saveBtn.TabIndex = 71;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.nameTxt.Location = new System.Drawing.Point(86, 79);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.ReadOnly = true;
            this.nameTxt.Size = new System.Drawing.Size(243, 28);
            this.nameTxt.TabIndex = 70;
            // 
            // lblPkgName
            // 
            this.lblPkgName.AutoSize = true;
            this.lblPkgName.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPkgName.Location = new System.Drawing.Point(24, 82);
            this.lblPkgName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPkgName.Name = "lblPkgName";
            this.lblPkgName.Size = new System.Drawing.Size(55, 21);
            this.lblPkgName.TabIndex = 69;
            this.lblPkgName.Text = "Name:";
            // 
            // supplierIdLbl
            // 
            this.supplierIdLbl.AutoSize = true;
            this.supplierIdLbl.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierIdLbl.Location = new System.Drawing.Point(24, 45);
            this.supplierIdLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.supplierIdLbl.Name = "supplierIdLbl";
            this.supplierIdLbl.Size = new System.Drawing.Size(97, 21);
            this.supplierIdLbl.TabIndex = 68;
            this.supplierIdLbl.Text = "Supplier ID:";
            // 
            // supplierIdTxt
            // 
            this.supplierIdTxt.Font = new System.Drawing.Font("Palatino Linotype", 11.25F);
            this.supplierIdTxt.Location = new System.Drawing.Point(124, 42);
            this.supplierIdTxt.Name = "supplierIdTxt";
            this.supplierIdTxt.Size = new System.Drawing.Size(57, 28);
            this.supplierIdTxt.TabIndex = 67;
            // 
            // AddSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(391, 273);
            this.Controls.Add(this.addModSupplierGbx);
            this.Name = "AddSupplierForm";
            this.Text = "AddSupplierForm";
            this.Load += new System.EventHandler(this.AddSupplierForm_Load);
            this.addModSupplierGbx.ResumeLayout(false);
            this.addModSupplierGbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox addModSupplierGbx;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label lblPkgName;
        private System.Windows.Forms.Label supplierIdLbl;
        private System.Windows.Forms.TextBox supplierIdTxt;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button saveBtn;
    }
}