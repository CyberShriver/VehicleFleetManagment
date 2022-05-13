using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VehicleFleetManagment.FleetApp
{
    public partial class fleet : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LogoutLink(object sender, EventArgs args)
        {
            HttpCookie Code_Min = new HttpCookie("Code_Min");
            Code_Min.Expires = DateTime.Now.AddMilliseconds(-10);
            Response.Cookies.Add(Code_Min);
            Response.Redirect("~/FleetApp/Login.aspx");
        }

        protected void SideLogout_ServerClick(object sender, EventArgs e)
        {
            HttpCookie Code_Min = new HttpCookie("Code_Min");
            Code_Min.Expires = DateTime.Now.AddMilliseconds(-10);
            Response.Cookies.Add(Code_Min);
            Response.Redirect("~/FleetApp/Login.aspx");
        }
    }
}