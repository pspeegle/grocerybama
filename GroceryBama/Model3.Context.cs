﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroceryBama
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GroceryBamaEntities3 : DbContext
    {
        public GroceryBamaEntities3()
            : base("name=GroceryBamaEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ADDRESS> ADDRESS { get; set; }
        public virtual DbSet<BUYER> BUYER { get; set; }
        public virtual DbSet<GROCERYSTORE> GROCERYSTORE { get; set; }
        public virtual DbSet<ITEM> ITEM { get; set; }
        public virtual DbSet<MANAGES> MANAGES { get; set; }
        public virtual DbSet<ORDERR> ORDERR { get; set; }
        public virtual DbSet<SYSTEMINFORMATION> SYSTEMINFORMATION { get; set; }
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<DELIVERED_BY> DELIVERED_BY { get; set; }
        public virtual DbSet<ORDERFROM> ORDERFROM { get; set; }
        public virtual DbSet<PAYMENT> PAYMENT { get; set; }
        public virtual DbSet<SELECTITEM> SELECTITEM { get; set; }
    }
}