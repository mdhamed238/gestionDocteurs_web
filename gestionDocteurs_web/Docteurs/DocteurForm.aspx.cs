using gestionDocteurs_web.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestionDocteurs_web.Docteurs
{
    public partial class DocteurForm : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["gestionDocteursConnectionString"].ConnectionString;
        DocteurDAL docteurDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/LoginForm.aspx");
            }
            if (!IsPostBack)
            {
                LoadDocteurs();
            }
        }

        private void LoadDocteurs()
        {
            docteurDAL = new DocteurDAL(connectionString);
            gvDocteurs.DataSource = docteurDAL.GetAllDocteurs();
            gvDocteurs.DataBind();
        }

        protected void DeleteDocteurHandler(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            int docteurId = Convert.ToInt32(btnDelete.CommandArgument);
            docteurDAL = new DocteurDAL(connectionString);

            docteurDAL.DeleteDocteur(docteurId);
            LoadDocteurs();
        }
    }
}
