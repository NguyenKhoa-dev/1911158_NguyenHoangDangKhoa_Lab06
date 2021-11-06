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
    public partial class BillDetailsForm : Form
    {
        public BillDetailsForm()
        {
            InitializeComponent();
        }

        private void DisplayBillsDetail(SqlDataReader reader)
        {
            lvBillsDetail.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Quantity"].ToString());
                lvBillsDetail.Items.Add(item);
            }
        }

        public void LoadDetail(int BillsID)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query;

            query = "SELECT Name FROM Bills WHERE ID = " + BillsID;
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            Text = "Chi tiết hóa đơn: \"" + sqlCommand.ExecuteScalar().ToString() + "\"";

            query = "SELECT A.ID, B.Name, Quantity FROM BillDetails A, Food B WHERE A.FoodID = B.ID AND A.InvoiceID = " + BillsID;
            sqlCommand.CommandText = query;

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DisplayBillsDetail(sqlDataReader);
            sqlConnection.Close();
        }
    }
}
