<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="WebApplication3.product" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Product Management</title>
    <style>
        .frame {
            border: 1px solid black;
            padding: 10px;
            margin: 10px;
        }
        .frame input, .frame select {
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Ürün Kayıt Çerçevesi -->
        <div class="frame">
            <h3>Ürün Kayıt</h3>
            <label for="txtPrId">Ürün ID:</label>
            <asp:TextBox ID="txtPrId" runat="server"></asp:TextBox><br />
            <label for="txtName">Ürün Adı:</label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <label for="txtDate1">Tarih:</label>
            <asp:TextBox ID="txtDate1" runat="server" TextMode="Date"></asp:TextBox><br />
            <label for="txtPrice">Fiyat:</label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />
            <label for="txtStock">Stok:</label>
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox><br />
            <label for="txtComment">Yorum:</label>
            <asp:TextBox ID="txtComment" runat="server"></asp:TextBox><br />
            <label for="ddlPcId">Kategori ID:</label>
            <asp:DropDownList ID="ddlPcId" runat="server">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
                <asp:ListItem Value="7">7</asp:ListItem>
                <asp:ListItem Value="8">8</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Button ID="btnSaveProduct" runat="server" Text="Kaydet" OnClick="btnSaveProduct_Click" />
        </div>

        <!-- Fatura Kayıt Çerçevesi -->
        <div class="frame">
            <h3>Fatura Kayıt</h3>
            <label for="txtFactId">Fatura ID:</label>
            <asp:TextBox ID="txtFactId" runat="server"></asp:TextBox><br />
            <label for="txtCustId">Müşteri ID:</label>
            <asp:TextBox ID="txtCustId" runat="server"></asp:TextBox><br />
            <label for="txtFdate">Fatura Tarihi:</label>
            <asp:TextBox ID="txtFdate" runat="server" TextMode="Date"></asp:TextBox><br />
            <label for="txtAmount">Tutar:</label>
            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox><br />
            <label for="txtFType">Fatura Türü:</label>
            <asp:TextBox ID="txtFType" runat="server"></asp:TextBox><br />
            <label for="txtProductId">Ürün ID:</label>
            <asp:TextBox ID="txtProductId" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSaveInvoice" runat="server" Text="Kaydet" OnClick="btnSaveInvoice_Click" />
        </div>

        <!-- Ürün Kategorisi Göster Çerçevesi -->
        <div class="frame">
            <h3>Ürün Kategorisi Bilgileri</h3>
            <label for="txtPcId">Kategori ID:</label>
            <asp:TextBox ID="txtPcId" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnShowCategory" runat="server" Text="Göster" OnClick="btnShowCategory_Click" /><br /><br />
            <asp:TextBox ID="txtCategoryInfo" runat="server" TextMode="MultiLine" Rows="10" Columns="30" ReadOnly="true"></asp:TextBox>
        </div>
    </form>
</body>
</html>


