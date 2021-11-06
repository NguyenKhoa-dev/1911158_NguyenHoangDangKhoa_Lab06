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
    public partial class BillsForm : Form
    {
        public BillsForm()
        {
            InitializeComponent();
        }

        public void DisplayBills(SqlDataReader reader)
        {
            lvBills.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["TableID"].ToString());
                item.SubItems.Add(reader["Amount"].ToString());
                item.SubItems.Add(reader["Discount"].ToString());
                item.SubItems.Add(reader["Tax"].ToString());
                item.SubItems.Add(Convert.ToInt32(reader["Status"]) == 1 ? "Đã thanh toán" : "Chưa thanh toán");
                item.SubItems.Add((DateTime.Parse(reader["CheckoutDate"].ToString()).ToShortDateString()));
                item.SubItems.Add(reader["Account"].ToString());
                lvBills.Items.Add(item);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (dtpFrom.Value >= dtpTo.Value)
            {
                MessageBox.Show("Ngày tháng không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                string query = "SELECT * FROM Bills WHERE CheckoutDate > '" + dtpFrom.Value.ToString("MM/dd/yyyy")
                                + "' AND CheckoutDate < '" + dtpTo.Value.ToString("MM/dd/yyyy") + "'";
                sqlCommand.CommandText = query;

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DisplayBills(sqlDataReader);
                sqlConnection.Close();
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT * FROM Bills";
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayBills(sqlDataReader);
            sqlConnection.Close();
        }

        private void lvBills_DoubleClick(object sender, EventArgs e)
        {
            int count = lvBills.SelectedItems.Count;
            if (count > 0)
            {
                BillDetailsForm frm = new BillDetailsForm();
                frm.LoadDetail(Convert.ToInt32(lvBills.SelectedItems[0].Text));
                frm.ShowDialog();
            }
        }
    }
}
