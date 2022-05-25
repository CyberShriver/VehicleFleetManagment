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
    public class MinDriver_Imp: MinDriver_Interface
    {

        int msg;
        MINISTRY_DRIVER M = new MINISTRY_DRIVER();
        VEHICLE V = new VEHICLE();

        //ADD METHOD
        public int Add(MinDriver_Class Md)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M.DRIVER_ID = Md.DRIVER_ID;
                M.Min_Driver_RegNumber  = Md.Min_Driver_RegNumber ;
                M.MINISTRY_ID = Md.MINISTRY_ID;
                M.Position_Status = Md.Position_Status;
                // M.Saved_Date = Md.Saved_Date;

                con.MINISTRY_DRIVER.Add(M);

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
        public int Update(MinDriver_Class Md, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MINISTRY_DRIVER M = new MINISTRY_DRIVER();
                M = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id).FirstOrDefault();

                if (M != null)
                {

                    M.DRIVER_ID = Md.DRIVER_ID;
                    M.Min_Driver_RegNumber  = Md.Min_Driver_RegNumber ;
                    M.MINISTRY_ID = Md.MINISTRY_ID;
                    M.Position_Status = Md.Position_Status;

                    if (con.SaveChanges() > 0)
                    {
                        con.MINISTRY_DRIVER.Add(M);
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
                var obj = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.MINISTRY_DRIVER.Attach(obj);

                }
                con.MINISTRY_DRIVER.Remove(obj);
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
                        var obj = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.MINISTRY_DRIVER.Attach(obj);


                        }
                        con.MINISTRY_DRIVER.Remove(obj);
                        con.SaveChanges();
                    }
                }
                return msg;
            }

        }


        //DISPLAY METHOD
        public void Display(GridView gd, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_DRIVER where M.MINISTRY.Code_Min ==codeMin.Trim()

                           select new
                           {
                               MIN_DRIVER_ID = M.MIN_DRIVER_ID,
                               DRIVER_ID = M.DRIVER.Full_Name,
                               Min_Driver_RegNumber  = M.Min_Driver_RegNumber ,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name,
                               Position_Status = M.Position_Status
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY All METHOD
        public void DisplayAll(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_DRIVER
                           select new
                           {
                               MIN_DRIVER_ID = M.MIN_DRIVER_ID,
                               DRIVER_ID = M.DRIVER.Full_Name,
                               Min_Driver_RegNumber = M.Min_Driver_RegNumber,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name,
                               Position_Status = M.Position_Status
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(MinDriver_Class Md, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id).FirstOrDefault();

                Md.DRIVER_ID = M.DRIVER_ID;
                Md.Min_Driver_RegNumber  = M.Min_Driver_RegNumber ;
                Md.MINISTRY_ID = M.MINISTRY_ID;
                Md.Position_Status = M.Position_Status;
                // Md.Saved_Date = M.Saved_Date;

            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MINISTRY_DRIVER where l.MINISTRY.Code_Min == codeMin
                         select l).Count();
                n = M;
            }
            return n;
        }

        //COUNT All METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MINISTRY_DRIVER
                         select l).Count();
                n = M;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_DRIVER
                           where M.MINISTRY.Code_Min== codeMin &&
                           (M.Min_Driver_RegNumber ).ToString().StartsWith(SearchText) ||
                           M.DRIVER.Full_Name.StartsWith(SearchText) ||
                           M.DRIVER.Full_Name.StartsWith(SearchText) 
                           select new
                           {
                               MIN_DRIVER_ID = M.MIN_DRIVER_ID,
                               DRIVER_ID = M.DRIVER.Full_Name,
                               Min_Driver_RegNumber = M.Min_Driver_RegNumber,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name,
                               Position_Status = M.Position_Status

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //REASEARCH All METHOD
        public void ResearchAll(GridView gd,string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_DRIVER
                           where
                           (M.Min_Driver_RegNumber).ToString().StartsWith(SearchText) ||
                           M.DRIVER.Full_Name.StartsWith(SearchText) ||
                           M.DRIVER.Full_Name.StartsWith(SearchText)||
                           M.MINISTRY.Ministry_Name.StartsWith(SearchText)
                           select new
                           {
                               MIN_DRIVER_ID = M.MIN_DRIVER_ID,
                               DRIVER_ID = M.DRIVER.Full_Name,
                               Min_Driver_RegNumber = M.Min_Driver_RegNumber,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name,
                               Position_Status = M.Position_Status

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }


        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies where M.Code_Min== codeMin

                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Ministry_Name= M.Ministry_Name,
                               Code_Min = codeMin,
                               
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

        //DISPLAY  All MINISTRY METHOD
        public void DisplayMinistryAll(DropDownList drop)
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

        //DISPLAY VEHICLE DEPENDS ON MINISTRY CHOOSEN IN AUTOPOSTBACK METHOD
        public void DisplayVehicle(DropDownList drop,int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs where V.MINISTRY_ID==id && V.Stat == "Available"

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Local_Plate = V.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Local_Plate";
                drop.DataBind();
            }

        }

        //DISPLAY  ALL VEHICLE FOR SPECIFIC MINISTRY BASED ON CODE MINISTRY METHOD
        public void DisplayAllMinVehicle(DropDownList drop,string codeMin,int idMinDr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.MINISTRY_DRIVER where V.MINISTRY.Code_Min==codeMin && V.MIN_DRIVER_ID== idMinDr

                           select new
                           {
                               Min_Driver_RegNumber = V.Min_Driver_RegNumber,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Min_Driver_RegNumber";
                drop.DataBind();
            }

        }

        //DISPLAY  ALL VEHICLE METHOD
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
                drop.DataValueField = "Local_Plate";
                drop.DataBind();
            }

        }


        //DISPLAY  Driver for specific Ministry METHOD
        public void DisplayDriver(DropDownList drop, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.DRIVERs where D.Ministry_Work== codeMin && D.State=="Work"

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Full_Name = D.Full_Name 
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "DRIVER_ID";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }

        //DISPLAY All Driver for specific Ministry  METHOD 
        public void DisplayDriverMinAll(DropDownList drop,string codeMin,int idMinDr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.MINISTRY_DRIVER where D.MINISTRY.Code_Min == codeMin && D.MIN_DRIVER_ID == idMinDr

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Full_Name = D.DRIVER.Full_Name
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "DRIVER_ID";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }

        //DISPLAY  All Driver METHOD
        public void DisplayDriverAll(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.DRIVERs

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Full_Name = D.Full_Name
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "DRIVER_ID";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }

    }
}