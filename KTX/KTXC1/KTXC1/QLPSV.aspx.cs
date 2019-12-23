using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTXC1
{
    public partial class QLPSV : System.Web.UI.Page
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
            PhongSVDAO svDAO = new PhongSVDAO();
            gvPhongSV.DataSource = svDAO.LayPhongSV();
            gvPhongSV.DataBind();
        }
        private PhongSV LayDuLieuTuForm()
        {
            string maphong = txtMaPhong.Text;
            string masv = txtMaSV.Text;
            string ngaybd = txtNgayBD.Text;
            string ngaykt = txtNgayKT.Text;

            PhongSV sv = new PhongSV
            {
                MaPhong = maphong,
                MaSV = masv,
                NgayBD = ngaybd,
                NgayKT = ngaykt,
            };
            return sv;
        }
        public void DoDuLieuVaoCacTruong(PhongSV sv)
        {
            txtMaPhong.Text = sv.MaPhong;
            txtMaSV.Text = sv.MaSV;
            txtNgayBD.Text = sv.NgayBD;
            txtNgayKT.Text = sv.NgayKT;
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
                PhongSVDAO svDAO = new PhongSVDAO();
                gvPhongSV.DataSource = svDAO.Tim(key);
                gvPhongSV.DataBind();
            }

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            PhongSV sv = LayDuLieuTuForm();

            PhongSVDAO svDAO = new PhongSVDAO();

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
            string maphong = txtMaPhong.Text;
            PhongSVDAO svDAO = new PhongSVDAO();

            bool result = svDAO.Xoa(masv,maphong);
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
            PhongSV sv = LayDuLieuTuForm();
            PhongSVDAO svDAO = new PhongSVDAO();
            bool result = svDAO.ChinhSua(sv);
            if (result)
            {
                lblThongBao.Text = "Cập nhật thành công cho sinh viên: " + sv.MaSV;
                LaySinhVienVaoGV();
            }
            else
            {
                lblThongBao.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }

        }


        protected void gvPhongSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maphong = gvPhongSV.SelectedRow.Cells[0].Text;
            PhongSVDAO svDAO = new PhongSVDAO();
            PhongSV sv = svDAO.LayPhongSV(maphong);
            if (sv != null)
            {
                DoDuLieuVaoCacTruong(sv);
            }

        }

        protected void txtTim_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Menu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}