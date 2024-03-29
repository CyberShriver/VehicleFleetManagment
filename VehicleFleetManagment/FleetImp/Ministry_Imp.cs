﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;

namespace VehicleFleetManagment.FleetImp
{
    public class Ministry_Imp : Ministry_Interface
    {

        int msg;
        MINISTRY M = new MINISTRY();

        //ADD METHOD
        public int Add( Ministry_Class Min)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M.Code_Min = Min.Code_Min;
                M.Ministry_Name = Min.Ministry_Name;
                M.Address = Min.Address;
                M.Phone = Min.Phone;
                M.Postal_code = Min.Postal_code;
                M.Fax = Min.Fax;
                M.ROLE_ID = Min.ROLE_ID;
                M.System_Name = Min.System_Name;
                M.System_Title = Min.System_Title;
                M.System_Email = Min.System_Email;
                M.Logo = Min.Logo;
                M.Slogan = Min.Slogan;
                M.Theme = Min.Theme;
                M.Picture = Min.Picture;
                M.Deleted = "False";
                

                con.MINISTRies.Add(M);

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
        public int Update( Ministry_Class Min, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MINISTRY M = new MINISTRY();
                M = con.MINISTRies.Where(x => x.MINISTRY_ID == id).FirstOrDefault();

                if (M != null)
                {

                    M.Code_Min = Min.Code_Min;
                    M.Ministry_Name = Min.Ministry_Name;
                    M.Address = Min.Address;
                    M.Phone = Min.Phone;
                    M.Postal_code = Min.Postal_code;
                    M.Fax = Min.Fax;
                    M.ROLE_ID = Min.ROLE_ID;
                    M.System_Name = Min.System_Name;
                    M.System_Title = Min.System_Title;
                    M.System_Email = Min.System_Email;
                    M.Logo = Min.Logo;
                    M.Picture = Min.Picture;
                    M.Theme = Min.Theme;
                    M.Slogan = Min.Slogan;
                    M.Deleted = "False";

                    if (con.SaveChanges() > 0)
                    {
                        con.MINISTRies.Add(M);
                        con.Entry(M).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //UPDATE SETTINGS METHOD
        public int UpdateSettings(Ministry_Class Min, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MINISTRY M = new MINISTRY();
                M = con.MINISTRies.Where(x => x.MINISTRY_ID == id).FirstOrDefault();

                if (M != null)
                {

                    M.System_Name = Min.System_Name;
                    M.System_Title = Min.System_Title;
                    M.System_Email = Min.System_Email;
                    //M.Password = Min.Password;
                    M.Logo = Min.Logo;
                    M.Theme = Min.Theme;
                    M.Slogan = Min.Slogan;
                    M.ROLE_ID = Min.ROLE_ID;

                    if (con.SaveChanges() > 0)
                    {
                        con.MINISTRies.Add(M);
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
                var obj = con.MINISTRies.Where(x => x.MINISTRY_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.MINISTRies.Attach(obj);

                }
                con.MINISTRies.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //CHANGE DELETE STATE METHOD
        public int DeleteState( int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MINISTRY M = new MINISTRY();
                M = con.MINISTRies.Where(x => x.MINISTRY_ID == id).FirstOrDefault();

                if (M != null)
                {
                    M.Deleted = "True";

                    if (con.SaveChanges() > 0)
                    {
                        con.MINISTRies.Add(M);
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
                var obj = (from M in con.MINISTRies where M.Deleted=="False"
                           orderby M.MINISTRY_ID descending
                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Code_Min = M.Code_Min,
                               Ministry_Name = M.Ministry_Name,
                               Address = M.Address,
                               Phone = M.Phone,
                               Postal_code = M.Postal_code,
                               Fax = M.Fax,
                               System_Name = M.System_Name,
                               System_Title = M.System_Title,
                               System_Email = M.System_Email,
                               Logo = M.Logo,
                               Picture = M.Picture,
                               Slogan = M.Slogan,
                               ROLE_ID = M.ROLE.Role_Name,
                               Theme = M.Theme
            }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide( Ministry_Class Min, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MINISTRies.Where(x => x.MINISTRY_ID == id).FirstOrDefault();

                Min.Code_Min = M.Code_Min;
                Min.Ministry_Name = M.Ministry_Name;
                Min.Address = M.Address;
                Min.Phone = M.Phone;
                Min.Postal_code = M.Postal_code;
                Min.Fax = M.Fax;
                Min.System_Name = M.System_Name;
                Min.System_Title = M.System_Title;
                Min.System_Email = M.System_Email;
                Min.Logo = M.Logo;
                Min.Theme = M.Theme;
                Min.Picture = M.Picture;
                Min.Slogan = M.Slogan;
                Min.ROLE_ID = M.ROLE_ID;

            }
        }

        //Profile METHOD
        public void Profile(Ministry_Class Min, string codeMin )
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MINISTRies.Where(x => x.Code_Min == codeMin).FirstOrDefault();

                Min.Code_Min = M.Code_Min;
                Min.Ministry_Name = M.Ministry_Name;
                Min.Address = M.Address;
                Min.Phone = M.Phone;
                Min.Postal_code = M.Postal_code;
                Min.Fax = M.Fax;
                Min.System_Name = M.System_Name;
                Min.System_Title = M.System_Title;
                Min.System_Email = M.System_Email;
                Min.Logo = M.Logo;
                Min.Picture = M.Picture;
                Min.Slogan = M.Slogan;
                Min.Theme = M.Theme;
                Min.ROLE_ID = M.ROLE_ID;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MINISTRies where l.Deleted == "False"
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
                var obj = (from M in con.MINISTRies
                           where M.Deleted == "False" &&
                      ( M.Ministry_Name.StartsWith(SearchText) ||
                       M.Address.StartsWith(SearchText) ||
                       M.Code_Min.StartsWith(SearchText))

                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Code_Min = M.Code_Min,
                               Ministry_Name = M.Ministry_Name,
                               Address = M.Address,
                               Phone = M.Phone,
                               Postal_code = M.Postal_code,
                               Fax = M.Fax,
                               System_Name = M.System_Name,
                               System_Title = M.System_Title,
                               System_Email = M.System_Email,
                               Logo = M.Logo,
                               Picture = M.Picture,
                               Slogan = M.Slogan,                               
                               ROLE_ID = M.ROLE.Role_Name,                               
                               Theme = M.Theme

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY  All MINISTRY DROPDOWN METHOD
        public void DisplayMinistryAll(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies
                           where M.Deleted == "False"

                           select new
                           {
                               Code_Min = M.Code_Min,
                               Ministry_Name = M.Ministry_Name,

                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Code_Min";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

    }
}