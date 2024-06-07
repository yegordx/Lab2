using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data;

public partial class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    public virtual DbSet<Operation> Operations { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-QGR2O71\\SQLEXPRESS; Database=DB_lab2; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__doctor__3213E83F98A88CA2");

            entity.ToTable("doctor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Info).HasColumnName("info");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Post)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("post");
            entity.Property(e => e.SecondName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("second_name");
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hospital__3213E83FBF42680C");

            entity.ToTable("hospital");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
        });

        modelBuilder.Entity<Operation>(entity =>
        {
            entity.HasKey(e => new { e.DoctorId, e.PatientId, e.HospitalId }).HasName("PK__operatio__F9930F35DC190504");

            entity.ToTable("operation");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Info)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("info");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Operations)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__operation__docto__74AE54BC");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Operations)
                .HasForeignKey(d => d.HospitalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__operation__hospi__76969D2E");

            entity.HasOne(d => d.Patient).WithMany(p => p.Operations)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__operation__patie__75A278F5");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__patient__3213E83F9EB5A13E");

            entity.ToTable("patient");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.SecondName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("second_name");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.DoctorId }).HasName("PK__review__1265772095F4E687");

            entity.ToTable("review");

            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Text).HasColumnName("text");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__review__doctor_i__07C12930");

            entity.HasOne(d => d.Patient).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__review__patient___06CD04F7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
