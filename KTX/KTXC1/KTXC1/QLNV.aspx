<%@ Page Title="" Language="C#" MasterPageFile="~/HienThi.Master" AutoEventWireup="true" CodeBehind="QLNV.aspx.cs" Inherits="KTXC1.QLNV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Lable1" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red" Text="QUẢN LÝ NHÂN VIÊN"></asp:Label>
        <table style="width: 463px">
            <tr>
                <td>

                    <asp:Label ID="Label2" runat="server" Text="Mã nhân viên:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaNV" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaNV" runat="server" ErrorMessage="*" ControlToValidate="txtMaNV" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label3" runat="server" Text="Họ tên nhân viên:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtTenNV" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvHoTen" runat="server" ErrorMessage="*" ControlToValidate="txtTenNV" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label4" runat="server" Text="Ngày sinh:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtNgaySinh" runat="server" ></asp:TextBox>

                </td>
                <td> <asp:Label ID="Label10" runat="server" Text="(YYYY/MM/DD)" ForeColor="red"></asp:Label></td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label5" runat="server" Text="Giới tính:"></asp:Label>
                    </td>
                <td>
                    <asp:DropDownList ID="ddlGioiTinh" runat="server">
                        <asp:ListItem>Nam</asp:ListItem>
                        <asp:ListItem>Nữ</asp:ListItem>
                    </asp:DropDownList>

                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label6" runat="server" Text="CMND:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtCMND" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCMND" runat="server" ErrorMessage="*" ControlToValidate="txtCMND" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label7" runat="server" Text="Số điện thoại:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtSDT" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSDT" runat="server" ErrorMessage="*" ControlToValidate="txtSDT" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label9" runat="server" Text="Chức vụ:"></asp:Label>
                    </td>
                <td>
                    <asp:DropDownList ID="ddlChucVu" runat="server">
                        <asp:ListItem>Quản lý điện nước</asp:ListItem>
                        <asp:ListItem>Quản lý phòng</asp:ListItem>
                        <asp:ListItem>Quản lý sinh viên</asp:ListItem>
                        <asp:ListItem>Quản lý nhân viên</asp:ListItem>
                    </asp:DropDownList>

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
            </table>
    </div>

    <div style="width: 691px; padding-top: 2em; padding-left: 4em">
                    Nhập từ khóa cần tìm:
                    <asp:TextBox ID="txtTim" runat="server" class="txt" OnTextChanged="txtTim_TextChanged"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/search.png"/ height="30px" width="30px">
                    <asp:Button ID="btnTim" runat="server" Text="Tìm kiếm" class="btn" OnClick="btnTim_Click"/>
                    <div style="padding-left: 4em">
                    <asp:Label ID="lblThongBao" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                    </div>
                </div>
    </br>
         <asp:GridView ID="gvNhanVien" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="800px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" OnSelectedIndexChanged="gvNhanVienlectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="maNV" HeaderText="Mã nhân viên" />
                <asp:BoundField DataField="hoTen" HeaderText="Họ tên nhân viên" />
                <asp:BoundField DataField="ngaySinh" HeaderText="Ngày sinh" />
                <asp:BoundField DataField="gioiTinh" HeaderText="Giới tính" />
                <asp:BoundField DataField="cmnd" HeaderText="CMND" />
                <asp:BoundField DataField="sdt" HeaderText="Số điện thoại" />
                <asp:BoundField DataField="chucVu" HeaderText="Chức vụ" />
                
                <asp:CommandField ShowSelectButton="True" />
                
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
</asp:Content>

