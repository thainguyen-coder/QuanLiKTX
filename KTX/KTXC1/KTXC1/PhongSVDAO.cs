using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class PhongSVDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public int ThongKe()
        {
            string sql = @"SELECT COUNT(*) FROM PHONGSV";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count;
            }
        }
        public bool KTMaSV(string masv)
        {
            string sql = @"SELECT COUNT(*) FROM PHONGSV WHERE maSV = @masv";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@masv", masv);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        public bool KTMaPhong(string maphong)
        {
            string sql = @"SELECT COUNT(*) FROM PHONGSV WHERE maPhong = @maphong";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maphong", maphong);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        public PhongSV LayPhongSV(string maphong)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM PHONGSV WHERE maPhong = @maphong";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@maphong", maphong);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PhongSV sv = new PhongSV
                    {
                        MaPhong = (string)reader["maPhong"],
                        MaSV = (string)reader["maSV"],
                        //NgayBD = reader["ngayBD"].ToString(),
                        //NgayKT = reader["ngayKT"].ToString(),
                    };
                    return sv;
                }
            }
            return null;
        }
        public DataTable LayPhongSV()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM PHONGSV";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }

        public DataTable Tim(string key)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select * from PHONGSV where(maSV LIKE N'%" + key + "%' or maPhong LIKE N'%" + key + "%')";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public bool Them(PhongSV sv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO PHONGSV(maPhong,maSV,ngayBatDau,ngayKetThuc) VALUES(@maphong, @masv, @ngaybd, @ngaykt )";
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@maphong", sv.MaPhong);
                    command.Parameters.AddWithValue("@masv", sv.MaSV);
                    command.Parameters.AddWithValue("@ngaybd", Convert.ToDateTime(sv.NgayBD));
                    command.Parameters.AddWithValue("@ngaykt", Convert.ToDateTime(sv.NgayKT));
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return (result >= 1);
                }
            }
        }
        public bool ChinhSua(PhongSV sv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE PHONGSV SET ngayBatDau= @ngaybd, ngayKetThuc=@ngaykt WHERE maSV = @masv and maPhong=@maphong";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maphong", sv.MaPhong);
                command.Parameters.AddWithValue("@masv", sv.MaSV);
                command.Parameters.AddWithValue("@ngaybd", Convert.ToDateTime(sv.NgayBD));
                command.Parameters.AddWithValue("@ngaykt", Convert.ToDateTime(sv.NgayKT));
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Xoa(string masv,string maphong)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM PHONGSV WHERE maSV = @masv and maPhong = @maphong";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@masv", masv);
                command.Parameters.AddWithValue("@maphong", maphong);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}