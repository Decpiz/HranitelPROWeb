using HranitelPROWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HranitelPROWeb.Data;

public partial class HranitelDBContext : DbContext
{
    public HranitelDBContext()
    {
    }

    public HranitelDBContext(DbContextOptions<HranitelDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Celi> Celis { get; set; }

    public virtual DbSet<CherniySpisok> CherniySpisoks { get; set; }

    public virtual DbSet<Dolzhnosti> Dolzhnostis { get; set; }

    public virtual DbSet<GrupZajavki> GrupZajavkis { get; set; }

    public virtual DbSet<Organizacii> Organizaciis { get; set; }

    public virtual DbSet<Pasport> Pasports { get; set; }

    public virtual DbSet<Podrazdelenium> Podrazdelenia { get; set; }

    public virtual DbSet<Polzovateli> Polzovatelis { get; set; }

    public virtual DbSet<Posetiteli> Posetitelis { get; set; }

    public virtual DbSet<Sotrudniki> Sotrudnikis { get; set; }

    public virtual DbSet<Statusi> Statusis { get; set; }

    public virtual DbSet<Zajavki> Zajavkis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=WIN-D0O9AOUQLF2\\SQLEXPRESSSERVER;" +
            "Database=HranitelPRO_DB_Tests2;" +
            "Trusted_Connection=True;" +
            "MultipleActiveResultSets=true;" +
            "TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Celi>(entity =>
        {
            entity.HasKey(e => e.IdCeli);

            entity.ToTable("Celi");

            entity.Property(e => e.IdCeli).HasColumnName("ID_Celi");
            entity.Property(e => e.Tekst).HasMaxLength(50);
        });

        modelBuilder.Entity<CherniySpisok>(entity =>
        {
            entity.HasKey(e => e.IdCs);

            entity.ToTable("CherniySpisok");

            entity.Property(e => e.IdCs).HasColumnName("ID_CS");
            entity.Property(e => e.Familia).HasMaxLength(30);
            entity.Property(e => e.Imya).HasMaxLength(30);
            entity.Property(e => e.NomerPas)
                .HasMaxLength(6)
                .HasColumnName("Nomer_pas");
            entity.Property(e => e.NomerTelefona)
                .HasMaxLength(16)
                .HasColumnName("Nomer_telefona");
            entity.Property(e => e.Otchestvo).HasMaxLength(30);
            entity.Property(e => e.SeriaPas)
                .HasMaxLength(4)
                .HasColumnName("Seria_pas");
        });

        modelBuilder.Entity<Dolzhnosti>(entity =>
        {
            entity.HasKey(e => e.IdDolzhnosti);

            entity.ToTable("Dolzhnosti");

            entity.Property(e => e.IdDolzhnosti).HasColumnName("ID_Dolzhnosti");
            entity.Property(e => e.Nazvanie).HasMaxLength(50);
        });

        modelBuilder.Entity<GrupZajavki>(entity =>
        {
            entity.HasKey(e => new { e.IdZajavki, e.IdPosetitelia });

            entity.ToTable("GrupZajavki");

            entity.Property(e => e.IdZajavki).HasColumnName("ID_Zajavki");
            entity.Property(e => e.IdPosetitelia).HasColumnName("ID_Posetitelia");
            entity.Property(e => e.A1)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdPosetiteliaNavigation).WithMany(p => p.GrupZajavkis)
                .HasForeignKey(d => d.IdPosetitelia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrupZajavki_Posetiteli");

            entity.HasOne(d => d.IdZajavkiNavigation).WithMany(p => p.GrupZajavkis)
                .HasForeignKey(d => d.IdZajavki)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrupZajavki_Zajavki1");
        });

        modelBuilder.Entity<Organizacii>(entity =>
        {
            entity.HasKey(e => e.IdOrganizacii);

            entity.ToTable("Organizacii");

            entity.Property(e => e.IdOrganizacii).HasColumnName("ID_Organizacii");
            entity.Property(e => e.GenDirFio)
                .HasMaxLength(90)
                .HasColumnName("GenDir_FIO");
            entity.Property(e => e.Inn)
                .HasMaxLength(10)
                .HasColumnName("INN");
            entity.Property(e => e.Nazvanie).HasMaxLength(60);
            entity.Property(e => e.Ogrn)
                .HasMaxLength(13)
                .HasColumnName("OGRN");
        });

        modelBuilder.Entity<Pasport>(entity =>
        {
            entity.HasKey(e => e.IdPasporta);

            entity.ToTable("Pasport");

            entity.Property(e => e.IdPasporta).HasColumnName("ID_Pasporta");
            entity.Property(e => e.DataVidachi)
                .HasColumnType("date")
                .HasColumnName("Data_vidachi");
            entity.Property(e => e.KodPodrazdelenia)
                .HasMaxLength(7)
                .HasColumnName("Kod_podrazdelenia");
            entity.Property(e => e.Nomer).HasMaxLength(6);
            entity.Property(e => e.Seria).HasMaxLength(4);
        });

        modelBuilder.Entity<Podrazdelenium>(entity =>
        {
            entity.HasKey(e => e.IdPodrazdelenia);

            entity.Property(e => e.IdPodrazdelenia).HasColumnName("ID_Podrazdelenia");
            entity.Property(e => e.NazvanieGoroda)
                .HasMaxLength(40)
                .HasColumnName("Nazvanie_goroda");
            entity.Property(e => e.NazvanieYlici)
                .HasMaxLength(40)
                .HasColumnName("Nazvanie_ylici");
            entity.Property(e => e.NomerStroenia).HasColumnName("Nomer_stroenia");
        });

        modelBuilder.Entity<Polzovateli>(entity =>
        {
            entity.HasKey(e => e.IdPolzovatelia).HasName("PK_Polzovateli_1");

            entity.ToTable("Polzovateli");

            entity.Property(e => e.IdPolzovatelia).HasColumnName("ID_Polzovatelia");
            entity.Property(e => e.Email).HasMaxLength(35);
            entity.Property(e => e.Familia).HasMaxLength(30);
            entity.Property(e => e.IdOrganizacii).HasColumnName("ID_Organizacii");
            entity.Property(e => e.Imya).HasMaxLength(30);
            entity.Property(e => e.Login).HasMaxLength(20);
            entity.Property(e => e.Otchestvo).HasMaxLength(30);
            entity.Property(e => e.Parol).HasMaxLength(30);
            entity.Property(e => e.Status).HasMaxLength(1);

            entity.HasOne(d => d.IdOrganizaciiNavigation).WithMany(p => p.Polzovatelis)
                .HasForeignKey(d => d.IdOrganizacii)
                .HasConstraintName("FK_Polzovateli_Organizacii");
        });

        modelBuilder.Entity<Posetiteli>(entity =>
        {
            entity.HasKey(e => e.IdPsetitelia);

            entity.ToTable("Posetiteli");

            entity.Property(e => e.IdPsetitelia).HasColumnName("ID_Psetitelia");
            entity.Property(e => e.DataRozhdenia)
                .HasColumnType("date")
                .HasColumnName("Data_rozhdenia");
            entity.Property(e => e.Email).HasMaxLength(35);
            entity.Property(e => e.Familia).HasMaxLength(30);
            entity.Property(e => e.Imya).HasMaxLength(30);
            entity.Property(e => e.NazvanieOrganizacii)
                .HasMaxLength(50)
                .HasColumnName("Nazvanie_organizacii");
            entity.Property(e => e.NomerPas)
                .HasMaxLength(6)
                .HasColumnName("Nomer_pas");
            entity.Property(e => e.NomerTelefona)
                .HasMaxLength(16)
                .HasColumnName("Nomer_telefona");
            entity.Property(e => e.Otchestvo).HasMaxLength(30);
            entity.Property(e => e.SeriaPas)
                .HasMaxLength(4)
                .HasColumnName("Seria_pas");
        });

        modelBuilder.Entity<Sotrudniki>(entity =>
        {
            entity.HasKey(e => e.IdSotrudnika);

            entity.ToTable("Sotrudniki");

            entity.Property(e => e.IdSotrudnika).HasColumnName("ID_Sotrudnika");
            entity.Property(e => e.Familia).HasMaxLength(50);
            entity.Property(e => e.IdDolzhnosti).HasColumnName("ID_Dolzhnosti");
            entity.Property(e => e.IdPodrazdelenia).HasColumnName("ID_Podrazdelenia");
            entity.Property(e => e.Imya).HasMaxLength(30);
            entity.Property(e => e.KodAvtorizacii)
                .HasMaxLength(8)
                .HasColumnName("Kod_avtorizacii");
            entity.Property(e => e.NomerPas)
                .HasMaxLength(6)
                .HasColumnName("Nomer_pas");
            entity.Property(e => e.Otchestvo).HasMaxLength(30);
            entity.Property(e => e.SeriaPas)
                .HasMaxLength(4)
                .HasColumnName("Seria_pas");

            entity.HasOne(d => d.IdDolzhnostiNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdDolzhnosti)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sotrudniki_Dolzhnosti");

            entity.HasOne(d => d.IdPodrazdeleniaNavigation).WithMany(p => p.Sotrudnikis)
                .HasForeignKey(d => d.IdPodrazdelenia)
                .HasConstraintName("FK_Sotrudniki_Podrazdelenia");
        });

        modelBuilder.Entity<Statusi>(entity =>
        {
            entity.HasKey(e => e.IdStatusa);

            entity.ToTable("Statusi");

            entity.Property(e => e.IdStatusa).HasColumnName("ID_Statusa");
            entity.Property(e => e.Color).HasMaxLength(7);
            entity.Property(e => e.Nazvanie).HasMaxLength(15);
        });

        modelBuilder.Entity<Zajavki>(entity =>
        {
            entity.HasKey(e => e.IdZajavki);

            entity.ToTable("Zajavki");

            entity.Property(e => e.IdZajavki).HasColumnName("ID_Zajavki");
            entity.Property(e => e.DataOformlenia)
                .HasColumnType("date")
                .HasColumnName("Data_oformlenia");
            entity.Property(e => e.DataPoseshenia)
                .HasColumnType("date")
                .HasColumnName("Data_poseshenia");
            entity.Property(e => e.IdCeli).HasColumnName("ID_Celi");
            entity.Property(e => e.IdPodrazdelenia).HasColumnName("ID_Podrazdelenia");
            entity.Property(e => e.IdPolzovatelia).HasColumnName("ID_Polzovatelia");
            entity.Property(e => e.IdStatusa).HasColumnName("ID_Statusa");
            entity.Property(e => e.NomerZajavki)
                .HasMaxLength(12)
                .HasColumnName("Nomer_zajavki");
            entity.Property(e => e.Soobshenie).HasMaxLength(90);

            entity.HasOne(d => d.IdCeliNavigation).WithMany(p => p.Zajavkis)
                .HasForeignKey(d => d.IdCeli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zajavki_Celi");

            entity.HasOne(d => d.IdPodrazdeleniaNavigation).WithMany(p => p.Zajavkis)
                .HasForeignKey(d => d.IdPodrazdelenia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zajavki_Podrazdelenia");

            entity.HasOne(d => d.IdPolzovateliaNavigation).WithMany(p => p.Zajavkis)
                .HasForeignKey(d => d.IdPolzovatelia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zajavki_Polzovateli");

            entity.HasOne(d => d.IdStatusaNavigation).WithMany(p => p.Zajavkis)
                .HasForeignKey(d => d.IdStatusa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Zajavki_Statusi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
