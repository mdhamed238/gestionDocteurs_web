﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HopitalForm.aspx.cs" Inherits="gestionDocteurs_web.HopitalForm" %>
<%@ Register Src="~/Navbar.ascx" TagName="navbar" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hopitaux</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body>
    <!-- Navbar -->
    <uc:navbar runat="server" />

    <form id="form1" runat="server">
        <div class="container">
            <h1 style="margin: 2rem 0;">Hopitaux</h1>
            <a runat="server" href="UpdateHopital.aspx?mode=create" class="btn btn-lg btn-success" style="margin-bottom: 1.5rem;">Add</a>
            <asp:GridView ID="gvHopitaux" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nom" HeaderText="Nom" />
                    <asp:BoundField DataField="Adresse" HeaderText="Adresse" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <a class="btn btn-primary" href="UpdateHopital.aspx?mode=edit&id=<%# Eval("ID") %>">Edit</a>
                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" CommandArgument='<%# Eval("ID") %>' OnClick="DeleteHopitalHandler" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
