using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UESAN.INVES.CORE.Core.Entities;

namespace UESAN.INVES.CORE.Infrastructure.Data;

public partial class VdiIntranetContext : DbContext
{
    public VdiIntranetContext()
    {
    }

    public VdiIntranetContext(DbContextOptions<VdiIntranetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accesos> Accesos { get; set; }

    public virtual DbSet<Asignaciones> Asignaciones { get; set; }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<FaqChatbot> FaqChatbot { get; set; }

    public virtual DbSet<FormularioInvestigacion> FormularioInvestigacion { get; set; }

    public virtual DbSet<Notificaciones> Notificaciones { get; set; }

    public virtual DbSet<Publicaciones> Publicaciones { get; set; }

    public virtual DbSet<PublicacionesGuardadas> PublicacionesGuardadas { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    // NO OLVIDEN REVISAR QUE LA BASE DE DATOS ESTE CONECTADO A SU USUARIO 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JEFFFERSON;Database=VDI_Intranet;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accesos>(entity =>
        {
            entity.HasKey(e => e.AccesoId).HasName("PK__Accesos__66CA1179EBF107AB");

            entity.Property(e => e.AccesoId).HasColumnName("AccesoID");
            entity.Property(e => e.FechaHoraAcceso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Accesos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Accesos__Usuario__2D27B809");
        });

        modelBuilder.Entity<Asignaciones>(entity =>
        {
            entity.HasKey(e => e.AsignacionId).HasName("PK__Asignaci__D82B5BB79F37C07A");

            entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PublicacionId).HasColumnName("PublicacionID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Publicacion).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.PublicacionId)
                .HasConstraintName("FK__Asignacio__Publi__3D5E1FD2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Asignacio__Usuar__3C69FB99");
        });

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C5C72192EA");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.NombreCategoria).HasMaxLength(255);
        });

        modelBuilder.Entity<FaqChatbot>(entity =>
        {
            entity.HasKey(e => e.Faqid).HasName("PK__FAQ_Chat__4B89D1E2F1B2DC5B");

            entity.ToTable("FAQ_Chatbot");

            entity.Property(e => e.Faqid).HasColumnName("FAQID");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PreguntaClave).HasMaxLength(255);
            entity.Property(e => e.Visible).HasDefaultValue(true);
        });

        modelBuilder.Entity<FormularioInvestigacion>(entity =>
        {
            entity.HasKey(e => e.FormularioId).HasName("PK__Formular__02C09CF3EDC10AD0");

            entity.Property(e => e.FormularioId).HasColumnName("FormularioID");
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.AsignacionId).HasColumnName("AsignacionID");
            entity.Property(e => e.CategoriaRenacyt).HasMaxLength(100);
            entity.Property(e => e.CodigoProy)
                .HasMaxLength(35)
                .HasComputedColumnSql("('PROY_'+CONVERT([nvarchar],[FormularioID]))", false)
                .HasColumnName("Codigo_PROY");
            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .HasColumnName("DNI");
            entity.Property(e => e.EditorialUniversidad).HasMaxLength(255);
            entity.Property(e => e.GradoAcademico).HasMaxLength(100);
            entity.Property(e => e.IssnIsbn)
                .HasMaxLength(50)
                .HasColumnName("ISSN_ISBN");
            entity.Property(e => e.LineaInvestigacion).HasMaxLength(255);
            entity.Property(e => e.MontoApc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MontoAPC");
            entity.Property(e => e.NombrePublicacion).HasMaxLength(255);
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.PosgradoPregrado).HasMaxLength(50);
            entity.Property(e => e.RegimenDedicacion).HasMaxLength(100);
            entity.Property(e => e.TituloProyecto).HasMaxLength(255);

            entity.HasOne(d => d.Asignacion).WithMany(p => p.FormularioInvestigacion)
                .HasForeignKey(d => d.AsignacionId)
                .HasConstraintName("FK__Formulari__Asign__403A8C7D");
        });

        modelBuilder.Entity<Notificaciones>(entity =>
        {
            entity.HasKey(e => e.NotificacionId).HasName("PK__Notifica__BCC120C4CF94971E");

            entity.Property(e => e.NotificacionId).HasColumnName("NotificacionID");
            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Leido).HasDefaultValue(false);
            entity.Property(e => e.Mensaje).HasMaxLength(500);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificaciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Notificac__Usuar__44FF419A");
        });

        modelBuilder.Entity<Publicaciones>(entity =>
        {
            entity.HasKey(e => e.PublicacionId).HasName("PK__Publicac__10DF15AA2E724548");

            entity.Property(e => e.PublicacionId).HasColumnName("PublicacionID");
            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("Disponible");
            entity.Property(e => e.IncentivoUsd)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("IncentivoUSD");
            entity.Property(e => e.Issn)
                .HasMaxLength(20)
                .HasColumnName("ISSN");
            entity.Property(e => e.Issn2)
                .HasMaxLength(20)
                .HasColumnName("ISSN2");
            entity.Property(e => e.Issn3)
                .HasMaxLength(20)
                .HasColumnName("ISSN3");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Puntaje).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Publicaciones)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Publicaci__Categ__32E0915F");
        });

        modelBuilder.Entity<PublicacionesGuardadas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publicac__3214EC277A13B37C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaGuardado)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PublicacionId).HasColumnName("PublicacionID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Publicacion).WithMany(p => p.PublicacionesGuardadas)
                .HasForeignKey(d => d.PublicacionId)
                .HasConstraintName("FK__Publicaci__Publi__37A5467C");

            entity.HasOne(d => d.Usuario).WithMany(p => p.PublicacionesGuardadas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Publicaci__Usuar__36B12243");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__F92302D1E4CF511C");

            entity.Property(e => e.RolId).HasColumnName("RolID");
            entity.Property(e => e.NombreRol).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE79830AF430C");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A1909E7469D").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RolId).HasColumnName("RolID");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__RolID__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
