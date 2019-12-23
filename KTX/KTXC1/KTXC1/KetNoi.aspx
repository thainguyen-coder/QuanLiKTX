<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KetNoi.aspx.cs" Inherits="KTXC1.KetNoi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form  id="form1" runat="server">
        <table border="1">
            <tr>
                <td >
        <asp:Label ID="Label1" runat="server" ForeColor="#6600CC" Font-Size="XX-Large"  Font-Bold="true" Text="Khởi tạo kết nối"></asp:Label></td>
             </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" ForeColor="#6600CC" Font-Bold="true" Text="Username"></asp:Label>    
                    <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 11px"></asp:TextBox> <br />
                    <asp:Label ID="Label3" runat="server" ForeColor="#6600CC" Font-Bold="true" Text="Psssword"></asp:Label>    
                    <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 16px"></asp:TextBox> 
                                      
                    <br />
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" ForeColor="#CC6600" Text="Quyền admin"  />
                                      
                    <asp:Button ID="Button1" runat="server" ForeColor="#000099" BackColor="SkyBlue" style="margin-left: 45px" Text="Kết nối" />
                                      
                </td> 
                </tr>
        </table>
    </form>
</body>
</html>
