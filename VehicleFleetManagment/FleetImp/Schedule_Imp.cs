using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetImp
{
    public class Schedule_Imp: Schedule_Interface
    {


        int msg;
        SCHEDULE S = new SCHEDULE();
     

        //ADD METHOD
        public int Add(Schedule_Class  sc)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                S.MINISTRY_ID  = sc.MINISTRY_ID ;
                S.VEHICLE_ID = sc.VEHICLE_ID;
                S.Time = sc.Time;
                S.Date = sc.Date;
                S.Mission = sc.Mission;
                S.Saved_Date = sc.Saved_Date;
                S.Deleted ="False";
                S.Comment = sc.Comment;

                con.SCHEDULEs.Add(S);

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
        public int Update(Schedule_Class  sc, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                SCHEDULE S = new SCHEDULE();
                S = con.SCHEDULEs.Where(x => x.SCHEDULE_ID == id).FirstOrDefault();

                if (S != null)
                {

                    S.MINISTRY_ID = sc.MINISTRY_ID;
                    S.VEHICLE_ID = sc.VEHICLE_ID;
                    S.Time = sc.Time;
                    S.Date = sc.Date;
                    S.Deleted = "False";
                    S.Mission = sc.Mission;
                    S.Saved_Date = sc.Saved_Date;
                    S.Comment = sc.Comment;

                    if (con.SaveChanges() > 0)
                    {
                        con.SCHEDULEs.Add(S);
                        con.Entry(S).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //Delete value by change state
        public int DeleteState(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                SCHEDULE S = new SCHEDULE();
                S = con.SCHEDULEs.Where(x => x.SCHEDULE_ID == id).FirstOrDefault();

                if (S != null)
                {                    
                    S.Deleted ="True";

                    if (con.SaveChanges() > 0)
                    {
                        con.SCHEDULEs.Add(S);
                        con.Entry(S).State = EntityState.Modified;

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
                var obj = con.SCHEDULEs.Where(x => x.SCHEDULE_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.SCHEDULEs.Attach(obj);

                }
                con.SCHEDULEs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DISPLAY METHOD
        public void Display(GridView gd,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from S in con.SCHEDULEs where S.MINISTRY.Code_Min== codeMin && S.Deleted=="False"

                           select new
                           {
                               SCHEDULE_ID = S.SCHEDULE_ID,
                               MINISTRY_ID  = S.MINISTRY.Ministry_Name ,
                               VEHICLE_ID = S.VEHICLE.Local_Plate,
                               Saved_Date = S.Saved_Date,
                               Time = S.Time,
                               Date = S.Date,
                               Mission = S.Mission,
                               Comment = S.Comment
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY ALL METHOD
        public void DisplayAll(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from S in con.SCHEDULEs where S.Deleted == "False"

                           select new
                           {
                               SCHEDULE_ID = S.SCHEDULE_ID,
                               MINISTRY_ID = S.MINISTRY.Ministry_Name,
                               VEHICLE_ID = S.VEHICLE.Local_Plate,
                               Saved_Date = S.Saved_Date,
                               Time = S.Time,
                               Date = S.Date,
                               Mission = S.Mission,
                               Comment = S.Comment
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Schedule_Class  sc, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                S = con.SCHEDULEs.Where(x => x.SCHEDULE_ID == id).FirstOrDefault();

                sc.SCHEDULE_ID = S.SCHEDULE_ID;
                sc.VEHICLE_ID = S.VEHICLE_ID;
                sc.MINISTRY_ID  = S.MINISTRY_ID ;
                sc.MINISTRY_ID  = S.MINISTRY_ID ;
                sc.Time  = S.Time ;
                sc.Date  = S.Date ;
                sc.Mission = S.Mission;
                sc.Comment = S.Comment;

            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var S = (from l in con.SCHEDULEs where l.MINISTRY.Code_Min== codeMin && l.Deleted == "False"
                         select l).Count();
                n = S;
            }
            return n;
        }

        //COUNT ALL METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var S = (from l in con.SCHEDULEs where l.Deleted == "False"
                         select l).Count();
                n = S;
            }
            return n;
        }


        //REASEARCH METHOD
        public void Research(GridView gd,string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from S in con.SCHEDULEs
                           where S.MINISTRY.Code_Min==codeMin && S.Deleted=="False" &&
                      S.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                      S.Date.StartsWith(SearchText) ||
                      S.Saved_Date.StartsWith(SearchText) ||
                      S.VEHICLE.Local_Plate.StartsWith(SearchText)

                           select new
                           {
                               SCHEDULE_ID = S.SCHEDULE_ID,
                               MINISTRY_ID = S.MINISTRY.Ministry_Name,
                               VEHICLE_ID = S.VEHICLE.Local_Plate,
                               Saved_Date = S.Saved_Date,
                               Time = S.Time,
                               Date = S.Date,
                               Mission = S.Mission,
                               Comment = S.Comment

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //REASEARCH ALL METHOD
        public void ResearchAll(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from S in con.SCHEDULEs
                           where S.Deleted == "False" &&
                      S.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                      S.Date.StartsWith(SearchText) ||
                      S.Saved_Date.StartsWith(SearchText) ||
                      S.VEHICLE.Local_Plate.StartsWith(SearchText)

                           select new
                           {
                               SCHEDULE_ID = S.SCHEDULE_ID,
                               MINISTRY_ID = S.MINISTRY.Ministry_Name,
                               VEHICLE_ID = S.VEHICLE.Local_Plate,
                               Saved_Date = S.Saved_Date,
                               Time = S.Time,
                               Date = S.Date,
                               Mission = S.Mission,
                               Comment = S.Comment

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
                drop.DataTextField = "Local_Plate";
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
        public void DisplayMinistry(DropDownList drop,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies where M.Code_Min==codeMin

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

        //DISPLAY METHOD ALL MINISTRY
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

    }
}