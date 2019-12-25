using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class HoaDonDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public int ThongKe()
        {
            string sql = @"SELECT COUNT(*) FROM HOADON";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count;
            }
        }
        public bool KTMaHD(string mahd)
        {
            string sql = @"SELECT COUNT(*) FROM HOADON WHERE maHD = @mahd";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mahd", mahd);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        public Hoadon LayHoaDon(string mahd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM HOADON WHERE maHD = @mahd";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@mahd", mahd);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Hoadon hd = new Hoadon
                    {
                        MaHD = (string)reader["maHD"],
                        MaNV = (string)reader["maNV"],
                        MaPhong = reader["maPhong"].ToString(),
                        MaCongToDien = (string)reader["maCongToDien"],
                        MaCongToNuoc = (string)reader["maCongToNuoc"],
                        TongTien = (long)reader["tongTien"],
                        NgayGhi = (string)reader["ngayGhi"],
                        
                    };
                    return hd;
                }
            }
            return null;
        }


        public DataTable LayHoaDon()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM HOADON";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }

        public DataTable Tim(string key)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select * from HOADON where(maNV LIKE N'%" + key + "%' or hoTen LIKE N'%" + key + "%')";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public bool Them(Hoadon hd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO HOADON(maHD,maNV,maPhong,maCongToDien,maCongToNuoc,tongTien,ngayGhi)
                            VALUES(@mahd, @manv, @maphong, @mctd, @mctn, @tongtien, @ngayghi)";
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@mahd", hd.MaHD);
                    command.Parameters.AddWithValue("@manv", hd.MaNV);
                    command.Parameters.AddWithValue("@maphong", hd.MaPhong);
                    command.Parameters.AddWithValue("@mctd", hd.MaCongToDien);
                    command.Parameters.AddWithValue("@mctn", hd.MaCongToNuoc);
                    command.Parameters.AddWithValue("@tongtien", hd.TongTien);
                    command.Parameters.AddWithValue("@ngayghi", Convert.ToDateTime(hd.NgayGhi));
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                 
                    return (result >= 1);
                }
            }
        }
        public bool ChinhSua(Hoadon nv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE HOADON SET maHD=@mahd,maNV=@manv,maPhong=@maphong,maCongToDien=@mctd,maCongToNuoc=@mctn,tongTien=@tongtien,ngayGhi=@ngayghi WHERE maHD = @mahd";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mahd", nv.MaHD);
                command.Parameters.AddWithValue("@manv", nv.MaNV);
                command.Parameters.AddWithValue("@maphong", nv.MaPhong);
                command.Parameters.AddWithValue("@mctd", nv.MaCongToDien);
                command.Parameters.AddWithValue("@mctn", nv.MaCongToNuoc);
                command.Parameters.AddWithValue("@tongtien", nv.TongTien);
                command.Parameters.AddWithValue("@ngayghi", Convert.ToDateTime(nv.NgayGhi));
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Xoa(string manv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM HOADON WHERE maHD = @mahd";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mahd", manv);
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