﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoJQueryDatatable.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<APPOINTMENT> APPOINTMENTs { get; set; }
        public virtual DbSet<APPOINTMENT_NOTE> APPOINTMENT_NOTE { get; set; }
        public virtual DbSet<CONSULTANT_TYPE> CONSULTANT_TYPE { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<DOCTOR> DOCTORs { get; set; }
        public virtual DbSet<MODE_OF_CONSULTING> MODE_OF_CONSULTING { get; set; }
        public virtual DbSet<PATIENT> PATIENTs { get; set; }
        public virtual DbSet<PRESCRIPTION> PRESCRIPTIONs { get; set; }
        public virtual DbSet<QUALIFICATION> QUALIFICATIONs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULEs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
    }
}
