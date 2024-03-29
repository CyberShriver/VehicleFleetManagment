﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetImp
{
    public class Model_Imp:Model_Interface
    {


        int msg;
        MODEL M = new MODEL();
        MARK Ma = new MARK();

        //ADD METHOD
        public int Add(Model_Class Mo)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M.MARK_ID = Mo.MARK_ID;
                M.Model_Name = Mo.Model_Name;
                M.Comment = Mo.Comment;
                M.Deleted = "False";

                con.MODELs.Add(M);

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
        public int Update(Model_Class Mo, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MODEL M = new MODEL();
                M = con.MODELs.Where(x => x.MODEL_ID == id).FirstOrDefault();

                if (M != null)
                {

                    M.MARK_ID = Mo.MARK_ID;
                    M.Model_Name = Mo.Model_Name;
                    M.Comment = Mo.Comment;
                    M.Deleted = "False";

                    if (con.SaveChanges() > 0)
                    {
                        con.MODELs.Add(M);
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
                var obj = con.MODELs.Where(x => x.MODEL_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.MODELs.Attach(obj);

                }
                con.MODELs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //CHANGE DELETE STATE METHOD
        public int DeleteState(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MODEL M = new MODEL();
                M = con.MODELs.Where(x => x.MODEL_ID == id).FirstOrDefault();

                if (M != null)
                {
                    M.Deleted = "True";

                    if (con.SaveChanges() > 0)
                    {
                        con.MODELs.Add(M);
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
                var obj = (from M in con.MODELs where M.Deleted=="False"
                           orderby M.MODEL_ID descending
                           select new
                           {
                               MODEL_ID = M.MODEL_ID,
                               MARK_ID = M.MARK.Mark_Name,
                               Model_Name = M.Model_Name,
                               Comment = M.Comment
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Model_Class Mo, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MODELs.Where(x => x.MODEL_ID == id).FirstOrDefault();

                Mo.MODEL_ID = M.MODEL_ID;
                Mo.Model_Name = M.Model_Name;
                Mo.MARK_ID = M.MARK_ID;
                Mo.Comment = M.Comment;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MODELs where l.Deleted == "False"
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
                var obj = (from M in con.MODELs
                           where M.Deleted == "False" &&
                       ( M.Model_Name.StartsWith(SearchText) ||
                       M.MARK.Mark_Name.StartsWith(SearchText))

                           select new
                           {
                               MODEL_ID = M.MODEL_ID,
                               MARK_ID = M.MARK.Mark_Name,
                               Model_Name = M.Model_Name,
                               Comment = M.Comment
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY METHOD MARK
        public void DisplayMark(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MARKs where M.Deleted == "False"

                           select new
                           {
                               MARK_ID = M.MARK_ID,
                               Mark_Name = M.Mark_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MARK_ID";
                drop.DataTextField = "Mark_Name";
                drop.DataBind();
            }

        }

    }
}