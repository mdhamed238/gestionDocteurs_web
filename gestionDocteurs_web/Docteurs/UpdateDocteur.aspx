<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDocteur.aspx.cs" Inherits="gestionDocteurs_web.Docteurs.UpdateDocteur" %>
<%@ Register Src="~/Navbar.ascx" TagName="navbar" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <title>Gestion des docteurs et des hôpitaux</title>
</head>
<body class="d-flex align-items-center justify bg-light">
    
     <!-- Navbar -->
    <uc:navbar runat="server" />

    <div class="container mt-5">
        <div class="row">
            <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
                <div class="card card-signin my-5">
                    <div class="card-body">
                        <h5 class="card-title text-center">Docteur</h5>
                        <form id="hopitalForm" class="form-hopital" runat="server">
                            <div class="form-label-group">
                                <asp:TextBox ID="txtNom" runat="server" class="form-control" placeholder="Nom" />
                                <label for="txtNom">Nom</label>
                            </div>

                            <div class="form-label-group">
                                <asp:TextBox ID="txtPrenom" runat="server" class="form-control" placeholder="Prenom" />
                                <label for="txtPrenom">Prenom</label>
                            </div>

                            <div class="form-label-group">
                                <asp:TextBox ID="specialite" runat="server" class="form-control" placeholder="Specialite" />
                                <label for="specialite">Specialite</label>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="hopital" Text="Hopital"></asp:Label>
                                <asp:DropDownList runat="server" ID="hopital" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-lg btn-primary btn-block text-uppercase" />
                        </form>
                        <asp:Label ID="lblMessage" runat="server" Visible="false" class="alert alert-danger" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
