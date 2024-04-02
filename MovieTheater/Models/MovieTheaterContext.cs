using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieTheater.Models;

public partial class MovieTheaterContext : DbContext
{
    public MovieTheaterContext()
    {
    }

    public MovieTheaterContext(DbContextOptions<MovieTheaterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Saloon> Saloons { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Week> Weeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-KVVGNCFL\\SQLEXPRESS;database=MovieTheater;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3214EC27503971ED");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC272799F394");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.GenreId).HasColumnName("Genre_Id");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("FK__Movies__Genre_Id__73BA3083");
        });

        modelBuilder.Entity<Saloon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Saloons__3214EC27E6175FA5");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MovieId).HasColumnName("Movie_Id");

            entity.HasOne(d => d.Movie).WithMany(p => p.Saloons)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Saloons__Movie_I__04E4BC85");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MovieId).HasColumnName("Movie_Id");
            entity.Property(e => e.SaloonId).HasColumnName("SaloonID");
            entity.Property(e => e.SessionTime).HasColumnType("datetime");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.WeekId).HasColumnName("WeekID");

            entity.HasOne(d => d.Movie).WithMany()
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Sessions__Movie___17036CC0");

            entity.HasOne(d => d.Saloon).WithMany()
                .HasForeignKey(d => d.SaloonId)
                .HasConstraintName("FK__Sessions__Saloon__18EBB532");

            entity.HasOne(d => d.Ticket).WithMany()
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Sessions__Ticket__19DFD96B");

            entity.HasOne(d => d.Week).WithMany()
                .HasForeignKey(d => d.WeekId)
                .HasConstraintName("FK__Sessions__WeekID__17F790F9");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3214EC27B9D9D907");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Week>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Weeks__3214EC27DEFB7E0E");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Week1).HasColumnName("Week");
            entity.Property(e => e.WeekFirstDay).HasMaxLength(50);
            entity.Property(e => e.WeekLastDay).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
