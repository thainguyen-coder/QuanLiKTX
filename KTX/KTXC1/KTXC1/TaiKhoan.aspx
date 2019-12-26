<%@ Page Title="" Language="C#" MasterPageFile="~/HienThi.Master" AutoEventWireup="true" CodeBehind="TaiKhoan.aspx.cs" Inherits="KTXC1.TaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 30px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div >
           <table id="Form" border="1" style="margin-left:0px;margin-top:20px;width:600px;height:500px;">
              <tr>
                  <td>               
                      <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red" Text="QUẢN LÝ TÀI KHOẢN CÁN BỘ NHÂN VIÊN"></asp:Label>              
                  </td>
              </tr>
               <tr>
                   <td>
                       <asp:Label ID="Label3" runat="server" Text="Thông tin tài khoản" Font-Size="20px" BackColor="#00CC99" BorderColor="White" ForeColor="White"></asp:Label>  
                       
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label runat="server" Text="Mã nhân viên: "></asp:Label>
                       <asp:TextBox ID="txtMaNV" runat="server" style="margin-left: 5px" Width="111px"></asp:TextBox>
                       <asp:Label ID="Label4" runat="server" Text="Họ Tên: "></asp:Label>
                       <asp:TextBox ID="txtTenNV" runat="server" style="margin-left: 23px" Width="131px"></asp:TextBox>
                   </td>
               </tr>
                 <tr>
                   <td>

                       <asp:Label ID="Label1" runat="server" Text="CMND: "></asp:Label>
                       <asp:TextBox ID="txtCMND" runat="server" style="margin-left: 23px" Width="131px"></asp:TextBox>
                       <asp:Label ID="Label13" runat="server" Text="Số Điện Thoại: "></asp:Label>
                       <asp:TextBox ID="txtSDT" runat="server" style="margin-left: 5px" Width="111px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td class="auto-style3">

                       <asp:Label ID="Label6" runat="server" Text="Ngày Sinh :"></asp:Label>
                       <asp:TextBox ID="txtNgaySinh" runat="server" style="margin-left: 9px" Width="126px"></asp:TextBox>
                       <asp:Label ID="Label7" runat="server" Text="Địa chỉ : "></asp:Label>
                       <asp:TextBox ID="txtDiaChi" runat="server" style="margin-left: 49px" Width="113px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                       <asp:Label ID="Label8" runat="server" Text="Giới Tính :"></asp:Label>
                       <asp:DropDownList ID="ddlGioiTinh" runat="server" style="margin-left: 20px" Width="116px" Height="19px">
                           <asp:ListItem>Nam</asp:ListItem>
                           <asp:ListItem>Nữ</asp:ListItem>
                       </asp:DropDownList>
                       <asp:Label ID="Label10" runat="server" Text="Tên Đăng Nhập :"></asp:Label>
                       <asp:TextBox ID="txtTenDangNhap" runat="server" style="margin-left: 16px" Width="112px" Height="16px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td>
                      <asp:Label ID="Label9" runat="server" Text="Chức Vụ :"></asp:Label>
                       <asp:DropDownList ID="ddlChucVu" runat="server" style="margin-left: 16px" Height="16px" Width="114px">
                           <asp:ListItem>Giám Đốc</asp:ListItem>
                           <asp:ListItem>QL Phòng</asp:ListItem>
                           <asp:ListItem>QL Điện Nước</asp:ListItem>
                           <asp:ListItem>QL Nhân Viên</asp:ListItem>
                           <asp:ListItem>QL Sinh Viên</asp:ListItem>
                       </asp:DropDownList>
                       <asp:Label ID="Label11" runat="server" Text="Mật Khẩu :"></asp:Label>
                       <asp:TextBox ID="txtMatKhau" type="password" runat="server" style="margin-left: 58px" Width="111px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                <td class="auto-style8" colspan="3">
                    &nbsp;<img src="img/them.png" height="30px" width="30px" /><asp:Button ID="btnThem" runat="server" Text="Thêm" class="btn" OnClick="btnThem_Click"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/update.png" height="30px" width="30px" /><asp:Button ID="btnSua" runat="server" Text="Chỉnh sửa" class="btn" OnClick="btnSua_Click"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/xoa.png" height="30px" width="30px" /><asp:Button ID="btnXoa" runat="server" Text="Xóa" class="btn" OnClick="btnXoa_Click" OnClientClick="return confirm(&quot;Bạn chắc chắn muốn xóa?&quot;);"/>
                </td>
            </tr>
               <tr>
                   <td>
                     <div style="padding-left: 4em">
                    <asp:Label ID="lblThongBao" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                    </div>
                       </td>
               </tr>
               <tr>
                   <td>
                       
                       <asp:GridView ID="gvTK" runat="server" AutoGenerateColumns="False" Height="126px" Width="600px">
                           <Columns>
                               <asp:BoundField DataField="maNV" HeaderText="Mã nhân viên">
                               <ControlStyle BackColor="#0000CC" />
                               <FooterStyle BackColor="#0000CC" />
                               <HeaderStyle ForeColor="#0000CC" />
                               </asp:BoundField>
                               <asp:BoundField DataField="hoTen" HeaderText="Tên nhân viên">
                               <HeaderStyle ForeColor="#0000CC" />
                               </asp:BoundField>
                               <asp:BoundField DataField="chucVu" HeaderText="Chức vụ">
                               <HeaderStyle ForeColor="#0000CC" />
                               </asp:BoundField>
                               <asp:BoundField DataField="tenDangNhap" HeaderText="Tên đăng nhập">
                               <HeaderStyle ForeColor="#0000CC" />
                               </asp:BoundField>
                           </Columns>
                       </asp:GridView>
                       
                   </td>
               </tr>

           </table>
       </div>
    </asp:Content>

