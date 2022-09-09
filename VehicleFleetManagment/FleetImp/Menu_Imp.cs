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
    public class Menu_Imp: Menu_Interface
    {


        int msg;
        MENU M = new MENU();

        //ADD METHOD
        public int Add(Menu_Class Me)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M.Title_Menu = Me.Title_Menu;
                M.Stat = Me.Stat;
                M.Deleted = "False";

                con.MENUs.Add(M);

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
        public int Update(Menu_Class Me, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MENU M = new MENU();
                M = con.MENUs.Where(x => x.Menu_Code == id).FirstOrDefault();

                if (M != null)
                {

                    M.Title_Menu = Me.Title_Menu;
                    M.Stat = Me.Stat;
                    M.Deleted = "False";

                    if (con.SaveChanges() > 0)
                    {
                        con.MENUs.Add(M);
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
                var obj = con.MENUs.Where(x => x.Menu_Code == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.MENUs.Attach(obj);

                }
                con.MENUs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DELETE STATE METHOD
        public int DeleteState(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MENU M = new MENU();
                M = con.MENUs.Where(x => x.Menu_Code == id).FirstOrDefault();

                if (M != null)
                {
                    M.Deleted = "True";

                    if (con.SaveChanges() > 0)
                    {
                        con.MENUs.Add(M);
                        con.Entry(M).State = EntityState.Modified;

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
                var obj = (from M in con.MENUs where M.Deleted=="False"

                           select new
                           {
                               Menu_Code = M.Menu_Code,
                               Title_Menu = M.Title_Menu,
                               Stat = M.Stat,
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY DETAILS METHOD OF ROLE
        public void DisplayDetails(string menu, Menu_Class Me)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MENUs.Where(x => x.Title_Menu == menu && x.Deleted == "False").FirstOrDefault();
                if (M != null)
                {
                    Me.Menu_Code = M.Menu_Code;
                    Me.Title_Menu = M.Title_Menu;
                    Me.Stat = M.Stat;
                }


            }
        }

        //PROVIDE METHOD
        public void provide(Menu_Class Me, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MENUs.Where(x => x.Menu_Code == id).FirstOrDefault();

                Me.Title_Menu = M.Title_Menu;
                Me.Stat = M.Stat;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var b = (from l in con.MENUs where M.Deleted == "False"
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
                var obj = (from M in con.MENUs
                           where M.Deleted == "False" && M.Title_Menu.StartsWith(SearchText)

                           select new
                           {
                               Menu_Code = M.Menu_Code,
                               Title_Menu = M.Title_Menu,
                               Stat = M.Stat,

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

    }
}