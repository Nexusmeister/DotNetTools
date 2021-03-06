﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tools.Core.Models.Administration;

namespace Tools.Core.Datenzugriff.Administration.EntityMapConfig
{
    public class CustomizingConfiguration : IEntityTypeConfiguration<Customizing>
    {
        public void Configure(EntityTypeBuilder<Customizing> entity)
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id);

            entity.Property(e => e.Aenderungsdatum)
                .HasColumnType("datetime")
                .HasComment("Zeitpunkt der letzten Änderung");

            entity.Property(e => e.Anlagedatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasComment("Anlagezeitpunkt des Eintrags");

            entity.Property(e => e.Beschreibung)
                .IsUnicode(false)
                .HasMaxLength(250)
                .IsRequired(true)
                .HasComment("Beschreibung des Customizing-Eintrags");

            entity.Property(e => e.IntWert).HasComment("Integer Customizing");

            entity.Property(e => e.StringWert)
                .IsUnicode(false)
                .HasMaxLength(200)
                .HasComment("String Customizing");
        }
    }
}
