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
    public partial class LoginForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["gestionDocteursConnectionString"].ConnectionString;

            LoginDAL loginDAL = new LoginDAL(connectionString);
            var result = loginDAL.LoginUser(username, password);

            if (result != null)
            {
                Session["user"] = username;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid Login";
            }
        }
    }
}