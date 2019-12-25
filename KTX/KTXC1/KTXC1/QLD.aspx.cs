using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace KTXC1
{
    public partial class QLD : System.Web.UI.Page
    {
        private void LayDuLieuTuGirdview()
        {
            DienDAO DienDAO = new DienDAO();
            gvDien.DataSource = DienDAO.ALL();
            gvDien.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuTuGirdview();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            int csd;
            int csc;
            int dg;
            csd = Convert.ToInt16(txtChisocdau.Text);
            csc = Convert.ToInt16(txtChisocuoi.Text);
            dg = Convert.ToInt16(txtDongia.Text);
            int tthu;
            tthu = (csc - csd);
            txtTieuthu.Text = tthu.ToString();
            Dien DN = LayDuLieuTuForm();
            DienDAO DienDAO = new DienDAO();
            bool exist = DienDAO.checkmact(DN.Macongtodien);
            if (exist)
            {
                lblThongBao.Text = "Mã công tơ nước đã tồn tại";

            }
            else
            {
                bool result = DienDAO.Them(DN);
                if (result)
                {
                    lblThongBao.Text = "Tính thành công";
                    LayDuLieuTuGirdview();
                }
                else
                {
                    lblThongBao.Text = "Lỗi";
                }
            }
        }
        private Dien LayDuLieuTuForm()
        {

            string maCongToDien = txtMacongtodien.Text;
            string chisodau = txtChisocdau.Text;
            string chisocuoi = txtChisocuoi.Text;
            string ngayghi = txtNgayghi.Text;
            float gia = float.Parse(txtDongia.Text);
            string tieuthu = txtTieuthu.Text;
            double thanhtien = double.Parse(tieuthu) * gia;
            long thanhtien1 = Convert.ToInt64(thanhtien);
            Dien D = new Dien
            {
                Macongtodien = maCongToDien,
                ChisoDau = chisodau,
                ChisoCuoi = chisocuoi,
                NgayGhi = ngayghi,
                TieuThu = tieuthu,
                DonGia = gia,
                ThanhTien = thanhtien1,
            };
            return D;
        }

        protected void gvDienNuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMacongtodien.Text = gvDien.SelectedRow.Cells[0].Text;
            txtChisocdau.Text = gvDien.SelectedRow.Cells[1].Text;
            txtChisocuoi.Text = gvDien.SelectedRow.Cells[2].Text;
            txtNgayghi.Text = gvDien.SelectedRow.Cells[3].Text;
            txtDongia.Text = gvDien.SelectedRow.Cells[4].Text;
        }
        public void DoDuLieuVaoCacTruong(Dien nv)
        {
            txtMacongtodien.Text = nv.Macongtodien;
            txtChisocdau.Text = nv.ChisoDau;
            txtChisocuoi.Text = nv.ChisoCuoi;
            txtNgayghi.Text = nv.NgayGhi;
            txtDongia.Text = nv.DonGia.ToString();
            txtTieuthu.Text = nv.TieuThu;
            
            

        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            int csd;
            int csc;
            int dg;
            csd = Convert.ToInt16(txtChisocdau.Text);
            csc = Convert.ToInt16(txtChisocuoi.Text);
            dg = Convert.ToInt16(txtDongia.Text);
            int tthu;
            tthu = (csc - csd);
            txtTieuthu.Text = tthu.ToString();
            Dien D = LayDuLieuTuForm();
            DienDAO DienDAO = new DienDAO();
            bool result = DienDAO.ChinhSua(D);
            if (result)
            {
                lblThongBao.Text = "Cập nhật thành công : " + D.NgayGhi;
                LayDuLieuTuGirdview();
            }
            else
            {
                lblThongBao.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string maCongToDien = txtMacongtodien.Text;

            DienDAO DienDAO = new DienDAO();

            bool result = DienDAO.Xoa(maCongToDien);
            if (result)
            {
                lblThongBao.Text = "Xóa thành công";
                LayDuLieuTuGirdview();
            }
            else
            {
                lblThongBao.Text = "Xóa không thành công, vui lòng kiểm tra lại!";
            }
        }

        protected void btnTim_Click1(object sender, EventArgs e)
        {
            string search = txtTim.Text;
            if (string.IsNullOrEmpty(search))
            {
                lblThongBao.Text = "Bạn phải nhập từ khóa trước khi tìm";
            }
            else
            {
                lblThongBao.Text = "Kết quả tìm kiếm";
                DienDAO DienDAO = new DienDAO();
                gvDien.DataSource = DienDAO.Tim(search);
                gvDien.DataBind();
            }
        }
    }
    }