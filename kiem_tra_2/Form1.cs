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

namespace kiem_tra_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updateTable();
            update.Enabled = false;
            delete.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
          
            DaiLy daiLy = new DaiLy(
                Convert.ToInt16(txtID.Text),
                txtTen.Text,
                txtPhone.Text,
                receptionDay.Value,
                address.Text,
                email.Text
                );
            daiLy.save();
            updateTable();

        }
        private void updateTable()
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=daily;Integrated Security=True;");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from daily", con);
            DataTable dt = new DataTable();
            con.Open();
            adapter.Fill(dt);
            grvData.DataSource = dt;
            con.Close();
            resetInputBox();
        }

        private void grvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = grvData.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = grvData.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPhone.Text = grvData.Rows[e.RowIndex].Cells[2].Value.ToString();
            receptionDay.Text = grvData.Rows[e.RowIndex].Cells[3].Value.ToString();
            address.Text = grvData.Rows[e.RowIndex].Cells[4].Value.ToString();
            email.Text = grvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            delete.Enabled = true;
            add.Enabled = false;
            update.Enabled = true;
            txtID.Enabled = false;
        }

        private void update_Click(object sender, EventArgs e)
        {
            DaiLy daiLy = new DaiLy(
                Convert.ToInt16(txtID.Text),
                txtTen.Text,
                txtPhone.Text,
                receptionDay.Value,
                address.Text,
                email.Text
                );
            daiLy.update();
            updateTable();
            txtID.Enabled = true;
            add.Enabled = true;
            resetInputBox();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DaiLy daiLy = new DaiLy(
               Convert.ToInt16(txtID.Text),
               txtTen.Text,
               txtPhone.Text,
               receptionDay.Value,
               address.Text,
               email.Text
               );
            daiLy.delete();
            updateTable();
            txtID.Enabled = true;
            add.Enabled = true;
            resetInputBox();
        }

        private void view_Click(object sender, EventArgs e)
        {
            updateTable();
            resetInputBox();
            txtID.Enabled = true;
            add.Enabled = true;
        }
        private void resetInputBox()
        {
            txtID.Text = "";
            txtTen.Text = "";
            txtPhone.Text = "";
            address.Text = "";
            email.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=daily;Integrated Security=True;");
            string search = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter($"select * from daily where name LIKE '%{search}%'", con);
            DataTable dt = new DataTable();
            con.Open();
            adapter.Fill(dt);
            grvData.DataSource = dt;
            con.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
