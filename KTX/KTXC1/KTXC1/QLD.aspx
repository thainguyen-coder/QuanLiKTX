<%@ Page Title="" Language="C#" MasterPageFile="~/HienThi.Master" AutoEventWireup="true" CodeBehind="QLD.aspx.cs" Inherits="KTXC1.QLD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 463px">
            <tr>
                <td>
                    <asp:Label ID="Lable1" runat="server" Font-Bold="true" Font-Size="X-Large" ForeColor="Red" Text="QUẢN LÝ ĐIỆN"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label3" runat="server" Text="Mã công tơ điện:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtMacongtodien" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMaCTD" runat="server" ErrorMessage="*" ControlToValidate="txtMacongtodien" ForeColor="#CC3300"> </asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label4" runat="server" Text="Chỉ số đầu :"></asp:Label>
                    </td>
                <td>
                    
                    <asp:TextBox ID="txtChisocdau" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvChisocdau" runat="server" ErrorMessage="*" ControlToValidate="txtChisocdau" ForeColor="#CC3300"> </asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label5" runat="server" Text="Chỉ số cuối:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtChisocuoi" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCSC" runat="server" ErrorMessage="*" ControlToValidate="txtChisocuoi" ForeColor="#CC3300"> </asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label8" runat="server" Text="Ngày ghi:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtNgayghi" runat="server" ></asp:TextBox>

                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label7" runat="server" Text="Đơn giá:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtDongia" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDonGia" runat="server" ErrorMessage="*" ControlToValidate="txtDongia" ForeColor="#CC3300"> </asp:RequiredFieldValidator>
                </td>
              
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label6" runat="server" Text="Tiêu thụ:"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtTieuthu" runat="server" Enabled="False" ></asp:TextBox>

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
                    <asp:TextBox ID="txtTim" runat="server" class="txt"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="img/search.png"/ height="30px" width="30px">
                    <asp:Button ID="btnTim" runat="server" Text="Tìm kiếm" class="btn" OnClick="btnTim_Click1" />
                    <div style="padding-left: 4em">
                    <asp:Label ID="lblThongBao" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                    </div>
         </div>
    </br>
    <asp:GridView ID="gvDien" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" Width="800px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="gvDienNuoc_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="MaCongToDien" HeaderText="Mã công điện" />
                <asp:BoundField DataField="ChiSoDau" HeaderText="Chỉ số đầu" />
                <asp:BoundField DataField="ChiSoCuoi" HeaderText="Chỉ số cuối" />
                <asp:BoundField DataField="NgayGhi" HeaderText="Ngày ghi" />
                <asp:BoundField DataField="gia" HeaderText="Đơn giá" />
                <asp:BoundField  DataField="ThanhTien" HeaderText="Thành tiền" />
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
