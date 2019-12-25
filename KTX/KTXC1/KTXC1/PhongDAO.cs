using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class PhongDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public bool KTMaPhong(string mp)
        {
            string sql = @"SELECT COUNT(*) FROM PHONG WHERE MaPhong = @mp";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mp", mp);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }

        internal bool Them(Hoadon ph)
        {
            throw new NotImplementedException();
        }

        public bool Them(Phong ph)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO PHONG(maPhong, soLuongSV,tinhTrangPhong) VALUES(@maphong, @soluong, @tinhtrangphong)";
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@maphong", ph.MaPhong);
                    command.Parameters.AddWithValue("@soluong", ph.SoLuongSV);
                    command.Parameters.AddWithValue("@tinhtrangphong", ph.TinhTrangPhong);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return (result >= 1);
                }
            }
        }
        public DataTable LayPhong()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM PHONG";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public Phong LayPhongTheoMa(string mp)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM PHONG WHERE MaPhong = @maphong";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@maphong", mp);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Phong ph = new Phong
                    {
                        MaPhong = reader["MaPhong"].ToString(),
                    };
                    return ph;
                }
            }
            return null;
        }
        public bool ChinhSua(Phong ph)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE PHONG SET soLuongSV= @soluong, tinhTrangPhong =@tinhtrangphong WHERE maPhong = @maphong";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maphong", ph.MaPhong);
                command.Parameters.AddWithValue("@soluong", ph.SoLuongSV);
                command.Parameters.AddWithValue("@tinhtrangphong", ph.TinhTrangPhong);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Xoa(string mp)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"DELETE FROM PHONG WHERE maPhong = @maphong";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@maphong", mp);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result >= 1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                
            }
          
            return false;
        }
        public DataTable Tim(string key)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select * from PHONG where (MaPhong LIKE N'%" + key + "%')";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
    }
}