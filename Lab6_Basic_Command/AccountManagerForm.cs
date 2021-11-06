using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_Basic_Command
{
    public partial class AccountManagerForm : Form
    {
        private string currentRoleName = "";
        public AccountManagerForm()
        {
            InitializeComponent();
        }

        private string QueryRoleName(string RoleName, bool actived)
        {
            string query;
            if (string.IsNullOrWhiteSpace(RoleName))
            {

                if (actived)
                {
                    query = "SELECT A.AccountName, FullName, Email, Tell, Actived, RoleName "
                         + "FROM Account A, [Role] B, RoleAccount C "
                         + "WHERE A.AccountName = C.AccountName AND B.ID = C.RoleID AND Actived = 1";
                }
                else
                {
                    query = "SELECT A.AccountName, FullName, Email, Tell, Actived, RoleName "
                         + "FROM Account A, [Role] B, RoleAccount C "
                         + "WHERE A.AccountName = C.AccountName AND B.ID = C.RoleID";
                }
            }
            else
            {
                if (actived)
                {
                    query = "SELECT A.AccountName, FullName, Email, Tell, Actived, RoleName "
                         + "FROM Account A, [Role] B, RoleAccount C "
                         + "WHERE A.AccountName = C.AccountName AND B.ID = C.RoleID AND Actived = 1 AND RoleName = " + "N'" + RoleName + "'";
                }
                else
                {
                    query = "SELECT A.AccountName, FullName, Email, Tell, Actived, RoleName "
                         + "FROM Account A, [Role] B, RoleAccount C "
                         + "WHERE A.AccountName = C.AccountName AND B.ID = C.RoleID AND RoleName = " + "N'" + RoleName + "'";
                }
            }            
            currentRoleName = RoleName;
            return query;
        }

        private void DisplayAccount(SqlDataReader reader)
        {
            lvAccount.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["AccountName"].ToString());
                item.SubItems.Add(reader["FullName"].ToString());
                item.SubItems.Add(reader["Email"].ToString());
                item.SubItems.Add(reader["Tell"].ToString());
                item.SubItems.Add(reader["Actived"].ToString() == "True" ? "Hoạt động" : "Không hoạt động");
                item.SubItems.Add(reader["RoleName"].ToString());
                lvAccount.Items.Add(item);
            }
        }

        private void AccountManagerForm_Load(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT A.AccountName, FullName, Email, Tell, Actived, RoleName "
                            + "FROM Account A, [Role] B, RoleAccount C " 
                            + "WHERE A.AccountName = C.AccountName AND B.ID = C.RoleID";
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayAccount(sqlDataReader);
            sqlConnection.Close();
        }

        private void ViewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = QueryRoleName("", ActivedToolStripMenuItem.Checked);
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayAccount(sqlDataReader);
            sqlConnection.Close();
        }

        private void ViewAdminstratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = QueryRoleName("Adminstrator", ActivedToolStripMenuItem.Checked);
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayAccount(sqlDataReader);
            sqlConnection.Close();
        }

        private void ViewKeToanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = QueryRoleName("Kế toán", ActivedToolStripMenuItem.Checked);
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayAccount(sqlDataReader);
            sqlConnection.Close();
        }

        private void ViewNVThanhToanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = QueryRoleName("Nhân viên thanh toán", ActivedToolStripMenuItem.Checked);
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayAccount(sqlDataReader);
            sqlConnection.Close();
        }

        private void ViewNVPhucVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = QueryRoleName("Nhân viên phục vụ", ActivedToolStripMenuItem.Checked);
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayAccount(sqlDataReader);
            sqlConnection.Close();
        }

        private void ActivedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string query = "";

            if (ActivedToolStripMenuItem.Checked)
                query = QueryRoleName(currentRoleName, ActivedToolStripMenuItem.Checked);
            else
                query = QueryRoleName(currentRoleName, ActivedToolStripMenuItem.Checked);

            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();            
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayAccount(sqlDataReader);
            sqlConnection.Close();
        }

        private void InsertAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountSettingForm frm = new AccountSettingForm(null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ViewAllToolStripMenuItem.PerformClick();
            }
        }

        private void lvAccount_DoubleClick(object sender, EventArgs e)
        {
            int count = lvAccount.SelectedItems.Count;
            if (count > 0)
            {
                AccountSettingForm frm = new AccountSettingForm(lvAccount.SelectedItems[0].SubItems[0].Text);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ViewAllToolStripMenuItem.PerformClick();
                }
            }
        }

        private void ViewRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = lvAccount.SelectedItems.Count;
            if (count > 0)
            {
                string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                string query = "SELECT RoleName from Role A, RoleAccount B where A.ID = B.RoleID and AccountName = N'"
                    + lvAccount.SelectedItems[0].SubItems[0].Text + "'";
                sqlCommand.CommandText = query;

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                string msg = "";
                while (sqlDataReader.Read())
                {
                    msg += sqlDataReader["RoleName"].ToString() + ", ";
                }
                sqlConnection.Close();

                MessageBox.Show(msg, "Danh sách vai trò", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = lvAccount.SelectedItems.Count;
            if (count > 0)
            {
                string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                string query = "EXEC Account_Delete N'" + lvAccount.SelectedItems[0].SubItems[0].Text + "', 0";
                sqlCommand.CommandText = query;

                sqlConnection.Open();
                int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (numOfRowsEffected > 0)
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ViewAllToolStripMenuItem.PerformClick();
            }
        }        
    }
}
