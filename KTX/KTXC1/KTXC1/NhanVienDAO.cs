using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class NhanVienDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        
        public int ThongKe()
        {
            string sql = @"SELECT COUNT(*) FROM NHANVIEN";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count;
            }
        }
        public bool KTMaNV(string manv)
        {
            string sql = @"SELECT COUNT(*) FROM NHANVIEN WHERE maNV = @manv";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@manv", manv);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        public NhanVien LayNhanVien(string manv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM NHANVIEN WHERE maNV = @manv";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@manv", manv);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNV = (string)reader["maNV"],
                        TenNV = (string)reader["hoTen"],
                        NgaySinh = reader["ngaySinh"].ToString(),
                        GioiTinh = (string)reader["gioiTinh"],
                        CMND = (string)reader["cmnd"],
                        SDT = (string)reader["sdt"],
                        ChucVu = (string)reader["chucVu"],
                    };
                    return nv;
                }
            }
            return null;
        }
        public DataTable LayNhanVien()
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT * FROM NHANVIEN";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }

        public DataTable Tim(string key)
        {
            DataTable table = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"select * from NHANVIEN where(maNV LIKE N'%" + key + "%' or hoTen LIKE N'%" + key + "%')";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(table);
            return table;
        }
        public bool Them(NhanVien nv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO NHANVIEN(maNV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,chucVu) VALUES(@manv, @ten, @ngaysinh, @gioitinh, @diachi, @sdt, @chucvu)";
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@manv", nv.MaNV);
                    command.Parameters.AddWithValue("@ten", nv.TenNV);
                    command.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(nv.NgaySinh));
                    command.Parameters.AddWithValue("@gioitinh", nv.GioiTinh);
                    command.Parameters.AddWithValue("@diachi", nv.CMND);
                    command.Parameters.AddWithValue("@sdt", nv.SDT);
                    command.Parameters.AddWithValue("@chucvu", nv.ChucVu);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return (result >= 1);
                }
            }
        }
        public bool ChinhSua(NhanVien nv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE NHANVIEN SET hoTen= @ten, ngaySinh= @ngaysinh, gioiTinh = @gioitinh, cmnd = @cmnd,  sdt= @sdt, chucVu = @chucvu WHERE MaNV = @manv";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@manv", nv.MaNV);
                command.Parameters.AddWithValue("@ten", nv.TenNV);
                command.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(nv.NgaySinh));
                command.Parameters.AddWithValue("@gioitinh", nv.GioiTinh);
                command.Parameters.AddWithValue("@cmnd", nv.CMND);
                command.Parameters.AddWithValue("@sdt", nv.SDT);
                command.Parameters.AddWithValue("@chucvu", nv.ChucVu);
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
                string sql = @"DELETE FROM NHANVIEN WHERE maNV = @manv";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@manv", manv);
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