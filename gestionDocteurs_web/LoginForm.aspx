<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="gestionDocteurs_web.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <title>Gestion des docteurs et des hôpitaux</title>
</head>
<body class="d-flex align-items-center bg-light">
  <div class="container mt-5" style="margin: auto;">
        <div class="card card-signin my-5 pd-5">
          <div class="card-body">
            <h5 class="card-title display-3 text-center">Connexion</h5>
            <form id="loginForm" class="form-signin" runat="server">
              <div class="form-label-group">
                <label for="inputUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="Username" />
              </div>

              <div class="form-label-group">
                <label for="inputPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" placeholder="Password" />
              </div>

              <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="btn btn-lg btn-primary btn-block text-uppercase" />
             </form>
          </div>

          <div class="mt-3">
              <asp:Label ID="lblMessage" runat="server" Visible="false" class="alert alert-danger w-100" />
          </div>
        </div>
  </div>
</body>
</html>

