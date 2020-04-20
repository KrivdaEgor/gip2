using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database
{
    public partial class DatabaseContext : IdentityDbContext<IdentityUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<ClassRooms> ClassRooms { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Lectures> Lectures { get; set; }
        public virtual DbSet<LecturesPool> LecturesPool { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassRooms>(entity =>
            {
                entity.HasKey(e => e.IdClassRoom)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdClassRoom)
                    .HasColumnName("idClassRoom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Capacity).HasColumnType("int(11)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("char(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Resource)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasKey(e => e.IdGroup)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdGroup)
                    .HasColumnName("idGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(75)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Lectures>(entity =>
            {
                entity.HasKey(e => e.IdLecture)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdClassRoom)
                    .HasName("idClassRoom_idx");

                entity.HasIndex(e => e.IdSubject)
                    .HasName("idSubject_idx");

                entity.Property(e => e.IdLecture)
                    .HasColumnName("idLecture")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.IdClassRoom)
                    .HasColumnName("idClassRoom")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSubject)
                    .IsRequired()
                    .HasColumnName("idSubject")
                    .HasColumnType("char(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdClassRoomNavigation)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.IdClassRoom)
                    .HasConstraintName("idClassRoom");

                entity.HasOne(d => d.IdSubjectNavigation)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.IdSubject)
                    .HasConstraintName("idSubject");
            });

            modelBuilder.Entity<LecturesPool>(entity =>
            {
                entity.HasKey(e => e.IdLecturesPool)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLecture)
                    .HasName("idLecture_idx");

                entity.HasIndex(e => e.IdUser)
                    .HasName("idUser_idx");

                entity.Property(e => e.IdLecturesPool)
                    .HasColumnName("idLecturesPool")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdLecture)
                    .HasColumnName("idLecture")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    /*.HasColumnType("")*/;

                entity.HasOne(d => d.IdLectureNavigation)
                    .WithMany(p => p.LecturesPool)
                    .HasForeignKey(d => d.IdLecture)
                    .HasConstraintName("idLecture");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.LecturesPool)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("Id");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.IdSubject)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdSubject)
                    .HasColumnName("idSubject")
                    .HasColumnType("char(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StudentPoints).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.IdGroup)
                    .HasName("idGroup_idx");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("char(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("char(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IdGroup)
                    .HasColumnName("idGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("char(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnType("char(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeUser).HasColumnType("int(11)");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdGroup)
                    .HasConstraintName("idGroup");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
