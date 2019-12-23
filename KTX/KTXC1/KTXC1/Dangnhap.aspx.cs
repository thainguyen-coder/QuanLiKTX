using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KTXC1
{
    public partial class Dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        
        protected void btnDN_Click(object sender, EventArgs e)
        {
            TaiKhoanDAO nvDAO = new TaiKhoanDAO();
            string manv = txtUserName.Text;
            string mk = txtPassWord.Text;
            bool exist = nvDAO.KTDangNhapNV(manv, mk);
            if (exist)
            {

                Session["manv"] = manv;
                Session["mk"] = mk;
                Response.Redirect("TrangChu.aspx");

            }
            else
                {
                    Response.Write("<script>alert('Sai tên đăng nhập hoặc mật khẩu')</script>");
                }
        }
    }
}