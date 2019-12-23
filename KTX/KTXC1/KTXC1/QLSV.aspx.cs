using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTXC1
{
    public partial class QLSV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LaySinhVienVaoGV();
            }

        }
        private void LaySinhVienVaoGV()
        {
            SinhVienDAO svDAO = new SinhVienDAO();
            gvSinhVien.DataSource = svDAO.LaySinhVien();
            gvSinhVien.DataBind();
        }
        private SinhVien LayDuLieuTuForm()
        {
            string masv = txtMaSV.Text;
            string tensv = txtTenSV.Text;
            string ngaysinh = txtNgaySinh.Text;
            string cmnd = txtCMND.Text;
            string gioitinh = ddlGioiTinh.SelectedValue;
            string sdt = txtSDT.Text;
            string lop = txtLop.Text;

            SinhVien sv = new SinhVien
            {
                MaSV = masv,
                TenSV = tensv,
                NgaySinh = ngaysinh,
                GioiTinh = gioitinh,
                CMND = cmnd,
                SDT = sdt,
                Lop = lop,
            };
            return sv;
        }
        public void DoDuLieuVaoCacTruong(SinhVien sv)
        {
            txtMaSV.Text = sv.MaSV;
            txtTenSV.Text = sv.TenSV;
            txtNgaySinh.Text = sv.NgaySinh;
            txtCMND.Text = sv.CMND;
            txtSDT.Text = sv.SDT;
            ddlGioiTinh.SelectedValue = sv.GioiTinh.ToString();
            txtLop.Text = sv.Lop;

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
                SinhVienDAO svDAO = new SinhVienDAO();
                gvSinhVien.DataSource = svDAO.Tim(key);
                gvSinhVien.DataBind();
            }

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = LayDuLieuTuForm();

            SinhVienDAO svDAO = new SinhVienDAO();

            bool exist = svDAO.KTMaSV(sv.MaSV);
            if (exist)
            {
                lblThongBao.Text = "Sinh viên đã tồn tại";
            }
            else
            {
                bool result = svDAO.Them(sv);
                if (result)
                {
                    lblThongBao.Text = "Thêm sinh viên thành công";
                    LaySinhVienVaoGV();
                }
                else
                {
                    lblThongBao.Text = "Có lỗi, vui lòng thử lại!";
                }
            }

        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string masv = txtMaSV.Text;

            SinhVienDAO svDAO = new SinhVienDAO();

            bool result = svDAO.Xoa(masv);
            if (result)
            {
                lblThongBao.Text = "Xóa thành công";
                LaySinhVienVaoGV();
            }
            else
            {
                lblThongBao.Text = "Xóa không thành công, vui lòng kiểm tra lại!";
            }

        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = LayDuLieuTuForm();
            SinhVienDAO svDAO = new SinhVienDAO();
            bool result = svDAO.ChinhSua(sv);
            if (result)
            {
                lblThongBao.Text = "Cập nhật thành công cho sinh viên: " + sv.TenSV;
                LaySinhVienVaoGV();
            }
            else
            {
                lblThongBao.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }

        }


        protected void gvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string masv = gvSinhVien.SelectedRow.Cells[0].Text;
            SinhVienDAO svDAO = new SinhVienDAO();
            SinhVien sv = svDAO.LaySinhVien(masv);
            if (sv != null)
            {
                DoDuLieuVaoCacTruong(sv);
            }

        }

        protected void txtTim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}