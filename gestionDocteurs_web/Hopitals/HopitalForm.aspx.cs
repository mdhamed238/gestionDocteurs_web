using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gestionDocteurs_web.DAL;

namespace gestionDocteurs_web
{
    public partial class HopitalForm : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["gestionDocteursConnectionString"].ConnectionString;
        HopitalDAL hopitalDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] == null)
            {
                Response.Redirect("~/LoginForm.aspx");
            }
            if (!IsPostBack)
            {
                LoadHopitaux();
            }
        }

        private void LoadHopitaux()
        {
            hopitalDAL = new HopitalDAL(connectionString);
            gvHopitaux.DataSource = hopitalDAL.GetAllHopitaux();
            gvHopitaux.DataBind();
        }

        protected void DeleteHopitalHandler(object sender, EventArgs e)
        {
            LinkButton btnDelete = (LinkButton)sender;
            int hopitalId = Convert.ToInt32(btnDelete.CommandArgument);
            hopitalDAL = new HopitalDAL(connectionString);
            int doctorCount = hopitalDAL.GetDoctorCountForHopital(hopitalId);

            if (doctorCount > 0)
            {
                // Show a warning message to the user
                string message = "There are " + doctorCount + " doctors associated with this hospital. Delete all the associated doctors first";
                string script = "alert('" + message + "')";
                btnDelete.Attributes["onclick"] = script;  
            }
            else
            {
                DeleteHopital(hopitalId);
            }
        }
        private void DeleteHopital(int hopitalId)
        {
            hopitalDAL.DeleteHopital(hopitalId);
            LoadHopitaux();
        }
    }
}

           