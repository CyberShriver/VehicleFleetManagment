﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MINISTRY_DB_Connection : DbContext
    {
        public MINISTRY_DB_Connection()
            : base("name=MINISTRY_DB_Connection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BODY_TYPE> BODY_TYPE { get; set; }
        public virtual DbSet<MARK> MARKs { get; set; }
        public virtual DbSet<MODEL> MODELs { get; set; }
        public virtual DbSet<PROVIDER> PROVIDERs { get; set; }
        public virtual DbSet<REAL_ESTATE> REAL_ESTATE { get; set; }
        public virtual DbSet<DRIVER> DRIVERs { get; set; }
        public virtual DbSet<LEAVE_TYPE> LEAVE_TYPE { get; set; }
    }
}
