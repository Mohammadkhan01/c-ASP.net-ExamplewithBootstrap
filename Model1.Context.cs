﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class aaa95_anjuman_testEntities2 : DbContext
    {
        public aaa95_anjuman_testEntities2()
            : base("name=aaa95_anjuman_testEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<distribution> distributions { get; set; }
        public virtual DbSet<Fund> Funds { get; set; }
        public virtual DbSet<Fund_Contribution> Fund_Contribution { get; set; }
        public virtual DbSet<Fund_distribution> Fund_distribution { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<ScholarshipCandidateTable> ScholarshipCandidateTables { get; set; }
        public virtual DbSet<SecurityCodeCD> SecurityCodeCDs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<Bank_Account> Bank_Account { get; set; }
    }
}