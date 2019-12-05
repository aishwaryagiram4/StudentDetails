using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentDetails.Models
{
    public partial class StudentDBContext : DbContext
    {
        public StudentDBContext()
        {
        }
        public StudentDBContext(DbContextOptions<StudentDBContext> options)
            : base(options)
        {
        }
        // //entities
        public virtual DbSet<LoginTable> LoginTable { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
             modelBuilder.Entity<LoginTable>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__LoginTab__7ED91ACF3CC7C2A3");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            


            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudId)
                    .HasName("PK__Students__F5C0A7FF436C4713");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CratedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Marks).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
