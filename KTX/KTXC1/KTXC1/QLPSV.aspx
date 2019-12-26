<%@ Page Title="" Language="C#" MasterPageFile="~/HienThi.Master" AutoEventWireup="true" CodeBehind="QLPSV.aspx.cs" Inherits="KTXC1.QLPSV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Lbl1" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red" Text="QUẢN LÝ PHÒNG SINH VIÊN"></asp:Label>
        <table style="width: 463px;">
            <tr>
                <td>

                    <asp:Label ID="Lbl2" runat="server" Text="Mã phòng:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMaPhong" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaPhong" runat="server" ErrorMessage="*" ControlToValidate="txtMaPhong" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Lbl3" runat="server" Text="Mã sinh viên:"></asp:Label>
                     </td>
                <td>
                    <asp:TextBox ID="txtMaSV" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaSV" runat="server" ErrorMessage="*" ControlToValidate="txtMaSV" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Lbl4" runat="server" Text="Ngày bắt đầu:"></asp:Label>

                     </td>
                <td>
                    <asp:TextBox ID="txtNgayBD" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNgayBD" runat="server" ErrorMessage="*" ControlToValidate="txtNgayBD" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td> <asp:Label ID="Label10" runat="server" Text="(YYYY/MM/DD)" ForeColor="red"></asp:Label></td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label1" runat="server" Text="Ngày kết thúc:"></asp:Label>
                     </td>
                <td>
                    <asp:TextBox ID="txtNgayKT" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNgayKT" runat="server" ErrorMessage="*" ControlToValidate="txtNgayKT" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
                <td> <asp:Label ID="Label12" runat="server" Text="(YYYY/MM/DD)" ForeColor="red"></asp:Label></td>
              
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
    <asp:GridView ID="gvPhongSV" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="Horizontal" Width="800px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" OnSelectedIndexChanged="gvPhongSV_SelectedIndexChanged" >
            <Columns>
                <asp:BoundField DataField="maPhong" HeaderText="Mã phòng" />
                <asp:BoundField DataField="maSV" HeaderText="Mã sinh viên" />
                <asp:BoundField DataField="ngayBatDau" HeaderText="Ngày bắt đầu" />
                <asp:BoundField DataField="ngayKetThuc" HeaderText="Ngày kết thúc" />
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
