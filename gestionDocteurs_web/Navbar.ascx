<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="gestionDocteurs_web.Navbar" %>

<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <a class="navbar-brand" href="#">Acceuil</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav mr-auto">
            <li class="nav-item">
                <a class="nav-link" href="~/Docteurs/DocteurForm.aspx" runat="server">Docteurs</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="~/Hopitals/HopitalForm.aspx" runat="server">Hopitaux</a>
            </li>
        </ul>
        <ul class="navbar-nav">
            <li class="nav-item">
                <a class="nav-link text-dark font-weight-bold" href="#" runat="server" onclick="Logout();">Logout</a>
            </li>
        </ul>
    </div>
</nav>


<script>
    function Logout() {
        '<% Session.Abandon(); %>';
        window.location.href = "LoginForm.aspx";
    }
</script>
