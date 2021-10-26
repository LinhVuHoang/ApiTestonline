using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Project3.Models
{
    public partial class Projectky3Context : DbContext
    {
       

        public Projectky3Context(DbContextOptions<Projectky3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Qexam> Qexams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<User> Users { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.Idexam);

                entity.Property(e => e.Idexam).HasColumnName("idexam");

                entity.Property(e => e.Dateexam).HasColumnType("date");

                entity.Property(e => e.Lodifficult)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Qexam>(entity =>
            {
                entity.Property(e => e.Datemake).HasColumnType("date");

                entity.HasOne(d => d.IdexamNavigation)
                    .WithMany(p => p.Qexams)
                    .HasForeignKey(d => d.Idexam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Qexams_Exams");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.Qexams)
                    .HasForeignKey(d => d.Question)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Qexams_Questions");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Idquestion);

                entity.Property(e => e.Answer1false).IsRequired();

                entity.Property(e => e.Answer2false).IsRequired();

                entity.Property(e => e.Answer3false).IsRequired();

                entity.Property(e => e.Answertrue).IsRequired();

                entity.Property(e => e.Contentq).IsRequired();

                entity.Property(e => e.Dateq).HasColumnType("date");

                entity.Property(e => e.Lodifficult)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Point).HasColumnType("decimal(18, 10)");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.RankNavigation)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.Rank)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ratings_Results");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(e => e.Idresult);

                entity.Property(e => e.Point).HasColumnType("decimal(18, 10)");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ConfirmPassword).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
