<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateHopital.aspx.cs" Inherits="gestionDocteurs_web.UpdateHopital" %>
<%@ Register Src="~/Navbar.ascx" TagName="navbar" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestion des docteurs et des hôpitaux</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>
<body class="d-flex align-items-center justify bg-light">

  <!-- Navbar -->
  <uc:navbar runat="server" />

  <div class="container mt-5">
    <div class="row">
      <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
        <div class="card card-signin my-5">
          <div class="card-body">
            <h5 class="card-title text-center">Hopital</h5>
            <form id="hopitalForm" class="form-hopital" runat="server">
              <div class="form-label-group">
                <asp:TextBox ID="txtNom" runat="server" class="form-control" placeholder="Nom" />
                <label for="txtNom">Nom</label>
              </div>

              <div class="form-label-group">
                <asp:TextBox ID="txtAdresse" runat="server" class="form-control" placeholder="Adresse" />
                <label for="txtAdresse">Adresse</label>
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
