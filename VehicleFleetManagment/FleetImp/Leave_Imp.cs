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
                L.Approved_Dte = "";
                L.Saved_Date = Le.Saved_Date;
                L.MINISTRY_ID = Le.MINISTRY_ID;
                L.MIN_DRIVER_ID = Le.MIN_DRIVER_ID;
                L.LEAVE_TYPE_ID = Le.LEAVE_TYPE_ID;
                L.State = Le.State;

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
                    L.State = Le.State;


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

        //DISPLAY METHOD
        public void Display(GridView gd,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LEAVEs where L.MINISTRY.Code_Min== codeMin orderby L.LEAVE_ID descending

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
                               State = L.State,
                               MIN_DRIVER_ID = L.MINISTRY_DRIVER.DRIVER.Full_Name,
                               LEAVE_TYPE_ID = L.LEAVE_TYPE.Leave_Type_Description,
                               MINISTRY_ID = L.MINISTRY.Ministry_Name,
                               Picture=L.MINISTRY_DRIVER.DRIVER.Picture

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
                               State = L.State,
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
                Le.State = L.State;
                Le.Saved_Date = L.Saved_Date;
                Le.Approved_Dte = L.Approved_Dte;

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

        //COUNT NOTIFICATION
        public int countNotification(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LEAVEs
                         where l.State == "in Progress" || l.State == "Pending..." && l.MINISTRY.Code_Min == codeMin
                         select l).Count();
                n = L;
            }
            return n;
        }

        //COUNT ACTIVE LEAVE METHOD
        public int countActive(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LEAVEs
                         where l.State== "in Progress" && l.MINISTRY.Code_Min == codeMin
                         select l).Count();
                n = L;
            }
            return n;
        }

        //COUNT PENDING LEAVE METHOD
        public int countPending(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LEAVEs
                         where l.State == "Pending..." && l.MINISTRY.Code_Min == codeMin
                         select l).Count();
                n = L;
            }
            return n;
        }

        //COUNT DUE SOON LEAVE METHOD
        public int countDueSoon(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LEAVEs
                         where l.State == "Approved" && l.MINISTRY.Code_Min == codeMin
                         select l).Count();
                n = L;
            }
            return n;
        }

        //COUNT FINISH SOON LEAVE METHOD
        public int countFinishSoon(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LEAVEs
                         where l.State == "in Progress" && ((Convert.ToDateTime(l.End_Dte).Date - DateTime.Now.Date)).TotalDays <= 2 && l.MINISTRY.Code_Min == codeMin
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
                       L.State.StartsWith(SearchText) ||
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
                               State = L.State,
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
                       L.State.StartsWith(SearchText) ||
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
                               State = L.State,
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
                               Leave_Type_Description = Lev.Leave_Type_Description,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Leave_Type_Description";
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
                           where Md.MINISTRY.MINISTRY_ID == id && Md.Position_Status=="On Post"

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

        //UPDATE VEHICLE VAILABLE STATE METHOD
        public int UpdateVehAvailable(string LocalPlate)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                VEHICLE V = new VEHICLE();
                V = con.VEHICLEs.Where(x => x.Local_Plate == LocalPlate).FirstOrDefault();

                if (V != null)
                {
                    V.Stat = "Available";
                    if (con.SaveChanges() > 0)
                    {
                        con.VEHICLEs.Add(V);
                        con.Entry(V).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //UPDATE DRIVER VISIBILITY FALSE METHOD
        public int UpdateDriverVisibilty(long id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                DRIVER D = new DRIVER();
                D = con.DRIVERs.Where(x => x.DRIVER_ID == id).FirstOrDefault();

                if (D != null)
                {                  
                        D.Visibility = "false";
                    
                    if (con.SaveChanges() > 0)
                    {
                        con.DRIVERs.Add(D);
                        con.Entry(D).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //UPDATE DRIVER VISIBILITY TRUE METHOD
        public int UpdateDriverVisibiltyTrue(long id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                DRIVER D = new DRIVER();
                D = con.DRIVERs.Where(x => x.DRIVER_ID == id).FirstOrDefault();

                if (D != null)
                {
                    D.Visibility = "True";

                    if (con.SaveChanges() > 0)
                    {
                        con.DRIVERs.Add(D);
                        con.Entry(D).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }
        //UPDATE DRIVER POSITION & VEHICLE STATE & DRIVER VISIBILITY
        public long UpdatePositionState(long id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MINISTRY_DRIVER M = new MINISTRY_DRIVER();
                M = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id && x.Position_Status=="On Post").FirstOrDefault();

                if (M != null)
                {
                    M.Position_Status = "Leave";
                    M.EndDate = DateTime.Now.ToString();
                    UpdateVehAvailable(M.Min_Driver_RegNumber);
                    UpdateDriverVisibilty(M.DRIVER_ID);
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
        //AUTO SWITCH  THE STATE AND POSITION WHEN APPROVED AND START LEAVE
        public void AutoSwitch()
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L = con.LEAVEs.AsEnumerable().Where(x => x.State == "Approved" && Convert.ToDateTime(x.Start_Dte).Date<= DateTime.Now.Date).FirstOrDefault();

                if (L != null)
                {
                    L.State = "in Progress";
                    UpdatePositionState(L.MIN_DRIVER_ID);
                    if (con.SaveChanges() > 0)
                    {
                        con.LEAVEs.Add(L);
                        con.Entry(L).State = EntityState.Modified;

                    }
                }
            }
        }

        //UPDATE APPROVED  STATE METHOD ON CLICK APPROVE BTN
        public int UpdateStateApproved(long id,string approvBy)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L = con.LEAVEs.Where(x => x.LEAVE_ID == id).FirstOrDefault();

                if (L != null)
                {
                    L.State = "Approved";
                    L.Approved_Dte =DateTime.Today.ToString("yyyy-MM-dd");
                    L.Approved_By = approvBy;
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

        //UPDATE DENY  STATE METHOD ON CLICK CANCEL BTN
        public int UpdateStateDeny(long id,string approvBy)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L = con.LEAVEs.Where(x => x.LEAVE_ID == id).FirstOrDefault();

                if (L != null)
                {
                    L.State = "Denied";
                    L.Approved_Dte = DateTime.Today.ToString("yyyy-MM-dd");
                    L.Approved_By = approvBy;

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

        //AUTO UPDATE FINISH  STATE METHOD
        public int UpdateStateFinished()
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L = con.LEAVEs.AsEnumerable().Where(x => x.State == "Approved" || x.State == "in Progress" && Convert.ToDateTime(x.End_Dte).Date<= DateTime.Now.Date).FirstOrDefault();

                if (L != null)
                {
                    L.State = "Finished";
                    UpdateDriverVisibiltyTrue(L.MINISTRY_DRIVER.DRIVER.DRIVER_ID);

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

        //AUTO CHANGE PENDING WHEN START DATE IS OVERAL
        public int UpdateAutoStateDenied(string approvBy)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L = con.LEAVEs.AsEnumerable().Where(x => x.State == "Pending..." && Convert.ToDateTime(x.Start_Dte).Date <= DateTime.Now.Date).FirstOrDefault();

                if (L != null)
                {
                    L.State = "Denied";
                    L.Approved_Dte = DateTime.Today.ToString("yyyy-MM-dd");
                    L.Approved_By = approvBy;
                    UpdateDriverVisibiltyTrue(L.MINISTRY_DRIVER.DRIVER.DRIVER_ID);

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
        ////CHECK LAST SAVED

        //public void LastSaved(MinDriver_Class Md, int driver)
        //{
        //    int id;
        //    using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
        //    {
        //        var M = con.MINISTRY_DRIVER.OrderByDescending(x => x.MIN_DRIVER_ID).Where(x => x.DRIVER_ID == driver).FirstOrDefault();

        //        if (M != null)
        //        {
        //            id = Convert.ToInt32(M.MIN_DRIVER_ID);

        //            if (M.Position_Status == "On Post")
        //            {
        //                UpdatePositionState(id);
        //            }

        //        }

        //    }

        //}
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

        //DISPLAY Leave Type FOR SPECIFIC DRIVER ( In case of Edit) WHEN DRIVER START LEAVE
        public void DisplaySelectedLeave(DropDownList drop, int idMin, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LEAVEs
                           where L.MINISTRY.MINISTRY_ID == idMin && L.LEAVE_ID == id

                           select new
                           {
                               LEAVE_TYPE_ID = L.LEAVE_TYPE_ID,
                               Leave_Type_Description = L.LEAVE_TYPE.Leave_Type_Description,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Leave_Type_Description";
                drop.DataValueField = "LEAVE_TYPE_ID";
                drop.DataBind();
            }

        }

        // DISPLAY SPECIFIC  DRIVER   (In case of Edit) WHEN DRIVER START LEAVE
        public void DisplaySelectedDriver(DropDownList drop, int idMin, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LEAVEs
                           where L.MINISTRY.MINISTRY_ID == idMin && L.LEAVE_ID == id

                           select new
                           {
                               MIN_DRIVER_ID = L.MIN_DRIVER_ID,
                               Full_Name = L.MINISTRY_DRIVER.DRIVER.Full_Name
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MIN_DRIVER_ID";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }

        // DISPLAY NOTIFICATION
        public void LeaveNotification(ListView listProgress, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LEAVEs
                           where L.MINISTRY.Code_Min == codeMin && L.State == "in Progress" || L.State == "Pending..."

                           select new
                           {
                               Picture=L.MINISTRY_DRIVER.DRIVER.Picture,
                               Full_Name = L.MINISTRY_DRIVER.DRIVER.Full_Name,
                               Leave_Code=L.Leave_Code,
                               State=L.State
                           }
                           ).ToList();

                listProgress.DataSource = obj;
                listProgress.DataBind();
            }

        }



    }
}