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
    public partial class BillsOfTableForm : Form
    {
        private string _tableID;
        public BillsOfTableForm(string TableID)
        {
            _tableID = TableID;
            InitializeComponent();
        }

        private void LoadListBox()
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT CheckoutDate FROM Bills WHERE TableID = " + _tableID; 
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            lbxNgay.Items.Clear();
            while (sqlDataReader.Read())
            {
                lbxNgay.Items.Add(sqlDataReader["CheckoutDate"].ToString().Split(' ')[0]);
            }
            sqlConnection.Close();                   
        }

        private void LoadListView(SqlDataReader reader)
        {
            lvBillsOfTable.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Quantity"].ToString());
                item.SubItems.Add(reader["Price"].ToString());
                item.SubItems.Add(reader["Amount"].ToString());
                lvBillsOfTable.Items.Add(item);
            }
        }

        private void BillsOfTableForm_Load(object sender, EventArgs e)
        {
            LoadListBox();
        }

        private void lbxNgay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ngay = DateTime.Parse(lbxNgay.SelectedItem.ToString()).ToString("MM/dd/yyyy");

            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT A.ID, C.Name, Quantity, Price, Price * Quantity as Amount "
                            + "FROM Bills A, BillDetails B, Food C "
                            + "WHERE A.ID = B.InvoiceID AND B.FoodID = C.ID AND CheckoutDate = '"
                            + ngay + "' AND TableID = " + _tableID;
            sqlCommand.CommandText = query;

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            LoadListView(sqlDataReader);
            sqlConnection.Close();
        }
    }
}
