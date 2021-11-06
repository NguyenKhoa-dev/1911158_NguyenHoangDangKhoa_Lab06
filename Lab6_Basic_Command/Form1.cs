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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT ID, Name, Type FROM Category";
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayCategory(sqlDataReader);
            sqlConnection.Close();
        } 

        private void DisplayCategory(SqlDataReader reader)
        {
            lvCategory.Items.Clear();

            while(reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
                lvCategory.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "INSERT INTO Category (Name, [Type])" + "VALUES (N'" + txtName.Text + "', " + txtType.Text + ")";
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLoad.PerformClick();
                txtName.Text = "";
                txtType.Text = "";
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvCategory.SelectedItems[0];

            txtID.Text = item.Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[2].Text;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "UPDATE Category SET Name = N'" + txtName.Text + 
                            "', [TYPE] = " + txtType.Text +
                            "WHERE ID = " + txtID.Text;
            sqlCommand.CommandText = query;
            sqlConnection.Open();

            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                item.SubItems[1].Text = txtName.Text;
                item.SubItems[2].Text = txtType.Text;

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Cập nhật món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "DELETE FROM Category " + "WHERE ID = " + txtID.Text;
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                lvCategory.Items.Remove(item);

                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại sau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
                btnDelete.PerformClick();
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                frmFood foodForm = new frmFood();
                foodForm.Show();
                foodForm.LoadFood(Convert.ToInt32(txtID.Text));
            }
        }

        private void BillsFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT * FROM Bills";
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            BillsForm bills = new BillsForm();
            bills.DisplayBills(sqlDataReader);
            sqlConnection.Close();
            bills.ShowDialog();
        }

        private void AccountManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountManagerForm frm = new AccountManagerForm();
            frm.ShowDialog();
        }

        private void TableManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm frm = new TableForm();
            frm.ShowDialog();
        }
    }
}
