namespace Lab6_Basic_Command
{
    partial class AccountManagerForm
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
            this.components = new System.ComponentModel.Container();
            this.lvAccount = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewAdminstratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewKeToanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewNVThanhToanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewNVPhucVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trạngTháiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActivedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InsertAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAccount
            // 
            this.lvAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvAccount.ContextMenuStrip = this.contextMenuStrip1;
            this.lvAccount.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAccount.FullRowSelect = true;
            this.lvAccount.GridLines = true;
            this.lvAccount.Location = new System.Drawing.Point(3, 27);
            this.lvAccount.MultiSelect = false;
            this.lvAccount.Name = "lvAccount";
            this.lvAccount.Size = new System.Drawing.Size(918, 464);
            this.lvAccount.TabIndex = 0;
            this.lvAccount.UseCompatibleStateImageBehavior = false;
            this.lvAccount.View = System.Windows.Forms.View.Details;
            this.lvAccount.DoubleClick += new System.EventHandler(this.lvAccount_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên tài khoản";
            this.columnHeader1.Width = 124;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ tên";
            this.columnHeader2.Width = 205;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Email";
            this.columnHeader3.Width = 145;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SĐT";
            this.columnHeader4.Width = 125;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Trạng thái";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Vai trò";
            this.columnHeader6.Width = 150;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemToolStripMenuItem,
            this.trạngTháiToolStripMenuItem,
            this.InsertAccountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(921, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xemToolStripMenuItem
            // 
            this.xemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewAdminstratorToolStripMenuItem,
            this.ViewKeToanToolStripMenuItem,
            this.ViewNVThanhToanToolStripMenuItem,
            this.ViewNVPhucVuToolStripMenuItem,
            this.toolStripSeparator1,
            this.ViewAllToolStripMenuItem});
            this.xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            this.xemToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.xemToolStripMenuItem.Text = "Xem";
            // 
            // ViewAdminstratorToolStripMenuItem
            // 
            this.ViewAdminstratorToolStripMenuItem.Name = "ViewAdminstratorToolStripMenuItem";
            this.ViewAdminstratorToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ViewAdminstratorToolStripMenuItem.Text = "Adminstrator";
            this.ViewAdminstratorToolStripMenuItem.Click += new System.EventHandler(this.ViewAdminstratorToolStripMenuItem_Click);
            // 
            // ViewKeToanToolStripMenuItem
            // 
            this.ViewKeToanToolStripMenuItem.Name = "ViewKeToanToolStripMenuItem";
            this.ViewKeToanToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ViewKeToanToolStripMenuItem.Text = "Kế toán";
            this.ViewKeToanToolStripMenuItem.Click += new System.EventHandler(this.ViewKeToanToolStripMenuItem_Click);
            // 
            // ViewNVThanhToanToolStripMenuItem
            // 
            this.ViewNVThanhToanToolStripMenuItem.Name = "ViewNVThanhToanToolStripMenuItem";
            this.ViewNVThanhToanToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ViewNVThanhToanToolStripMenuItem.Text = "Nhân viên thanh toán";
            this.ViewNVThanhToanToolStripMenuItem.Click += new System.EventHandler(this.ViewNVThanhToanToolStripMenuItem_Click);
            // 
            // ViewNVPhucVuToolStripMenuItem
            // 
            this.ViewNVPhucVuToolStripMenuItem.Name = "ViewNVPhucVuToolStripMenuItem";
            this.ViewNVPhucVuToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ViewNVPhucVuToolStripMenuItem.Text = "Nhân viên phục vụ";
            this.ViewNVPhucVuToolStripMenuItem.Click += new System.EventHandler(this.ViewNVPhucVuToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // ViewAllToolStripMenuItem
            // 
            this.ViewAllToolStripMenuItem.Name = "ViewAllToolStripMenuItem";
            this.ViewAllToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ViewAllToolStripMenuItem.Text = "Tất cả";
            this.ViewAllToolStripMenuItem.Click += new System.EventHandler(this.ViewAllToolStripMenuItem_Click);
            // 
            // trạngTháiToolStripMenuItem
            // 
            this.trạngTháiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActivedToolStripMenuItem});
            this.trạngTháiToolStripMenuItem.Name = "trạngTháiToolStripMenuItem";
            this.trạngTháiToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.trạngTháiToolStripMenuItem.Text = "Trạng thái";
            // 
            // ActivedToolStripMenuItem
            // 
            this.ActivedToolStripMenuItem.CheckOnClick = true;
            this.ActivedToolStripMenuItem.Name = "ActivedToolStripMenuItem";
            this.ActivedToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.ActivedToolStripMenuItem.Text = "Active";
            this.ActivedToolStripMenuItem.Click += new System.EventHandler(this.ActivedToolStripMenuItem_Click);
            // 
            // InsertAccountToolStripMenuItem
            // 
            this.InsertAccountToolStripMenuItem.Name = "InsertAccountToolStripMenuItem";
            this.InsertAccountToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.InsertAccountToolStripMenuItem.Text = "Thêm tài khoản";
            this.InsertAccountToolStripMenuItem.Click += new System.EventHandler(this.InsertAccountToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteAccountToolStripMenuItem,
            this.ViewRolesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 70);
            // 
            // DeleteAccountToolStripMenuItem
            // 
            this.DeleteAccountToolStripMenuItem.Name = "DeleteAccountToolStripMenuItem";
            this.DeleteAccountToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.DeleteAccountToolStripMenuItem.Text = "Xóa tài khoản";
            this.DeleteAccountToolStripMenuItem.Click += new System.EventHandler(this.DeleteAccountToolStripMenuItem_Click);
            // 
            // ViewRolesToolStripMenuItem
            // 
            this.ViewRolesToolStripMenuItem.Name = "ViewRolesToolStripMenuItem";
            this.ViewRolesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ViewRolesToolStripMenuItem.Text = "Xem danh sách vai trò";
            this.ViewRolesToolStripMenuItem.Click += new System.EventHandler(this.ViewRolesToolStripMenuItem_Click);
            // 
            // AccountManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 491);
            this.Controls.Add(this.lvAccount);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AccountManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.AccountManagerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAccount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewAdminstratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewKeToanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewNVThanhToanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewNVPhucVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ViewAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trạngTháiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActivedToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripMenuItem InsertAccountToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DeleteAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewRolesToolStripMenuItem;
    }
}