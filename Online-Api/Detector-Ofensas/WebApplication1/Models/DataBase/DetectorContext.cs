﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class DetectorContext : DbContext
{
    public DetectorContext(DbContextOptions<DetectorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FalsoPositivo> FalsoPositivos { get; set; }

    public virtual DbSet<Ofensa> Ofensas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FalsoPositivo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("falso_positivo");

            entity.HasIndex(e => e.SOfensa, "UQ__falso_po__95A33635A0337FA8").IsUnique();

            entity.Property(e => e.SOfensa)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("S_ofensa");
            entity.Property(e => e.SPalavra)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("S_palavra");
        });

        modelBuilder.Entity<Ofensa>(entity =>
        {
            entity
                .HasKey(O => O.SOfensa);


            entity.HasIndex(e => e.SOfensa, "UQ__ofensas__95A33635BC0CB215").IsUnique();

            entity.Property(e => e.NNivel).HasColumnName("N_nivel");
            entity.Property(e => e.SOfensa)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("S_ofensa");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}