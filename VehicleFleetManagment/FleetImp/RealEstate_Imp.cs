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
    public class RealEstate_Imp: RealEstate_Interface
    {


        int msg;
        REAL_ESTATE R = new REAL_ESTATE();

        //ADD METHOD
        public int Add(RealEstate_Class Re)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                R.RealEstate_Name = Re.RealEstate_Name;
                R.Comment = Re.Comment;

                con.REAL_ESTATE.Add(R);

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
        public int Update(RealEstate_Class Re, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                REAL_ESTATE R = new REAL_ESTATE();
                R = con.REAL_ESTATE.Where(x => x.REAL_ESTATE_ID == id).FirstOrDefault();

                if (R != null)
                {

                    R.RealEstate_Name = Re.RealEstate_Name;
                    R.Comment = Re.Comment;

                    if (con.SaveChanges() > 0)
                    {
                        con.REAL_ESTATE.Add(R);
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
                var obj = con.REAL_ESTATE.Where(x => x.REAL_ESTATE_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.REAL_ESTATE.Attach(obj);

                }
                con.REAL_ESTATE.Remove(obj);
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
                        var obj = con.REAL_ESTATE.Where(x => x.REAL_ESTATE_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.REAL_ESTATE.Attach(obj);


                        }
                        con.REAL_ESTATE.Remove(obj);
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
                var obj = (from R in con.REAL_ESTATE

                           select new
                           {
                               REAL_ESTATE_ID = R.REAL_ESTATE_ID,
                               RealEstate_Name = R.RealEstate_Name,
                               Comment = R.Comment
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(RealEstate_Class Re, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                R = con.REAL_ESTATE.Where(x => x.REAL_ESTATE_ID == id).FirstOrDefault();

                Re.RealEstate_Name = R.RealEstate_Name;
                Re.Comment = R.Comment;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var R = (from l in con.REAL_ESTATE
                         select l).Count();
                n = R;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.REAL_ESTATE
                           where
                      R.RealEstate_Name == SearchText ||
                      R.Comment.ToString() == SearchText

                           select new
                           {
                               REAL_ESTATE_ID = R.REAL_ESTATE_ID,
                               RealEstate_Name = R.RealEstate_Name,
                               Comment = R.Comment

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }







    }
}