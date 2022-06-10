using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.DBModels
{
    public partial class BankContext : DbContext
    {
        public BankContext()
        {
        }

        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Balance> Balances { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAccountMapping> UserAccountMappings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KARTHIK-WINDOWS\\KARTHIK;Database=Bank;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountHolderName).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("date");
            });

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.ToTable("Balance");

                entity.Property(e => e.BalanceId).HasColumnName("BalanceID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Balance1)
                    .HasColumnType("money")
                    .HasColumnName("Balance");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Balances)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Balance_Account");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.TransactionFlow).HasMaxLength(50);

                entity.Property(e => e.TransactionMode).HasMaxLength(50);

                entity.Property(e => e.TransactionStatusId).HasColumnName("TransactionStatusID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transaction_Account");

                entity.HasOne(d => d.TransactionStatus)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionStatusId)
                    .HasConstraintName("FK_Transaction_TransactionStatus");
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.ToTable("TransactionStatus");

                entity.Property(e => e.TransactionStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("TransactionStatusID");

                entity.Property(e => e.TransactionStatus1)
                    .HasMaxLength(50)
                    .HasColumnName("TransactionStatus");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.AddressCity).IsUnicode(false);

                entity.Property(e => e.AddressPinCode).IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            modelBuilder.Entity<UserAccountMapping>(entity =>
            {
                entity.ToTable("UserAccountMapping");

                entity.Property(e => e.UserAccountMappingId).HasColumnName("UserAccountMappingID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserAccountMappings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccountMapping_Account");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAccountMappings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAccountMapping_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
