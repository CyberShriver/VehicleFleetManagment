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
                M.User_Nme = Min.User_Nme;
                M.Fax = Min.Fax;
                M.System_Name = Min.System_Name;
                M.System_Title = Min.System_Title;
                M.System_Email = Min.System_Email;
                M.Password = Min.Password;
                M.Logo = Min.Logo;
                

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
                    M.User_Nme = Min.User_Nme;
                    M.Fax = Min.Fax;
                    M.System_Name = Min.System_Name;
                    M.System_Title = Min.System_Title;
                    M.System_Email = Min.System_Email;
                    M.Password = Min.Password;
                    M.Logo = Min.Logo;

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

        //Login Connection METHOD
        public int Connexion(Ministry_Class Min, string userName, string password)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MINISTRies.Where(x => x.User_Nme == userName && x.Password == password).FirstOrDefault();

                if (M!= null)
                {
                    Min.Code_Min = M.Code_Min;
                    Min.Ministry_Name = M.Ministry_Name;
                    Min.Address = M.Address;
                    Min.Phone = M.Phone;
                    Min.Postal_code = M.Postal_code;
                    Min.User_Nme = M.User_Nme;
                    Min.Fax = M.Fax;
                    Min.System_Name = M.System_Name;
                    Min.System_Title = M.System_Title;
                    Min.System_Email = M.System_Email;
                    Min.Password = M.Password;
                    Min.Logo = M.Logo;

                    return msg = 1;
                }
                else return msg = 0;

            }
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
                        var obj = con.MINISTRies.Where(x => x.MINISTRY_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.MINISTRies.Attach(obj);


                        }
                        con.MINISTRies.Remove(obj);
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
                var obj = (from M in con.MINISTRies

                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Code_Min = M.Code_Min,
                               Ministry_Name = M.Ministry_Name,
                               Address = M.Address,
                               Phone = M.Phone,
                               Postal_code = M.Postal_code,
                               User_Nme = M.User_Nme,
                               Fax = M.Fax,
                               System_Name = M.System_Name,
                               System_Title = M.System_Title,
                               System_Email = M.System_Email,
                               Password = M.Password,
                               Logo = M.Logo
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
                Min.User_Nme = M.User_Nme;
                Min.Fax = M.Fax;
                Min.System_Name = M.System_Name;
                Min.System_Title = M.System_Title;
                Min.System_Email = M.System_Email;
                Min.Password = M.Password;
                Min.Logo = M.Logo;

            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MINISTRies
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
                           where
                       M.Ministry_Name.StartsWith(SearchText) ||
                       M.Address.StartsWith(SearchText) ||
                       M.Code_Min.StartsWith(SearchText)

                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Code_Min = M.Code_Min,
                               Ministry_Name = M.Ministry_Name,
                               Address = M.Address,
                               Phone = M.Phone,
                               Postal_code = M.Postal_code,
                               User_Nme = M.User_Nme,
                               Fax = M.Fax,
                               System_Name = M.System_Name,
                               System_Title = M.System_Title,
                               System_Email = M.System_Email,
                               Password = M.Password,
                               Logo = M.Logo

            }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

    }
}