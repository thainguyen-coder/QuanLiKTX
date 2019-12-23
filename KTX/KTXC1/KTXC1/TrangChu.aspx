<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrangChu.aspx.cs" Inherits="KTXC1.TrangChu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .anh{
            background:#99CCCC;   
        }
        .p{
            margin-left:200px;
        }
        .bg{
            background:#99CCCC;   
            height:630px;
            width:1343px;
            
        }
        .bg1{
            background-image:url("Images/KK.jpg");
            height:630px;
            width:954px;
            margin-left:200px;
        }
        #Menu1{
            margin-left:200px;
        }

    </style>
    
</head>
<body class="anh">
    <form  id="form1" runat="server">
        <table class="p">
            <tr>
                <td>
                    <asp:Image ID="Image1" runat="server"  ImageUrl="~/Images/Settings-icon.png" Height="20px" Width="20px"/>
                    <asp:Label ID="label1" runat="server" ForeColor="White" Font-Size="Large" Text="<strong>QUẢN LÝ KÝ TÚC XÁ TRƯỜNG ĐẠI HỌC QUY NHƠN</strong>" />
                </td>
            </tr>
        </table>
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
                        <asp:MenuItem Text="Quản Lý Điện Nước" Value="Quản Lý Điện Nước" NavigateUrl="~/QLDN.aspx"></asp:MenuItem>
                        <asp:MenuItem Text="Quản Lý Phòng Sinh Viên" Value="Quản Lý Phòng Sinh Viên" NavigateUrl="~/QLPSV.aspx"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Hóa Đơn" Value="Hóa đơn" ImageUrl="~/Images/DanhGia32.png" NavigateUrl="~/HoaDon.aspx">
                    </asp:MenuItem>
                    <asp:MenuItem Text="Trợ Giúp" Value="Trợ Giúp" ImageUrl="~/Images/TroGiup32.png">
                        <asp:MenuItem Text="Sự Cố" Value="Sự Cố"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="Đăng Xuất" Value="Đăng Xuất" ImageUrl="~/Images/DangXuat32.png" NavigateUrl="~/Dangnhap.aspx"></asp:MenuItem>
                </Items>
                <StaticHoverStyle BackColor="#66FF33" ForeColor="#3333CC" />
                <StaticMenuItemStyle BackColor="#99CCFF" HorizontalPadding="20px" VerticalPadding="5px" />
                <StaticSelectedStyle BackColor="#507CD1" />
            </asp:Menu>
    </form>
    <div class="bg">
        <div class="bg1"></div>
    </div>
</body>
</html>
