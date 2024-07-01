<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication3.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Müşteri Kayıt Formu</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .container {
            display: flex;
            justify-content: center;
            align-items: flex-start;
            margin-top: 20px;
        }
        .frame {
            border: 1px solid #ccc;
            padding: 40px;
            margin: 10px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            background-color: #f9f9f9;
        }
        .centered-title {
            text-align: center;
            font-size: 24px;
            margin-top: 20px;
        }
        .form-group {
            margin-bottom: 10px;
        }
        .form-group label {
            display: block;
        }
        .form-group input {
            width: 100%;
            padding: 5px;
            margin-top: 5px;
        }
        .button-group {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <h2 class="centered-title">Müşteri Formu</h2>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Müşteri Kayıt Formu Çerçevesi -->
            <div class="frame">
                <h3>Müşteri Kayıt</h3>
                <div class="form-group">
                    <label for="txtId">ID:</label>
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtName">İsim:</label>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtSurname">Soyisim:</label>
                    <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtPhoneNumber">Telefon Numarası:</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txtIBAN">IBAN Numarası:</label>
                    <asp:TextBox ID="txtIBAN" runat="server"></asp:TextBox>
                </div>

                <div class="button-group">
                    <asp:Button ID="btnSave" runat="server" Text="Kaydet" OnClick="btnSave_Click" />
                </div>
            </div>

            <!-- Müşteri İşlemleri Çerçevesi -->
            <div class="frame">
                <asp:Button ID="btnViewAll" runat="server" Text="Tüm Müşterileri Görüntüle" OnClick="btnViewAll_Click" />
                <br /><br />
                <label for="txtDeleteCustomerId">Müşteri ID:</label>
                <asp:TextBox ID="txtDeleteCustomerId" runat="server"></asp:TextBox>
                <asp:Button ID="btnDeleteCustomer" runat="server" Text="Müşteri Sil" OnClick="btnDeleteCustomer_Click" />
                <br /><br />
                <asp:Button ID="btnInsertJson" runat="server" Text="JSON Ekle" OnClick="btnInsertJson_Click" />
                <asp:TextBox ID="txtJsonResult" runat="server" TextMode="MultiLine" Rows="10" Columns="30"></asp:TextBox>
            </div>

            <div class="frame">
                <h3>Fatura Bilgileri</h3>
                <label for="txtCustIdForInvoice">Müşteri ID:</label>
                <asp:TextBox ID="txtCustIdForInvoice" runat="server"></asp:TextBox><br />
                <asp:Button ID="btnShowInvoices" runat="server" Text="Faturaları Listele" OnClick="btnShowInvoices_Click" /><br /><br />
                <asp:GridView ID="gridInvoices" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="fact_id" HeaderText="Fatura ID" />
                        <asp:BoundField DataField="cust_id" HeaderText="Müşteri ID" />
                        <asp:BoundField DataField="fdate" HeaderText="Fatura Tarihi" />
                        <asp:BoundField DataField="amount" HeaderText="Tutar" />
                        <asp:BoundField DataField="f_type" HeaderText="Fatura Türü" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>

        <div>
            <h2>Müşteri Arama Formu</h2>
            <label for="txtSearchName">İsim:</label>
            <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchByName" runat="server" Text="İsimle Ara" OnClick="btnSearchByName_Click" />
            <br />
            <label for="txtSearchId">ID:</label>
            <asp:TextBox ID="txtSearchId" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchById" runat="server" Text="ID ile Ara" OnClick="btnSearchById_Click" />
            <br />
            <label for="txtSearchFamily">Soyisim:</label>
            <asp:TextBox ID="txtSearchFamily" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchByFamily" runat="server" Text="Soyisimle Ara" OnClick="btnSearchByFamily_Click" />
            <br />
            <label for="txtSearchIban">IBAN Numarası:</label>
            <asp:TextBox ID="txtSearchIban" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchByIban" runat="server" Text="IBAN ile Ara" OnClick="btnSearchByIban_Click" />
            <br />
            <label for="txtSearchTell">Telefon Numarası:</label>
            <asp:TextBox ID="txtSearchTell" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchByTell" runat="server" Text="Telefon Numarası ile Ara" OnClick="btnSearchByTell_Click" />
            <br />
            <asp:GridView ID="gridCustomers" runat="server" AutoGenerateColumns="False" OnRowEditing="gridCustomers_RowEditing">
                <Columns>
                    <asp:BoundField DataField="cu_id" HeaderText="ID" />
                    <asp:BoundField DataField="name" HeaderText="İsim" />
                    <asp:BoundField DataField="family" HeaderText="Soyisim" />
                    <asp:BoundField DataField="tell" HeaderText="Telefon Numarası" />
                    <asp:BoundField DataField="iban" HeaderText="IBAN Numarası" />          
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
