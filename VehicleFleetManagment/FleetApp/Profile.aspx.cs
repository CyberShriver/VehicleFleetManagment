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
        Ministry_Class Min = new Ministry_Class();
        Ministry_Interface I = new Ministry_Imp();
        string codeMin;


        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie Code_Min = new HttpCookie("Code_Min");

            if (Request.Cookies["Code_Min"].Value != null)
            {
                codeMin = Request.Cookies["Code_Min"].Value;
            }

            if (!IsPostBack)
            {
                ChargeData();
            }
        }

        protected void ChargeData()
        {
            if (codeMin != null)
            {
                I.Profile(Min, codeMin);

                txtCode.Text = Min.Code_Min;
                txtName.Text = Min.Ministry_Name;
                txtAddress.Text = Min.Address;
                txtTel.Text = Min.Phone;
                txtFax.Text = Min.Fax;
                txtPostal.Text = Min.Postal_code;
                txtUserName.Text = Min.User_Nme;
                Image1.ImageUrl ="~/FleetApp/assets/images/"+Min.Picture;
            }
        }
    }
}