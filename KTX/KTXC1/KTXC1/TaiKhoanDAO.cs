using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class TaiKhoanDAO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
        public bool KTDangNhapQL(string tendangnhap, string mk)
        {
            string sql = @"SELECT COUNT(*) FROM TAIKHOAN1 WHERE tenDangNhap='TDP' and matKhau = @mk ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                command.Parameters.AddWithValue("@mk", mk);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }

        public bool KTDangNhapNV(string tendangnhap, string mk)
        {
            string sql = @"SELECT COUNT(*) FROM TAIKHOAN1 WHERE tenDangNhap= @tendangnhap and matKhau = @mk";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                command.Parameters.AddWithValue("@mk", mk);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
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
        public bool KTTenDN(string tdn)
        {
            string sql = @"SELECT COUNT(*) FROM TAIKHOAN WHERE tenDangNhap = @tendangnhap";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@tendangnhap", tdn);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return (count >= 1);
            }
        }
        public TaiKhoan1 LayNhanVien(string manv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM NHANVIEN WHERE maNV = @manv";
                string sql1 = @"SELECT * FROM TAIKHOAN1 WHERE tenDangNhap = @tendangnhap,maNV = @manv";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlCommand cmd1 = new SqlCommand(sql1, connection);
                cmd.Parameters.AddWithValue("@manv", manv);
                cmd1.Parameters.AddWithValue("@tendangnhap",manv);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    TaiKhoan1 nv = new TaiKhoan1
                    {
                        MaNV = (string)reader["maNV"],
                        TenNV = (string)reader["hoTen"],
                        NgaySinh = reader["ngaySinh"].ToString(),
                        GioiTinh = (string)reader["gioiTinh"],
                        CMND = (string)reader["diaChi"],
                        SDT = (string)reader["sdt"],
                        ChucVu = (string)reader["chucVu"],
                        TenDangNhap = (string)reader1["tenDangNhap"],
                        MatKhau = (string)reader1["matKhau"],
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
            string sql = @"SELECT * FROM NHANVIEN,TAIKHOAN1 where NHANVIEN.maNV = TAIKHOAN1.maNV";
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
        public bool Them(TaiKhoan1 nv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"INSERT INTO NHANVIEN(maNV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,chucVu) VALUES(@manv, @ten, @ngaysinh, @gioitinh, @diachi, @sdt, @chucvu)";
                string sql1 = @"INSERT INTO TAIKHOAN1(tenDangNhap,matKhau,maNV) VALUES(@tendangnhap, @matkhau,@manv)";
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlCommand command1 = new SqlCommand(sql1, connection);
                    command.Parameters.AddWithValue("@manv", nv.MaNV);
                    command.Parameters.AddWithValue("@ten", nv.TenNV);
                    command.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(nv.NgaySinh));
                    command.Parameters.AddWithValue("@gioitinh", nv.GioiTinh);
                    command.Parameters.AddWithValue("@diachi", nv.CMND);
                    command.Parameters.AddWithValue("@sdt", nv.SDT);
                    command.Parameters.AddWithValue("@chucvu", nv.ChucVu);
                    command1.Parameters.AddWithValue("@tendangnhap", nv.TenDangNhap);
                    command1.Parameters.AddWithValue("@matkhau", nv.MatKhau);
                    command1.Parameters.AddWithValue("@manv", nv.MaNV);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    int result1 = command1.ExecuteNonQuery();
                    return (result >= 1 || result1 >=1);
                }
            }
        }
        public bool ChinhSua(TaiKhoan1 nv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"UPDATE NHANVIEN SET hoTen= @ten, ngaySinh= @ngaysinh, gioiTinh = @gioitinh, cmnd = @cmnd,  sdt= @sdt, chucVu = @chucvu WHERE maNV = @manv";
                string sql1 = @"UPDATE TAIKHOAN1 SET tenDangNhap= @tendangnhap, matKhau= @matkhau WHERE maNV = @manv";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlCommand command1 = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@manv", nv.MaNV);
                command.Parameters.AddWithValue("@ten", nv.TenNV);
                command.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(nv.NgaySinh));
                command.Parameters.AddWithValue("@gioitinh", nv.GioiTinh);
                command.Parameters.AddWithValue("@cmnd", nv.CMND);
                command.Parameters.AddWithValue("@sdt", nv.SDT);
                command.Parameters.AddWithValue("@chucvu", nv.ChucVu);
                command1.Parameters.AddWithValue("@tendangnhap", nv.TenDangNhap);
                command1.Parameters.AddWithValue("@chucvu", nv.MatKhau);
                command1.Parameters.AddWithValue("@manv", nv.MaNV);
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
                string sql1 = @"DELETE FROM TAIKHOAN1 WHERE tenDangNhap = @tendangnhap";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlCommand command1 = new SqlCommand(sql1, connection);
                command.Parameters.AddWithValue("@manv", manv);
                command1.Parameters.AddWithValue("@tendangnhap", manv);
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