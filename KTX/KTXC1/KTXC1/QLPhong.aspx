<%@ Page Title="" Language="C#" MasterPageFile="~/HienThi.Master" AutoEventWireup="true" CodeBehind="QLPhong.aspx.cs" Inherits="KTXC1.QLPhong" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Lable1" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red" Text="QUẢN LÝ PHÒNG"></asp:Label>
        <table style="width: 463px">
            <tr>
                <td>

                    <asp:Label ID="Label2" runat="server" Text="Mã phòng:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMaPhong" runat="server"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaPhong" runat="server" ErrorMessage="*" ControlToValidate="txtMaPhong" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label3" runat="server" Text="Tình trạng phòng:"></asp:Label>

                    </td>
                <td>
                    <asp:TextBox ID="txtTinhTrangPhong" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTinhTrangPhong" runat="server" ErrorMessage="*" ControlToValidate="txtTinhTrangPhong" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label4" runat="server" Text="Số lượng SV:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtSoLuongSV" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSLSV" runat="server" ErrorMessage="*" ControlToValidate="txtSoLuongSV" ForeColor="Red"></asp:RequiredFieldValidator>
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
    <asp:GridView ID="gvPhong" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="500px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" OnSelectedIndexChanged="gvPhong_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="MaPhong" HeaderText="Mã phòng" />
                <asp:BoundField DataField="TinhTrangPhong" HeaderText="Tình trạng phòng" />
                <asp:BoundField DataField="SoLuongSV" HeaderText="Số lượng sinh viên" />
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
