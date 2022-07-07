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
    public class Repair_Imp: Repair_Interface
    {


        int msg;
        REPAIR R = new REPAIR();

        //ADD METHOD
        public int Add(Repair_Class Re)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                R.Work_Number  = Re.Work_Number ;
                R.Reason  = Re.Reason ;
                R.Start_Dte = Re.Start_Dte;
                R.End_Dte = Re.End_Dte;
                R.Internal_External  = Re.Internal_External ;
                R.Comment = Re.Comment;
                R.Location_Code  = Re.Location_Code ;
                R.Work_Status  = Re.Work_Status ;
                R.Saved_Date = Re.Saved_Date;
                R.MINISTRY_ID = Re.MINISTRY_ID;
                R.VEHICLE_ID  = Re.VEHICLE_ID ;
                R.Odometer_IN = Re.Odometer_IN;
                R.Odometer_OUT = Re.Odometer_OUT;
                R.Start_Work_Time = Re.Start_Work_Time;
                R.End_Work_Time = Re.End_Work_Time;
                R.Off_Service_Days_Number = Re.Off_Service_Days_Number;
                R.Participant_Emp_Code = Re.Participant_Emp_Code;
                R.CAR_CRASH_ID = Re.CAR_CRASH_ID;


                con.REPAIRs.Add(R);

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
        public int Update(Repair_Class Re, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                REPAIR R = new REPAIR();
                R = con.REPAIRs.Where(x => x.REPAIR_ID== id).FirstOrDefault();

                if (R != null)
                {

                    R.Work_Number = Re.Work_Number;
                    R.Reason = Re.Reason;
                    R.Start_Dte = Re.Start_Dte;
                    R.End_Dte = Re.End_Dte;
                    R.Internal_External = Re.Internal_External;
                    R.Comment = Re.Comment;
                    R.Location_Code = Re.Location_Code;
                    R.Work_Status = Re.Work_Status;
                    R.Saved_Date = Re.Saved_Date;
                    R.MINISTRY_ID = Re.MINISTRY_ID;
                    R.VEHICLE_ID = Re.VEHICLE_ID;
                    R.Odometer_IN = Re.Odometer_IN;
                    R.Odometer_OUT = Re.Odometer_OUT;
                    R.Start_Work_Time = Re.Start_Work_Time;
                    R.End_Work_Time = Re.End_Work_Time;
                    R.Off_Service_Days_Number = Re.Off_Service_Days_Number;
                    R.Participant_Emp_Code = Re.Participant_Emp_Code;
                    R.CAR_CRASH_ID = Re.CAR_CRASH_ID;

                    if (con.SaveChanges() > 0)
                    {
                        con.REPAIRs.Add(R);
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
                var obj = con.REPAIRs.Where(x => x.REPAIR_ID  == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.REPAIRs.Attach(obj);

                }
                con.REPAIRs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DISPLAY METHOD
        public void Display(GridView gd,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.REPAIRs where R.MINISTRY.Code_Min== codeMin

                           select new
                           {
                               REPAIR_ID  = R.REPAIR_ID ,
                               Work_Number  = R.Work_Number ,
                               Reason  = R.Reason ,
                               Start_Dte = R.Start_Dte,
                               End_Dte = R.End_Dte,
                               Internal_External  = R.Internal_External ,
                               Work_Status  = R.Work_Status ,
                               Saved_Date = R.Saved_Date,
                               Location_Code  = R.Location_Code ,
                               Comment = R.Comment,
                               VEHICLE_ID  = R.VEHICLE.Local_Plate,
                               Odometer_IN  = R.Odometer_IN,
                               MINISTRY_ID = R.MINISTRY.Ministry_Name,
                               Odometer_OUT = R.Odometer_OUT,
                               Start_Work_Time = R.Start_Work_Time,
                               End_Work_Time = R.End_Work_Time,
                               Off_Service_Days_Number = R.Off_Service_Days_Number,
                               Participant_Emp_Code = R.Participant_Emp_Code,
                               CAR_CRASH_ID = R.CAR_CRASH.Crash_Code

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
                var obj = (from R in con.REPAIRs

                           select new
                           {
                               REPAIR_ID = R.REPAIR_ID,
                               Work_Number = R.Work_Number,
                               Reason = R.Reason,
                               Start_Dte = R.Start_Dte,
                               End_Dte = R.End_Dte,
                               Internal_External = R.Internal_External,
                               Work_Status = R.Work_Status,
                               Saved_Date = R.Saved_Date,
                               Location_Code = R.Location_Code,
                               Comment = R.Comment,
                               VEHICLE_ID = R.VEHICLE.Local_Plate,
                               Odometer_IN = R.Odometer_IN,
                               MINISTRY_ID = R.MINISTRY.Ministry_Name,
                               Odometer_OUT = R.Odometer_OUT,
                               Start_Work_Time = R.Start_Work_Time,
                               End_Work_Time = R.End_Work_Time,
                               Off_Service_Days_Number = R.Off_Service_Days_Number,
                               Participant_Emp_Code = R.Participant_Emp_Code,
                               CAR_CRASH_ID = R.CAR_CRASH.Crash_Code

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Repair_Class Re, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                R = con.REPAIRs.Where(x => x.REPAIR_ID  == id).FirstOrDefault();

                Re.Work_Number  = R.Work_Number ;
                Re.Reason  = R.Reason ;
                Re.Start_Dte = R.Start_Dte;
                Re.End_Dte = R.End_Dte;
                Re.Internal_External  = R.Internal_External ;
                Re.Comment = R.Comment;
                Re.Location_Code  = R.Location_Code ;
                Re.Work_Status = R.Work_Status;
                Re.VEHICLE_ID  = R.VEHICLE_ID ;
                Re.MINISTRY_ID = R.MINISTRY_ID;
                Re.Odometer_IN  = R.Odometer_IN ;
                Re.Saved_Date = R.Saved_Date;
                Re.Odometer_OUT = R.Odometer_OUT;
                Re.Start_Work_Time = R.Start_Work_Time;
                Re.End_Work_Time = R.End_Work_Time;
                Re.Off_Service_Days_Number = R.Off_Service_Days_Number;
                Re.Participant_Emp_Code = R.Participant_Emp_Code;
                Re.CAR_CRASH_ID = R.CAR_CRASH_ID;

            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var R = (from c in con.REPAIRs where c.MINISTRY.Code_Min== codeMin
                         select c).Count();
                n = R;
            }
            return n;
        }

        //COUNT ALL METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var R = (from c in con.REPAIRs
                         select c).Count();
                n = R;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd,string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.REPAIRs
                           where R.MINISTRY.Code_Min== codeMin &&
                       R.Work_Number.StartsWith(SearchText) ||
                       R.Start_Dte.StartsWith(SearchText) ||
                       R.VEHICLE.Local_Plate.StartsWith(SearchText) ||
                       R.CAR_CRASH.Crash_Code.StartsWith(SearchText) ||
                       R.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                       R.Work_Status .ToString() == SearchText

                           select new
                           {
                               REPAIR_ID = R.REPAIR_ID,
                               Work_Number = R.Work_Number,
                               Reason = R.Reason,
                               Start_Dte = R.Start_Dte,
                               End_Dte = R.End_Dte,
                               Internal_External = R.Internal_External,
                               Work_Status = R.Work_Status,
                               Saved_Date = R.Saved_Date,
                               Location_Code = R.Location_Code,
                               Comment = R.Comment,
                               VEHICLE_ID = R.VEHICLE.Local_Plate,
                               Odometer_IN = R.Odometer_IN,
                               MINISTRY_ID = R.MINISTRY.Ministry_Name,
                               Odometer_OUT = R.Odometer_OUT,
                               Start_Work_Time = R.Start_Work_Time,
                               End_Work_Time = R.End_Work_Time,
                               Off_Service_Days_Number = R.Off_Service_Days_Number,
                               Participant_Emp_Code = R.Participant_Emp_Code,
                               CAR_CRASH_ID = R.CAR_CRASH.Crash_Code

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
                var obj = (from R in con.REPAIRs
                           where
                       R.Work_Number.StartsWith(SearchText) ||
                       R.Start_Dte.StartsWith(SearchText) ||
                       R.VEHICLE.Local_Plate.StartsWith(SearchText) ||
                       R.CAR_CRASH.Crash_Code.StartsWith(SearchText) ||
                       R.MINISTRY.Ministry_Name.StartsWith(SearchText) ||
                       R.Work_Status.ToString() == SearchText

                           select new
                           {
                               REPAIR_ID = R.REPAIR_ID,
                               Work_Number = R.Work_Number,
                               Reason = R.Reason,
                               Start_Dte = R.Start_Dte,
                               End_Dte = R.End_Dte,
                               Internal_External = R.Internal_External,
                               Work_Status = R.Work_Status,
                               Saved_Date = R.Saved_Date,
                               Location_Code = R.Location_Code,
                               Comment = R.Comment,
                               VEHICLE_ID = R.VEHICLE.Local_Plate,
                               Odometer_IN = R.Odometer_IN,
                               MINISTRY_ID = R.MINISTRY.Ministry_Name,
                               Odometer_OUT = R.Odometer_OUT,
                               Start_Work_Time = R.Start_Work_Time,
                               End_Work_Time = R.End_Work_Time,
                               Off_Service_Days_Number = R.Off_Service_Days_Number,
                               Participant_Emp_Code = R.Participant_Emp_Code,
                               CAR_CRASH_ID = R.CAR_CRASH.Crash_Code

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }
        //DISPLAY METHOD ALL Driver
        public void DisplayAllVehicle(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs

                           select new
                           {
                               VEHICLE_ID  = V.VEHICLE_ID ,
                               Local_Plate = V.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Local_Plate";
                drop.DataValueField = "VEHICLE_ID ";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD ALL Crash
        public void DisplayAllCrash(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from car in con.CAR_CRASH

                           select new
                           {
                               CAR_CRASH_ID = car.CAR_CRASH_ID,
                               Crash_Code = car.Crash_Code,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Crash_Code";
                drop.DataValueField = "CAR_CRASH_ID ";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD REPAIR Type
        public void DisplayCarCrash(DropDownList drop, string plate)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from carc in con.CAR_CRASH
                           where carc.Local_Plate == plate

                           select new
                           {
                               Crash_Reason = carc.Crash_Reason +"/"+ carc.Crash_Date,
                               Crash_Code = carc.Crash_Code,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Crash_Reason";
                drop.DataValueField = "Crash_Code";
                drop.DataBind();
            }

        }


        //DISPLAY METHOD Driver
        public void DisplayVehicle(DropDownList drop, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from veh in con.VEHICLEs
                           where veh.MINISTRY_ID  == id

                           select new
                           {
                               VEHICLE_ID  = veh.VEHICLE_ID ,
                               Local_Plate = veh.Local_Plate,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataTextField = "Local_Plate";
                drop.DataValueField = "VEHICLE_ID";
                drop.DataBind();
            }

        }

        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop,string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from R in con.MINISTRies where R.Code_Min== codeMin

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

    }
}