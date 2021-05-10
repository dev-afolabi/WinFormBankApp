
namespace BankApp.UI.Views.UserControls
{
    partial class AccountStatement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboAccounts = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewStatement = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dtgStatement = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgStatement)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAccounts
            // 
            this.cboAccounts.AllowDrop = true;
            this.cboAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAccounts.FormattingEnabled = true;
            this.cboAccounts.Location = new System.Drawing.Point(307, 75);
            this.cboAccounts.Name = "cboAccounts";
            this.cboAccounts.Size = new System.Drawing.Size(400, 33);
            this.cboAccounts.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(81, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "Select Account:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(217, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "VIEW ACCOUNT STATEMENT";
            // 
            // btnViewStatement
            // 
            this.btnViewStatement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnViewStatement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewStatement.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnViewStatement.ForeColor = System.Drawing.Color.White;
            this.btnViewStatement.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnViewStatement.Location = new System.Drawing.Point(408, 148);
            this.btnViewStatement.Name = "btnViewStatement";
            this.btnViewStatement.Size = new System.Drawing.Size(323, 60);
            this.btnViewStatement.TabIndex = 28;
            this.btnViewStatement.TabStop = false;
            this.btnViewStatement.Text = "View Statement";
            this.btnViewStatement.UseVisualStyleBackColor = false;
            this.btnViewStatement.Click += new System.EventHandler(this.btnViewStatement_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(71, 149);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(318, 59);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtgStatement
            // 
            this.dtgStatement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgStatement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgStatement.Location = new System.Drawing.Point(121, 319);
            this.dtgStatement.Name = "dtgStatement";
            this.dtgStatement.RowHeadersWidth = 62;
            this.dtgStatement.RowTemplate.Height = 33;
            this.dtgStatement.Size = new System.Drawing.Size(548, 275);
            this.dtgStatement.TabIndex = 30;
            // 
            // AccountStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.Controls.Add(this.dtgStatement);
            this.Controls.Add(this.btnViewStatement);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAccounts);
            this.Controls.Add(this.label4);
            this.Name = "AccountStatement";
            this.Size = new System.Drawing.Size(822, 631);
            this.Load += new System.EventHandler(this.AccountStatement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgStatement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAccounts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewStatement;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dtgStatement;
    }
}
