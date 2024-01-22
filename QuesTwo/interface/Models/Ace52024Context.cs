using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace flightbooking.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Flightdetail> Flightdetails { get; set; }

    public virtual DbSet<Kushairport> Kushairports { get; set; }

    public virtual DbSet<Kushbook> Kushbooks { get; set; }

    public virtual DbSet<Kushbooking> Kushbookings { get; set; }

    public virtual DbSet<Kushcustomer> Kushcustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("admin");

            entity.Property(e => e.Aname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("aname");
            entity.Property(e => e.Apwd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apwd");
        });

        modelBuilder.Entity<Flightdetail>(entity =>
        {
            entity.HasKey(e => e.FlightDid).HasName("PK__flightde__DEAA0BB52A18CD42");

            entity.ToTable("flightdetail");

            entity.Property(e => e.FlightDid).HasColumnName("flightDid");
            entity.Property(e => e.Departure)
                .HasColumnType("datetime")
                .HasColumnName("departure");
            entity.Property(e => e.Destination)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("destination");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Source)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("source");
        });

        modelBuilder.Entity<Kushairport>(entity =>
        {
            entity.HasKey(e => e.Aid).HasName("PK__Kushairp__C6970A10301F0BEF");

            entity.ToTable("Kushairport");

            entity.Property(e => e.Aid).ValueGeneratedNever();
            entity.Property(e => e.Alocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Aname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kushbook>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("PK__Kushbook__3DE1DE3FC5CC177C");

            entity.ToTable("Kushbook");

            entity.Property(e => e.Bookdate).HasColumnType("datetime");
            entity.Property(e => e.FlightsDid).HasColumnName("flightsDid");

            entity.HasOne(d => d.Custo).WithMany(p => p.Kushbooks)
                .HasForeignKey(d => d.Custoid)
                .HasConstraintName("FK__Kushbook__Custoi__22EA20B8");

            // entity.HasOne(d => d.FlightsDid).WithMany(p => p.Kushbooks)
            //     .HasForeignKey(d => d.FlightsDid)
            //     .HasConstraintName("FK__Kushbook__flight__21F5FC7F");
        });

        modelBuilder.Entity<Kushbooking>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("PK__Kushbook__3DE1DE3F71A6DBCA");

            entity.ToTable("Kushbooking");

            entity.Property(e => e.Bookdate).HasColumnType("datetime");

            entity.HasOne(d => d.Cust).WithMany(p => p.Kushbookings)
                .HasForeignKey(d => d.Custid)
                .HasConstraintName("FK__Kushbooki__Custi__05C3D225");
        });

        modelBuilder.Entity<Kushcustomer>(entity =>
        {
            entity.HasKey(e => e.Custid).HasName("PK__Kushcust__049D3E81D96825FD");

            entity.ToTable("Kushcustomer");

            entity.Property(e => e.Custid).ValueGeneratedNever();
            entity.Property(e => e.Custadr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Custname)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Custphno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Custpwd)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
