using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PersonPortal.Data.DbModels
{
    public partial class PersonDBContext : DbContext
    {
        public PersonDBContext()
        {
        }

        public PersonDBContext(DbContextOptions<PersonDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonPhone> PersonPhone { get; set; }
        public virtual DbSet<PersonToPerson> PersonToPerson { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<RelationTypes> RelationTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=PersonDB;Trusted_Connection=False;User ID=sa;Password=1234Qwer");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonalNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Person_City");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderiD)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_Gender");
            });

            modelBuilder.Entity<PersonPhone>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PhoneTypeId).HasColumnName("PhoneTypeID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPhone)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_PersonPhone_Person");

                entity.HasOne(d => d.PhoneType)
                    .WithMany(p => p.PersonPhone)
                    .HasForeignKey(d => d.PhoneTypeId)
                    .HasConstraintName("FK_PersonPhone_PhoneType");
            });

            modelBuilder.Entity<PersonToPerson>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.RelatedPersonId).HasColumnName("RelatedPersonID");

                entity.Property(e => e.RelationTypeId).HasColumnName("RelationTypeID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonToPersonPerson)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_PersonToPerson_Person");

                entity.HasOne(d => d.RelatedPerson)
                    .WithMany(p => p.PersonToPersonRelatedPerson)
                    .HasForeignKey(d => d.RelatedPersonId)
                    .HasConstraintName("FK_PersonToPerson_Person1");

                entity.HasOne(d => d.RelationType)
                    .WithMany(p => p.PersonToPerson)
                    .HasForeignKey(d => d.RelationTypeId)
                    .HasConstraintName("FK_PersonToPerson_RelationTypes");
            });

            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RelationTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
