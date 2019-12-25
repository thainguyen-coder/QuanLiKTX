using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace KTXC1
{
    public class QLDNDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public DataTable ALL()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM NUOC", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            return table;
        }
        public DN NAME(string maCongToNuoc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM NUOC WHERE maCongToNuoc = @mn ", connection);
                cmd.Parameters.AddWithValue("@mn", maCongToNuoc);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DN NC = new DN
                    {
                        MaCongToNuoc = (string)reader["maCongToNuoc"],
                        ChisoDau = (string)reader["chiSoDau"],
                        ChisoCuoi = (string)reader["chiSoCuoi"],
                        DonGia = (float)reader["gia"],
                        ThanhTien = (long)reader["thanhTien"],
                        NgayGhi = reader["ngayGhi"].ToString(),
                    };
                    return NC;
                }
                return null;
            }
        }
        public bool checkmact(string maCongToNuoc)
        {
            string sql = @"SELECT COUNT(*) FROM NUOC WHERE maCongToNuoc = @ctn";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ctn", maCongToNuoc);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }

        public long getThanhTien(string maCongToNuoc)
        {

            string sql = "SELECT * FROM NUOC WHERE maCongToNuoc = @ctn ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@ctn", maCongToNuoc);
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
            string sql = @"select * from NUOC where(maCongToNuoc LIKE N'%" + search + "%' )";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public bool Them(DN DN)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO NUOC(maCongToNuoc,chiSoDau,chiSoCuoi,tieuThu, gia, thanhTien,ngayGhi)
                                VALUES(@mctn,@csd,@csc,@tthu,@Gia,@ttien,@ngayghi)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@mctn", DN.MaCongToNuoc);
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
        public bool ChinhSua(DN DN)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE NUOC SET chiSoDau= @csd, chiSoCuoi = @csc, tieuThu = @tthu,  gia= @Gia, thanhTien = @ttien, ngayGhi=@ngayghi WHERE maCongToNuoc = @mctn";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@mctn", DN.MaCongToNuoc);
                command.Parameters.AddWithValue("@csd", DN.ChisoDau);
                command.Parameters.AddWithValue("@csc", DN.ChisoCuoi);
                command.Parameters.AddWithValue("@tthu", DN.TieuThu);
                command.Parameters.AddWithValue("@Gia", DN.DonGia);
                command.Parameters.AddWithValue("@ttien", DN.ThanhTien);
                command.Parameters.AddWithValue("@ngayghi", DN.NgayGhi);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Xoa(string maCongToNuoc)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"DELETE FROM NUOC WHERE maCongToNuoc = @mctn";
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@mctn", maCongToNuoc);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result >= 1)
                    {
                        return true;
                    }
                }
            }
            catch (Exception) { }
            return false;
        }
    }
}