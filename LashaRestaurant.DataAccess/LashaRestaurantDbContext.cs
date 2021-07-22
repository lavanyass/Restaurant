using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LashaRestaurant.DataAccess.Models;

namespace LashaRestaurant.DataAccess
{
    public partial class LashaRestaurantDbContext : DbContext
    {
        public LashaRestaurantDbContext()
        {
        }

        public LashaRestaurantDbContext(DbContextOptions<LashaRestaurantDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeBankAccount> EmployeeBankAccount { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=host.docker.internal;Initial Catalog=Restaurant_DB;User ID=sa;Password=StrongPassword!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmployeeFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EmployeeBankAccount>(entity =>
            {
                entity.Property(e => e.EmployeeBankAccountId).ValueGeneratedNever();

                entity.Property(e => e.BankAccountNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoutingNumber).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeBankAccount)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeBankAccount_Employee");
            });

            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.Property(e => e.SalaryAmt).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SalaryDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSalary)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSalary_Employee");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
