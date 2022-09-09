//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleFleetManagment.FleetModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class VEHICLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VEHICLE()
        {
            this.VEHICLE_FUEL_SUPPLY = new HashSet<VEHICLE_FUEL_SUPPLY>();
            this.ASSURANCEs = new HashSet<ASSURANCE>();
            this.MOTs = new HashSet<MOT>();
            this.SCHEDULEs = new HashSet<SCHEDULE>();
            this.REPAIRs = new HashSet<REPAIR>();
        }
    
        public long VEHICLE_ID { get; set; }
        public string Veh_Code { get; set; }
        public int BODY_ID { get; set; }
        public string Local_Plate { get; set; }
        public int MODEL_ID { get; set; }
        public int MINISTRY_ID { get; set; }
        public string NameVeh { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public string Chassis_Num { get; set; }
        public string Engine_Num { get; set; }
        public string Engine_Manufacturer { get; set; }
        public string Engine_Type { get; set; }
        public string Alternator_Engine_Manufacturer { get; set; }
        public string Alternator_Engine_Type { get; set; }
        public double Kva { get; set; }
        public string Volt { get; set; }
        public string Generator_Weight { get; set; }
        public string Trailer { get; set; }
        public string Assembly_Num { get; set; }
        public string lhd_rhd { get; set; }
        public string Safety_Belt { get; set; }
        public string Gearbox_Type { get; set; }
        public string Opt_Four_Wheel { get; set; }
        public string Central_Locking { get; set; }
        public string Rear_Lock { get; set; }
        public string Engine_Series_Num { get; set; }
        public string Forward_Lock { get; set; }
        public string Engine_cylinder_Number { get; set; }
        public string Engine_cc { get; set; }
        public Nullable<double> Engine_Power { get; set; }
        public string Fuel_Fype { get; set; }
        public string Tank_Type1 { get; set; }
        public Nullable<int> Tank_Size1 { get; set; }
        public string Tank_Type2 { get; set; }
        public Nullable<int> Tank_Capacity2 { get; set; }
        public Nullable<int> Front_Seats_Number { get; set; }
        public Nullable<double> Battery_Voltage { get; set; }
        public string Air_Conditioner { get; set; }
        public string Additional_Heating { get; set; }
        public Nullable<double> Veh_Weight { get; set; }
        public Nullable<double> Gross_Veh_Weigth { get; set; }
        public Nullable<double> Empty_Pod { get; set; }
        public string Key_Code { get; set; }
        public string Rear_Blake { get; set; }
        public string Electronic_Logbook { get; set; }
        public string Radio_Code { get; set; }
        public string Guaranteed_Expiration_Date { get; set; }
        public string Guaranteed_Certificate_Num { get; set; }
        public string Circulation_Expiration_Date { get; set; }
        public string Stat { get; set; }
        public string Picture { get; set; }
        public string Deleted { get; set; }
    
        public virtual BODY_TYPE BODY_TYPE { get; set; }
        public virtual MINISTRY MINISTRY { get; set; }
        public virtual MODEL MODEL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICLE_FUEL_SUPPLY> VEHICLE_FUEL_SUPPLY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSURANCE> ASSURANCEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MOT> MOTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULE> SCHEDULEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPAIR> REPAIRs { get; set; }
    }
}
