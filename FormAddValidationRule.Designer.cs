namespace lorakon_manager
{
    partial class FormAddValidationRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddValidationRule));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbNuclideName = new System.Windows.Forms.TextBox();
            this.tbActivityMin = new System.Windows.Forms.TextBox();
            this.tbActivityMax = new System.Windows.Forms.TextBox();
            this.tbConfidenceMin = new System.Windows.Forms.TextBox();
            this.cbCanBeAutoApproved = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 221);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 32);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(252, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(364, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 32);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Add";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbNuclideName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbActivityMin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbActivityMax, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbConfidenceMin, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbCanBeAutoApproved, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 221);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tbNuclideName
            // 
            this.tbNuclideName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNuclideName.Location = new System.Drawing.Point(143, 35);
            this.tbNuclideName.MaxLength = 16;
            this.tbNuclideName.Name = "tbNuclideName";
            this.tbNuclideName.Size = new System.Drawing.Size(330, 21);
            this.tbNuclideName.TabIndex = 1;
            // 
            // tbActivityMin
            // 
            this.tbActivityMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbActivityMin.Location = new System.Drawing.Point(143, 67);
            this.tbActivityMin.MaxLength = 16;
            this.tbActivityMin.Name = "tbActivityMin";
            this.tbActivityMin.Size = new System.Drawing.Size(330, 21);
            this.tbActivityMin.TabIndex = 2;
            // 
            // tbActivityMax
            // 
            this.tbActivityMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbActivityMax.Location = new System.Drawing.Point(143, 99);
            this.tbActivityMax.MaxLength = 16;
            this.tbActivityMax.Name = "tbActivityMax";
            this.tbActivityMax.Size = new System.Drawing.Size(330, 21);
            this.tbActivityMax.TabIndex = 3;
            // 
            // tbConfidenceMin
            // 
            this.tbConfidenceMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConfidenceMin.Location = new System.Drawing.Point(143, 131);
            this.tbConfidenceMin.MaxLength = 16;
            this.tbConfidenceMin.Name = "tbConfidenceMin";
            this.tbConfidenceMin.Size = new System.Drawing.Size(330, 21);
            this.tbConfidenceMin.TabIndex = 4;
            // 
            // cbCanBeAutoApproved
            // 
            this.cbCanBeAutoApproved.AutoSize = true;
            this.cbCanBeAutoApproved.Location = new System.Drawing.Point(143, 163);
            this.cbCanBeAutoApproved.Name = "cbCanBeAutoApproved";
            this.cbCanBeAutoApproved.Size = new System.Drawing.Size(142, 19);
            this.cbCanBeAutoApproved.TabIndex = 5;
            this.cbCanBeAutoApproved.Text = "Kan auto godkjennes";
            this.cbCanBeAutoApproved.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuklide navn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aktivitet Min.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Aktivitet Max.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Konfidens Min.";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(143, 192);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 15);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "<lblStatus>";
            // 
            // FormAddValidationRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 253);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddValidationRule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ny valideringsregel";
            this.Load += new System.EventHandler(this.FormAddValidationRule_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNuclideName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbActivityMin;
        private System.Windows.Forms.TextBox tbActivityMax;
        private System.Windows.Forms.TextBox tbConfidenceMin;
        private System.Windows.Forms.CheckBox cbCanBeAutoApproved;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
    }
}