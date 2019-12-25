using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.WebControls;
using System.IO;

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
                BindGridViewData();
            }

        }
        private void BindGridViewData()
        {
            string connection = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from HOADON", con);
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            int columnsCount = gvHoaDon.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns
            PdfPTable pdfTable = new PdfPTable(columnsCount);
            // Loop thru each cell in GrdiView header row
            foreach (TableCell gridViewHeaderCell in gvHoaDon.HeaderRow.Cells)
            {
                // Create the Font Object for PDF document
                Font font = new Font();
                // Set the font color to GridView header row font color
                font.Color = new BaseColor(gvHoaDon.HeaderStyle.ForeColor);

                // Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(gvHoaDon.HeaderStyle.BackColor);

                // Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }
            // Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in gvHoaDon.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    // Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(gvHoaDon.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfCell.BackgroundColor = new BaseColor(gvHoaDon.RowStyle.BackColor);

                        pdfTable.AddCell(pdfCell);
                    }
                }

            }
        
            // Create the PDF document specifying page size and margins
            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            // Roate page using Rotate() function, if you want in Landscape
            // pdfDocument.SetPageSize(PageSize.A4.Rotate());

            // Using PageSize.A4_LANDSCAPE may not work as expected
            // Document pdfDocument = new Document(PageSize.A4_LANDSCAPE, 10f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                "attachment;filename=HoaDon.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
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