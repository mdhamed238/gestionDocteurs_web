using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestionDocteurs_web.DAL;
using gestionDocteurs_web.Models;

namespace gestionDocteurs_web.Docteurs
{
    public partial class UpdateDocteur : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["gestionDocteursConnectionString"].ConnectionString;
        HopitalDAL hopitalDAL;
        DocteurDAL docteurDAL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/LoginForm.aspx");
            }

            if (!IsPostBack)
            {
                docteurDAL = new DocteurDAL(connectionString);
                hopitalDAL = new HopitalDAL(connectionString);

                // Fill the hopital DropDownList
                hopital.DataSource = hopitalDAL.GetAllHopitaux();
                hopital.DataTextField = "Nom";
                hopital.DataValueField = "Id";
                hopital.DataBind();

                string mode = Request.QueryString["mode"];
                if (mode == "edit")
                {
                    int docteurId = Convert.ToInt32(Request.QueryString["ID"]);
                    Docteur docteur = docteurDAL.GetDocteurById(docteurId);

                    txtNom.Text = docteur.Nom;
                    txtPrenom.Text = docteur.Prenom;
                    specialite.Text = docteur.Specialite;
                    hopital.SelectedValue = docteur.HopitalId.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string mode = Request.QueryString["mode"];
            DocteurDAL docteurDAL = new DocteurDAL(connectionString);
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string specialite = this.specialite.Text;
            string hopitalId = hopital.SelectedValue;


            if (mode == "create")
            {
                Docteur docteur = new Docteur
                {
                    Nom = nom,
                    Prenom = prenom,
                    Specialite = specialite,
                    HopitalId = hopitalId
                };

                docteurDAL.AddDocteur(docteur);
            }
            else if(mode == "edit")
            {
                string docteurId = Request.QueryString["id"];
                Docteur docteur = new Docteur
                {
                    Id = docteurId,
                    Nom = nom,
                    Prenom = prenom,
                    Specialite = specialite,
                    HopitalId = hopitalId
                };

                docteurDAL.UpdateDocteur(docteur);
            }
            
            Response.Redirect("~/Docteurs/DocteurForm.aspx");
        }

    }
}