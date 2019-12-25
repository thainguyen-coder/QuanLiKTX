using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace KTXC1
{
    public class DienDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public DataTable ALL()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM DIEN", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
        public Dien NAME(string maCongToDien)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM DIEN WHERE maCongToDien = @md ", connection);
                cmd.Parameters.AddWithValue("@md", maCongToDien);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Dien D = new Dien
                    {
                        Macongtodien = (string)reader["maCongToDien"],
                        ChisoDau = (string)reader["chiSoDau"],
                        ChisoCuoi = (string)reader["chiSoCuoi"],
                        DonGia = (float)reader["gia"],
                        TieuThu = (string)reader["TieuThu"],
                        ThanhTien = (long)reader["thanhTien"],
                        NgayGhi = reader["ngayGhi"].ToString(),
                    };
                    return D;
                }
                return null;
            }
        }
        public bool checkmact(string maCongToDien)
        {
            string sql = @"SELECT COUNT(*) FROM DIEN WHERE maCongToDien = @ctd";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ctd", maCongToDien);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }

        public long getThanhTien(string maCongToDien)
        {

            string sql = "SELECT * FROM DIEN WHERE maCongToDien = @ctd ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ctd", maCongToDien);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return (long)reader["thanhTien"];
                }
                return 0;
            }
        }
        public DataTable Tim(string search)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select * from DIEN where(maCongToDien LIKE N'%" + search + "%' )";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public bool Them(Dien DN)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO DIEN(maCongToDien,chiSoDau,chiSoCuoi,tieuThu, gia, thanhTien,ngayGhi)
                                VALUES(@mctd,@csd,@csc,@tthu,@Gia,@ttien,@ngayghi)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@mctd", DN.Macongtodien);
                cmd.Parameters.AddWithValue("@csd", DN.ChisoDau);
                cmd.Parameters.AddWithValue("@csc", DN.ChisoCuoi);
                cmd.Parameters.AddWithValue("@tthu", DN.TieuThu);
                cmd.Parameters.AddWithValue("@Gia", DN.DonGia);
                cmd.Parameters.AddWithValue("@ttien", DN.ThanhTien);
                cmd.Parameters.AddWithValue("@ngayghi", Convert.ToDateTime(DN.NgayGhi));
                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return (result >= 1);
            }
        }
        public bool ChinhSua(Dien DN)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE DIEN SET chiSoDau= @csd, chiSoCuoi = @csc, tieuThu = @tthu,  gia= @Gia, thanhTien = @ttien, ngayGhi=@ngayghi WHERE maCongToDien = @mctd";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mctd", DN.Macongtodien);
                command.Parameters.AddWithValue("@csd", DN.ChisoDau);
                command.Parameters.AddWithValue("@csc", DN.ChisoCuoi);
                command.Parameters.AddWithValue("@tthu", DN.TieuThu);
                command.Parameters.AddWithValue("@Gia", DN.DonGia);
                command.Parameters.AddWithValue("@ttien", DN.ThanhTien);
                command.Parameters.AddWithValue("@ngayghi", Convert.ToDateTime(DN.NgayGhi));
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Xoa(string maCongToDien)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM DIEN WHERE maCongToDien = @mctd";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mctd", maCongToDien);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        public Dien LayDien(string mactd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT maCongToDien,chiSoDau,chiSoCuoi,ngayGhi,gia,TieuThu FROM DIEN WHERE maCongToDien = @mactd";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@mactd", mactd);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Dien hd = new Dien
                    {
                        Macongtodien = (string)reader["maCongToDien"],
                        ChisoDau =(string) reader["chiSoDau"],
                        ChisoCuoi =(string) reader["chiSoDau"],                                       
                       // ThanhTien =(long)reader["thanhTien"],
                        NgayGhi = reader["ngayGhi"].ToString(),
                        DonGia = (float)reader["gia"],
                        TieuThu =(string) reader["TieuThu"],
                    };
                    return hd;
                }
            }
            return null;
        }

    }
}