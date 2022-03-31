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
    public partial class AddMark : System.Web.UI.Page
    {
        Mark_Class M = new Mark_Class();
        Mark_Interface I = new Mark_Imp();
        int msg;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Add();
            }

        }

        void Add()
        {

            if (txtMark.Value == "" || txtComment.Value == "" )
            {
                text_msg.InnerText = "Please Complete all fields!!";
            }
            else
            {              
                M.Mark_Name = txtMark.Value;
                M.Comment = txtComment.Value;             

                msg = I.Add(M);

                if (msg > 0)
                {
                    text_msg.InnerText = "Your Data is added";
                    I.Add(M);
                    txtMark.Value = "";
                    txtComment.Value = "";
                 
                }
                else
                {
                    text_msg.InnerText = "Something goes wrong!!! please try Again";

                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs args)
        {
            Add();
        }

    }
}