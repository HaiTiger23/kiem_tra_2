using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiem_tra_2
{
    internal class DaiLy
    {
        private int id;
        private String name;
        private String phone;
        private DateTime receptionDay;
        private String address;
        private String email;
        private SqlConnection conn;

        public DaiLy(int id, string name, string phone, DateTime receptionDay, string address, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.ReceptionDay = receptionDay;
            this.Address = address;
            this.Email = email;
            this.conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=daily;Integrated Security=True;");
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public void save()
        {
            String sql = $"insert into daily values('{this.id}','{this.name}','{this.phone}','{this.receptionDay}','{this.address}','{this.email}')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Thêm Thành Công");
            this.conn.Close();
        }
        public void update()
        {
            String sql = $"update daily set name = '{this.name}', phone = '{this.phone}', receptionDay = '{this.receptionDay}',address = '{this.address}', email = '{this.email}' where id = '{this.id}'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cập nhật Thành Công");
            this.conn.Close();
        }
        public void delete()
        {
            SqlCommand cmd = new SqlCommand($"DELETE FROM daily WHERE id = '{id}';", conn);
            this.conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xóa Thành Công");
            this.conn.Close();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime ReceptionDay { get => receptionDay; set => receptionDay = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
    }
}
