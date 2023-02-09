<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gestionDocteurs_web.Default" %>
<%@ Register Src="~/Navbar.ascx" TagName="navbar" TagPrefix="uc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <title>Gestion des docteurs et des hôpitaux</title>
</head>

<body>
    <!-- Navbar -->
    <uc:navbar runat="server" />
    
    <div class="container">
        <h1 class="display-5 font-weight-bold text-center my-3">Gestion des docteurs et des hôpitaux</h1>
        <div class="container my-5">
            <p class="lead text-justify">
                Ce projet consiste en la création d'une application CRUD (Create, Read, Update, Delete) pour la gestion des docteurs et des hôpitaux en utilisant ASP.NET Web Forms et SQL Server.
            Il y aura une table de connexion pour l'authentification des utilisateurs, une table pour les hôpitaux et une autre pour les docteurs.
            Les classes DAL seront utilisées pour gérer les opérations de la base de données, tandis que les classes de modèle de données seront utilisées pour relier les classes DAL à l'interface utilisateur.
            Enfin, des formulaires web seront créés pour les différentes opérations CRUD pour chaque table.
            </p>
        </div>
        <form id="form1" runat="server">
            <div>
            </div>
        </form>
    </div>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</body>
</html>
