<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="WebApplication3.giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .centered-frame {
            width: 300px;
            margin: 0 auto; /* Horizontally center the div */
            border: 1px solid #ccc;
            padding: 20px;
            text-align: center; /* Center the text inside the div */
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%); /* Center the div vertically and horizontally */
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
    </style>
</head>
<body>
    <a href="./html_pages/htmlpage2.html">link</a>

    <form id="form1" runat="server">
        <div class="centered-frame">
            <!-- Müşteri Butonu -->
            <asp:Button ID="btnCustomer" runat="server" Text="Müşteri" OnClick="btnCustomer_Click" />
            <br /><br />
            <!-- Ürün Butonu -->
            <asp:Button ID="btnProduct" runat="server" Text="Ürün" OnClick="btnProduct_Click" />
        </div>
    </form>
</body>
</html>


