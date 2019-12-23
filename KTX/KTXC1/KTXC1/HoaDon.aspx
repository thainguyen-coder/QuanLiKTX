<%@ Page Title="" Language="C#" MasterPageFile="~/HienThi.Master" AutoEventWireup="true" CodeBehind="HoaDon.aspx.cs" Inherits="KTXC1.HoaDon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Menu ID="Menu1" runat="server" BackColor="#66CCFF" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="Black" Orientation="Horizontal" StaticSubMenuIndent="10px">
                <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                <DynamicMenuStyle BackColor="#B5C7DE" />
                <DynamicSelectedStyle BackColor="#507CD1" />
                <Items>
                    <asp:MenuItem Text="Hệ Thống" Value="Hệ Thống" ImageUrl="~/Images/HeThong32.png" NavigateUrl="~/TrangQL.aspx">
                        <asp:MenuItem Text="Tài Khoản" Value="Tài Khoản" NavigateUrl="~/TaiKhoan.aspx"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Quản Lý" Value="Quản Lý" ImageUrl="~/Images/QuanLy32.png" NavigateUrl="~/TrangQL.aspx">
                        <asp:MenuItem Text="Quản Lý Sinh Viên" Value="Quản Lý Sinh Viên" NavigateUrl="~/QLSV.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Quản Lý Nhân Viên" Value="Quản Lý Nhân Viên" NavigateUrl="~/QLNV.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Quản Lý Phòng" Value="Quản Lý Phòng" NavigateUrl="~/QLPhong.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Quản Lý Điện Nước" Value="Quản Lý Điện Nước" NavigateUrl="~/QLDN.aspx">
                            <asp:MenuItem NavigateUrl="~/QLDN.aspx" Text="Quản lý nước" Value="Quản lý nước"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/QLD.aspx" Text="Quản lý điện" Value="Quản lý điện"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Quản Lý Phòng Sinh Viên" Value="Quản Lý Phòng Sinh Viên" NavigateUrl="~/QLPSV.aspx"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Hóa Đơn" Value="Hóa đơn" ImageUrl="~/Images/DanhGia32.png" NavigateUrl="~/HoaDon.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Trợ Giúp" Value="Trợ Giúp" ImageUrl="~/Images/TroGiup32.png">
                        <asp:MenuItem Text="Sự Cố" Value="Sự Cố"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Đăng Xuất" Value="Đăng Xuất" ImageUrl="~/Images/DangXuat32.png" NavigateUrl="~/DangNhap.aspx"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#66FF33" ForeColor="#3333CC" />
                <StaticMenuItemStyle BackColor="#99CCFF" HorizontalPadding="20px" VerticalPadding="5px" />
                <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
    <div>
        <table style="width: 463px">
            <asp:Label ID="Lable1" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red" Text="HÓA ĐƠN" Style="text-align: center"></asp:Label>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label3" runat="server" Text="Mã Hóa Đơn:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaHĐ" runat="server" ></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label4" runat="server" Text="Mã Nhân Viên :"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaNV" runat="server"></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label5" runat="server" Text="Mã Phòng:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaPhong" runat="server" ></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label8" runat="server" Text="Mã Công Tơ Điện:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaCTD" runat="server" ></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label7" runat="server" Text="Mã Công Tơ Nước:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaCTN" runat="server" ></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label6" runat="server" Text="Ngày Ghi:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtNgayGhi" runat="server" ></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label1" runat="server" Text="Tổng Tiền:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style8" colspan="3">
                    &nbsp;<img src="img/them.png" height="30px" width="30px" /><asp:Button ID="Button1" runat="server" Text="Thêm" class="btn" OnClick="btnThem_Click"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/update.png" height="30px" width="30px" /><asp:Button ID="Button2" runat="server" Text="Chỉnh sửa" class="btn" OnClick="btnSua_Click"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/xoa.png" height="30px" width="30px" /><asp:Button ID="Button3" runat="server" Text="Xóa" class="btn" OnClick="btnXoa_Click" OnClientClick="return confirm(&quot;Bạn chắc chắn muốn xóa?&quot;);"/>
                    </br>
                    <img src="img/thanhtoan.png" height="30px" width="30px" style="margin-left:150px" /><asp:Button ID="Button5" runat="server" Text="In hóa đơn" class="btn" OnClick="btnInHoaDon_Click"/>
                </td>
            </tr>

            </table>
    </div>
    <div style="width: 691px; padding-top: 2em; padding-left: 4em">
                    Nhập từ khóa cần tìm:
                    <asp:TextBox ID="txtTim" runat="server" class="txt"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/search.png"/ height="30px" width="30px">
                    <asp:Button ID="btnTim" runat="server" Text="Tìm kiếm" class="btn" OnClick="btnTim_Click" />
                    <div style="padding-left: 4em">
                    <asp:Label ID="lblThongBao" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                    </div>
                </div>
    <asp:GridView ID="gvHoaDon" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" Width="800px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="maHD" HeaderText="Mã Hóa Đơn" />
                <asp:BoundField DataField="maNV" HeaderText="Mã Nhân Viên" />
                <asp:BoundField DataField="maPhong" HeaderText="Mã Phòng" />
                <asp:BoundField DataField="maCongToDien" HeaderText="Mã CT Điện" />
                <asp:BoundField DataField="maCongToNuoc" HeaderText="Mã CT Nước" />
                <asp:BoundField  DataField="ngayGhi" HeaderText="Ngày Ghi" />
                <asp:BoundField DataField="tongTien" HeaderText="Tổng Tiền" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black"  />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
</asp:Content>
