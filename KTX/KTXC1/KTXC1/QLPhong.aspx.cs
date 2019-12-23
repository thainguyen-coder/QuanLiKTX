using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTXC1
{
    public partial class QLPhong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayPhongVaoGV();
            }
        }

        private void LayPhongVaoGV()
        {
            PhongDAO phDAO = new PhongDAO();
            gvPhong.DataSource = phDAO.LayPhong();
            gvPhong.DataBind();
        }
        private Phong LayDuLieuTuForm()
        {
            string maPhong = txtMaPhong.Text;
            string tinhTrangPhong = txtTinhTrangPhong.Text;
            int soLuongSV = int.Parse(txtSoLuongSV.Text);

            Phong ph = new Phong
            {
                MaPhong = maPhong,
                TinhTrangPhong = tinhTrangPhong,
                SoLuongSV = soLuongSV,
            };
            return ph;
        }

        public void DoDuLieuVaoCacTruong(Phong ph)
        {
            
            txtMaPhong.Text = ph.MaPhong;
            txtTinhTrangPhong.Text = ph.TinhTrangPhong;
            //ph.SoLuongSV = int.Parse(txtSoLuongSV.Text);
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            Phong ph = LayDuLieuTuForm();

            PhongDAO phDAO = new PhongDAO();

            bool exist = phDAO.KTMaPhong(ph.MaPhong);
            if (exist)
            {
                lblThongBao.Text = "Mã phòng đã tồn tại";
            }
            else
            {
                bool result = phDAO.Them(ph);
                if (result)
                {
                    lblThongBao.Text = "Thêm phòng thành công";
                    LayPhongVaoGV();

                }
                else
                {
                    lblThongBao.Text = "Có lỗi, vui lòng thử lại!";
                }
            }

        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            string maphong = txtMaPhong.Text;
            Phong ph = LayDuLieuTuForm();
            PhongDAO phDAO = new PhongDAO();
            bool result = phDAO.ChinhSua(ph);
            if (result)
            {

                lblThongBao.Text = "Cập nhật thành công cho Mã Phòng: " + maphong;
                LayPhongVaoGV();
            }
            else
            {
                lblThongBao.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string maphong = txtMaPhong.Text;

            PhongDAO phDAO = new PhongDAO();

            bool result = phDAO.Xoa(maphong);
            if (result)
            {
                lblThongBao.Text = "Xóa thành công";
                LayPhongVaoGV();
            }
            else
            {
                lblThongBao.Text = "Xóa không thành công, vui lòng kiểm tra lại!";
            }
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
                lblThongBao.Text = "Kết quả tìm kiếm cho từ khóa :'" + txtTim.Text + "'";
                PhongDAO phDAO = new PhongDAO();
                gvPhong.DataSource = phDAO.Tim(key);
                gvPhong.DataBind();
            }
        }
        protected void gvPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mp = gvPhong.SelectedRow.Cells[0].Text;
            PhongDAO phDAO = new PhongDAO();
            Phong ph = phDAO.LayPhongTheoMa(mp);
            if (ph != null)
            {
                DoDuLieuVaoCacTruong(ph);
            }
        }


        protected void txtTim_TextChanged(object sender, EventArgs e)
        {
        }
    }
}