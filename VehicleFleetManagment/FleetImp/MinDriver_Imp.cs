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
    public class MinDriver_Imp: MinDriver_Interface
    {

        int msg;
        MINISTRY_DRIVER M = new MINISTRY_DRIVER();
        VEHICLE V = new VEHICLE();
        DRIVER D = new DRIVER();

        //ADD METHOD
        public int Add(MinDriver_Class Md)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M.DRIVER_ID = Md.DRIVER_ID;
                M.Min_Driver_RegNumber  = Md.Min_Driver_RegNumber ;
                M.Swaped_Vehicle  = Md.Swaped_Vehicle ;
                M.MINISTRY_ID = Md.MINISTRY_ID;
                M.Position_Status = Md.Position_Status;
                M.StartDate = Md.StartDate;
                M.EndDate = Md.EndDate;

                con.MINISTRY_DRIVER.Add(M);

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

        public int DrivingLicenceValidation( int driver,string regNumber)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                LICENSE L = new LICENSE();
                VEHICLE V = new VEHICLE();
                L = con.LICENSEs.Where(x => x.DRIVER_ID == driver).FirstOrDefault();
                V = con.VEHICLEs.Where(x => x.Local_Plate == regNumber).FirstOrDefault();

                if (L != null && V != null)
                {
                    if (L.Category_B == "Yes" && V.Trailer == "Compact Car") { return msg = 1; }
                    else if (L.Category_C == "Yes" && ( V.Trailer == "Compact Car" || V.Trailer == "small lorry truck")) { return msg = 1; }
                    else if (L.Category_D1 == "Yes" && (V.Trailer == "Compact Car" || V.Trailer == "small lorry truck" || V.Trailer == "Van")) { return msg = 1; }
                    else if ( L.Category_D2 == "Yes" && ( V.Trailer == "Compact Car" || V.Trailer == "small lorry truck" || V.Trailer == "Van" || V.Trailer == "Bus")) { return msg = 1; }
                    else if ( L.Category_E == "Yes" && (V.Trailer == "Compact Car" || V.Trailer == "small lorry truck" || V.Trailer == "Van" || V.Trailer == "Bus" || V.Trailer == "Trailer")) { return msg = 1; }
                    else if ( L.Category_F == "Yes" && (V.Trailer == "Compact Car" || V.Trailer == "small lorry truck" || V.Trailer == "Van" || V.Trailer == "Bus" || V.Trailer == "Trailer" || V.Trailer == "Tractor")) { return msg = 1; } else { return msg = 0; }

                }
                else return msg = 0;

            }
        }

        //UPDATE METHOD
        public int Update(MinDriver_Class Md, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                MINISTRY_DRIVER M = new MINISTRY_DRIVER();
                M = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id).FirstOrDefault();

                if (M != null)
                {

                    M.DRIVER_ID = Md.DRIVER_ID;
                    M.Min_Driver_RegNumber  = Md.Min_Driver_RegNumber ;
                    M.Swaped_Vehicle  = Md.Swaped_Vehicle ;
                    M.MINISTRY_ID = Md.MINISTRY_ID;
                    M.Position_Status = Md.Position_Status;

                    if (con.SaveChanges() > 0)
                    {
                        con.MINISTRY_DRIVER.Add(M);
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
                var obj = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.MINISTRY_DRIVER.Attach(obj);

                }
                con.MINISTRY_DRIVER.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DISPLAY METHOD
        public void Display(GridView gd, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_DRIVER where M.MINISTRY.Code_Min ==codeMin.Trim()
                           orderby M.MIN_DRIVER_ID descending

                           select new
                           {
                               MIN_DRIVER_ID = M.MIN_DRIVER_ID,
                               DRIVER_ID = M.DRIVER.Full_Name,
                               Min_Driver_RegNumber = M.Min_Driver_RegNumber,
                               Swaped_Vehicle = M.Swaped_Vehicle,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name,
                               StartDate = M.StartDate,
                               EndDate = M.EndDate,
                               Position_Status = M.Position_Status,
                               Picture= M.DRIVER.Picture
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY All METHOD
        public void DisplayAll(GridView gd)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_DRIVER
                           orderby M.MIN_DRIVER_ID descending
                           select new
                           {
                               MIN_DRIVER_ID = M.MIN_DRIVER_ID,
                               DRIVER_ID = M.DRIVER.Full_Name,
                               Min_Driver_RegNumber = M.Min_Driver_RegNumber,
                               Swaped_Vehicle = M.Swaped_Vehicle,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name,
                               StartDate = M.StartDate,
                               EndDate = M.EndDate,
                               Position_Status = M.Position_Status
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(MinDriver_Class Md, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                M = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id).FirstOrDefault();

                Md.DRIVER_ID = M.DRIVER_ID;
                Md.Min_Driver_RegNumber  = M.Min_Driver_RegNumber ;
                Md.MINISTRY_ID = M.MINISTRY_ID;
                Md.Position_Status = M.Position_Status;
                // Md.Saved_Date = M.Saved_Date;

            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MINISTRY_DRIVER where l.MINISTRY.Code_Min == codeMin
                         select l).Count();
                n = M;
            }
            return n;
        }

        //COUNT ON POST POSITION METHOD
        public int countOnPost(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MINISTRY_DRIVER
                         where l.MINISTRY.Code_Min == codeMin && l.Position_Status=="On Post"
                         select l).Count();
                n = M;
            }
            return n;
        }

        //COUNT All METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var M = (from l in con.MINISTRY_DRIVER
                         select l).Count();
                n = M;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_DRIVER
                           where M.MINISTRY.Code_Min== codeMin &&
                           (M.Min_Driver_RegNumber ).ToString().StartsWith(SearchText) ||
                           M.DRIVER.Full_Name.StartsWith(SearchText) ||
                           M.StartDate.StartsWith(SearchText) ||
                           M.EndDate.StartsWith(SearchText) ||
                           M.Position_Status.StartsWith(SearchText) ||
                           M.DRIVER.Full_Name.StartsWith(SearchText) 
                           select new
                           {
                               MIN_DRIVER_ID = M.MIN_DRIVER_ID,
                               DRIVER_ID = M.DRIVER.Full_Name,
                               Min_Driver_RegNumber = M.Min_Driver_RegNumber,
                               Swaped_Vehicle = M.Swaped_Vehicle,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name,
                               StartDate = M.StartDate,
                               EndDate = M.EndDate,
                               Position_Status = M.Position_Status

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //REASEARCH All METHOD
        public void ResearchAll(GridView gd,string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRY_DRIVER
                           where 
                           (M.Min_Driver_RegNumber).ToString().StartsWith(SearchText) ||
                           M.DRIVER.Full_Name.StartsWith(SearchText) ||
                           M.StartDate.StartsWith(SearchText) ||
                           M.EndDate.StartsWith(SearchText) ||
                           M.DRIVER.Full_Name.StartsWith(SearchText)
                           select new
                           {
                               MIN_DRIVER_ID = M.MIN_DRIVER_ID,
                               DRIVER_ID = M.DRIVER.Full_Name,
                               Min_Driver_RegNumber = M.Min_Driver_RegNumber,
                               Swaped_Vehicle = M.Swaped_Vehicle,
                               MINISTRY_ID = M.MINISTRY.Ministry_Name,
                               StartDate = M.StartDate,
                               EndDate = M.EndDate,
                               Position_Status = M.Position_Status

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }


        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies where M.Code_Min== codeMin

                           select new
                           {
                               MINISTRY_ID = M.MINISTRY_ID,
                               Ministry_Name= M.Ministry_Name,
                               Code_Min = codeMin,
                               
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

        //DISPLAY  All MINISTRY METHOD
        public void DisplayMinistryAll(DropDownList drop)
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

        //DISPLAY VEHICLE DEPENDS ON MINISTRY CHOOSEN IN AUTOPOSTBACK METHOD
        public void DisplayVehicle(DropDownList drop,int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs where V.MINISTRY_ID==id && V.Stat == "Available"

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Local_Plate = V.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Local_Plate";
                drop.DataBind();
            }

        }

        //DISPLAY  ALL VEHICLE FOR SPECIFIC MINISTRY BASED ON CODE MINISTRY METHOD()
        public void DisplayAllMinVehicle(DropDownList drop,string codeMin,int idMinDr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.MINISTRY_DRIVER where V.MINISTRY.Code_Min==codeMin && V.MIN_DRIVER_ID== idMinDr

                           select new
                           {
                               Min_Driver_RegNumber = V.Min_Driver_RegNumber,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Min_Driver_RegNumber";
                drop.DataBind();
            }

        }

        //DISPLAY  ALL VEHICLE METHOD
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
                drop.DataValueField = "Local_Plate";
                drop.DataBind();
            }

        }
        //UPDATE VEHICLE VAILABLE STATE METHOD
        public int UpdateVehAvailable(string LocalPlate)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                VEHICLE V = new VEHICLE();
                V = con.VEHICLEs.Where(x => x.Local_Plate == LocalPlate).FirstOrDefault();

                if (V != null)
                {
                    V.Stat = "Available";
                    if (con.SaveChanges() > 0)
                    {
                        con.VEHICLEs.Add(V);
                        con.Entry(V).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }

        //UPDATE VEHICLE UNVAILABLE STATE METHOD
        public int UpdateVehUnavailable( string LocalPlate)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                VEHICLE V = new VEHICLE();
                V = con.VEHICLEs.Where(x => x.Local_Plate == LocalPlate).FirstOrDefault();

                if (V != null)
                {
                    V.Stat = "Unavailable";
                    if (con.SaveChanges() > 0)
                    {
                        con.VEHICLEs.Add(V);
                        con.Entry(V).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }


        //UPDATE VEHICLE UNVAILABLE STATE METHOD
        //public int UpdateDriverVisibility(int id)
        //{
        //    using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
        //    {
        //        DRIVER V = new DRIVER();
        //        D = con.DRIVERs.Where(x => x.DRIVER_ID == id).FirstOrDefault();

        //        if (D != null)
        //        {
        //            MINISTRY_DRIVER M = new MINISTRY_DRIVER();
        //            M = con.MINISTRY_DRIVER.Where(x => x.DRIVER_ID == id).FirstOrDefault();

        //            if (M.Position_Status=="On Post" || M.Position_Status == "Swaped")
        //            {
        //            D.Visibility = "true";

        //            }
        //            else
        //            {
        //            D.Visibility = "false";
        //            }
        //            if (con.SaveChanges() > 0)
        //            {
        //                con.DRIVERs.Add(D);
        //                con.Entry(D).State = EntityState.Modified;

        //                msg = 1;
        //            }

        //            else
        //                msg = 0;
        //        }
        //    }


        //    return msg;
        //}

        //DISPLAY  Driver for specific Ministry METHOD
        public void DisplayDriver(DropDownList drop, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.DRIVERs where D.Ministry_Work== codeMin && D.State=="Work" && D.Visibility=="true"

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Full_Name = D.Full_Name 
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "DRIVER_ID";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }

        //DISPLAY All Driver for specific Ministry  METHOD 
        public void DisplayDriverMinAll(DropDownList drop,string codeMin,int idMinDr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.MINISTRY_DRIVER where D.MINISTRY.Code_Min == codeMin && D.MIN_DRIVER_ID == idMinDr

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Full_Name = D.DRIVER.Full_Name
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "DRIVER_ID";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }

        //DISPLAY  All Driver METHOD
        public void DisplayDriverAll(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from D in con.DRIVERs

                           select new
                           {
                               DRIVER_ID = D.DRIVER_ID,
                               Full_Name = D.Full_Name
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "DRIVER_ID";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }

        //UPDATE Position
        int UpdatePositionState(int id, string swapedVeh)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                
                M = con.MINISTRY_DRIVER.Where(x => x.MIN_DRIVER_ID == id).FirstOrDefault();

                if (M != null)
                {
                    M.Position_Status = "Swaped";
                    M.Swaped_Vehicle = swapedVeh;
                    M.EndDate = DateTime.Today.ToShortDateString();
                    UpdateVehAvailable(M.Min_Driver_RegNumber);
                    if (con.SaveChanges() > 0)
                    {
                        con.MINISTRY_DRIVER.Add(M);
                        con.Entry(M).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }
      
        //CHECK LAST SAVED
        public int LastSaved(MinDriver_Class Md, int driver,string swapdVeh)
        {
            int id;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                 var M = con.MINISTRY_DRIVER.OrderByDescending(x => x.MIN_DRIVER_ID).Where(x => x.DRIVER_ID == driver).FirstOrDefault();

                if (M!=null)
                {
                    id = Convert.ToInt32(M.MIN_DRIVER_ID);

                    if(M.Position_Status=="On Post" || M.Position_Status == "Leave")
                    {
                        UpdatePositionState(id,swapdVeh);
                    }
                    
                        return msg = 1;

                }
                else
                {
                    return msg = 0;
                }

            }

        }

        //Auto swap driver When driver is fired but in case is not in leave and change vehicle state
       public int AutoSwap()
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {

                M = con.MINISTRY_DRIVER.Where(x => x.Position_Status=="On Post" && x.DRIVER.Ministry_Work==null).FirstOrDefault();

                if (M != null)
                {
                    M.Position_Status = "Fired";
                    M.EndDate = DateTime.Today.ToShortDateString();
                    UpdateVehAvailable(M.Min_Driver_RegNumber);
                    if (con.SaveChanges() > 0)
                    {
                        con.MINISTRY_DRIVER.Add(M);
                        con.Entry(M).State = EntityState.Modified;

                        msg = 1;
                    }

                    else
                        msg = 0;
                }
            }


            return msg;
        }



    }
}