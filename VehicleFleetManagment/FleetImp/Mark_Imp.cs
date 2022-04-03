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
    public class Mark_Imp:Mark_Interface
    {
        int msg;
        MARK M = new MARK();

        //ADD METHOD
        public int Add(Mark_Class Ma)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M.Mark_Name = Ma.Mark_Name;
                M.Comment = Ma.Comment;

                con.MARKs.Add(M);

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
        public int Update(Mark_Class Ma, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MARK M = new MARK();
                M = con.MARKs.Where(x => x.MARK_ID == id).FirstOrDefault();

                if (M != null)
                {

                    M.Mark_Name = Ma.Mark_Name;
                    M.Comment = Ma.Comment;

                    if (con.SaveChanges() > 0)
                    {
                        con.MARKs.Add(M);
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
                var obj = con.MARKs.Where(x => x.MARK_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.MARKs.Attach(obj);

                }
                con.MARKs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DELETE CHECK METHOD
        public int DeleteCheck(GridView gd,CheckBox chk, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                for (int i = 0; i < gd.Rows.Count; i++)
                {
                    CheckBox chkselect = (CheckBox)gd.Rows[i].FindControl("chk");
                    if (chkselect.Checked == true)
                    {
                        id = Convert.ToInt32(gd.Rows[i].Cells[i].Text);
                        var obj = con.MARKs.Where(x => x.MARK_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.MARKs.Attach(obj);


                        }
                        con.MARKs.Remove(obj);
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
                var obj = (from M in con.MARKs

                           select new
                           {
                               MARK_ID = M.MARK_ID,
                               Mark_Name = M.Mark_Name,
                               Comment = M.Comment,
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Mark_Class Ma, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MARKs.Where(x => x.MARK_ID == id).FirstOrDefault();

                Ma.Mark_Name = M.Mark_Name;
                Ma.Comment = M.Comment;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using(MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var b = (from l in con.MARKs
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
                var obj = (from M in con.MARKs
                           where
                      M.Mark_Name == SearchText ||
                      M.Comment == SearchText

                           select new
                           {
                               MARK_ID = M.MARK_ID,
                               Mark_Name = M.Mark_Name,
                               Comment = M.Comment,

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }
    }
}