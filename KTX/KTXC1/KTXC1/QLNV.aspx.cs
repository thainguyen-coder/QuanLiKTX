using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTXC1
{
    public partial class QLNV : System.Web.UI.Page
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
            NhanVienDAO nvDAO = new NhanVienDAO();
            gvNhanVien.DataSource = nvDAO.LayNhanVien();
            gvNhanVien.DataBind();
        }
        private NhanVien LayDuLieuTuForm()
        {
            string manv = txtMaNV.Text;
            string tennv = txtTenNV.Text;
            string ngaysinh = txtNgaySinh.Text;
            string cmnd = txtCMND.Text;
            string gioitinh = ddlGioiTinh.SelectedValue;
            string sdt = txtSDT.Text;
            string chucvu = ddlChucVu.SelectedValue;

            NhanVien nv = new NhanVien
            {
                MaNV = manv,
                TenNV = tennv,
                NgaySinh = ngaysinh,
                GioiTinh = gioitinh,
                CMND = cmnd,
                SDT = sdt,
                ChucVu = chucvu
            };
            return nv;
        }
        public void DoDuLieuVaoCacTruong(NhanVien nv)
        {
            txtMaNV.Text = nv.MaNV;
            txtTenNV.Text = nv.TenNV;
            txtNgaySinh.Text = nv.NgaySinh;
            txtCMND.Text = nv.CMND;
            txtSDT.Text = nv.SDT;
            ddlChucVu.SelectedValue = nv.ChucVu;
            ddlGioiTinh.SelectedValue = nv.GioiTinh.ToString();

        }

        protected void btnTim_Click(object sender, EventArgs e)
        {
            string key = txtTim.Text;
            if (string.IsNullOrEmpty(key))
            {
                lblThongBao.Text = "Bạn phải nhập từ khóa trước khi tìm";
            }
            else
            {
                lblThongBao.Text = "Kết quả tìm kiếm";
                NhanVienDAO nvDAO = new NhanVienDAO();
                gvNhanVien.DataSource = nvDAO.Tim(key);
                gvNhanVien.DataBind();
            }

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nv = LayDuLieuTuForm();

            NhanVienDAO nvDAO = new NhanVienDAO();

            bool exist = nvDAO.KTMaNV(nv.MaNV);
            if (exist)
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

            NhanVienDAO nvDAO = new NhanVienDAO();

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
            NhanVien nv = LayDuLieuTuForm();
            NhanVienDAO nvDAO = new NhanVienDAO();
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


        protected void gvNhanVienlectedIndexChanged(object sender, EventArgs e)
        {
            string manv = gvNhanVien.SelectedRow.Cells[0].Text;
            NhanVienDAO nvDAO = new NhanVienDAO();
            NhanVien nv = nvDAO.LayNhanVien(manv);
            if (nv != null)
            {
                DoDuLieuVaoCacTruong(nv);
            }

        }

        protected void txtTim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}