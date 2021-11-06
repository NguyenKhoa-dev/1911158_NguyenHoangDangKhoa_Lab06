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
    public partial class frmFood : Form
    {
        int currentRows = 0;
        public frmFood()
        {
            InitializeComponent();
        }

        private void SetTitleDGVFood()
        {
            dgvFood.Columns[0].HeaderText = "Mã";
            dgvFood.Columns[1].HeaderText = "Tên thức ăn";
            dgvFood.Columns[2].HeaderText = "Đơn vị tính";
            dgvFood.Columns[3].HeaderText = "Loại";
            dgvFood.Columns[4].HeaderText = "Đơn giá";
            dgvFood.Columns[5].HeaderText = "Ghi chú";
            dgvFood.Columns[1].Width = 136;
        }

        public void LoadFood(int categoryID)
        {
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT Name FROM Category " + "WHERE ID = " + categoryID;
            sqlCommand.CommandText = query;

            sqlConnection.Open();

            string catName = sqlCommand.ExecuteScalar().ToString();
            Text = "Danh sách các món ăn thuộc nhóm: " + catName;
            query = "SELECT * FROM Food WHERE FoodCategoryID = " + categoryID;
            sqlCommand.CommandText = query;

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Food");
            da.Fill(dt);
            dgvFood.DataSource = dt;
            SetTitleDGVFood();

            currentRows = dgvFood.Rows.Count;

            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

        private void btnSaveFood_Click(object sender, EventArgs e)
        {
            int rowInsert = dgvFood.Rows.Count - currentRows;
            int numOfRowsEffected = 0;

            string query;
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            if (rowInsert > 0)
            {
                for (int i = currentRows - 1; i < dgvFood.Rows.Count - 1; i++)
                {
                    query = "EXEC InsertFood 0, N'"
                        + dgvFood.Rows[i].Cells[1].Value + "', N'"
                        + dgvFood.Rows[i].Cells[2].Value + "', "
                        + dgvFood.Rows[i].Cells[3].Value + ", "
                        + dgvFood.Rows[i].Cells[4].Value + ", N'"
                        + dgvFood.Rows[i].Cells[5].Value + "'";

                    sqlCommand.CommandText = query;

                    sqlConnection.Open();
                    numOfRowsEffected += sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                if (numOfRowsEffected == rowInsert)
                    MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                currentRows = dgvFood.Rows.Count;
                LoadFood(Convert.ToInt32(dgvFood.Rows[0].Cells[3].Value));
            }
            else
            {
                for (int i = 0; i < dgvFood.Rows.Count - 1; i++)
                {
                    query = "EXEC Food_Update "
                        + dgvFood.Rows[i].Cells[0].Value + ", N'"
                        + dgvFood.Rows[i].Cells[1].Value + "', N'"
                        + dgvFood.Rows[i].Cells[2].Value + "', "
                        + dgvFood.Rows[i].Cells[3].Value + ", "
                        + dgvFood.Rows[i].Cells[4].Value + ", N'"
                        + dgvFood.Rows[i].Cells[5].Value + "'";

                    sqlCommand.CommandText = query;

                    sqlConnection.Open();
                    numOfRowsEffected += sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                if (numOfRowsEffected == currentRows - 1)
                    MessageBox.Show("Cập nhật món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int numOfRowsEffected = 0;
            string query;
            string connectionString = "server = DESKTOP-RN0HE9G\\SQLEXPRESS; database = RestaurantManagement; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            foreach (DataGridViewRow row in dgvFood.SelectedRows)
            {
                query = "EXEC Food_Delete " + row.Cells[0].Value;
                sqlCommand.CommandText = query;

                sqlConnection.Open();
                numOfRowsEffected += sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            if (numOfRowsEffected == dgvFood.SelectedRows.Count)
                MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadFood(Convert.ToInt32(dgvFood.Rows[0].Cells[3].Value));
        }

        private void dgvFood_SelectionChanged(object sender, EventArgs e)
        {
            int count = dgvFood.SelectedRows.Count;
            if (count > 0)
                btnDeleteFood.Enabled = true;
            else
                btnDeleteFood.Enabled = false;
        }
    }
}
