﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using VehicleFleetManagment.FleetClass;
using VehicleFleetManagment.FleetModel;
using System.Data.Entity;

namespace VehicleFleetManagment.FleetImp
{
    public class Assurance_Imp: Assurance_Interface
    {

        int msg;
        ASSURANCE A = new ASSURANCE();

        //ADD METHOD
        public int Add(Assurance_Class As)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                A.Maintenance_Type  = As.Maintenance_Type ;
                A.Insurance_Policy  = As.Insurance_Policy ;
                A.Insurance_Start_Date  = As.Insurance_Start_Date ;
                A.Local_Insurance_Exp_Date  = As.Local_Insurance_Exp_Date ;
                A.Amount = As.Amount;
                A.Insurance_Company = As.Insurance_Company;
                A.Comment = As.Comment;
                A.Insurance_State = As.Insurance_State;
                A.MINISTRY_ID = As.MINISTRY_ID;
                A.VEHICLE_ID = As.VEHICLE_ID;

                con.ASSURANCEs.Add(A);

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
        public int Update(Assurance_Class As, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                ASSURANCE A = new ASSURANCE();
                A = con.ASSURANCEs.Where(x => x.ASSURANCE_ID  == id).FirstOrDefault();

                if (A != null)
                {

                    A.Maintenance_Type  = As.Maintenance_Type ;
                    A.Insurance_Policy  = As.Insurance_Policy ;
                    A.Insurance_Start_Date  = As.Insurance_Start_Date ;
                    A.Local_Insurance_Exp_Date  = As.Local_Insurance_Exp_Date ;
                    A.Amount = As.Amount;
                    A.Insurance_Company = As.Insurance_Company;
                    A.Comment = As.Comment;
                    A.Insurance_State = As.Insurance_State;
                    A.MINISTRY_ID = As.MINISTRY_ID;
                    A.VEHICLE_ID = As.VEHICLE_ID;

                    if (con.SaveChanges() > 0)
                    {
                        con.ASSURANCEs.Add(A);
                        con.Entry(A).State = EntityState.Modified;

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
                var obj = con.ASSURANCEs.Where(x => x.ASSURANCE_ID  == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.ASSURANCEs.Attach(obj);

                }
                con.ASSURANCEs.Remove(obj);
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
                        var obj = con.ASSURANCEs.Where(x => x.ASSURANCE_ID  == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.ASSURANCEs.Attach(obj);


                        }
                        con.ASSURANCEs.Remove(obj);
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
                var obj = (from A in con.ASSURANCEs

                           select new
                           {
                               ASSURANCE_ID  = A.ASSURANCE_ID ,
                               Maintenance_Type  = A.Maintenance_Type ,
                               Insurance_Policy  = A.Insurance_Policy ,
                               Insurance_Start_Date  = A.Insurance_Start_Date ,
                               Local_Insurance_Exp_Date  = A.Local_Insurance_Exp_Date ,
                               Amount = A.Amount ,
                               Insurance_Company = A.Insurance_Company ,
                               Insurance_State = A.Insurance_State ,
                               Comment = A.Comment ,
                               VEHICLE_ID = A.VEHICLE.Local_Plate,
                               MINISTRY_ID = A.MINISTRY.Ministry_Name

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Assurance_Class As, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                A = con.ASSURANCEs.Where(x => x.ASSURANCE_ID  == id).FirstOrDefault();

                As.Maintenance_Type  = A.Maintenance_Type ;
                As.Insurance_Policy  = A.Insurance_Policy ;
                As.Insurance_Start_Date  = A.Insurance_Start_Date ;
                As.Local_Insurance_Exp_Date  = A.Local_Insurance_Exp_Date ;
                As.Amount = A.Amount ;
                As.Comment = A.Comment ;
                As.Insurance_State = A.Insurance_State ;
                As.Insurance_Company = A.Insurance_Company ;
                As.VEHICLE_ID = A.VEHICLE_ID;
                As.MINISTRY_ID = A.MINISTRY_ID;



            }
        }

        //COUNT METHOD
        public int count()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var A = (from l in con.ASSURANCEs
                         select l).Count();
                n = A;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from A in con.ASSURANCEs
                           where
                       A.Insurance_Policy  == SearchText ||
                       A.Maintenance_Type  == SearchText ||
                       A.Insurance_Start_Date .ToString() == SearchText ||
                       A.VEHICLE_ID.ToString() == SearchText

                           select new
                           {
                               ASSURANCE_ID = A.ASSURANCE_ID,
                               Maintenance_Type = A.Maintenance_Type,
                               Insurance_Policy = A.Insurance_Policy,
                               Insurance_Start_Date = A.Insurance_Start_Date,
                               Local_Insurance_Exp_Date = A.Local_Insurance_Exp_Date,
                               Amount = A.Amount,
                               Insurance_Company = A.Insurance_Company,
                               Insurance_State = A.Insurance_State,
                               Comment = A.Comment,
                               VEHICLE_ID = A.VEHICLE.Local_Plate,
                               MINISTRY_ID = A.MINISTRY.Ministry_Name

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY METHOD ALL VEHICLE
        public void DisplayAllVehicle(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Local_Plate = V.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Local_Plate";
                drop.DataValueField = "VEHICLE_ID";
                drop.DataBind();
            }

        }


        //DISPLAY METHOD VEHICLE
        public void DisplayVehicle(DropDownList drop, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs
                           where V.MINISTRY_ID == id

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Local_Plate = V.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Local_Plate";
                drop.DataValueField = "VEHICLE_ID";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from A in con.MINISTRies

                           select new
                           {
                               MINISTRY_ID = A.MINISTRY_ID,
                               Ministry_Name = A.Ministry_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

    }
}