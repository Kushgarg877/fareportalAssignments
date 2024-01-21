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

    public virtual DbSet<Kushairport> Kushairports { get; set; }

    public virtual DbSet<Kushbooking> Kushbookings { get; set; }

    public virtual DbSet<Kushcustomer> Kushcustomers { get; set; }

    public virtual DbSet<Kushflight> Kushflights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<Kushbooking>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("PK__Kushbook__3DE1DE3F71A6DBCA");

            entity.ToTable("Kushbooking");

            entity.Property(e => e.Bookdate).HasColumnType("datetime");

            entity.HasOne(d => d.Cust).WithMany(p => p.Kushbookings)
                .HasForeignKey(d => d.Custid)
                .HasConstraintName("FK__Kushbooki__Custi__05C3D225");

            entity.HasOne(d => d.Flight).WithMany(p => p.Kushbookings)
                .HasForeignKey(d => d.Flightid)
                .HasConstraintName("FK__Kushbooki__Fligh__04CFADEC");
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

        modelBuilder.Entity<Kushflight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Kushflig__8A9E14EE3094E2BA");

            entity.ToTable("Kushflight");

            entity.Property(e => e.FlightId).ValueGeneratedNever();
            entity.Property(e => e.Arrtime).HasColumnType("datetime");
            entity.Property(e => e.Deptime).HasColumnType("datetime");
            entity.Property(e => e.Flightname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Arr).WithMany(p => p.KushflightArrs)
                .HasForeignKey(d => d.Arrid)
                .HasConstraintName("FK__Kushfligh__Arrid__01F34141");

            entity.HasOne(d => d.Cust).WithMany(p => p.Kushflights)
                .HasForeignKey(d => d.Custid)
                .HasConstraintName("FK__Kushfligh__Custi__000AF8CF");

            entity.HasOne(d => d.Dep).WithMany(p => p.KushflightDeps)
                .HasForeignKey(d => d.Depid)
                .HasConstraintName("FK__Kushfligh__Depid__00FF1D08");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
