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
                R.Deleted = "False";

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
                    R.Deleted = "False";

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

        //CHANGE DELETE STATE METHOD
        public int DeleteState( int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                REAL_ESTATE R = new REAL_ESTATE();
                R = con.REAL_ESTATE.Where(x => x.REAL_ESTATE_ID == id).FirstOrDefault();

                if (R != null)
                {
                    R.Deleted = "True";

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

        //DISPLAY METHOD
        public void Display(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.REAL_ESTATE where R.Deleted=="False"

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
                var R = (from l in con.REAL_ESTATE where l.Deleted == "False"
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
                           where R.Deleted == "False" && R.RealEstate_Name.StartsWith(SearchText)

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