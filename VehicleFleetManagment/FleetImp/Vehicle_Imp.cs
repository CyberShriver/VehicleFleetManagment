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
    public class Vehicle_Imp : Vehicle_Interface
    {

        int msg;
        VEHICLE V = new VEHICLE();

        //ADD METHOD
        public int Add(Vehicle_Class Veh)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                V.Veh_Code = Veh.Veh_Code;
                V.BODY_ID = Veh.BODY_ID;
                V.Local_Plate = Veh.Local_Plate;
                V.MODEL_ID = Veh.MODEL_ID;
                V.MINISTRY_ID = Veh.MINISTRY_ID;
                V.NameVeh = Veh.NameVeh;
                V.Color = Veh.Color;
                V.Condition = Veh.Condition;
                V.Chassis_Num = Veh.Chassis_Num;
                V.Engine_Num = Veh.Engine_Num;
                V.Engine_Manufacturer = Veh.Engine_Manufacturer;
                V.Engine_Type = Veh.Engine_Type;
                V.Alternator_Engine_Manufacturer = Veh.Alternator_Engine_Manufacturer;
                V.Alternator_Engine_Type = Veh.Alternator_Engine_Type;
                V.Kva = Veh.Kva;
                V.Volt = Veh.Volt;
                V.Picture = Veh.Picture;
                V.Generator_Weight = Veh.Generator_Weight;
                V.Trailer = Veh.Trailer;
                V.Assembly_Num = Veh.Assembly_Num;
                V.lhd_rhd = Veh.lhd_rhd;
                V.Safety_Belt = Veh.Safety_Belt;
                V.Gearbox_Type = Veh.Gearbox_Type;
                V.Opt_Four_Wheel = Veh.Opt_Four_Wheel;
                V.Central_Locking = Veh.Central_Locking;
                V.Rear_Lock = Veh.Rear_Lock;
                V.Engine_Series_Num = Veh.Engine_Series_Num;
                V.Forward_Lock = Veh.Forward_Lock;
                V.Engine_cylinder_Number = Veh.Engine_cylinder_Number;
                V.Engine_cc = Veh.Engine_cc;
                V.Engine_Power = Veh.Engine_Power;
                V.Fuel_Fype = Veh.Fuel_Fype;
                V.Tank_Type1 = Veh.Tank_Type1;
                V.Tank_Size1 = Veh.Tank_Size1;
                V.Tank_Type2 = Veh.Tank_Type2;
                V.Tank_Capacity2 = Veh.Tank_Capacity2;
                V.Front_Seats_Number = Veh.Front_Seats_Number;
                V.Battery_Voltage = Veh.Battery_Voltage;
                V.Air_Conditioner = Veh.Air_Conditioner;
                V.Additional_Heating = Veh.Additional_Heating;
                V.Veh_Weight = Veh.Veh_Weight;
                V.Gross_Veh_Weigth = Veh.Gross_Veh_Weigth;
                V.Empty_Pod = Veh.Empty_Pod;
                V.Key_Code = Veh.Key_Code;
                V.Rear_Blake = Veh.Rear_Blake;
                V.Electronic_Logbook = Veh.Electronic_Logbook;
                V.Radio_Code = Veh.Radio_Code;
                V.Guaranteed_Expiration_Date = Veh.Guaranteed_Expiration_Date;
                V.Guaranteed_Certificate_Num = Veh.Guaranteed_Certificate_Num;
                V.Circulation_Expiration_Date = Veh.Circulation_Expiration_Date;
                V.Stat = Veh.Stat;
                V.Picture = Veh.Picture;


                con.VEHICLEs.Add(V);

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
        public int Update(Vehicle_Class Veh, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                VEHICLE V = new VEHICLE();
                V = con.VEHICLEs.Where(x => x.VEHICLE_ID == id).FirstOrDefault();

                if (V != null)
                {

                    V.Veh_Code = Veh.Veh_Code;
                    V.BODY_ID = Veh.BODY_ID;
                    V.Local_Plate = Veh.Local_Plate;
                    V.MODEL_ID = Veh.MODEL_ID;
                    V.MINISTRY_ID = Veh.MINISTRY_ID;
                    V.NameVeh = Veh.NameVeh;
                    V.Color = Veh.Color;
                    V.Condition = Veh.Condition;
                    V.Chassis_Num = Veh.Chassis_Num;
                    V.Engine_Num = Veh.Engine_Num;
                    V.Engine_Manufacturer = Veh.Engine_Manufacturer;
                    V.Engine_Type = Veh.Engine_Type;
                    V.Alternator_Engine_Manufacturer = Veh.Alternator_Engine_Manufacturer;
                    V.Alternator_Engine_Type = Veh.Alternator_Engine_Type;
                    V.Kva = Veh.Kva;
                    V.Volt = Veh.Volt;
                    V.Picture = Veh.Picture;
                    V.Generator_Weight = Veh.Generator_Weight;
                    V.Trailer = Veh.Trailer;
                    V.Assembly_Num = Veh.Assembly_Num;
                    V.lhd_rhd = Veh.lhd_rhd;
                    V.Safety_Belt = Veh.Safety_Belt;
                    V.Gearbox_Type = Veh.Gearbox_Type;
                    V.Opt_Four_Wheel = Veh.Opt_Four_Wheel;
                    V.Central_Locking = Veh.Central_Locking;
                    V.Rear_Lock = Veh.Rear_Lock;
                    V.Engine_Series_Num = Veh.Engine_Series_Num;
                    V.Forward_Lock = Veh.Forward_Lock;
                    V.Engine_cylinder_Number = Veh.Engine_cylinder_Number;
                    V.Engine_cc = Veh.Engine_cc;
                    V.Engine_Power = Veh.Engine_Power;
                    V.Fuel_Fype = Veh.Fuel_Fype;
                    V.Tank_Type1 = Veh.Tank_Type1;
                    V.Tank_Size1 = Veh.Tank_Size1;
                    V.Tank_Type2 = Veh.Tank_Type2;
                    V.Tank_Capacity2 = Veh.Tank_Capacity2;
                    V.Front_Seats_Number = Veh.Front_Seats_Number;
                    V.Battery_Voltage = Veh.Battery_Voltage;
                    V.Air_Conditioner = Veh.Air_Conditioner;
                    V.Additional_Heating = Veh.Additional_Heating;
                    V.Veh_Weight = Veh.Veh_Weight;
                    V.Gross_Veh_Weigth = Veh.Gross_Veh_Weigth;
                    V.Empty_Pod = Veh.Empty_Pod;
                    V.Key_Code = Veh.Key_Code;
                    V.Rear_Blake = Veh.Rear_Blake;
                    V.Electronic_Logbook = Veh.Electronic_Logbook;
                    V.Radio_Code = Veh.Radio_Code;
                    V.Guaranteed_Expiration_Date = Veh.Guaranteed_Expiration_Date;
                    V.Guaranteed_Certificate_Num = Veh.Guaranteed_Certificate_Num;
                    V.Circulation_Expiration_Date = Veh.Circulation_Expiration_Date;
                    V.Stat = Veh.Stat;
                    V.Picture = Veh.Picture;

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

        //DELETE METHOD
        public int Delete(int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = con.VEHICLEs.Where(x => x.VEHICLE_ID == id).First();

                if (con.Entry(obj).State == EntityState.Detached)
                {
                    con.VEHICLEs.Attach(obj);

                }
                con.VEHICLEs.Remove(obj);
                con.SaveChanges();
                return msg;
            }

        }

        //DISPLAY METHOD
        public void Display(GridView gd, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs where  V.MINISTRY.Code_Min== codeMin

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Veh_Code = V.Veh_Code,
                               BODY_ID = V.BODY_TYPE.Category,
                               Local_Plate = V.Local_Plate,
                               MODEL_ID =( V.MODEL.Model_Name)+" , "+ (V.MODEL.MARK.Mark_Name),
                               MINISTRY_ID = V.MINISTRY.Ministry_Name,
                               NameVeh = V.NameVeh,
                               Color = V.Color,
                               Condition = V.Condition,
                               Chassis_Num = V.Chassis_Num,
                               Engine_Num = V.Engine_Num,
                               Engine_Manufacturer = V.Engine_Manufacturer,
                               Engine_Type = V.Engine_Type,
                               Alternator_Engine_Manufacturer = V.Alternator_Engine_Manufacturer,
                               Alternator_Engine_Type = V.Alternator_Engine_Type,
                               Kva = V.Kva,
                               Volt = V.Volt,
                               Generator_Weight = V.Generator_Weight,
                               Trailer = V.Trailer,
                               Assembly_Num = V.Assembly_Num,
                               lhd_rhd = V.lhd_rhd,
                               Safety_Belt = V.Safety_Belt,
                               Gearbox_Type = V.Gearbox_Type,
                               Opt_Four_Wheel = V.Opt_Four_Wheel,
                               Central_Locking = V.Central_Locking,
                               Rear_Lock = V.Rear_Lock,
                               Engine_Series_Num = V.Engine_Series_Num,
                               Forward_Lock = V.Forward_Lock,
                               Engine_cylinder_Number = V.Engine_cylinder_Number,
                               Engine_cc = V.Engine_cc,
                               Engine_Power = V.Engine_Power,
                               Fuel_Fype = V.Fuel_Fype,
                               Tank_Type1 = V.Tank_Type1,
                               Tank_Size1 = V.Tank_Size1,
                               Tank_Type2 = V.Tank_Type2,
                               Tank_Capacity2 = V.Tank_Capacity2,
                               Front_Seats_Number = V.Front_Seats_Number,
                               Battery_Voltage = V.Battery_Voltage,
                               Air_Conditioner = V.Air_Conditioner,
                               Additional_Heating = V.Additional_Heating,
                               Veh_Weight = V.Veh_Weight,
                               Gross_Veh_Weigth = V.Gross_Veh_Weigth,
                               Empty_Pod = V.Empty_Pod,
                               Key_Code = V.Key_Code,
                               Rear_Blake = V.Rear_Blake,
                               Electronic_Logbook = V.Electronic_Logbook,
                               Radio_Code = V.Radio_Code,
                               Guaranteed_Expiration_Date = V.Guaranteed_Expiration_Date,
                               Guaranteed_Certificate_Num = V.Guaranteed_Certificate_Num,
                               Circulation_Expiration_Date = V.Circulation_Expiration_Date,
                               Stat = V.Stat,
                               Picture = V.Picture
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
                var obj = (from V in con.VEHICLEs

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Veh_Code = V.Veh_Code,
                               BODY_ID = V.BODY_TYPE.Category,
                               Local_Plate = V.Local_Plate,
                               MODEL_ID = (V.MODEL.Model_Name) + " , " + (V.MODEL.MARK.Mark_Name),
                               MINISTRY_ID = V.MINISTRY.Ministry_Name,
                               NameVeh = V.NameVeh,
                               Color = V.Color,
                               Condition = V.Condition,
                               Chassis_Num = V.Chassis_Num,
                               Engine_Num = V.Engine_Num,
                               Engine_Manufacturer = V.Engine_Manufacturer,
                               Engine_Type = V.Engine_Type,
                               Alternator_Engine_Manufacturer = V.Alternator_Engine_Manufacturer,
                               Alternator_Engine_Type = V.Alternator_Engine_Type,
                               Kva = V.Kva,
                               Volt = V.Volt,
                               Generator_Weight = V.Generator_Weight,
                               Trailer = V.Trailer,
                               Assembly_Num = V.Assembly_Num,
                               lhd_rhd = V.lhd_rhd,
                               Safety_Belt = V.Safety_Belt,
                               Gearbox_Type = V.Gearbox_Type,
                               Opt_Four_Wheel = V.Opt_Four_Wheel,
                               Central_Locking = V.Central_Locking,
                               Rear_Lock = V.Rear_Lock,
                               Engine_Series_Num = V.Engine_Series_Num,
                               Forward_Lock = V.Forward_Lock,
                               Engine_cylinder_Number = V.Engine_cylinder_Number,
                               Engine_cc = V.Engine_cc,
                               Engine_Power = V.Engine_Power,
                               Fuel_Fype = V.Fuel_Fype,
                               Tank_Type1 = V.Tank_Type1,
                               Tank_Size1 = V.Tank_Size1,
                               Tank_Type2 = V.Tank_Type2,
                               Tank_Capacity2 = V.Tank_Capacity2,
                               Front_Seats_Number = V.Front_Seats_Number,
                               Battery_Voltage = V.Battery_Voltage,
                               Air_Conditioner = V.Air_Conditioner,
                               Additional_Heating = V.Additional_Heating,
                               Veh_Weight = V.Veh_Weight,
                               Gross_Veh_Weigth = V.Gross_Veh_Weigth,
                               Empty_Pod = V.Empty_Pod,
                               Key_Code = V.Key_Code,
                               Rear_Blake = V.Rear_Blake,
                               Electronic_Logbook = V.Electronic_Logbook,
                               Radio_Code = V.Radio_Code,
                               Guaranteed_Expiration_Date = V.Guaranteed_Expiration_Date,
                               Guaranteed_Certificate_Num = V.Guaranteed_Certificate_Num,
                               Circulation_Expiration_Date = V.Circulation_Expiration_Date,
                               Stat = V.Stat,
                               Picture = V.Picture
                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //PROVIDE METHOD
        public void provide(Vehicle_Class Veh, int id)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            { 
                V = con.VEHICLEs.Where(x => x.VEHICLE_ID == id).FirstOrDefault();

                Veh.Veh_Code = V.Veh_Code;
                Veh.BODY_ID = V.BODY_ID;
                Veh.Local_Plate = V.Local_Plate;
                Veh.MODEL_ID = V.MODEL_ID;
                Veh.MINISTRY_ID = V.MINISTRY_ID;
                Veh.NameVeh = V.NameVeh;
                Veh.Color = V.Color;
                Veh.Condition = V.Condition;
                Veh.Chassis_Num = V.Chassis_Num;
                Veh.Engine_Num = V.Engine_Num;
                Veh.Engine_Manufacturer = V.Engine_Manufacturer;
                Veh.Engine_Type = V.Engine_Type;
                Veh.Alternator_Engine_Manufacturer = V.Alternator_Engine_Manufacturer;
                Veh.Alternator_Engine_Type = V.Alternator_Engine_Type;
                Veh.Kva = V.Kva;
                Veh.Volt = V.Volt;
                Veh.Picture = V.Picture;
                Veh.Generator_Weight = V.Generator_Weight;
                Veh.Trailer = V.Trailer;
                Veh.Assembly_Num = V.Assembly_Num;
                Veh.lhd_rhd = V.lhd_rhd;
                Veh.Safety_Belt = V.Safety_Belt;
                Veh.Gearbox_Type = V.Gearbox_Type;
                Veh.Opt_Four_Wheel = V.Opt_Four_Wheel;
                Veh.Central_Locking = V.Central_Locking;
                Veh.Rear_Lock = V.Rear_Lock;
                Veh.Engine_Series_Num = V.Engine_Series_Num;
                Veh.Forward_Lock = V.Forward_Lock;
                Veh.Engine_cylinder_Number = V.Engine_cylinder_Number;
                Veh.Engine_cc = V.Engine_cc;
                Veh.Engine_Power = V.Engine_Power;
                Veh.Fuel_Fype = V.Fuel_Fype;
                Veh.Tank_Type1 = V.Tank_Type1;
                Veh.Tank_Size1 = V.Tank_Size1;
                Veh.Tank_Type2 = V.Tank_Type2;
                Veh.Tank_Capacity2 = V.Tank_Capacity2;
                Veh.Front_Seats_Number = V.Front_Seats_Number;
                Veh.Battery_Voltage = V.Battery_Voltage;
                Veh.Air_Conditioner = V.Air_Conditioner;
                Veh.Additional_Heating = V.Additional_Heating;
                Veh.Veh_Weight = V.Veh_Weight;
                Veh.Gross_Veh_Weigth = V.Gross_Veh_Weigth;
                Veh.Empty_Pod = V.Empty_Pod;
                Veh.Key_Code = V.Key_Code;
                Veh.Rear_Blake = V.Rear_Blake;
                Veh.Electronic_Logbook = V.Electronic_Logbook;
                Veh.Radio_Code = V.Radio_Code;
                Veh.Guaranteed_Expiration_Date = V.Guaranteed_Expiration_Date;
                Veh.Guaranteed_Certificate_Num = V.Guaranteed_Certificate_Num;
                Veh.Circulation_Expiration_Date = V.Circulation_Expiration_Date;
                Veh.Stat = V.Stat;
                Veh.Picture = V.Picture;

            }
        }


        //PROVIDE METHOD by plate
        public int ProvideByPlate(Vehicle_Class Veh, string plate)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                V = con.VEHICLEs.Where(x => x.Local_Plate == plate).FirstOrDefault();

                if (V != null)
                {
                    Veh.Veh_Code = V.Veh_Code;
                    Veh.BODY_ID = V.BODY_ID;
                    Veh.Local_Plate = V.Local_Plate;
                    Veh.MODEL_ID = V.MODEL_ID;
                    Veh.MINISTRY_ID = V.MINISTRY_ID;
                    Veh.NameVeh = V.NameVeh;
                    Veh.Color = V.Color;
                    Veh.Condition = V.Condition;
                    Veh.Chassis_Num = V.Chassis_Num;
                    Veh.Engine_Num = V.Engine_Num;
                    Veh.Engine_Manufacturer = V.Engine_Manufacturer;
                    Veh.Engine_Type = V.Engine_Type;
                    Veh.Alternator_Engine_Manufacturer = V.Alternator_Engine_Manufacturer;
                    Veh.Alternator_Engine_Type = V.Alternator_Engine_Type;
                    Veh.Kva = V.Kva;
                    Veh.Volt = V.Volt;
                    Veh.Picture = V.Picture;
                    Veh.Generator_Weight = V.Generator_Weight;
                    Veh.Trailer = V.Trailer;
                    Veh.Assembly_Num = V.Assembly_Num;
                    Veh.lhd_rhd = V.lhd_rhd;
                    Veh.Safety_Belt = V.Safety_Belt;
                    Veh.Gearbox_Type = V.Gearbox_Type;
                    Veh.Opt_Four_Wheel = V.Opt_Four_Wheel;
                    Veh.Central_Locking = V.Central_Locking;
                    Veh.Rear_Lock = V.Rear_Lock;
                    Veh.Engine_Series_Num = V.Engine_Series_Num;
                    Veh.Forward_Lock = V.Forward_Lock;
                    Veh.Engine_cylinder_Number = V.Engine_cylinder_Number;
                    Veh.Engine_cc = V.Engine_cc;
                    Veh.Engine_Power = V.Engine_Power;
                    Veh.Fuel_Fype = V.Fuel_Fype;
                    Veh.Tank_Type1 = V.Tank_Type1;
                    Veh.Tank_Size1 = V.Tank_Size1;
                    Veh.Tank_Type2 = V.Tank_Type2;
                    Veh.Tank_Capacity2 = V.Tank_Capacity2;
                    Veh.Front_Seats_Number = V.Front_Seats_Number;
                    Veh.Battery_Voltage = V.Battery_Voltage;
                    Veh.Air_Conditioner = V.Air_Conditioner;
                    Veh.Additional_Heating = V.Additional_Heating;
                    Veh.Veh_Weight = V.Veh_Weight;
                    Veh.Gross_Veh_Weigth = V.Gross_Veh_Weigth;
                    Veh.Empty_Pod = V.Empty_Pod;
                    Veh.Key_Code = V.Key_Code;
                    Veh.Rear_Blake = V.Rear_Blake;
                    Veh.Electronic_Logbook = V.Electronic_Logbook;
                    Veh.Radio_Code = V.Radio_Code;
                    Veh.Guaranteed_Expiration_Date = V.Guaranteed_Expiration_Date;
                    Veh.Guaranteed_Certificate_Num = V.Guaranteed_Certificate_Num;
                    Veh.Circulation_Expiration_Date = V.Circulation_Expiration_Date;
                    Veh.Stat = V.Stat;
                    Veh.Picture = V.Picture;

                    return msg = 1;
                }
                else return msg = 0;

            }
        }

        //COUNT METHOD
        public int count(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var V = (from l in con.VEHICLEs where l.MINISTRY.Code_Min== codeMin
                         select l).Count();
                n = V;
            }
            return n;
        }

        //COUNT AVAILABLE METHOD
        public int countAvailable(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var V = (from l in con.VEHICLEs
                         where l.MINISTRY.Code_Min == codeMin && l.Stat=="Available"
                         select l).Count();
                n = V;
            }
            return n;
        }

        //COUNT UNAVAILABLE METHOD
        public int countUnavailable(string codeMin)
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var V = (from l in con.VEHICLEs
                         where l.MINISTRY.Code_Min == codeMin && l.Stat == "Unavailable"
                         select l).Count();
                n = V;
            }
            return n;
        }

        //COUNT All METHOD
        public int countAll()
        {
            int n = 0;
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var V = (from l in con.VEHICLEs
                         select l).Count();
                n = V;
            }
            return n;
        }

        //REASEARCH METHOD
        public void Research(GridView gd, string codeMin, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs
                           where V.MINISTRY.Code_Min == codeMin &&
                       V.Local_Plate.StartsWith(SearchText) ||
                       V.Veh_Code.StartsWith(SearchText) ||
                       V.BODY_TYPE.Category.StartsWith(SearchText) ||
                       V.Veh_Code.StartsWith(SearchText) ||
                       V.MODEL.Model_Name.StartsWith(SearchText) ||
                       V.MODEL.MARK.Mark_Name.StartsWith(SearchText) ||
                       V.Chassis_Num.StartsWith(SearchText) ||
                       V.NameVeh.StartsWith(SearchText)

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Veh_Code = V.Veh_Code,
                               BODY_ID = V.BODY_TYPE.Category,
                               Local_Plate = V.Local_Plate,
                               MODEL_ID = (V.MODEL.Model_Name) + "," + (V.MODEL.MARK.Mark_Name),
                               MINISTRY_ID = V.MINISTRY.Ministry_Name,
                               NameVeh = V.NameVeh,
                               Color = V.Color,
                               Condition = V.Condition,
                               Chassis_Num = V.Chassis_Num,
                               Engine_Num = V.Engine_Num,
                               Engine_Manufacturer = V.Engine_Manufacturer,
                               Engine_Type = V.Engine_Type,
                               Alternator_Engine_Manufacturer = V.Alternator_Engine_Manufacturer,
                               Alternator_Engine_Type = V.Alternator_Engine_Type,
                               Kva = V.Kva,
                               Volt = V.Volt,
                               Generator_Weight = V.Generator_Weight,
                               Trailer = V.Trailer,
                               Assembly_Num = V.Assembly_Num,
                               lhd_rhd = V.lhd_rhd,
                               Safety_Belt = V.Safety_Belt,
                               Gearbox_Type = V.Gearbox_Type,
                               Opt_Four_Wheel = V.Opt_Four_Wheel,
                               Central_Locking = V.Central_Locking,
                               Rear_Lock = V.Rear_Lock,
                               Engine_Series_Num = V.Engine_Series_Num,
                               Forward_Lock = V.Forward_Lock,
                               Engine_cylinder_Number = V.Engine_cylinder_Number,
                               Engine_cc = V.Engine_cc,
                               Engine_Power = V.Engine_Power,
                               Fuel_Fype = V.Fuel_Fype,
                               Tank_Type1 = V.Tank_Type1,
                               Tank_Size1 = V.Tank_Size1,
                               Tank_Type2 = V.Tank_Type2,
                               Tank_Capacity2 = V.Tank_Capacity2,
                               Front_Seats_Number = V.Front_Seats_Number,
                               Battery_Voltage = V.Battery_Voltage,
                               Air_Conditioner = V.Air_Conditioner,
                               Additional_Heating = V.Additional_Heating,
                               Veh_Weight = V.Veh_Weight,
                               Gross_Veh_Weigth = V.Gross_Veh_Weigth,
                               Empty_Pod = V.Empty_Pod,
                               Key_Code = V.Key_Code,
                               Rear_Blake = V.Rear_Blake,
                               Electronic_Logbook = V.Electronic_Logbook,
                               Radio_Code = V.Radio_Code,
                               Guaranteed_Expiration_Date = V.Guaranteed_Expiration_Date,
                               Guaranteed_Certificate_Num = V.Guaranteed_Certificate_Num,
                               Circulation_Expiration_Date = V.Circulation_Expiration_Date,
                               Stat = V.Stat,
                               Picture = V.Picture

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //REASEARCH All METHOD
        public void ResearchAll(GridView gd, string SearchText)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from V in con.VEHICLEs
                           where
                       V.Local_Plate.StartsWith(SearchText) ||
                       V.Veh_Code.StartsWith(SearchText) ||
                       V.BODY_TYPE.Category.StartsWith(SearchText) ||
                       V.Veh_Code.StartsWith(SearchText) ||
                       V.MODEL.Model_Name.StartsWith(SearchText) ||
                       V.MODEL.MARK.Mark_Name.StartsWith(SearchText) ||
                       V.Chassis_Num.StartsWith(SearchText) ||
                       V.NameVeh.StartsWith(SearchText)

                           select new
                           {
                               VEHICLE_ID = V.VEHICLE_ID,
                               Veh_Code = V.Veh_Code,
                               BODY_ID = V.BODY_TYPE.Category,
                               Local_Plate = V.Local_Plate,
                               MODEL_ID = (V.MODEL.Model_Name) + "," + (V.MODEL.MARK.Mark_Name),
                               MINISTRY_ID = V.MINISTRY.Ministry_Name,
                               NameVeh = V.NameVeh,
                               Color = V.Color,
                               Condition = V.Condition,
                               Chassis_Num = V.Chassis_Num,
                               Engine_Num = V.Engine_Num,
                               Engine_Manufacturer = V.Engine_Manufacturer,
                               Engine_Type = V.Engine_Type,
                               Alternator_Engine_Manufacturer = V.Alternator_Engine_Manufacturer,
                               Alternator_Engine_Type = V.Alternator_Engine_Type,
                               Kva = V.Kva,
                               Volt = V.Volt,
                               Generator_Weight = V.Generator_Weight,
                               Trailer = V.Trailer,
                               Assembly_Num = V.Assembly_Num,
                               lhd_rhd = V.lhd_rhd,
                               Safety_Belt = V.Safety_Belt,
                               Gearbox_Type = V.Gearbox_Type,
                               Opt_Four_Wheel = V.Opt_Four_Wheel,
                               Central_Locking = V.Central_Locking,
                               Rear_Lock = V.Rear_Lock,
                               Engine_Series_Num = V.Engine_Series_Num,
                               Forward_Lock = V.Forward_Lock,
                               Engine_cylinder_Number = V.Engine_cylinder_Number,
                               Engine_cc = V.Engine_cc,
                               Engine_Power = V.Engine_Power,
                               Fuel_Fype = V.Fuel_Fype,
                               Tank_Type1 = V.Tank_Type1,
                               Tank_Size1 = V.Tank_Size1,
                               Tank_Type2 = V.Tank_Type2,
                               Tank_Capacity2 = V.Tank_Capacity2,
                               Front_Seats_Number = V.Front_Seats_Number,
                               Battery_Voltage = V.Battery_Voltage,
                               Air_Conditioner = V.Air_Conditioner,
                               Additional_Heating = V.Additional_Heating,
                               Veh_Weight = V.Veh_Weight,
                               Gross_Veh_Weigth = V.Gross_Veh_Weigth,
                               Empty_Pod = V.Empty_Pod,
                               Key_Code = V.Key_Code,
                               Rear_Blake = V.Rear_Blake,
                               Electronic_Logbook = V.Electronic_Logbook,
                               Radio_Code = V.Radio_Code,
                               Guaranteed_Expiration_Date = V.Guaranteed_Expiration_Date,
                               Guaranteed_Certificate_Num = V.Guaranteed_Certificate_Num,
                               Circulation_Expiration_Date = V.Circulation_Expiration_Date,
                               Stat = V.Stat,
                               Picture = V.Picture

                           }
                           ).ToList();

                gd.DataSource = obj;
                gd.DataBind();
            }

        }

        //DISPLAY METHOD MINISTRY
        public void DisplayMinistry(DropDownList drop, string codeMin)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from M in con.MINISTRies where M.Code_Min == codeMin

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

        //DISPLAY METHOD All MINISTRY
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

        //DISPLAY METHOD Model
        public void DisplayModel(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from Mo in con.MODELs 

                           select new
                           {
                               MODEL_ID = Mo.MODEL_ID,
                               Model_Name ="Model: " +(Mo.Model_Name)+" ,  Mark: "+ (Mo.MARK.Mark_Name),
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "MODEL_ID";
                drop.DataTextField = "Model_Name";
                drop.DataBind();
            }

        }
        //FuelType
        public void DisplayFuel(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from P in con.PROVIDERs

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

        //BodyType 
        public void DisplayBodyType(DropDownList drop)
        {
            using (MINISTRY_DB_Connection con = new MINISTRY_DB_Connection())
            {
                var obj = (from B in con.BODY_TYPE

                           select new
                           {
                               BODY_ID = B.BODY_ID,
                               Category = B.Category,
                           }
                           ).ToList();

                drop.DataSource = obj;
                drop.DataValueField = "BODY_ID";
                drop.DataTextField = "Category";
                drop.DataBind();
            }

        }

        //UPDATE VEHICLE UNVAILABLE STATE METHOD
        public int UpdateVehUnavailable(Vehicle_Class veh, string LocalPlate)
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

        //UPDATE VEHICLE VAILABLE STATE METHOD
        public int UpdateVehAvailable(Vehicle_Class veh, string LocalPlate)
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
    }
}