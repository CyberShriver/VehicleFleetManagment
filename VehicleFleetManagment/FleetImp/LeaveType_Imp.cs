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
    public class LeaveType_Imp:LeaveType_Interface
    {

        int msg;
        LEAVE_TYPE L = new LEAVE_TYPE();

        //ADD METHOD
        public int Add(LeaveType_Class Le)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L.Leave_Type_Description = Le.Leave_Type_Description;
                L.Leave_Number = Le.Leave_Number;
                L.Deleted ="False";

                con.LEAVE_TYPE.Add(L);

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
        public int Update(LeaveType_Class Le, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                LEAVE_TYPE L = new LEAVE_TYPE();
                L = con.LEAVE_TYPE.Where(x => x.LEAVE_TYPE_ID == id).FirstOrDefault();

                if (L != null)
                {

                    L.Leave_Type_Description = Le.Leave_Type_Description;
                    L.Leave_Number = Le.Leave_Number;
                    L.Deleted = "False";

                    if (con.SaveChanges() > 0)
                    {
                        con.LEAVE_TYPE.Add(L);
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
                var obj = con.LEAVE_TYPE.Where(x => x.LEAVE_TYPE_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.LEAVE_TYPE.Attach(obj);

                }
                con.LEAVE_TYPE.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DELETE STATE METHOD
        public int DeleteState(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                LEAVE_TYPE L = new LEAVE_TYPE();
                L = con.LEAVE_TYPE.Where(x => x.LEAVE_TYPE_ID == id).FirstOrDefault();

                if (L != null)
                {
                    L.Deleted = "True";

                    if (con.SaveChanges() > 0)
                    {
                        con.LEAVE_TYPE.Add(L);
                        con.Entry(L).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }


        //DISPLAY METHOD
        public void Display(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LEAVE_TYPE where L.Deleted=="False"

                           select new
                           {
                               LEAVE_TYPE_ID = L.LEAVE_TYPE_ID,
                               Leave_Type_Description = L.Leave_Type_Description,
                               Leave_Number = L.Leave_Number
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(LeaveType_Class Le, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                L = con.LEAVE_TYPE.Where(x => x.LEAVE_TYPE_ID == id).FirstOrDefault();

                Le.Leave_Type_Description = L.Leave_Type_Description;
                Le.Leave_Number = L.Leave_Number;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var L = (from l in con.LEAVE_TYPE where l.Deleted == "False"
                         select l).Count();
                n = L;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from L in con.LEAVE_TYPE
                           where L.Deleted == "False" &&
                      L.Leave_Type_Description.StartsWith(SearchText) ||
                      L.Leave_Number.ToString().StartsWith(SearchText)

                           select new
                           {
                               LEAVE_TYPE_ID = L.LEAVE_TYPE_ID,
                               Leave_Type_Description = L.Leave_Type_Description,
                               Leave_Number = L.Leave_Number

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }


    }
}