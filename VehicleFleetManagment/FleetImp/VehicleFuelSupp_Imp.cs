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
    public class VehicleFuelSupp_Imp: VehicleFuelSupp_Interface
    {
        int msg;
        VEHICLE_FUEL_SUPPLY V = new VEHICLE_FUEL_SUPPLY();

        //ADD METHOD
        public int Add(VehicleFuelSup_Class Ve)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                V.Provider_Code = Ve.Provider_Code;
                V.VEHICLE_ID = Ve.VEHICLE_ID;
                V.MINISTRY_ID = Ve.MINISTRY_ID;
                V. Fuel_Type = Ve. Fuel_Type;
                V.Tank_Type = Ve.Tank_Type;
                V.Tank_Code  = Ve.Tank_Code ;
                V.Odometer  = Ve.Odometer ;
                V.Initial_Qty = Ve.Initial_Qty;
                V.Consumed_Qty    = Ve.Consumed_Qty   ;
                V.Fuel_Used    = Ve.Fuel_Used;
                V.United_Price  = Ve.United_Price ;
                V.Total_Price  = Ve.Total_Price ;
                V.Liter_100_km  = Ve.Liter_100_km ;
                V.Permission  = Ve.Permission;
                V.User_IP_Address  = Ve.User_IP_Address;
                V.Comment  = Ve.Comment ;
                V.Saved_Date  = Ve.Saved_Date ;              
                V.Deleted  ="False" ;              

                con.VEHICLE_FUEL_SUPPLY.Add(V);

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
        public int Update(VehicleFuelSup_Class Ve, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                VEHICLE_FUEL_SUPPLY V = new VEHICLE_FUEL_SUPPLY();
                V = con.VEHICLE_FUEL_SUPPLY.Where(x => x.VEHICLE_FUEL_ID  == id).FirstOrDefault();

                if (V != null)
                {

                    V.Provider_Code = Ve.Provider_Code;
                    V.VEHICLE_ID = Ve.VEHICLE_ID;
                    V.MINISTRY_ID = Ve.MINISTRY_ID;
                    V. Fuel_Type = Ve. Fuel_Type;
                    V.Tank_Type = Ve.Tank_Type;
                    V.Tank_Code  = Ve.Tank_Code ;
                    V.Odometer  = Ve.Odometer ;
                    V.Initial_Qty = Ve.Initial_Qty;
                    V.Fuel_Used = Ve.Fuel_Used;
                    V.Consumed_Qty    = Ve.Consumed_Qty   ;
                    V.United_Price  = Ve.United_Price ;
                    V.Total_Price  = Ve.Total_Price ;
                    V.Liter_100_km  = Ve.Liter_100_km ;
                    V.Permission = Ve.Permission;
                    V.User_IP_Address = Ve.User_IP_Address;
                    V.Comment  = Ve.Comment ;
                    V.Saved_Date  = Ve.Saved_Date ;
                    V.Deleted = "False";

                    if (con.SaveChanges() > 0)
                    {
                        con.VEHICLE_FUEL_SUPPLY.Add(V);
                        con.Entry(V).State = EntityState.Modified;

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
                var obj = con.VEHICLE_FUEL_SUPPLY.Where(x => x.VEHICLE_FUEL_ID  == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.VEHICLE_FUEL_SUPPLY.Attach(obj);

                }
                con.VEHICLE_FUEL_SUPPLY.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //Delete State METHOD
        public int DeleteState(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                VEHICLE_FUEL_SUPPLY V = new VEHICLE_FUEL_SUPPLY();
                V = con.VEHICLE_FUEL_SUPPLY.Where(x => x.VEHICLE_FUEL_ID == id).FirstOrDefault();

                if (V != null)
                {
                    V.Deleted = "True";

                    if (con.SaveChanges() > 0)
                    {
                        con.VEHICLE_FUEL_SUPPLY.Add(V);
                        con.Entry(V).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //DISPLAY METHOD
        public void Display(GridView gd,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLE_FUEL_SUPPLY where V.Deleted=="False" && V.MINISTRY.Code_Min== codeMin 
                           orderby V.VEHICLE_FUEL_ID descending

                           select new
                           {
                               VEHICLE_FUEL_ID  = V.VEHICLE_FUEL_ID ,
                               Provider_Code = V.Provider_Code,
                               VEHICLE_ID = V.VEHICLE.Local_Plate,
                               MINISTRY_ID = V.MINISTRY.Ministry_Name,
                                Fuel_Type = V. Fuel_Type,
                               Tank_Type = V.Tank_Type,
                               Tank_Code  = V.Tank_Code ,
                               Odometer  = V.Odometer ,
                               Fuel_Used = V.Fuel_Used ,
                               Initial_Qty = V.Initial_Qty,
                               Consumed_Qty    = V.Consumed_Qty   ,
                               United_Price  = V.United_Price ,
                               Total_Price  = V.Total_Price ,
                               Liter_100_km  = V.Liter_100_km ,
                               Comment  = V.Comment ,
                               Permission = V.Permission ,
                               User_IP_Address = V.User_IP_Address ,
                               Saved_Date  = V.Saved_Date ,
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }


        //DISPLAY ALL METHOD
        public void DisplayAll(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLE_FUEL_SUPPLY where V.Deleted == "False"
                           orderby V.VEHICLE_FUEL_ID descending
                           select new
                           {
                               VEHICLE_FUEL_ID = V.VEHICLE_FUEL_ID,
                               Provider_Code = V.Provider_Code,
                               VEHICLE_ID = V.VEHICLE.Local_Plate,
                               MINISTRY_ID = V.MINISTRY.Ministry_Name,
                               Fuel_Type = V.Fuel_Type,
                               Tank_Type = V.Tank_Type,
                               Tank_Code = V.Tank_Code,
                               Odometer = V.Odometer,
                               Fuel_Used = V.Fuel_Used,
                               Initial_Qty = V.Initial_Qty,
                               Consumed_Qty = V.Consumed_Qty,
                               United_Price = V.United_Price,
                               Total_Price = V.Total_Price,
                               Liter_100_km = V.Liter_100_km,
                               Permission = V.Permission,
                               User_IP_Address = V.User_IP_Address,
                               Comment = V.Comment,
                               Saved_Date = V.Saved_Date,
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(VehicleFuelSup_Class Ve, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                V = con.VEHICLE_FUEL_SUPPLY.Where(x => x.VEHICLE_FUEL_ID  == id).FirstOrDefault();

                Ve.Provider_Code = V.Provider_Code;
                Ve.VEHICLE_ID = V.VEHICLE_ID;
                Ve.MINISTRY_ID = V.MINISTRY_ID;
                Ve. Fuel_Type = V. Fuel_Type;
                Ve.Tank_Type = V.Tank_Type;
                Ve.Tank_Code  = V.Tank_Code ;
                Ve.Odometer  = V.Odometer ;
                Ve.Initial_Qty = V.Initial_Qty;
                Ve.Consumed_Qty    = V.Consumed_Qty   ;
                Ve.Fuel_Used = V.Fuel_Used   ;
                Ve.United_Price  = V.United_Price ;
                Ve.Total_Price  = V.Total_Price ;
                Ve.Liter_100_km  = V.Liter_100_km ;
                Ve.Permission  = V.Permission ;
                Ve.User_IP_Address  = V.User_IP_Address ;
                Ve.Comment  = V.Comment ;
                Ve.Saved_Date  = V.Saved_Date ;

            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var V = (from l in con.VEHICLE_FUEL_SUPPLY where l.Deleted == "False" && l.MINISTRY.Code_Min==codeMin
                         select l).Count();
                n = V;
            }
            return n;
        }

        //COUNT ALL METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var V = (from l in con.VEHICLE_FUEL_SUPPLY where l.Deleted == "False"
                         select l).Count();
                n = V;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd,string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLE_FUEL_SUPPLY
                           where V.Deleted == "False" && V.MINISTRY.Code_Min== codeMin &&
                       (V.Provider_Code.StartsWith(SearchText) ||
                        V.VEHICLE.Local_Plate.StartsWith(SearchText) ||
                       V.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                       V.Fuel_Type.StartsWith(SearchText))

                           select new
                           {
                               VEHICLE_FUEL_ID = V.VEHICLE_FUEL_ID,
                               Provider_Code = V.Provider_Code,
                               VEHICLE_ID = V.VEHICLE.Local_Plate,
                               MINISTRY_ID = V.MINISTRY.Ministry_Name,
                               Fuel_Type = V.Fuel_Type,
                               Tank_Type = V.Tank_Type,
                               Tank_Code = V.Tank_Code,
                               Odometer = V.Odometer,
                               Fuel_Used = V.Fuel_Used,
                               Initial_Qty = V.Initial_Qty,
                               Consumed_Qty = V.Consumed_Qty,
                               United_Price = V.United_Price,
                               Total_Price = V.Total_Price,
                               Liter_100_km = V.Liter_100_km,
                               Permission = V.Permission,
                               User_IP_Address = V.User_IP_Address,
                               Comment = V.Comment,
                               Saved_Date = V.Saved_Date

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //REASEARCH ALL METHOD
        public void ResearchAll(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLE_FUEL_SUPPLY
                           where V.Deleted == "False" &&
                       (V.Provider_Code.StartsWith(SearchText) ||
                        V.VEHICLE.Local_Plate.StartsWith(SearchText) ||
                       V.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                       V.Fuel_Type.StartsWith(SearchText))

                           select new
                           {
                               VEHICLE_FUEL_ID = V.VEHICLE_FUEL_ID,
                               Provider_Code = V.Provider_Code,
                               VEHICLE_ID = V.VEHICLE.Local_Plate,
                               MINISTRY_ID = V.MINISTRY.Ministry_Name,
                               Fuel_Type = V.Fuel_Type,
                               Tank_Type = V.Tank_Type,
                               Tank_Code = V.Tank_Code,
                               Odometer = V.Odometer,
                               Fuel_Used = V.Fuel_Used,
                               Initial_Qty = V.Initial_Qty,
                               Consumed_Qty = V.Consumed_Qty,
                               United_Price = V.United_Price,
                               Total_Price = V.Total_Price,
                               Liter_100_km = V.Liter_100_km,
                               Permission = V.Permission,
                               User_IP_Address = V.User_IP_Address,
                               Comment = V.Comment,
                               Saved_Date = V.Saved_Date

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }


        //DISPLAY METHOD MINISTRY IN DROPDOWN
        public void DisplayMinistry(DropDownList drop,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies where M.Deleted == "False" &&  M.Code_Min==codeMin

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

        //DISPLAY METHOD ALL MINISTRY IN DROPDOWN
        public void DisplayMinistryAll(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies where M.Deleted == "False"

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


        //DISPLAY ALL VEHICLE
        public void DisplayAllVehicle(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs where V.Deleted == "False"

                           select new
                           {
                               VEHICLE_ID =V.VEHICLE_ID,
                               Local_Plate = V.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "VEHICLE_ID";
                drop.DataTextField = "Local_Plate";
                drop.DataBind();
            }

        }

        //DISPLAY  VEHICLE FOR SPECIFIC MINISTRY
        public void DisplayVehicle(DropDownList drop, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs where V.Deleted == "False" && V.MINISTRY.Code_Min== codeMin

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Local_Plate = V.Local_Plate
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "VEHICLE_ID";
                drop.DataTextField = "Local_Plate";
                drop.DataBind();
            }

        }

        //DISPLAY  VEHICLE TANK CAPACITY
            public void DisplayVehicleTankCapacity(DropDownList drop, string Plate)
            {
                using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
                {
                    var obj = (from V in con.VEHICLEs
                               where V.Deleted == "False" && V.Local_Plate == Plate

                               select new
                               {
                                   Tank_Capacity2 = V.Tank_Capacity2
                               }
                               ).ToList();

                    drop.DataSource = obj;
                    drop.DataValueField = "Tank_Capacity2";
                    drop.DataBind();
                }

            }

        

        //Provider
        public void DisplayProvider(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from P in con.PROVIDERs where P.Deleted == "False"

                           select new
                           {
                               Provider_Code = P.Provider_Code,
                               Full_Name = P.Full_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Provider_Code";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }

        //DISPLAY  Fuel Type Consumed By This Vehicle
        public void DisplayFuelType(DropDownList drop, string Plate)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs
                           where V.Deleted == "False" && V.Local_Plate== Plate

                           select new
                           {
                               Fuel_Fype = V.Fuel_Fype
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Fuel_Fype";
                drop.DataBind();
            }

        }

        //DISPLAY   Vehicle category
        public void DisplayVehicleCategory(DropDownList drop, string Plate)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs
                           where V.Deleted == "False" && V.Local_Plate == Plate

                           select new
                           {
                               Trailer = V.Trailer
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Trailer";
                drop.DataBind();
            }

        }

    }
}