using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Linq;
using System.Web.UI;
using System.Web;

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
                LayDuLieu();
            }

        }
        private void BindGridViewData()
        {
            string connection = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlDataAdapter da = new SqlDataAdapter(" SELECT * FROM HOADON  ", con);


                
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvHoaDon.DataSource = ds;
                gvHoaDon.DataBind();
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
            long tongtien =long.Parse(TextBox1.Text);




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
        private void ExportGridToExcel()
        {
            //cach 2
            //Đối tượng Response dùng để gửi các đáp ứng của server cho client. Chúng ta thường dùng một số lệnh Response sau:
            //Xóa tất cả đầu ra nội dung từ luồng đệm.
           
       
            string FileName = "Hóa Đơn" + DateTime.Now + ".xls";
            // cho phép bạn ghi vào chuỗi một cách đồng bộ hoặc không đồng bộ. 
            StringWriter strwritter = new StringWriter();
            //được sử dụng để hiển thị HTML 4.0 cho các trình duyệt máy tính
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //cung cấp loại nội dung để mở tệp xlsx trong broowser ....

            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);

            gvHoaDon.GridLines = GridLines.Both;
            gvHoaDon.HeaderStyle.Font.Bold = true;
            //xuất nội dung điều khiển máy chủ cho một đối tượng HtmlTextWrite
            gvHoaDon.RenderControl(htmltextwrtter);
            //Đưa thông tin ra màn hình trang web
            Response.Write(strwritter.ToString());
            //Ngừng xử lý các Script. Dùng lệnh này khi muốn dừng xử lý ở một vị trí nào đó và bỏ qua các mã lệnh ASP ở phía sau. Đây là cách rất hay dùng trong một số tình huống, chẳng hạn như debug lỗi
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
           
        }


        protected void tinhThanhTien()
        {
            string maCongToDien = txtMaCTD.Text;
            string maCongToNuoc = txtMaCTN.Text;
            DienDAO dienDao = new DienDAO();
            long tienDien = dienDao.getThanhTien(maCongToDien);

            QLDNDAO nuocDao = new QLDNDAO();
            long tienNuoc = nuocDao.getThanhTien(maCongToNuoc);

            TextBox1.Text = (tienDien + tienNuoc) + "";

        }

        protected void txtMaCTD_TextChanged(object sender, EventArgs e)
        {
            this.tinhThanhTien();
        }

        protected void txtMaCTN_TextChanged(object sender, EventArgs e)
        {
            this.tinhThanhTien();

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            this.tinhThanhTien();

        }

        protected void Button6_Click1(object sender, EventArgs e)
        {
            this.tinhThanhTien();
        }

    }

}