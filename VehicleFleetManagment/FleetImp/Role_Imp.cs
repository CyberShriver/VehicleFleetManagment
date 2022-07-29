using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetImp
{
    public class Role_Imp: Role_Interface
    {

        int msg;
        ROLE R = new ROLE();

        //ADD METHOD
        public int Add(Role_Class Ro)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                R.Role_Name = Ro.Role_Name;
                R.Descrept = Ro.Descrept;

                con.ROLEs.Add(R);

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
        public int Update(Role_Class Ro, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                ROLE R = new ROLE();
                R = con.ROLEs.Where(x => x.ROLE_ID == id).FirstOrDefault();

                if (R != null)
                {

                    R.Role_Name = Ro.Role_Name;
                    R.Descrept = Ro.Descrept;

                    if (con.SaveChanges() > 0)
                    {
                        con.ROLEs.Add(R);
                        con.Entry(R).State = EntityState.Modified;

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
                var obj = con.ROLEs.Where(x => x.ROLE_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.ROLEs.Attach(obj);

                }
                con.ROLEs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DISPLAY METHOD
        public void Display(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.ROLEs

                           select new
                           {
                               ROLE_ID = R.ROLE_ID,
                               Role_Name = R.Role_Name,
                               Descrept = R.Descrept,
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Role_Class Ro, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                R = con.ROLEs.Where(x => x.ROLE_ID == id).FirstOrDefault();

                Ro.Role_Name = R.Role_Name;
                Ro.Descrept = R.Descrept;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var b = (from l in con.ROLEs
                         select l).Count();
                n = b;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.ROLEs
                           where R.Role_Name.StartsWith(SearchText)

                           select new
                           {
                               ROLE_ID = R.ROLE_ID,
                               Role_Name = R.Role_Name,
                               Descrept = R.Descrept,

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DROPDOWN ROLE
        public void DropdownRole(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.ROLEs
                           
                           select new
                           {
                               ROLE_ID = R.ROLE_ID,
                               Role_Name = R.Role_Name,

                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "ROLE_ID";
                drop.DataTextField = "Role_Name";
                drop.DataBind();
            }

        }

        // DISPLAY ROLE NAME FOR MINISTRY TABLE
        public void DropdownRoleName(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.ROLEs

                           select new
                           {
                               Role_Name = R.Role_Name,

                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Role_Name";
                drop.DataBind();
            }

        }

    }
}