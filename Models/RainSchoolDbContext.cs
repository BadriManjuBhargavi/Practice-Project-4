using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PProject4.Models;

public partial class RainSchoolDbContext : DbContext
{
    public RainSchoolDbContext()
    {
    }

    public RainSchoolDbContext(DbContextOptions<RainSchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsMark> StudentsMarks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-JPNMO15;database=RainSchoolDb;trusted_connection=true;TrustserverCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B9993586EBD");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.StudentName).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentsMark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0768D4473C");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Subject).HasMaxLength(50);

            entity.HasOne(d => d.StudentsNavigation).WithMany(p => p.StudentsMarks)
                .HasForeignKey(d => d.Students)
                .HasConstraintName("FK__StudentsM__Stude__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
