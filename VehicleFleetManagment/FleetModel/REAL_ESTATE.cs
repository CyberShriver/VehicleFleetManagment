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
    
    public partial class REAL_ESTATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REAL_ESTATE()
        {
            this.MINISTRY_REAL_ESTATE = new HashSet<MINISTRY_REAL_ESTATE>();
        }
    
        public int REAL_ESTATE_ID { get; set; }
        public string RealEstate_Name { get; set; }
        public string Comment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MINISTRY_REAL_ESTATE> MINISTRY_REAL_ESTATE { get; set; }
    }
}