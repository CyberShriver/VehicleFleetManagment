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
    public class MinRealEstate_Imp: MinRealEstate_Interface
    {

        int msg;
        MINISTRY_REAL_ESTATE M = new MINISTRY_REAL_ESTATE();

        //ADD METHOD
        public int Add(MinRealEstate_Class Mr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M.REAL_ESTATE_ID  = Mr.REAL_ESTATE_ID ;
                M.Quantity = Mr.Quantity;
                M.MINISTRY_ID = Mr.MINISTRY_ID;            
                M.Comment = Mr.Comment;
               // M.Saved_Date = Mr.Saved_Date;

                con.MINISTRY_REAL_ESTATE.Add(M);

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
        public int Update(MinRealEstate_Class Mr, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MINISTRY_REAL_ESTATE M = new MINISTRY_REAL_ESTATE();
                M = con.MINISTRY_REAL_ESTATE.Where(x => x.MIN_REAL_ESTATE_ID == id).FirstOrDefault();

                if (M != null)
                {

                    M.REAL_ESTATE_ID = Mr.REAL_ESTATE_ID;
                    M.Quantity = Mr.Quantity;
                    M.MINISTRY_ID = Mr.MINISTRY_ID;
                    M.Comment = Mr.Comment;
                    // M.Saved_Date = Mr.Saved_Date;

                    if (con.SaveChanges() > 0)
                    {
                        con.MINISTRY_REAL_ESTATE.Add(M);
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
                var obj = con.MINISTRY_REAL_ESTATE.Where(x => x.MIN_REAL_ESTATE_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.MINISTRY_REAL_ESTATE.Attach(obj);

                }
                con.MINISTRY_REAL_ESTATE.Remove(obj);
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
                        var obj = con.MINISTRY_REAL_ESTATE.Where(x => x.MIN_REAL_ESTATE_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.MINISTRY_REAL_ESTATE.Attach(obj);


                        }
                        con.MINISTRY_REAL_ESTATE.Remove(obj);
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
                var obj = (from M in con.MINISTRY_REAL_ESTATE

                           select new
                           {
                               MIN_REAL_ESTATE_ID = M.MIN_REAL_ESTATE_ID,
                               REAL_ESTATE_ID  = M.REAL_ESTATE_ID ,
                               Quantity = M.Quantity,
                               MINISTRY_ID = M.MINISTRY_ID,                               
                               Comment = M.Comment                             
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(MinRealEstate_Class Mr, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MINISTRY_REAL_ESTATE.Where(x => x.MIN_REAL_ESTATE_ID == id).FirstOrDefault();

                Mr.REAL_ESTATE_ID  = M.REAL_ESTATE_ID ;
                Mr.Quantity = M.Quantity;
                Mr.MINISTRY_ID = M.MINISTRY_ID;
                Mr.Comment = M.Comment;
               // Mr.Saved_Date = M.Saved_Date;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MINISTRY_REAL_ESTATE
                         select l).Count();
                n = M;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_REAL_ESTATE
                           where (M.Quantity).ToString() == SearchText || (M.MINISTRY_ID).ToString() == SearchText                        
                           select new
                           {
                               MIN_REAL_ESTATE_ID = M.MIN_REAL_ESTATE_ID,
                               REAL_ESTATE_ID  = M.REAL_ESTATE_ID ,
                               Quantity = M.Quantity,
                               MINISTRY_ID = M.MINISTRY_ID,                               
                               Comment = M.Comment
                              
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }


        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop)
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


        //DISPLAY METHOD REAL_ESTATE
        public void DisplayREAL_ESTATE(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.REAL_ESTATE

                           select new
                           {
                               REAL_ESTATE_ID = R.REAL_ESTATE_ID,
                               RealEstate_Name = R.RealEstate_Name
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "REAL_ESTATE_ID";
                drop.DataTextField = "RealEstate_Name";
                drop.DataBind();
            }

        }


    }
}