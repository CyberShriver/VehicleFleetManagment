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
    public class Leave_Imp: Leave_Interface
    {

        int msg;
        LEAVE L = new LEAVE();

        //ADD METHOD
        public int Add(Leave_Class Le)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L.Leave_Code = Le.Leave_Code;
                L.Carpooling = Le.Carpooling;
                L.Start_Dte = Le.Start_Dte;
                L.End_Dte = Le.End_Dte;
                L.Approved_By = Le.Approved_By;
                L.Comment = Le.Comment;
                L.Demand_Dte = Le.Demand_Dte;
                L.Approved_Dte = Le.Approved_Dte;
                L.Saved_Date = Le.Saved_Date;
                L.MINISTRY_ID = Le.MINISTRY_ID;
                L.MIN_DRIVER_ID = Le.MIN_DRIVER_ID;
                L.LEAVE_TYPE_ID = Le.LEAVE_TYPE_ID;

                con.LEAVEs.Add(L);

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
        public int Update(Leave_Class Le, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                LEAVE L = new LEAVE();
                L = con.LEAVEs.Where(x => x.LEAVE_ID == id).FirstOrDefault();

                if (L != null)
                {

                    L.Leave_Code = Le.Leave_Code;
                    L.Carpooling = Le.Carpooling;
                    L.Start_Dte = Le.Start_Dte;
                    L.End_Dte = Le.End_Dte;
                    L.Approved_By = Le.Approved_By;
                    L.Comment = Le.Comment;
                    L.Demand_Dte = Le.Demand_Dte;
                    L.Approved_Dte = Le.Approved_Dte;
                    L.Saved_Date = Le.Saved_Date;
                    L.MINISTRY_ID = Le.MINISTRY_ID;
                    L.MIN_DRIVER_ID = Le.MIN_DRIVER_ID;
                    L.LEAVE_TYPE_ID = Le.LEAVE_TYPE_ID;

                    if (con.SaveChanges() > 0)
                    {
                        con.LEAVEs.Add(L);
                        con.Entry(L).State = EntityState.Modified;

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
                var obj = con.LEAVEs.Where(x => x.LEAVE_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.LEAVEs.Attach(obj);

                }
                con.LEAVEs.Remove(obj);
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
                        var obj = con.LEAVEs.Where(x => x.LEAVE_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.LEAVEs.Attach(obj);


                        }
                        con.LEAVEs.Remove(obj);
                        con.SaveChanges();
                    }
                }
                return msg;
            }

        }


        //DISPLAY METHOD
        public void Display(GridView gd,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LEAVEs where L.MINISTRY.Code_Min== codeMin

                           select new
                           {
                               LEAVE_ID = L.LEAVE_ID,
                               Leave_Code = L.Leave_Code,
                               Carpooling = L.Carpooling,
                               Start_Dte = L.Start_Dte,
                               End_Dte = L.End_Dte,
                               Approved_By = L.Approved_By,
                               Approved_Dte = L.Approved_Dte,
                               Saved_Date = L.Saved_Date,
                               Demand_Dte = L.Demand_Dte,
                               Comment = L.Comment,
                               MIN_DRIVER_ID = L.MINISTRY_DRIVER.DRIVER.Full_Name,
                               LEAVE_TYPE_ID = L.LEAVE_TYPE.Leave_Type_Description,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name

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
                var obj = (from L in con.LEAVEs

                           select new
                           {
                               LEAVE_ID = L.LEAVE_ID,
                               Leave_Code = L.Leave_Code,
                               Carpooling = L.Carpooling,
                               Start_Dte = L.Start_Dte,
                               End_Dte = L.End_Dte,
                               Approved_By = L.Approved_By,
                               Approved_Dte = L.Approved_Dte,
                               Saved_Date = L.Saved_Date,
                               Demand_Dte = L.Demand_Dte,
                               Comment = L.Comment,
                               MIN_DRIVER_ID = L.MINISTRY_DRIVER.DRIVER.Full_Name,
                               LEAVE_TYPE_ID = L.LEAVE_TYPE.Leave_Type_Description,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Leave_Class Le, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L = con.LEAVEs.Where(x => x.LEAVE_ID == id).FirstOrDefault();

                Le.Leave_Code = L.Leave_Code;
                Le.Carpooling = L.Carpooling;
                Le.Start_Dte = L.Start_Dte;
                Le.End_Dte = L.End_Dte;
                Le.Approved_By = L.Approved_By;
                Le.Comment = L.Comment;
                Le.Demand_Dte = L.Demand_Dte;
                Le.LEAVE_TYPE = L.LEAVE_TYPE;
                Le.MIN_DRIVER_ID = L.MIN_DRIVER_ID;
                Le.MINISTRY_ID = L.MINISTRY_ID;
                Le.LEAVE_TYPE_ID = L.LEAVE_TYPE_ID;



            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LEAVEs where l.MINISTRY.Code_Min==codeMin
                         select l).Count();
                n = L;
            }
            return n;
        }

        //COUNT All METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LEAVEs
                         select l).Count();
                n = L;
            }
            return n;
        }
        //REASEARCH METHOD
        public void Research(GridView gd,string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LEAVEs
                           where L.MINISTRY.Code_Min==codeMin &&
                       L.Leave_Code.StartsWith(SearchText) ||
                       L.Start_Dte.StartsWith(SearchText) ||
                       L.Demand_Dte.StartsWith(SearchText) ||
                       L.MINISTRY_DRIVER.DRIVER.Full_Name.StartsWith(SearchText) ||
                       L.LEAVE_TYPE.Leave_Type_Description.StartsWith(SearchText) ||
                       L.Approved_Dte.StartsWith(SearchText)

                           select new
                           {
                               LEAVE_ID = L.LEAVE_ID,
                               Leave_Code = L.Leave_Code,
                               Carpooling = L.Carpooling,
                               Start_Dte = L.Start_Dte,
                               End_Dte = L.End_Dte,
                               Approved_By = L.Approved_By,
                               Approved_Dte = L.Approved_Dte,
                               Saved_Date = L.Saved_Date,
                               Demand_Dte = L.Demand_Dte,
                               Comment = L.Comment,
                               MIN_DRIVER_ID = L.MINISTRY_DRIVER.DRIVER.Full_Name,
                               LEAVE_TYPE_ID = L.LEAVE_TYPE.Leave_Type_Description,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name

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
                var obj = (from L in con.LEAVEs
                           where
                       L.Leave_Code.StartsWith(SearchText) ||
                       L.Start_Dte.StartsWith(SearchText) ||
                       L.Demand_Dte.StartsWith(SearchText) ||
                       L.MINISTRY_DRIVER.DRIVER.Full_Name.StartsWith(SearchText) ||
                       L.LEAVE_TYPE.Leave_Type_Description.StartsWith(SearchText) ||
                       L.Approved_Dte.StartsWith(SearchText)

                           select new
                           {
                               LEAVE_ID = L.LEAVE_ID,
                               Leave_Code = L.Leave_Code,
                               Carpooling = L.Carpooling,
                               Start_Dte = L.Start_Dte,
                               End_Dte = L.End_Dte,
                               Approved_By = L.Approved_By,
                               Approved_Dte = L.Approved_Dte,
                               Saved_Date = L.Saved_Date,
                               Demand_Dte = L.Demand_Dte,
                               Comment = L.Comment,
                               MIN_DRIVER_ID = L.MINISTRY_DRIVER.DRIVER.Full_Name,
                               LEAVE_TYPE_ID = L.LEAVE_TYPE.Leave_Type_Description,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY METHOD ALL Driver
        public void DisplayAllDriver(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from Md in con.MINISTRY_DRIVER

                           select new
                           {
                               MIN_DRIVER_ID = Md.MIN_DRIVER_ID,
                               Full_Name = Md.DRIVER.Full_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Full_Name";
                drop.DataValueField = "MIN_DRIVER_ID";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD Leave Type
        public void DisplayLeaveType(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from Lev in con.LEAVE_TYPE

                           select new
                           {
                               LEAVE_TYPE_ID = Lev.LEAVE_TYPE_ID,
                               Leave_Number = Lev.Leave_Number,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Leave_Number";
                drop.DataValueField = "LEAVE_TYPE_ID";
                drop.DataBind();
            }

        }


        //DISPLAY METHOD Driver
        public void DisplayDriver(DropDownList drop, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from Md in con.MINISTRY_DRIVER
                           where Md.MIN_DRIVER_ID == id

                           select new
                           {
                               MIN_DRIVER_ID = Md.MIN_DRIVER_ID,
                               Full_Name = Md.DRIVER.Full_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Full_Name";
                drop.DataValueField = "MIN_DRIVER_ID";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.MINISTRies where L.Code_Min==codeMin

                           select new
                           {
                               MINISTRY_ID = L.MINISTRY_ID,
                               Ministry_Name = L.Ministry_Name,
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
                var obj = (from L in con.MINISTRies

                           select new
                           {
                               MINISTRY_ID = L.MINISTRY_ID,
                               Ministry_Name = L.Ministry_Name,
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