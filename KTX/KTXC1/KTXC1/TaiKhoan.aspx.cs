using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTXC1
{
    public partial class TaiKhoan : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayNhanVienVaoGV();
            }

        }
        private void LayNhanVienVaoGV()
        {
            TaiKhoanDAO nvDAO = new TaiKhoanDAO();
            gvTK.DataSource = nvDAO.LayNhanVien();
            gvTK.DataBind();
        }
        private TaiKhoan1 LayDuLieuTuForm()
        {
            string manv = txtMaNV.Text;
            string tennv = txtTenNV.Text;
            string ngaysinh = txtNgaySinh.Text;
            string cmnd = txtCMND.Text;
            string gioitinh = ddlGioiTinh.SelectedValue;
            string sdt = txtSDT.Text;
            string chucvu = ddlChucVu.SelectedValue;
            string tendangnhap = txtTenDangNhap.Text;
            string matkhau = txtMatKhau.Text;
            TaiKhoan1 nv = new TaiKhoan1
            {
                MaNV = manv,
                TenNV = tennv,
                NgaySinh = ngaysinh,
                GioiTinh = gioitinh,
                CMND = cmnd,
                SDT = sdt,
                ChucVu = chucvu,
                TenDangNhap = tendangnhap,
                MatKhau = matkhau,
            };
            return nv;
        }
        public void DoDuLieuVaoCacTruong(TaiKhoan1 nv)
        {
            txtMaNV.Text = nv.MaNV;
            txtTenNV.Text = nv.TenNV;
            txtNgaySinh.Text = nv.NgaySinh;
            txtCMND.Text = nv.CMND;
            txtSDT.Text = nv.SDT;
            ddlChucVu.SelectedValue = nv.ChucVu;
            ddlGioiTinh.SelectedValue = nv.GioiTinh.ToString();
            txtTenDangNhap.Text = nv.TenDangNhap;
            txtMatKhau.Text = nv.MatKhau;

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            TaiKhoan1 nv = LayDuLieuTuForm();

            TaiKhoanDAO nvDAO = new TaiKhoanDAO();

            bool exist = nvDAO.KTMaNV(nv.MaNV);
            bool exist1 = nvDAO.KTTenDN(nv.TenDangNhap);
            if (exist || exist1)
            {
                lblThongBao.Text = "Nhân Viên đã tồn tại";
            }
            else
            {
                bool result = nvDAO.Them(nv);
                if (result)
                {
                    lblThongBao.Text = "Thêm nhân viên thành công";
                    LayNhanVienVaoGV();
                }
                else
                {
                    lblThongBao.Text = "Có lỗi, vui lòng thử lại!";
                }
            }

        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string manv = txtMaNV.Text;

            TaiKhoanDAO nvDAO = new TaiKhoanDAO();

            bool result = nvDAO.Xoa(manv);
            if (result)
            {
                lblThongBao.Text = "Xóa thành công";
                LayNhanVienVaoGV();
            }
            else
            {
                lblThongBao.Text = "Xóa không thành công, vui lòng kiểm tra lại!";
            }

        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            TaiKhoan1 nv = LayDuLieuTuForm();
            TaiKhoanDAO nvDAO = new TaiKhoanDAO();
            bool result = nvDAO.ChinhSua(nv);
            if (result)
            {
                lblThongBao.Text = "Cập nhật thành công cho nhân viên: " + nv.TenNV;
                LayNhanVienVaoGV();
            }
            else
            {
                lblThongBao.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }

        }

        protected void gvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string manv = gvTK.SelectedRow.Cells[0].Text;
            TaiKhoanDAO nvDAO = new TaiKhoanDAO();
            TaiKhoan1 nv = nvDAO.LayNhanVien(manv);
            if (nv != null)
            {
                DoDuLieuVaoCacTruong(nv);
            }

        }
        protected void gvTaiKhoan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string manv = gvTK.Rows[e.RowIndex].Cells[0].Text;
            string ten = gvTK.Rows[e.RowIndex].Cells[1].Text;
            TaiKhoanDAO khDAO = new TaiKhoanDAO();
            bool result = khDAO.Xoa(manv);
            if (result)
            {
                lblThongBao.Text = "Đã xóa thành công nhân viên: " + ten;
                LayNhanVienVaoGV();
            }
            else
            {
                lblThongBao.Text = "Xóa không thành công, vui lòng kiểm tra lại";
            }

        }

        protected void txtTim_TextChanged(object sender, EventArgs e)
        {

        }
        }
}