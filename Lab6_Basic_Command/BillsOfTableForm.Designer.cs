namespace Lab6_Basic_Command
{
    partial class BillsOfTableForm
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
            this.lbxNgay = new System.Windows.Forms.ListBox();
            this.lvBillsOfTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lbxNgay
            // 
            this.lbxNgay.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxNgay.FormattingEnabled = true;
            this.lbxNgay.ItemHeight = 17;
            this.lbxNgay.Location = new System.Drawing.Point(13, 13);
            this.lbxNgay.Name = "lbxNgay";
            this.lbxNgay.Size = new System.Drawing.Size(172, 446);
            this.lbxNgay.TabIndex = 0;
            this.lbxNgay.SelectedIndexChanged += new System.EventHandler(this.lbxNgay_SelectedIndexChanged);
            // 
            // lvBillsOfTable
            // 
            this.lvBillsOfTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBillsOfTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvBillsOfTable.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBillsOfTable.FullRowSelect = true;
            this.lvBillsOfTable.GridLines = true;
            this.lvBillsOfTable.Location = new System.Drawing.Point(193, 13);
            this.lvBillsOfTable.MultiSelect = false;
            this.lvBillsOfTable.Name = "lvBillsOfTable";
            this.lvBillsOfTable.Size = new System.Drawing.Size(685, 446);
            this.lvBillsOfTable.TabIndex = 3;
            this.lvBillsOfTable.UseCompatibleStateImageBehavior = false;
            this.lvBillsOfTable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã hóa đơn";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên món ăn";
            this.columnHeader2.Width = 210;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tổng tiền";
            this.columnHeader5.Width = 140;
            // 
            // BillsOfTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 476);
            this.Controls.Add(this.lvBillsOfTable);
            this.Controls.Add(this.lbxNgay);
            this.Name = "BillsOfTableForm";
            this.Text = "BillsOfTableForm";
            this.Load += new System.EventHandler(this.BillsOfTableForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxNgay;
        private System.Windows.Forms.ListView lvBillsOfTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}