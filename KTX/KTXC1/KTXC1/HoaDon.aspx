<%@ Page Title="" Language="C#" MasterPageFile="~/HienThi.Master" AutoEventWireup="true" CodeBehind="HoaDon.aspx.cs" Inherits="KTXC1.HoaDon"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 463px">
            <asp:Label ID="Lable1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Text="HÓA ĐƠN" Style="text-align: center" OnLoad="Lable1_Load"></asp:Label>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label3" runat="server" Text="Mã Hóa Đơn:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaHĐ" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaHĐ" runat="server" ErrorMessage="*" ControlToValidate="txtMaHĐ" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label4" runat="server" Text="Mã Nhân Viên :"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaNV" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaNV" runat="server" ErrorMessage="*" ControlToValidate="txtMaNV" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label5" runat="server" Text="Mã Phòng:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaPhong" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaPhong" runat="server" ErrorMessage="*" ControlToValidate="txtMaPhong" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label8" runat="server" Text="Mã Công Tơ Điện:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaCTD" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaCTD" runat="server" ErrorMessage="*" ControlToValidate="txtMaCTD" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style3">

                    <asp:Label ID="Label7" runat="server" Text="Mã Công Tơ Nước:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaCTN" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaCTN" runat="server" ErrorMessage="*" ControlToValidate="txtMaCTN" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" ></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td class="auto-style8" colspan="3">
                    &nbsp;<img src="img/them.png" height="30px" width="30px" /><asp:Button ID="Button1" runat="server" Text="Thêm" class="btn" OnClick="Button1_Click"   />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/update.png" height="30px" width="30px" /><asp:Button ID="Button2" runat="server" Text="Chỉnh sửa" class="btn" OnClick="Button2_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button6" runat="server" Text="Tính Tổng Tiền" class="btn" OnClick="Button6_Click1" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/xoa.png" height="30px" width="30px" /><asp:Button ID="Button3" runat="server" Text="Xóa" class="btn"  OnClientClick="return confirm(&quot;Bạn chắc chắn muốn xóa?&quot;);" OnClick="Button3_Click"/>
                    </br>
                    <img src="img/thanhtoan.png" height="30px" width="30px" style="margin-left:150px" /><asp:Button ID="Button5" runat="server" Text="In hóa đơn" class="btn" OnClick="Button5_Click"/>
                </td>
            </tr>

            </table>
    </div>
    <div style="width: 691px; padding-top: 2em; padding-left: 4em">
                    Nhập từ khóa cần tìm:
                    <asp:TextBox ID="txtTim" runat="server" class="txt"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/search.png"/ height="30px" width="30px">
                    <asp:Button ID="btnTim" runat="server" Text="Tìm kiếm" class="btn"  />
                    <div style="padding-left: 4em">
                    <asp:Label ID="lblThongBao" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </br>
    <asp:GridView ID="gvHoaDon" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" Width="800px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="gvHoaDon_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="maHD" HeaderText="Mã hóa đơn" />
                <asp:BoundField DataField="maNV" HeaderText="Mã nhân viên" />
                <asp:BoundField DataField="maPhong" HeaderText="Mã Phòng" />
                <asp:BoundField DataField="maCongToDien" HeaderText="Mã CT Điện" />
                <asp:BoundField DataField="maCongToNuoc" HeaderText="Mã CT Nước" />
                <asp:BoundField  DataField="ngayGhi" HeaderText="Ngày Ghi" />
                <asp:BoundField DataField="tongTien" HeaderText="Tổng Tiền" />
                <asp:CommandField ShowSelectButton="True" />
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
