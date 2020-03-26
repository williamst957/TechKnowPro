namespace TechKnowPro.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Techknowprocontext : DbContext
    {
        public Techknowprocontext()
            : base("name=Techknowprocontext")
        {
        }

        public virtual DbSet<ContactList> ContactLists { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>()
                .Property(e => e.IncidentNo)
                .IsUnicode(false);

            modelBuilder.Entity<Incident>()
                .HasMany(e => e.Surveys)
                .WithRequired(e => e.Incident)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Register>()
                .HasMany(e => e.ContactLists)
                .WithRequired(e => e.Register)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Register>()
                .HasMany(e => e.Incidents)
                .WithRequired(e => e.Register)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecurityQuestion>()
                .Property(e => e.Questions)
                .IsUnicode(false);
        }
    }
}
