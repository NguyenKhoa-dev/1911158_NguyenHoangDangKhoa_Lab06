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
    public partial class AccountSettingForm : Form
    {
        private string _AccountName;
        public AccountSettingForm(string AccountName)
        {
            _AccountName = AccountName;
            InitializeComponent();
        }

        private void LoadCombobox()
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT RoleName FROM Role";
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            cbbRole.Items.Clear();
            while(sqlDataReader.Read())
            {
                cbbRole.Items.Add(sqlDataReader["RoleName"].ToString());
            }
                        
            sqlConnection.Close();
        }

        private void InsertAccount()
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "EXEC Account_Insert N'"
                            + txtAccountName.Text + "', N'"
                            + txtPassword.Text + "', N'"
                            + txtHoTen.Text + "', N'"
                            + txtEmail.Text + "', N'"
                            + txtSDT.Text + "', '"
                            + DateTime.Now.ToString("MM/dd/yyyy") + "'";
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowsEffected > 0)
                MessageBox.Show("Đã tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Vui lòng tạo lại tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InsertRoleAccount();
        }

        private void UpdateAccount()
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "EXEC Account_Update N'"
                            + txtAccountName.Text + "', N'"
                            + txtPassword.Text + "', N'"
                            + txtHoTen.Text + "', N'"
                            + txtEmail.Text + "', N'"
                            + txtSDT.Text + "'";
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
                MessageBox.Show("Đã cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Vui lòng cập nhật lại tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InsertRoleAccount()
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "EXEC RoleAccount_Insert "
                            + (cbbRole.SelectedIndex + 1) + ", N'"
                            + txtAccountName.Text + "', "
                            + 1 + ", "
                            + "NULL";
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();           
        }

        private void ShowAccount(SqlDataReader reader)
        {
            while(reader.Read())
            {
                txtAccountName.Text = reader["AccountName"].ToString();
                txtPassword.Text = reader["Password"].ToString();
                txtConfirmPassword.Text = reader["Password"].ToString();
                txtHoTen.Text = reader["FullName"].ToString();
                txtEmail.Text = reader["Email"].ToString();
                txtSDT.Text = reader["Tell"].ToString();
                cbbRole.Text = reader["RoleName"].ToString();
            }
        }

        private void AccountSettingForm_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            if (_AccountName != null)
            {
                txtAccountName.Enabled = false;
                cbbRole.Enabled = false;
                btnResetPassword.Enabled = true;

                string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                string query = "SELECT A.AccountName, Password, FullName, Email, Tell, RoleName "
                         + "FROM Account A, [Role] B, RoleAccount C "
                         + "WHERE A.AccountName = C.AccountName AND B.ID = C.RoleID AND A.AccountName = " + "N'" + _AccountName + "'";
                sqlCommand.CommandText = query;

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                ShowAccount(sqlDataReader);
                sqlConnection.Close();
            }
            else
            {
                cbbRole.Enabled = true;
                txtAccountName.Enabled = true;
                btnResetPassword.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_AccountName == null)
            {
                if (string.IsNullOrWhiteSpace(txtAccountName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)
                    || string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(cbbRole.Text))
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin của tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (txtPassword.Text.CompareTo(txtConfirmPassword.Text) == 0)
                    {
                        InsertAccount();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Mật khẩu không trùng khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtHoTen.Text))
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin của tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (txtPassword.Text.CompareTo(txtConfirmPassword.Text) == 0)
                    {
                        UpdateAccount();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Mật khẩu không trùng khớp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }                        
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "EXEC Password_Reset N'"
                            + txtAccountName.Text + "', N'1'";
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
                MessageBox.Show("Đã reset mật khẩu thành công!, mật khẩu hiện tại là 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Lỗi reset mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
    }
}
