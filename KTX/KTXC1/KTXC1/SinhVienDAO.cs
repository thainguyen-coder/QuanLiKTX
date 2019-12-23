using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class SinhVienDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public int ThongKe()
        {
            string sql = @"SELECT COUNT(*) FROM SINHVIEN";
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
            string sql = @"SELECT COUNT(*) FROM SINHVIEN WHERE maSV = @masv";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@masv", masv);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        public SinhVien LaySinhVien(string masv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM SINHVIEN WHERE maSV = @masv";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@masv", masv);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    SinhVien sv = new SinhVien
                    {
                        MaSV = (string)reader["maSV"],
                        TenSV = (string)reader["hoTen"],
                        NgaySinh = reader["ngaySinh"].ToString(),
                        GioiTinh = (string)reader["gioiTinh"],
                        CMND = (string)reader["cmnd"],
                        SDT = (string)reader["sdt"],
                        Lop = (string)reader["lop"],
                    };
                    return sv;
                }
            }
            return null;
        }
        public DataTable LaySinhVien()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM SINHVIEN";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }

        public DataTable Tim(string key)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select * from SINHVIEN where(maSV LIKE N'%" + key + "%' or hoTen LIKE N'%" + key + "%')";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public bool Them(SinhVien sv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO SINHVIEN(maSV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,lop) VALUES(@masv, @ten, @ngaysinh, @gioitinh, @diachi, @sdt, @lop)";
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@masv", sv.MaSV);
                    command.Parameters.AddWithValue("@ten", sv.TenSV);
                    command.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(sv.NgaySinh));
                    command.Parameters.AddWithValue("@gioitinh", sv.GioiTinh);
                    command.Parameters.AddWithValue("@diachi", sv.CMND);
                    command.Parameters.AddWithValue("@sdt", sv.SDT);
                    command.Parameters.AddWithValue("@lop", sv.Lop);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return (result >= 1);
                }
            }
        }
        public bool ChinhSua(SinhVien sv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE SINHVIEN SET hoTen= @ten, ngaySinh= @ngaysinh, gioiTinh = @gioitinh, cmnd = @cmnd,  sdt= @sdt, Lop = @lop WHERE maSV = @masv";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@masv", sv.MaSV);
                command.Parameters.AddWithValue("@ten", sv.TenSV);
                command.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(sv.NgaySinh));
                command.Parameters.AddWithValue("@gioitinh", sv.GioiTinh);
                command.Parameters.AddWithValue("@cmnd", sv.CMND);
                command.Parameters.AddWithValue("@sdt", sv.SDT);
                command.Parameters.AddWithValue("@lop", sv.Lop);
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result >= 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Xoa(string masv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"DELETE FROM SINHVIEN WHERE maSV = @masv";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@masv", masv);
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