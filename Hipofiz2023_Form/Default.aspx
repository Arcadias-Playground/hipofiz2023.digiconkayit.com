<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hipofiz2023_Form.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Hipofiz 2023 - Registration Form</title>
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/css/bootstrap.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/css/all.min.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=ResolveClientUrl("~/css/KuTechCSS.css?t=1") %>" />

    <script type="text/javascript" src="<%= ResolveClientUrl("~/js/jquery-3.7.1.min.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveClientUrl("~/js/bootstrap.js") %>"></script>
    <script type="text/javascript" src="<%=ResolveClientUrl("~/js/KuTechJS.js") %>"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <div class="row mx-auto">
                <div class="col-md-12 mx-auto">
                    <img src="Gorseller/banner.png" class="w-100 vertical-align-top" />
                </div>
                <asp:UpdatePanel ID="UPnlGenel" runat="server" class="col-md-10 mx-auto">
                    <ContentTemplate>
                        <h4 class="baslik py-2 mb-4">KAYIT TALEP FORMU</h4>
                        <table class="KuTechTable">
                            <tr class="table-row">
                                <td>*</td>
                                <td>Ad</td>
                                <td>
                                    <asp:TextBox ID="txtAd" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Soyad</td>
                                <td>
                                    <asp:TextBox ID="txtSoyad" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Tc No</td>
                                <td>
                                    <asp:TextBox ID="txtTCNo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Sicil No</td>
                                <td>
                                    <asp:TextBox ID="txtSicilNo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Branş</td>
                                <td>
                                    <asp:TextBox ID="txtBranş" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Meslek</td>
                                <td>
                                    <asp:TextBox ID="txtMeslek" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Unvan</td>
                                <td>
                                    <asp:TextBox ID="txtUnvan" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Çalıştığınız Hastane</td>
                                <td>
                                    <asp:TextBox ID="txtHastane" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>İl</td>
                                <td>
                                    <asp:TextBox ID="txtSehir" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>İlçe</td>
                                <td>
                                    <asp:TextBox ID="txtIlce" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>GSM</td>
                                <td>
                                    <asp:TextBox ID="txtTelefon" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Mail</td>
                                <td>
                                    <asp:TextBox ID="txtePosta" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Doğum Tarihi</td>
                                <td>
                                    <asp:TextBox ID="txtDogumTarihi" runat="server" class="form-control "></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Konuşmacı Mısınız ?</td>
                                <td>
                                    <asp:DropDownList ID="ddl_KonusmaciDurum" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="true">Evet</asp:ListItem>
                                        <asp:ListItem Value="false">Hayır</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="table-row">
                                <td>*</td>
                                <td>Bildiriniz Var Mı ?</td>
                                <td>
                                    <asp:DropDownList ID="ddl_BildiriDurum" runat="server" CssClass="form-control"  OnSelectedIndexChanged="ddl_BildiriDurum_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="">Seçiniz</asp:ListItem>
                                        <asp:ListItem Value="true">Evet</asp:ListItem>
                                        <asp:ListItem Value="false">Hayır</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr class="table-row" id="tr_BildiriNo" runat="server" visible="false">
                                <td>*</td>
                                <td>Bildiri Numaranız:</td>
                                <td>
                                    <asp:TextBox ID="txtBildiriNo" runat="server" class="form-control"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="text-center mt-3">
                            <asp:Button runat="server" Text="Kayıt Oluştur" CssClass="btn btn-primary" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </form>
    <footer class="bg-dark p-3">
        <div class="container">
            <div class="d-flex aling-items-center justify-content-center">
                <div class="ms-auto text-light text-center">
                    Copyright 2023 © 18. Hipofiz Sempozyumu
                    <br />
                    Tüm Hakları Saklıdır.
                </div>
                <div class="ms-auto">
                    <a href="https://arcadiastech.com/" target="_blank" style="color: #fff!important; font-size: 9px!important; text-decoration: none!important;"><span>
                        <img src="Gorseller/arkadyas.png" /></span></a>
                </div>
            </div>
        </div>
    </footer>
</body>
</html>
