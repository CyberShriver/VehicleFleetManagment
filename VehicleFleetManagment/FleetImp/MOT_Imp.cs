using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;
using System.Data.Entity;

namespace VehicleFleetManagment.FleetImp
{
    public class MOT_Imp: MOT_Interface
    {

        int msg;
        MOT M = new MOT();

        //ADD METHOD
        public int Add(MOT_Class Mo)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M.MOT_Number = Mo.MOT_Number;
                M.MOT_Agency_Name = Mo.MOT_Agency_Name;
                M.Visit_Dte = Mo.Visit_Dte;
                M.Validity_End_Dte = Mo.Validity_End_Dte;
                M.MINISTRY_ID = Mo.MINISTRY_ID;
                M.VEHICLE_ID = Mo.VEHICLE_ID;

                con.MOTs.Add(M);

                if (con.SaveChanges() > 0)
                {
                    msg = 1;
                }
                else
                {
                    msg = 0;
                }
            }


            return msg;
        }

        //UPDATE METHOD
        public int Update(MOT_Class Mo, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MOT M = new MOT();
                M = con.MOTs.Where(x => x.MOT_ID == id).FirstOrDefault();

                if (M != null)
                {

                    M.MOT_Number = Mo.MOT_Number;
                    M.MOT_Agency_Name = Mo.MOT_Agency_Name;
                    M.Visit_Dte = Mo.Visit_Dte;
                    M.Validity_End_Dte = Mo.Validity_End_Dte;
                    M.MINISTRY_ID = Mo.MINISTRY_ID;
                    M.VEHICLE_ID = Mo.VEHICLE_ID;

                    if (con.SaveChanges() > 0)
                    {
                        con.MOTs.Add(M);
                        con.Entry(M).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //DELETE METHOD
        public int Delete(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = con.MOTs.Where(x => x.MOT_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.MOTs.Attach(obj);

                }
                con.MOTs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DELETE CHECK METHOD
        public int DeleteCheck(GridView gd, CheckBox chk, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                for (int i = 0; i < gd.Rows.Count; i++)
                {
                    CheckBox chkselect = (CheckBox)gd.Rows[i].FindControl("chk");
                    if (chkselect.Checked == true)
                    {
                        id = Convert.ToInt32(gd.Rows[i].Cells[i].Text);
                        var obj = con.MOTs.Where(x => x.MOT_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.MOTs.Attach(obj);


                        }
                        con.MOTs.Remove(obj);
                        con.SaveChanges();
                    }
                }
                return msg;
            }

        }


        //DISPLAY METHOD
        public void Display(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MOTs

                           select new
                           {
                               MOT_ID = M.MOT_ID,
                               MOT_Number = M.MOT_Number,
                               MOT_Agency_Name = M.MOT_Agency_Name,
                               Visit_Dte = M.Visit_Dte,
                               Validity_End_Dte = M.Validity_End_Dte,
                               VEHICLE_ID = M.VEHICLE.Local_Plate,
                               MINISTRY_ID= M.MINISTRY.Ministry_Name
                          
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(MOT_Class Mo, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MOTs.Where(x => x.MOT_ID == id).FirstOrDefault();

                Mo.MOT_Number = M.MOT_Number;
                Mo.MOT_Agency_Name = M.MOT_Agency_Name;
                Mo.Visit_Dte = M.Visit_Dte;
                Mo.Validity_End_Dte = M.Validity_End_Dte;
                Mo.VEHICLE_ID = M.VEHICLE_ID;
                Mo.MINISTRY_ID = M.MINISTRY_ID;



            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MOTs
                         select l).Count();
                n = M;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MOTs
                           where
                       M.MOT_Agency_Name == SearchText ||
                       M.MOT_Number == SearchText ||
                       M.MINISTRY.Ministry_Name == SearchText ||
                       M.Visit_Dte.ToString() == SearchText ||
                       M.VEHICLE.Local_Plate == SearchText

                           select new
                           {
                               MOT_ID = M.MOT_ID,
                               MOT_Number = M.MOT_Number,
                               MOT_Agency_Name = M.MOT_Agency_Name,
                               Visit_Dte = M.Visit_Dte,
                               Validity_End_Dte = M.Validity_End_Dte,
                               VEHICLE_ID = M.VEHICLE.Local_Plate,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY METHOD ALL VEHICLE
        public void DisplayAllVehicle(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Local_Plate = V.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField= "Local_Plate";
                drop.DataValueField = "VEHICLE_ID";
                drop.DataBind();
            }

        }


        //DISPLAY METHOD VEHICLE
        public void DisplayVehicle(DropDownList drop, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs
                           where V.MINISTRY_ID == id

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Local_Plate = V.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Local_Plate";
                drop.DataValueField = "VEHICLE_ID";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies

                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Ministry_Name = M.Ministry_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

    }
}