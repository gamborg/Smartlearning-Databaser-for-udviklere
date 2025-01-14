using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Skoleinfo.Api.Models;

public partial class SkoleinfoContext : DbContext
{
    public SkoleinfoContext(DbContextOptions<SkoleinfoContext> options)
        : base(options)
    {
        InstitutionAvgScores = Set<InstitutionAvgScore>();
        Institutioners = Set<Institutioner>();
        Institutionsoplysningers = Set<Institutionsoplysninger>();
        Karakterers = Set<Karakterer>();
        Koens = Set<Koen>();
        Kommuners = Set<Kommuner>();
        Sporgsmaals = Set<Sporgsmaal>();
        Svars = Set<Svar>();
        Trivsels = Set<Trivsel>();
        TrivselViews = Set<TrivselView>();
    }

    public virtual DbSet<InstitutionAvgScore> InstitutionAvgScores { get; set; }

    public virtual DbSet<Institutioner> Institutioners { get; set; }

    public virtual DbSet<Institutionsoplysninger> Institutionsoplysningers { get; set; }

    public virtual DbSet<Karakterer> Karakterers { get; set; }

    public virtual DbSet<Koen> Koens { get; set; }

    public virtual DbSet<Kommuner> Kommuners { get; set; }

    public virtual DbSet<Sporgsmaal> Sporgsmaals { get; set; }

    public virtual DbSet<Svar> Svars { get; set; }

    public virtual DbSet<Trivsel> Trivsels { get; set; }

    public virtual DbSet<TrivselView> TrivselViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InstitutionAvgScore>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("institution_avg_score");

            entity.Property(e => e.AverageScore)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("average_score");
            entity.Property(e => e.Navn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("navn");
            entity.Property(e => e.Nummer).HasColumnName("nummer");
        });

        modelBuilder.Entity<Institutioner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__institut__3213E83F5C3B68B7");

            entity.ToTable("institutioner");

            entity.HasIndex(e => e.Nummer, "UC_institutioner_nummer").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Kommunenummer).HasColumnName("kommunenummer");
            entity.Property(e => e.Navn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("navn");
            entity.Property(e => e.Nummer).HasColumnName("nummer");

            entity.HasOne(d => d.KommunenummerNavigation).WithMany(p => p.Institutioners)
                .HasPrincipalKey(p => p.Nummer)
                .HasForeignKey(d => d.Kommunenummer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_institutioner_kommuner");
        });

        modelBuilder.Entity<Institutionsoplysninger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__institut__3213E83FEE947810");

            entity.ToTable("institutionsoplysninger");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(200)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("adresse");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("email");
            entity.Property(e => e.GeoBredde)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("geo_bredde");
            entity.Property(e => e.GeoLaengde)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("geo_laengde");
            entity.Property(e => e.Hjemmeside)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("hjemmeside");
            entity.Property(e => e.Navn)
                .HasMaxLength(200)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("navn");
            entity.Property(e => e.Nummer).HasColumnName("nummer");
            entity.Property(e => e.Postnummer)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("postnummer");
            entity.Property(e => e.Telefon)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("telefon");
        });

        modelBuilder.Entity<Karakterer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__karakter__3213E83F65CD290D");

            entity.ToTable("karakterer");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Gennemsnit)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("gennemsnit");
            entity.Property(e => e.Institutionsnummer).HasColumnName("institutionsnummer");
            entity.Property(e => e.Klassetrin).HasColumnName("klassetrin");
            entity.Property(e => e.Koen).HasColumnName("koen");
            entity.Property(e => e.Skoleaar)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("skoleaar");

            entity.HasOne(d => d.InstitutionsnummerNavigation).WithMany(p => p.Karakterers)
                .HasPrincipalKey(p => p.Nummer)
                .HasForeignKey(d => d.Institutionsnummer)
                .HasConstraintName("FK_karakterer_institutioner");

            entity.HasOne(d => d.KoenNavigation).WithMany(p => p.Karakterers)
                .HasForeignKey(d => d.Koen)
                .HasConstraintName("FK_karakterer_koen");
        });

        modelBuilder.Entity<Koen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__koen__3213E83FEF35C20F");

            entity.ToTable("koen");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Navn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("navn");
        });

        modelBuilder.Entity<Kommuner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kommuner__3213E83F6D1B3813");

            entity.ToTable("kommuner");

            entity.HasIndex(e => e.Nummer, "UC_kommuner_nummer").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Navn)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("navn");
            entity.Property(e => e.Nummer).HasColumnName("nummer");
        });

        modelBuilder.Entity<Sporgsmaal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sporgsma__3213E83F2AD8043A");

            entity.ToTable("sporgsmaal");

            entity.HasIndex(e => e.Nummer, "UC_sporgsmaal_nummer").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Nummer)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("nummer");
            entity.Property(e => e.Tekst)
                .HasColumnType("text")
                .HasColumnName("tekst");
        });

        modelBuilder.Entity<Svar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__svar__3213E83FC607F0E6");

            entity.ToTable("svar");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Sporgsmaalsnummer)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("sporgsmaalsnummer");
            entity.Property(e => e.Svarnummer).HasColumnName("svarnummer");
            entity.Property(e => e.Tekst)
                .HasColumnType("text")
                .HasColumnName("tekst");

            entity.HasOne(d => d.SporgsmaalsnummerNavigation).WithMany(p => p.Svars)
                .HasPrincipalKey(p => p.Nummer)
                .HasForeignKey(d => d.Sporgsmaalsnummer)
                .HasConstraintName("FK_svar_sporgsmaal");
        });

        modelBuilder.Entity<Trivsel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__trivsel__3213E83F2DA32161");

            entity.ToTable("trivsel");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Institutionsnummer).HasColumnName("institutionsnummer");
            entity.Property(e => e.Koen).HasColumnName("koen");
            entity.Property(e => e.Sporgsmaalsnummer)
                .HasMaxLength(5)
                .IsUnicode(false)
                .UseCollation("Latin1_General_100_BIN2_UTF8")
                .HasColumnName("sporgsmaalsnummer");
            entity.Property(e => e.Svarnummer).HasColumnName("svarnummer");
            entity.Property(e => e.Vaerdi)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("vaerdi");

            entity.HasOne(d => d.SporgsmaalsnummerNavigation).WithMany(p => p.Trivsels)
                .HasPrincipalKey(p => p.Nummer)
                .HasForeignKey(d => d.Sporgsmaalsnummer)
                .HasConstraintName("FK_trivsel_sporgsmaal");
        });

        modelBuilder.Entity<TrivselView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TrivselView");

            entity.Property(e => e.SporgsmaalTekst).HasColumnType("text");
            entity.Property(e => e.SvarTekst).HasColumnType("text");
            entity.Property(e => e.TrivselId).HasColumnName("TrivselID");
            entity.Property(e => e.Vaerdi).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
