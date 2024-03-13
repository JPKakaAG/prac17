using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prac17.models;

public partial class DevyatkinV11Pr17Context : DbContext
{
    public DevyatkinV11Pr17Context()
    {
    }

    public DevyatkinV11Pr17Context(DbContextOptions<DevyatkinV11Pr17Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Участники> Участникиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Devyatkin_v11_pr17; User=исп-31; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Участники>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Участники");

            entity.Property(e => e.Город).HasMaxLength(50);
            entity.Property(e => e.Имя).HasMaxLength(50);
            entity.Property(e => e.Отчество).HasMaxLength(50);
            entity.Property(e => e.Танец).HasMaxLength(50);
            entity.Property(e => e.Фамилия).HasMaxLength(50);
            entity.Property(e => e.ФамилияТренера)
                .HasMaxLength(50)
                .HasColumnName("Фамилия_тренера");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
