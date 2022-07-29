using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetImp;

namespace VehicleFleetManagment.FleetApp
{
    public partial class Profile : System.Web.UI.Page
    {
        Users_Class Us = new Users_Class();
        Users_Interface I = new Users_Imp();

        string codeMin, username, sytemTitle, slogan;
  
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargeCookies();
            if (!IsPostBack)
            {
                txtSystemTitle.Text = sytemTitle;
                txtSlogan.Text = slogan;

                ChargeData();
            }
        }

        void ChargeCookies()
        {
            if (Request.Cookies["Code_Min"] != null || Request.Cookies["Slogan"] != null || Request.Cookies["System_Title"] != null || Request.Cookies["User_Nme"] != null)
            {
                codeMin = Request.Cookies["Code_Min"].Value;
                sytemTitle = Request.Cookies["System_Title"].Value;
                slogan = Request.Cookies["Slogan"].Value;
                username = Request.Cookies["User_Nme"].Value;
            }

        }
        protected void ChargeData()
        {
            if (codeMin != null)
            {
                I.Profile(Us, username);

                txtFirstName.Text = Us.First_Name;
                txtLastName.Text = Us.Last_Name;
                txtAddress.Text = Us.Address;
                txtTel.Text = Us.Phone;
                txtbirth.Text = Us.DOB;
                txtMail.Text = Us.Email;
                txtUserCode.Text = Us.User_Code;
                Image1.ImageUrl ="~/FleetApp/assets/images/Users/"+ Us.Picture;
            }
        }
    }
}