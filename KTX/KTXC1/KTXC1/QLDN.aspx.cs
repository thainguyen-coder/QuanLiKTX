using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTXC1
{
    public partial class QLDN : System.Web.UI.Page
    {
        private void LayDuLieuTuGirdview()
        {
            QLDNDAO QLDAO = new QLDNDAO();
            gvNuoc.DataSource = QLDAO.ALL();
            gvNuoc.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieuTuGirdview();
            }
        }
        protected void btnTim_Click(object sender, EventArgs e)
        {
            string search = txtTim.Text;
            if (string.IsNullOrEmpty(search))
            {
                lblThongBao.Text = "Bạn phải nhập từ khóa trước khi tìm";
            }
            else
            {
                lblThongBao.Text = "Kết quả tìm kiếm";
                QLDNDAO QLDAO = new QLDNDAO();
                gvNuoc.DataSource = QLDAO.Tim(search);
                gvNuoc.DataBind();
            }
        }
        protected void txtTim_TextChanged(object sender, EventArgs e)
        {
        }

        protected void gvDienNuoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private DN LayDuLieuTuForm()
        {

            string maCongToNuoc = txtMacongtonuoc.Text;
            string chisodau = txtChisocdau.Text;
            string chisocuoi = txtChisocuoi.Text;
            string ngayghi = txtNgayghi.Text;
            float gia = float.Parse(txtDongia.Text);
            string tieuthu = txtTieuthu.Text;
            double thanhtien = double.Parse(tieuthu) * gia;
            DN dn = new DN
            {
                MaCongToNuoc = maCongToNuoc,
                ChisoDau = chisodau,
                ChisoCuoi = chisocuoi,
                NgayGhi = ngayghi,
                TieuThu = tieuthu,
                DonGia = gia,
                ThanhTien = thanhtien,
            };
            return dn;
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
            DN dn = LayDuLieuTuForm();
            QLDNDAO QLDAO = new QLDNDAO();
            bool exist = QLDAO.checkmact(dn.MaCongToNuoc);
            if (exist)
            {
                lblThongBao.Text = "Mã công tơ nước đã tồn tại";

            }
            else
            {
                bool result = QLDAO.Them(dn);
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
            DN DN = LayDuLieuTuForm();
            QLDNDAO QLDAO = new QLDNDAO();
            bool result = QLDAO.ChinhSua(DN);
            if (result)
            {
                lblThongBao.Text = "Cập nhật thành công : " + DN.NgayGhi;
                LayDuLieuTuGirdview();
            }
            else
            {
                lblThongBao.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }

        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            string maCongToNuoc = txtMacongtonuoc.Text;

            QLDNDAO QLDAO = new QLDNDAO();

            bool result = QLDAO.Xoa(maCongToNuoc);
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
    }
}