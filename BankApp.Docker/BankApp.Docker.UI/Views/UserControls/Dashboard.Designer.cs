
namespace BankApp.UI
{
    partial class Dashboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.savinAcLbl = new System.Windows.Forms.Label();
            this.transactionsGrid = new System.Windows.Forms.DataGridView();
            this.crtNumLbl = new System.Windows.Forms.Label();
            this.lblSaveAccNo = new System.Windows.Forms.Label();
            this.lblCurrentAccNo = new System.Windows.Forms.Label();
            this.savBalLba = new System.Windows.Forms.Label();
            this.crtBalLbl = new System.Windows.Forms.Label();
            this.lblSavingsBal = new System.Windows.Forms.Label();
            this.lblCurrentBal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // savinAcLbl
            // 
            this.savinAcLbl.AutoSize = true;
            this.savinAcLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savinAcLbl.ForeColor = System.Drawing.Color.White;
            this.savinAcLbl.Location = new System.Drawing.Point(12, 3);
            this.savinAcLbl.Name = "savinAcLbl";
            this.savinAcLbl.Size = new System.Drawing.Size(217, 25);
            this.savinAcLbl.TabIndex = 0;
            this.savinAcLbl.Text = "Savings Account Number:";
            // 
            // transactionsGrid
            // 
            this.transactionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transactionsGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.transactionsGrid.Location = new System.Drawing.Point(121, 212);
            this.transactionsGrid.Name = "transactionsGrid";
            this.transactionsGrid.RowHeadersWidth = 62;
            this.transactionsGrid.RowTemplate.Height = 33;
            this.transactionsGrid.Size = new System.Drawing.Size(548, 275);
            this.transactionsGrid.TabIndex = 2;
            // 
            // crtNumLbl
            // 
            this.crtNumLbl.AutoSize = true;
            this.crtNumLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crtNumLbl.ForeColor = System.Drawing.Color.White;
            this.crtNumLbl.Location = new System.Drawing.Point(466, 4);
            this.crtNumLbl.Name = "crtNumLbl";
            this.crtNumLbl.Size = new System.Drawing.Size(214, 25);
            this.crtNumLbl.TabIndex = 3;
            this.crtNumLbl.Text = "Current Account Number:";
            // 
            // lblSaveAccNo
            // 
            this.lblSaveAccNo.AutoSize = true;
            this.lblSaveAccNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSaveAccNo.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblSaveAccNo.Location = new System.Drawing.Point(223, 3);
            this.lblSaveAccNo.Name = "lblSaveAccNo";
            this.lblSaveAccNo.Size = new System.Drawing.Size(112, 25);
            this.lblSaveAccNo.TabIndex = 4;
            this.lblSaveAccNo.Text = "7364527489";
            // 
            // lblCurrentAccNo
            // 
            this.lblCurrentAccNo.AutoSize = true;
            this.lblCurrentAccNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentAccNo.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblCurrentAccNo.Location = new System.Drawing.Point(675, 4);
            this.lblCurrentAccNo.Name = "lblCurrentAccNo";
            this.lblCurrentAccNo.Size = new System.Drawing.Size(112, 25);
            this.lblCurrentAccNo.TabIndex = 5;
            this.lblCurrentAccNo.Text = "7364527489";
            // 
            // savBalLba
            // 
            this.savBalLba.AutoSize = true;
            this.savBalLba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savBalLba.ForeColor = System.Drawing.Color.White;
            this.savBalLba.Location = new System.Drawing.Point(12, 29);
            this.savBalLba.Name = "savBalLba";
            this.savBalLba.Size = new System.Drawing.Size(75, 25);
            this.savBalLba.TabIndex = 6;
            this.savBalLba.Text = "Balance:";
            // 
            // crtBalLbl
            // 
            this.crtBalLbl.AutoSize = true;
            this.crtBalLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crtBalLbl.ForeColor = System.Drawing.Color.White;
            this.crtBalLbl.Location = new System.Drawing.Point(466, 29);
            this.crtBalLbl.Name = "crtBalLbl";
            this.crtBalLbl.Size = new System.Drawing.Size(75, 25);
            this.crtBalLbl.TabIndex = 7;
            this.crtBalLbl.Text = "Balance:";
            // 
            // lblSavingsBal
            // 
            this.lblSavingsBal.AutoSize = true;
            this.lblSavingsBal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSavingsBal.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblSavingsBal.Location = new System.Drawing.Point(80, 28);
            this.lblSavingsBal.Name = "lblSavingsBal";
            this.lblSavingsBal.Size = new System.Drawing.Size(112, 25);
            this.lblSavingsBal.TabIndex = 8;
            this.lblSavingsBal.Text = "7364527489";
            // 
            // lblCurrentBal
            // 
            this.lblCurrentBal.AutoSize = true;
            this.lblCurrentBal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentBal.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblCurrentBal.Location = new System.Drawing.Point(534, 29);
            this.lblCurrentBal.Name = "lblCurrentBal";
            this.lblCurrentBal.Size = new System.Drawing.Size(112, 25);
            this.lblCurrentBal.TabIndex = 9;
            this.lblCurrentBal.Text = "7364527489";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(59)))));
            this.Controls.Add(this.lblCurrentBal);
            this.Controls.Add(this.lblSavingsBal);
            this.Controls.Add(this.crtBalLbl);
            this.Controls.Add(this.savBalLba);
            this.Controls.Add(this.lblCurrentAccNo);
            this.Controls.Add(this.lblSaveAccNo);
            this.Controls.Add(this.crtNumLbl);
            this.Controls.Add(this.transactionsGrid);
            this.Controls.Add(this.savinAcLbl);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(822, 631);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactionsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label savinAcLbl;
        private System.Windows.Forms.DataGridView transactionsGrid;
        private System.Windows.Forms.Label crtNumLbl;
        private System.Windows.Forms.Label lblSaveAccNo;
        private System.Windows.Forms.Label lblCurrentAccNo;
        private System.Windows.Forms.Label savBalLba;
        private System.Windows.Forms.Label crtBalLbl;
        private System.Windows.Forms.Label lblSavingsBal;
        private System.Windows.Forms.Label lblCurrentBal;
    }
}
