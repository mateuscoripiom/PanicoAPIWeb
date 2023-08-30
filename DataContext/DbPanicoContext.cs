using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PanicoAPIWeb.Models;

namespace PanicoAPIWeb.DataContext;

public partial class DbPanicoContext : DbContext
{
    public DbPanicoContext()
    {
    }

    public DbPanicoContext(DbContextOptions<DbPanicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAtor> TbAtors { get; set; }

    public virtual DbSet<TbObra> TbObras { get; set; }

    public virtual DbSet<TbPersonagen> TbPersonagens { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbPanico;Encrypt =False;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAtor>(entity =>
        {
            entity.HasKey(e => e.IdAtor).HasName("PK__tbAtor__74720FF9D9536671");
        });

        modelBuilder.Entity<TbObra>(entity =>
        {
            entity.HasKey(e => e.IdObra).HasName("PK__tbObra__D4C68C433722FA5D");

            entity.HasMany(d => d.IdPeople).WithMany(p => p.IdObras)
                .UsingEntity<Dictionary<string, object>>(
                    "TbObraPersonagem",
                    r => r.HasOne<TbPersonagen>().WithMany()
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tbObraPer__idPer__4316F928"),
                    l => l.HasOne<TbObra>().WithMany()
                        .HasForeignKey("IdObra")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tbObraPer__idObr__4222D4EF"),
                    j =>
                    {
                        j.HasKey("IdObra", "IdPerson").HasName("PK__tbObraPe__CF6DBF33BD11541F");
                        j.ToTable("tbObraPersonagem");
                        j.IndexerProperty<int>("IdObra").HasColumnName("idObra");
                        j.IndexerProperty<int>("IdPerson").HasColumnName("idPerson");
                    });
        });

        modelBuilder.Entity<TbPersonagen>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("PK__tbPerson__BAB3370059C8F4A6");

            entity.HasMany(d => d.IdAtors).WithMany(p => p.IdPeople)
                .UsingEntity<Dictionary<string, object>>(
                    "TbAtorPersonagem",
                    r => r.HasOne<TbAtor>().WithMany()
                        .HasForeignKey("IdAtor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tbAtorPer__idAto__3F466844"),
                    l => l.HasOne<TbPersonagen>().WithMany()
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tbAtorPer__idPer__3E52440B"),
                    j =>
                    {
                        j.HasKey("IdPerson", "IdAtor").HasName("PK__tbAtorPe__3DF417FFE6A7574E");
                        j.ToTable("tbAtorPersonagem");
                        j.IndexerProperty<int>("IdPerson").HasColumnName("idPerson");
                        j.IndexerProperty<int>("IdAtor").HasColumnName("idAtor");
                    });
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__tbUser__3717C98279C7D003");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
