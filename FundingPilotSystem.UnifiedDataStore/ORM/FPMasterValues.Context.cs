﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FundingPilotSystem.UnifiedDataStore.ORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FPMasterValuesEntities : DbContext
    {
        public FPMasterValuesEntities()
            : base("name=FPMasterValuesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAccountOpeningField> tblAccountOpeningFields { get; set; }
        public virtual DbSet<tblCompanyIndustryList> tblCompanyIndustryLists { get; set; }
        public virtual DbSet<tblCountryList> tblCountryLists { get; set; }
        public virtual DbSet<tblCountryOfOperation> tblCountryOfOperations { get; set; }
        public virtual DbSet<tblKYCStatus> tblKYCStatuses { get; set; }
        public virtual DbSet<tblPublicAuthorityIndustryList> tblPublicAuthorityIndustryLists { get; set; }
        public virtual DbSet<tblSupportedAccountType> tblSupportedAccountTypes { get; set; }
        public virtual DbSet<tblSupportedCurrency> tblSupportedCurrencies { get; set; }
        public virtual DbSet<tblSupportedLanguage> tblSupportedLanguages { get; set; }
        public virtual DbSet<tblSystemModule> tblSystemModules { get; set; }
        public virtual DbSet<tblUserStatus> tblUserStatuses { get; set; }
        public virtual DbSet<tblUserType> tblUserTypes { get; set; }
    }
}