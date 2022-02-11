using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dating.Models
{
    public partial class DateContext : DbContext
    {
        public DateContext()
        {
        }

        public DateContext(DbContextOptions<DateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Foodlist> Foodlist { get; set; }
        public virtual DbSet<Hobby> Hobby { get; set; }
        public virtual DbSet<Hobbylist> Hobbylist { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SREEHARIPRATHAP\\SQLEXPRESS;Database=Date;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("food");

                entity.Property(e => e.FoodId)
                    .HasColumnName("foodId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Food1)
                    .HasColumnName("food")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Foodlist>(entity =>
            {
                entity.ToTable("foodlist");

                entity.Property(e => e.FoodListId)
                    .HasColumnName("foodListId")
                    .ValueGeneratedNever();

                entity.Property(e => e.FoodId).HasColumnName("foodId");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Foodlist)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__foodlist__foodId__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Foodlist)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__foodlist__user_i__2F10007B");
            });

            modelBuilder.Entity<Hobby>(entity =>
            {
                entity.ToTable("hobby");

                entity.Property(e => e.HobbyId).HasColumnName("hobby_id");

                entity.Property(e => e.Hobby1)
                    .HasColumnName("hobby")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hobbylist>(entity =>
            {
                entity.ToTable("hobbylist");

                entity.Property(e => e.HobbylistId)
                    .HasColumnName("hobbylist_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.HobbyId).HasColumnName("hobby_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Hobby)
                    .WithMany(p => p.Hobbylist)
                    .HasForeignKey(d => d.HobbyId)
                    .HasConstraintName("FK__hobbylist__hobby__34C8D9D1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Hobbylist)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__hobbylist__user___33D4B598");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovId)
                    .HasName("PK__movie__0FDA8B2AB3CC4C7F");

                entity.ToTable("movie");

                entity.Property(e => e.MovId)
                    .HasColumnName("movId")
                    .ValueGeneratedNever();

                entity.Property(e => e.MovieGenre)
                    .HasColumnName("movieGenre")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__B9BE370F5C1AFD43");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MovId).HasColumnName("movId");

                entity.Property(e => e.Occupation)
                    .HasColumnName("occupation")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mov)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.MovId)
                    .HasConstraintName("FK__Users__movId__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
