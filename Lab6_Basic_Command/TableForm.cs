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
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        private void DisplayTable(SqlDataReader reader)
        {
            lvTable.Items.Clear();
            while(reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add((reader["Status"].ToString() == "0") ? "Còn trống" : "Có khách");
                item.SubItems.Add(reader["Capacity"].ToString());
                lvTable.Items.Add(item);
            }
        }

        private void LoadListView()
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT * FROM [Table] Order by Name";
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayTable(sqlDataReader);
            sqlConnection.Close();
        }

        private void ShowTable(ListViewItem item)
        {
            txtTableID.Text = item.SubItems[0].Text;
            txtTableName.Text = item.SubItems[1].Text;
            txtTableStatus.Text = (item.SubItems[2].Text) == "Còn trống" ? "0" : "1";
            txtTableCapacity.Text = item.SubItems[3].Text;
        }

        private void InsertTable()
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "EXEC Table_Insert 0, " + "N'"
                            + txtTableName.Text + "', 0, "
                            + txtTableCapacity.Text;
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int numOfRowEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowEffected == 1)
                MessageBox.Show("Đã thêm bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Thêm bàn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void UpdateTable()
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "EXEC Table_Update " + txtTableID.Text + ", N'"
                            + txtTableName.Text + "', "
                            + txtTableStatus.Text + ", "
                            + txtTableCapacity.Text;
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int numOfRowEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowEffected == 1)
                MessageBox.Show("Cập nhật bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Cập nhật bàn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DeleteTable(string tableID)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "EXEC Table_Delete " + tableID;
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            int numOfRowEffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            if (numOfRowEffected == 1)
                MessageBox.Show("Xóa bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Xóa bàn không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void lvTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = lvTable.SelectedItems.Count;

            if (count > 0)
            {
                ListViewItem item = lvTable.SelectedItems[0];
                ShowTable(item);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            InsertTable();
            LoadListView();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateTable();
            LoadListView();
        }

        private void DeleteTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = lvTable.SelectedItems.Count;

            if (count > 0)
            {
                DeleteTable(lvTable.SelectedItems[0].SubItems[0].Text);
                LoadListView();
            }
        }

        private void lvTable_DoubleClick(object sender, EventArgs e)
        {
            int count = lvTable.SelectedItems.Count;

            if (count > 0)
            {
                string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                string query = "SELECT A.ID, A.Name, TableID, Amount, Discount, Tax, A.[Status], CheckoutDate, Account "
                               + "FROM Bills A, [Table] B "
                               + "WHERE A.TableID = B.ID AND A.[Status] = 0 AND B.[Status] = 1 AND B.ID = " 
                               + lvTable.SelectedItems[0].SubItems[0].Text;
                sqlCommand.CommandText = query;

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BillsForm frm = new BillsForm();
                frm.DisplayBills(sqlDataReader);
                sqlConnection.Close();
                frm.ShowDialog();
            }
        }

        private void ViewListBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = lvTable.SelectedItems.Count;

            if (count > 0)
            {
                string TableName = lvTable.SelectedItems[0].SubItems[1].Text;
                BillsOfTableForm frm = new BillsOfTableForm(lvTable.SelectedItems[0].SubItems[0].Text);
                frm.Text = "Xem danh mục hóa đơn bàn " + TableName;
                frm.ShowDialog();               
            }
        }

        private void ViewSumaryBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string TableName = lvTable.SelectedItems[0].SubItems[1].Text;
            SumaryBillsForm frm = new SumaryBillsForm(lvTable.SelectedItems[0].SubItems[0].Text);
            frm.Text = "Xem nhật ký hóa đơn bàn " + TableName;
            frm.ShowDialog();
        }
    }
}
