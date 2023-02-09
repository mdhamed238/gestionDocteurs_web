using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestionDocteurs_web.DAL;
using gestionDocteurs_web.Models;

namespace gestionDocteurs_web
{
    public partial class UpdateHopital : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["gestionDocteursConnectionString"].ConnectionString;
        HopitalDAL hopitalDAL;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/LoginForm.aspx");
            }
            if (!IsPostBack)
            {
                string mode = Request.QueryString["mode"];
                if (mode == "edit")
                {
                    string hopitalId = Request.QueryString["id"];
                    hopitalDAL = new HopitalDAL(connectionString);
                    Hopital hopital = hopitalDAL.GetHopitalById(hopitalId);
                    txtNom.Text = hopital.Nom;
                    txtAdresse.Text = hopital.Adresse;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string mode = Request.QueryString["mode"];
            HopitalDAL hopitalDAL = new HopitalDAL(connectionString);
            if (mode == "create")
            {
                Hopital hopital = new Hopital
                {
                    Nom = txtNom.Text,
                    Adresse = txtAdresse.Text
                };
                hopitalDAL.AddHopital(hopital);
            }
            else if (mode == "edit")
            {
                string hopitalId = Request.QueryString["id"];
                Hopital hopital = hopitalDAL.GetHopitalById(hopitalId);
                hopital.Nom = txtNom.Text;
                hopital.Adresse = txtAdresse.Text;
                hopitalDAL.UpdateHopital(hopital);
            }

            Response.Redirect("HopitalForm.aspx");
        }
    }
}