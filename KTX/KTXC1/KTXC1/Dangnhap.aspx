<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dangnhap.aspx.cs" Inherits="KTXC1.Dangnhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .ok{
            text-align:center;
            color:#993300;
            font-size:xx-large;

        }
        .ok1{
            background-color:white;
            text-align:center;
            height: 214px;
            width: 402px;
            margin-left:450px;
            margin-bottom:150px;
        }
        .ok2{
            margin-left:70px;
            color:red;
        }
        .ok3{
            background-color:red;
            color:white;
        }
        .anh{
            background-image:url("nen1.png");
            width:100%;
            height:100%;           
        }

        .auto-style1 {
            width: 772px;
        }

    </style>
    
</head>
<body class="anh">
    <form  id="form1" runat="server">
    <table class="ok1"  >
        <tr>
            <td class="auto-style1">
                <asp:Label ID="Label4" runat="server" CssClass="ok" Text="<strong>Trường Đại Học Quy Nhơn<br/>Quản Lý Ký Túc Xá</strong>"></asp:Label>
                <br />
                <br />
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/QuanLy32.png" />
                <asp:Label ID="lblHeThong" runat="server" style="margin-left: 16px" Font-Bold="True" ForeColor="Blue" Font-Size="XX-Large" Text="HỆ THỐNG"></asp:Label> <br /><br />
                <asp:Label ID="Label2" runat="server" ForeColor="#6600CC" Font-Bold="true" Text="Tên đăng nhập: "></asp:Label>    
                <asp:TextBox ID="txtUserName" runat="server" style="margin-left: 2px" placeholder="Tên đăng nhập"></asp:TextBox> <br />
                <asp:Label ID="Label3" runat="server" ForeColor="#6600CC" Font-Bold="true" Text="Mật khẩu:" ></asp:Label>    
                <asp:TextBox ID="txtPassWord" runat="server" style="margin-left: 39px" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox> 
                <br />
                  <input type="checkbox" onchange="document.getElementById('txtPassWord').type = this.checked ? 'text' : 'txtPassWord'">
                Hiện mật khẩu


                <br />
                <br />
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Sua161.png" Height="16px" Width="16px" style="margin-top: 11px"  />
                <asp:Button ID="btnDN" runat="server" OnClick="btnDN_Click" Font-Bold="true" BackColor="#ff9933" Text="Đăng nhập"  ForeColor="White" Height="32px" Width="115px" />
                <br />
                <br />
                
                <asp:Label ID="lblChuthich" CssClass="ok3" runat="server" Text="*VUI LÒNG NHẬP MẬT KHẨU"></asp:Label>
                
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
