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
    
    public partial class MINISTRY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MINISTRY()
        {
            this.VEHICLEs = new HashSet<VEHICLE>();
            this.VEHICLE_FUEL_SUPPLY = new HashSet<VEHICLE_FUEL_SUPPLY>();
            this.MINISTRY_DRIVER = new HashSet<MINISTRY_DRIVER>();
            this.MINISTRY_REAL_ESTATE = new HashSet<MINISTRY_REAL_ESTATE>();
        }
    
        public int MINISTRY_ID { get; set; }
        public string Code_Min { get; set; }
        public string Ministry_Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Postal_code { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string System_Name { get; set; }
        public string System_Email { get; set; }
        public string System_Title { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICLE> VEHICLEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICLE_FUEL_SUPPLY> VEHICLE_FUEL_SUPPLY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MINISTRY_DRIVER> MINISTRY_DRIVER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MINISTRY_REAL_ESTATE> MINISTRY_REAL_ESTATE { get; set; }
    }
}
