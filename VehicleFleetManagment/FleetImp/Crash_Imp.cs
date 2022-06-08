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
    public class Crash_Imp: Crash_Interface
    {


        int msg;
        CAR_CRASH C = new CAR_CRASH();

        //ADD METHOD
        public int Add(CarCrash_Class cr)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                C.Crash_Code  = cr.Crash_Code ;
                C.Local_Plate = cr.Local_Plate;
                C.Crash_Date  = cr.Crash_Date ;
                C.Crash_Time  = cr.Crash_Time ;
                C.MINISTRY_ID = cr.MINISTRY_ID;
                C.Crash_Mileage  = cr.Crash_Mileage ;
                C.MIN_DRIVER_ID  = cr.MIN_DRIVER_ID ;
                C.Compensation_Rule_Dte  = cr.Compensation_Rule_Dte ;
                C.Circumstance  = cr.Circumstance ;
                C.Passenger_Comment  = cr.Passenger_Comment ;
                C.Crash_Place  = cr.Crash_Place ;
                C.Full_Crash_Address  = cr.Full_Crash_Address ;
                C.Crash_Info  = cr.Crash_Info ;
                C.Responsible  = cr.Responsible ;
                C.Crash_Reason  = cr.Crash_Reason ;
                C.Weather  = cr.Weather ;
                C.Estimated_Speed  = cr.Estimated_Speed ;
                C.Condition_After_Crash  = cr.Condition_After_Crash ;
                C.Tot_Number_Driver_drives  = cr.Tot_Number_Driver_drives ;
                C.Crash_Damage  = cr.Crash_Damage ;
                C.Insurance_Declaration_Dte  = cr.Insurance_Declaration_Dte ;
                C.Report_Dte  = cr.Report_Dte ;
                C.Final_Report_Dte  = cr.Final_Report_Dte ;
                C.Damage_Description  = cr.Damage_Description ;
                C.Damage_Third_Party  = cr.Damage_Third_Party ;
                C.Claim_Compensation_Amount  = cr.Claim_Compensation_Amount ;
                C.Damaged_Vehicle  = cr.Damaged_Vehicle ;
                C.Legal_Cost  = cr.Legal_Cost ;
                C.Third_Party_Injures  = cr.Third_Party_Injures ;
                C.Injures_Employee  = cr.Injures_Employee ;
                C.Local_Insurance_Compensation_Amount  = cr.Local_Insurance_Compensation_Amount ;
                C.Payed_Employee  = cr.Payed_Employee ;
                C.Employee_Amount_Recovered  = cr.Employee_Amount_Recovered ;
                C.ThirdParty_Amount_Recovered  = cr.ThirdParty_Amount_Recovered ;
                C.Crash_Pic  = cr.Crash_Pic ;
                C.Saved_Date  = cr.Saved_Date ;
                C.Stat  = cr.Stat ;
                


                con.CAR_CRASH.Add(C);

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
        public int Update(CarCrash_Class cr, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                CAR_CRASH C = new CAR_CRASH();
                C = con.CAR_CRASH.Where(x => x.CAR_CRASH_ID == id).FirstOrDefault();

                if (C != null)
                {

                    C.Crash_Code  = cr.Crash_Code ;
                    C.Local_Plate = cr.Local_Plate;
                    C.Crash_Date  = cr.Crash_Date ;
                    C.Crash_Time  = cr.Crash_Time ;
                    C.MINISTRY_ID = cr.MINISTRY_ID;
                    C.Crash_Mileage  = cr.Crash_Mileage ;
                    C.MIN_DRIVER_ID  = cr.MIN_DRIVER_ID ;
                    C.Compensation_Rule_Dte  = cr.Compensation_Rule_Dte ;
                    C.Circumstance  = cr.Circumstance ;
                    C.Passenger_Comment  = cr.Passenger_Comment ;
                    C.Crash_Place  = cr.Crash_Place ;
                    C.Full_Crash_Address  = cr.Full_Crash_Address ;
                    C.Crash_Info  = cr.Crash_Info ;
                    C.Responsible  = cr.Responsible ;
                    C.Crash_Reason  = cr.Crash_Reason ;
                    C.Weather  = cr.Weather ;
                    C.Estimated_Speed  = cr.Estimated_Speed ;
                    C.Condition_After_Crash  = cr.Condition_After_Crash ;
                    C.Tot_Number_Driver_drives  = cr.Tot_Number_Driver_drives ;
                    C.Crash_Damage  = cr.Crash_Damage ;
                    C.Insurance_Declaration_Dte  = cr.Insurance_Declaration_Dte ;
                    C.Report_Dte  = cr.Report_Dte ;
                    C.Final_Report_Dte  = cr.Final_Report_Dte ;
                    C.Damage_Description  = cr.Damage_Description ;
                    C.Damage_Third_Party  = cr.Damage_Third_Party ;
                    C.Claim_Compensation_Amount  = cr.Claim_Compensation_Amount ;
                    C.Damaged_Vehicle  = cr.Damaged_Vehicle ;
                    C.Legal_Cost  = cr.Legal_Cost ;
                    C.Third_Party_Injures  = cr.Third_Party_Injures ;
                    C.Injures_Employee  = cr.Injures_Employee ;
                    C.Local_Insurance_Compensation_Amount  = cr.Local_Insurance_Compensation_Amount ;
                    C.Payed_Employee  = cr.Payed_Employee ;
                    C.Employee_Amount_Recovered  = cr.Employee_Amount_Recovered ;
                    C.ThirdParty_Amount_Recovered  = cr.ThirdParty_Amount_Recovered ;
                    C.Crash_Pic  = cr.Crash_Pic ;
                    C.Saved_Date  = cr.Saved_Date ;
                    C.Stat  = cr.Stat ;
                   

                    if (con.SaveChanges() > 0)
                    {
                        con.CAR_CRASH.Add(C);
                        con.Entry(C).State = EntityState.Modified;

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
                var obj = con.CAR_CRASH.Where(x => x.CAR_CRASH_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.CAR_CRASH.Attach(obj);

                }
                con.CAR_CRASH.Remove(obj);
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
                        var obj = con.CAR_CRASH.Where(x => x.CAR_CRASH_ID == id).First();

                        if (con.Entry(obj).State == EntityState.Detached)
                        {
                            con.CAR_CRASH.Attach(obj);


                        }
                        con.CAR_CRASH.Remove(obj);
                        con.SaveChanges();
                    }
                }
                return msg;
            }

        }


        //DISPLAY METHOD
        public void Display(GridView gd,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from C in con.CAR_CRASH where C.MINISTRY.Code_Min==codeMin

                           select new
                           {
                               CAR_CRASH_ID = C.CAR_CRASH_ID,
                               Crash_Code = C.Crash_Code,
                               Local_Plate = C.Local_Plate,
                               Crash_Date = C.Crash_Date,
                               Crash_Time = C.Crash_Time,
                               MINISTRY_ID = C.MINISTRY.Ministry_Name,
                               Crash_Mileage = C.Crash_Mileage,
                               MIN_DRIVER_ID = C.MINISTRY_DRIVER.DRIVER.Full_Name,
                               Compensation_Rule_Dte = C.Compensation_Rule_Dte,
                               Circumstance = C.Circumstance,
                               Passenger_Comment = C.Passenger_Comment,
                               Crash_Place = C.Crash_Place,
                               Full_Crash_Address = C.Full_Crash_Address,
                               Crash_Info = C.Crash_Info,
                               Responsible = C.Responsible,
                               Crash_Reason = C.Crash_Reason,
                               Estimated_Speed= C.Estimated_Speed,
                               Weather = C.Weather,
                               Condition_After_Crash = C.Condition_After_Crash,
                               Tot_Number_Driver_drives = C.Tot_Number_Driver_drives,
                               Crash_Damage = C.Crash_Damage,
                               Insurance_Declaration_Dte = C.Insurance_Declaration_Dte,
                               Report_Dte = C.Report_Dte,
                               Final_Report_Dte = C.Final_Report_Dte,
                               Damage_Description = C.Damage_Description,
                               Damage_Third_Party = C.Damage_Third_Party,
                               Claim_Compensation_Amount = C.Claim_Compensation_Amount,
                               Damaged_Vehicle = C.Damaged_Vehicle,
                               Legal_Cost = C.Legal_Cost,
                               Third_Party_Injures = C.Third_Party_Injures,
                               Injures_Employee = C.Injures_Employee,
                               Local_Insurance_Compensation_Amount = C.Local_Insurance_Compensation_Amount,
                               Payed_Employee = C.Payed_Employee,
                               Employee_Amount_Recovered = C.Employee_Amount_Recovered,
                               ThirdParty_Amount_Recovered = C.ThirdParty_Amount_Recovered,
                               Crash_Pic = C.Crash_Pic,
                               Saved_Date = C.Saved_Date,
                               Stat = C.Stat,

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
                var obj = (from C in con.CAR_CRASH

                           select new
                           {
                               CAR_CRASH_ID = C.CAR_CRASH_ID,
                               Crash_Code = C.Crash_Code,
                               Local_Plate = C.Local_Plate,
                               Crash_Date = C.Crash_Date,
                               Crash_Time = C.Crash_Time,
                               MINISTRY_ID = C.MINISTRY.Ministry_Name,
                               Crash_Mileage = C.Crash_Mileage,
                               MIN_DRIVER_ID = C.MINISTRY_DRIVER.DRIVER.Full_Name,
                               Compensation_Rule_Dte = C.Compensation_Rule_Dte,
                               Circumstance = C.Circumstance,
                               Passenger_Comment = C.Passenger_Comment,
                               Crash_Place = C.Crash_Place,
                               Full_Crash_Address = C.Full_Crash_Address,
                               Crash_Info = C.Crash_Info,
                               Responsible = C.Responsible,
                               Crash_Reason = C.Crash_Reason,
                               Estimated_Speed = C.Estimated_Speed,
                               Weather = C.Weather,
                               Condition_After_Crash = C.Condition_After_Crash,
                               Tot_Number_Driver_drives = C.Tot_Number_Driver_drives,
                               Crash_Damage = C.Crash_Damage,
                               Insurance_Declaration_Dte = C.Insurance_Declaration_Dte,
                               Report_Dte = C.Report_Dte,
                               Final_Report_Dte = C.Final_Report_Dte,
                               Damage_Description = C.Damage_Description,
                               Damage_Third_Party = C.Damage_Third_Party,
                               Claim_Compensation_Amount = C.Claim_Compensation_Amount,
                               Damaged_Vehicle = C.Damaged_Vehicle,
                               Legal_Cost = C.Legal_Cost,
                               Third_Party_Injures = C.Third_Party_Injures,
                               Injures_Employee = C.Injures_Employee,
                               Local_Insurance_Compensation_Amount = C.Local_Insurance_Compensation_Amount,
                               Payed_Employee = C.Payed_Employee,
                               Employee_Amount_Recovered = C.Employee_Amount_Recovered,
                               ThirdParty_Amount_Recovered = C.ThirdParty_Amount_Recovered,
                               Crash_Pic = C.Crash_Pic,
                               Saved_Date = C.Saved_Date,
                               Stat = C.Stat,

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(CarCrash_Class cr, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                C = con.CAR_CRASH.Where(x => x.CAR_CRASH_ID == id).FirstOrDefault();

                cr.Crash_Code  = C.Crash_Code ;
                cr.Local_Plate = C.Local_Plate;
                cr.Crash_Date  = C.Crash_Date ;
                cr.Crash_Time  = C.Crash_Time ;
                cr.MINISTRY_ID = C.MINISTRY_ID;
                cr.Crash_Mileage  = C.Crash_Mileage ;
                cr.MIN_DRIVER_ID  = C.MIN_DRIVER_ID ;
                cr.Compensation_Rule_Dte  = C.Compensation_Rule_Dte ;
                cr.Circumstance  = C.Circumstance ;
                cr.Passenger_Comment  = C.Passenger_Comment ;
                cr.Crash_Place  = C.Crash_Place ;
                cr.Full_Crash_Address  = C.Full_Crash_Address ;
                cr.Crash_Info  = C.Crash_Info ;
                cr.Responsible  = C.Responsible ;
                cr.Crash_Reason  = C.Crash_Reason ;
                cr.Weather  = C.Weather ;
                cr.Estimated_Speed  = C.Estimated_Speed ;
                cr.Condition_After_Crash  = C.Condition_After_Crash ;
                cr.Tot_Number_Driver_drives  = C.Tot_Number_Driver_drives ;
                cr.Crash_Damage  = C.Crash_Damage ;
                cr.Insurance_Declaration_Dte  = C.Insurance_Declaration_Dte ;
                cr.Report_Dte  = C.Report_Dte ;
                cr.Final_Report_Dte  = C.Final_Report_Dte ;
                cr.Damage_Description  = C.Damage_Description ;
                cr.Damage_Third_Party  = C.Damage_Third_Party ;
                cr.Claim_Compensation_Amount  = C.Claim_Compensation_Amount ;
                cr.Damaged_Vehicle  = C.Damaged_Vehicle ;
                cr.Legal_Cost  = C.Legal_Cost ;
                cr.Third_Party_Injures  = C.Third_Party_Injures ;
                cr.Injures_Employee  = C.Injures_Employee ;
                cr.Local_Insurance_Compensation_Amount  = C.Local_Insurance_Compensation_Amount ;
                cr.Payed_Employee  = C.Payed_Employee ;
                cr.Employee_Amount_Recovered  = C.Employee_Amount_Recovered ;
                cr.ThirdParty_Amount_Recovered  = C.ThirdParty_Amount_Recovered ;
                cr.Crash_Pic  = C.Crash_Pic ;
                cr.Saved_Date  = C.Saved_Date ;
                cr.Stat  = C.Stat ;
              

            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var C = (from l in con.CAR_CRASH where l.MINISTRY.Code_Min==codeMin
                         select l).Count();
                n = C;
            }
            return n;
        }

        //COUNT ALL METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var C = (from l in con.CAR_CRASH
                         select l).Count();
                n = C;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd,string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from C in con.CAR_CRASH
                           where C.MINISTRY.Code_Min== codeMin &&
                       C.Local_Plate.StartsWith(SearchText) ||
                       C.Crash_Date.StartsWith(SearchText) ||
                       C.Crash_Time.StartsWith(SearchText) ||
                       C.Responsible.StartsWith(SearchText) ||
                       C.Crash_Place.StartsWith(SearchText) ||
                       C.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                       C.Report_Dte.StartsWith(SearchText) ||
                       C.MINISTRY_DRIVER.DRIVER.Full_Name.StartsWith(SearchText)

                           select new
                           {
                               CAR_CRASH_ID = C.CAR_CRASH_ID,
                               Crash_Code  = C.Crash_Code ,
                               Local_Plate = C.Local_Plate ,
                               Crash_Date  = C.Crash_Date ,
                               Crash_Time  = C.Crash_Time ,
                               MINISTRY_ID = C.MINISTRY.Ministry_Name,
                               Crash_Mileage  = C.Crash_Mileage ,
                               MIN_DRIVER_ID  = C.MINISTRY_DRIVER.DRIVER.Full_Name,
                               Compensation_Rule_Dte  = C.Compensation_Rule_Dte ,
                               Circumstance  = C.Circumstance ,
                               Passenger_Comment  = C.Passenger_Comment ,
                               Crash_Place  = C.Crash_Place ,
                               Full_Crash_Address  = C.Full_Crash_Address ,
                               Crash_Info  = C.Crash_Info ,
                               Responsible  = C.Responsible ,
                               Crash_Reason  = C.Crash_Reason ,
                               Estimated_Speed = C.Estimated_Speed,
                               Weather  = C.Weather ,
                               Condition_After_Crash  = C.Condition_After_Crash ,
                               Tot_Number_Driver_drives  = C.Tot_Number_Driver_drives ,
                               Crash_Damage  = C.Crash_Damage ,
                               Insurance_Declaration_Dte  = C.Insurance_Declaration_Dte ,
                               Report_Dte  = C.Report_Dte ,
                               Final_Report_Dte  = C.Final_Report_Dte ,
                               Damage_Description  = C.Damage_Description ,
                               Damage_Third_Party  = C.Damage_Third_Party ,
                               Claim_Compensation_Amount  = C.Claim_Compensation_Amount ,
                               Damaged_Vehicle  = C.Damaged_Vehicle ,
                               Legal_Cost  = C.Legal_Cost ,
                               Third_Party_Injures  = C.Third_Party_Injures ,
                               Injures_Employee  = C.Injures_Employee ,
                               Local_Insurance_Compensation_Amount  = C.Local_Insurance_Compensation_Amount ,
                               Payed_Employee  = C.Payed_Employee ,
                               Employee_Amount_Recovered  = C.Employee_Amount_Recovered ,
                               ThirdParty_Amount_Recovered  = C.ThirdParty_Amount_Recovered ,
                               Crash_Pic  = C.Crash_Pic ,
                               Saved_Date  = C.Saved_Date ,
                               Stat  = C.Stat ,
                              

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
                var obj = (from C in con.CAR_CRASH
                           where
                       C.Local_Plate.StartsWith(SearchText) ||
                       C.Crash_Date.StartsWith(SearchText) ||
                       C.Crash_Time.StartsWith(SearchText) ||
                       C.Responsible.StartsWith(SearchText) ||
                       C.Crash_Place.StartsWith(SearchText) ||
                       C.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                       C.Report_Dte.StartsWith(SearchText) ||
                       C.MINISTRY_DRIVER.DRIVER.Full_Name.StartsWith(SearchText)

                           select new
                           {
                               CAR_CRASH_ID = C.CAR_CRASH_ID,
                               Crash_Code = C.Crash_Code,
                               VEHICLE_ID = C.Local_Plate,
                               Crash_Date = C.Crash_Date,
                               Crash_Time = C.Crash_Time,
                               MINISTRY_ID = C.MINISTRY.Ministry_Name,
                               Crash_Mileage = C.Crash_Mileage,
                               MIN_DRIVER_ID = C.MINISTRY_DRIVER.DRIVER.Full_Name,
                               Compensation_Rule_Dte = C.Compensation_Rule_Dte,
                               Circumstance = C.Circumstance,
                               Passenger_Comment = C.Passenger_Comment,
                               Crash_Place = C.Crash_Place,
                               Full_Crash_Address = C.Full_Crash_Address,
                               Crash_Info = C.Crash_Info,
                               Responsible = C.Responsible,
                               Crash_Reason = C.Crash_Reason,
                               Estimated_Speed = C.Estimated_Speed,
                               Weather = C.Weather,
                               Condition_After_Crash = C.Condition_After_Crash,
                               Tot_Number_Driver_drives = C.Tot_Number_Driver_drives,
                               Crash_Damage = C.Crash_Damage,
                               Insurance_Declaration_Dte = C.Insurance_Declaration_Dte,
                               Report_Dte = C.Report_Dte,
                               Final_Report_Dte = C.Final_Report_Dte,
                               Damage_Description = C.Damage_Description,
                               Damage_Third_Party = C.Damage_Third_Party,
                               Claim_Compensation_Amount = C.Claim_Compensation_Amount,
                               Damaged_Vehicle = C.Damaged_Vehicle,
                               Legal_Cost = C.Legal_Cost,
                               Third_Party_Injures = C.Third_Party_Injures,
                               Injures_Employee = C.Injures_Employee,
                               Local_Insurance_Compensation_Amount = C.Local_Insurance_Compensation_Amount,
                               Payed_Employee = C.Payed_Employee,
                               Employee_Amount_Recovered = C.Employee_Amount_Recovered,
                               ThirdParty_Amount_Recovered = C.ThirdParty_Amount_Recovered,
                               Crash_Pic = C.Crash_Pic,
                               Saved_Date = C.Saved_Date,
                               Stat = C.Stat,


                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }
        //DISPLAY METHOD ALL Vehicle
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
                drop.DataValueField = "VEHICLE_ID ";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD ALL Driver
        public void DisplayAllDriver(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from Md in con.MINISTRY_DRIVER

                           select new
                           {
                               MIN_DRIVER_ID = Md.MIN_DRIVER_ID,
                               Full_Name = Md.DRIVER.Full_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Full_Name";
                drop.DataValueField = "MIN_DRIVER_ID";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD paticular Driver
        public void DisplayDriver(DropDownList drop,string plat)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from Md in con.MINISTRY_DRIVER
                           where Md.Position_Status=="On Post" && Md.Min_Driver_RegNumber== plat

                           select new
                           {
                               DRIVER_ID = Md.DRIVER_ID,
                               Full_Name = Md.DRIVER.Full_Name
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Full_Name";
                drop.DataValueField = "DRIVER_ID";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD paticular Vehicle
        public void DisplayVehicle(DropDownList drop, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from Md in con.MINISTRY_DRIVER
                           where Md.MINISTRY_ID == id && Md.Position_Status == "On Post" 
                           select new
                           {
                               Min_Driver_RegNumber = Md.Min_Driver_RegNumber
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Min_Driver_RegNumber";
                drop.DataBind();
            }


        }

        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies where M.Code_Min==codeMin

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

        //DISPLAY METHOD ALL MINISTRY
        public void DisplayMinistryAll(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.MINISTRies

                           select new
                           {
                               MINISTRY_ID = R.MINISTRY_ID,
                               Ministry_Name = R.Ministry_Name,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MINISTRY_ID";
                drop.DataTextField = "Ministry_Name";
                drop.DataBind();
            }

        }

        //DISPLAY VEHICLE FOR SPECIFIC MINISTRY BASED ON CODE MINISTRY METHOD ( In case of Edit) WHEN DRIVER AND VEH NOT ON POST
        public void DisplaySelectedVehicle(DropDownList drop, string codeMin, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from C in con.CAR_CRASH
                           where C.MINISTRY.Code_Min == codeMin && C.CAR_CRASH_ID == id

                           select new
                           {
                               Local_Plate = C.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "Local_Plate";
                drop.DataBind();
            }

        }

       // DISPLAY DRIVER FOR SPECIFIC MINISTRY BASED ON CODE MINISTRY METHOD(In case of Edit) WHEN DRIVER AND VEH NOT ON POST
        public void DisplaySelectedDriver(DropDownList drop, string codeMin, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from C in con.CAR_CRASH
                           where C.MINISTRY.Code_Min == codeMin && C.CAR_CRASH_ID == id

                           select new
                           {
                               DRIVER_ID = C.MINISTRY_DRIVER.DRIVER_ID,
                               Full_Name = C.MINISTRY_DRIVER.DRIVER.Full_Name
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "DRIVER_ID";
                drop.DataTextField = "Full_Name";
                drop.DataBind();
            }

        }



    }
}