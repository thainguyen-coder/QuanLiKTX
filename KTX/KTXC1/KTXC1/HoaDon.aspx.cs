using System;
using System.Collections.Generic;
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
            if(!IsPostBack)
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
    }

    }