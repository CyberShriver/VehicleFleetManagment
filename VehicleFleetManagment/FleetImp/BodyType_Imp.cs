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
    public class BodyType_Imp:BodyType_Interface
    {

        int msg;
        BODY_TYPE B = new BODY_TYPE();

        //ADD METHOD
        public int Add(BodyType_Class Bo)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                B.Category = Bo.Category;
                B.Category_N_ = Bo.Category_N_;

                con.BODY_TYPE.Add(B);

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
        public int Update(BodyType_Class Bo, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                BODY_TYPE B = new BODY_TYPE();
                B = con.BODY_TYPE.Where(x => x.BODY_ID == id).FirstOrDefault();

                if (B != null)
                {

                    B.Category = Bo.Category;
                    B.Category_N_ = Bo.Category_N_;

                    if (con.SaveChanges() > 0)
                    {
                        con.BODY_TYPE.Add(B);
                        con.Entry(B).State = EntityState.Modified;

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
                var obj = con.BODY_TYPE.Where(x => x.BODY_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.BODY_TYPE.Attach(obj);

                }
                con.BODY_TYPE.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DELETE CHECK METHOD
        public int DeleteCheck(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = con.BODY_TYPE.Where(x => x.BODY_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.BODY_TYPE.Attach(obj);

                }
                con.BODY_TYPE.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }


        //DISPLAY METHOD
        public void Display(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from B in con.BODY_TYPE

                           select new
                           {
                               BODY_ID = B.BODY_ID,                               
                               Category = B.Category,
                               Category_N_ = B.Category_N_
            }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(BodyType_Class Bo, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                B = con.BODY_TYPE.Where(x => x.BODY_ID == id).FirstOrDefault();

                Bo.Category = B.Category;
                Bo.Category_N_ = B.Category_N_;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var b = (from l in con.BODY_TYPE
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
                var obj = (from B in con.BODY_TYPE
                           where
                      B.Category.StartsWith(SearchText) ||
                      B.Category_N_.ToString().StartsWith(SearchText)

                           select new
                           {
                               BODY_ID = B.BODY_ID,
                               Category = B.Category,
                               Category_N_ = B.Category_N_

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }





    }
}