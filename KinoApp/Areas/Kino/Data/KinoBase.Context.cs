//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KinoApp.Areas.Kino.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KinoAPPEntities : DbContext
    {
        public KinoAPPEntities()
            : base("name=KinoAPPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<MovieDescription> MovieDescription { get; set; }
        public virtual DbSet<UsersMovie> UsersMovie { get; set; }
    }
}
