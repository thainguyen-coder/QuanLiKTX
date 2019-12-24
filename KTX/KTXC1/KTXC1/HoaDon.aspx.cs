using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTXC1
{
    public partial class HoaDon : System.Web.UI.Page
    {
        private void LayDuLieu()
        {
            HoaDonDAO HDDAO = new HoaDonDAO();
            gvHoaDon.DataSource = HDDAO.LayHoaDon();
            gvHoaDon.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LayDuLieu();
            }

        }
        private Hoadon LayDuLieuTuForm()
        {
            string mahd = txtMaHĐ.Text;
            string manv = txtMaNV.Text;
            string maphong = txtMaPhong.Text;
            string mctn = txtMaCTN.Text;
            string mctd = txtMaCTD.Text;
            string ngay = txtNgayGhi.Text;
            double tongtien =double.Parse(TextBox1.Text);



            Hoadon ph = new Hoadon
            {
                MaHD = mahd,
                MaNV = manv,
                MaPhong = maphong,
                MaCongToDien = mctd,
                MaCongToNuoc = mctn,
                NgayGhi = ngay,
                TongTien = tongtien

            };
            return ph;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Hoadon ph = LayDuLieuTuForm();

                HoaDonDAO phDAO = new HoaDonDAO();

                bool exist = phDAO.KTMaHD(ph.MaHD);
                if (exist)
                {
                    lblThongBao.Text = "Mã mã hóa đơn đã tồn tại";
                }
                else
                {
                    bool result = phDAO.Them(ph);
                    if (result)
                    {
                        lblThongBao.Text = "Thêm hóa đơn thành công";
                        LayDuLieu();

                    }
                    else
                    {
                        lblThongBao.Text = "Có lỗi, vui lòng thử lại!";
                    }
                }
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "cc";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Hoadon hd = LayDuLieuTuForm();
            HoaDonDAO nvDAO = new HoaDonDAO();
            bool result = nvDAO.ChinhSua(hd);
            if (result)
            {
                lblThongBao.Text = "Cập nhật thành công cho nhân viên: " + hd.MaHD;
                LayDuLieu();
            }
            else
            {
                lblThongBao.Text = "Cập nhật không thành công, vui lòng kiểm tra lại";
            }
        }

        protected void gvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string manv = gvHoaDon.SelectedRow.Cells[0].Text;
            HoaDonDAO nvDAO = new HoaDonDAO();
            Hoadon nv = nvDAO.LayHoaDon(manv);
            if (nv != null)
            {
                DoDuLieuVaoCacTruong(nv);
            }
        }
        public void DoDuLieuVaoCacTruong(Hoadon nv)
        {
            txtMaHĐ.Text = nv.MaHD;
            txtMaNV.Text = nv.MaNV;
            txtMaPhong.Text = nv.MaPhong;
            txtMaCTD.Text = nv.MaCongToDien;
            txtMaCTN.Text = nv.MaCongToNuoc;
            txtNgayGhi.Text = nv.NgayGhi;
            TextBox1.Text = nv.TongTien.ToString();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string manv = txtMaHĐ.Text;

            HoaDonDAO nvDAO = new HoaDonDAO();

            bool result = nvDAO.Xoa(manv);
            if (result)
            {
                lblThongBao.Text = "Xóa thành công";
                LayDuLieu();
            }
            else
            {
                lblThongBao.Text = "Xóa không thành công, vui lòng kiểm tra lại!";
            }
        }

        protected void Lable1_Load(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }
    }

}