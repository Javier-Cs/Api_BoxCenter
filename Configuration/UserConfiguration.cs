using Api_BoxCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_BoxCenter.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // eto lo entendi 
            // nombre de la tabla 
            builder.ToTable("usuario_tbl");

            builder.HasKey(x => x.IdUsuario);

            //id de usuario
            builder.Property(x => x.IdUsuario)
                .HasColumnName("id_usuario");

            //id de empresa 
            builder.Property(x => x.EmpresaId)
                .HasColumnName("empresa_id")
                .IsRequired();

            builder.Property(x => x.NombreUser)
                .HasColumnName("nombre_user")
                .HasMaxLength(70)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.Rol)
                .HasColumnName("rol")
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .HasMaxLength(70)
                .IsUnicode(false)
                .IsRequired();


            builder.Property(x => x.PassHash)
                .HasColumnName("pass_hash")
                .HasMaxLength(300)
                .IsUnicode(false)
                .IsRequired();


            builder.Property(x => x.UrlImgUser)
                .HasColumnName("url_img_user")
                .HasMaxLength(300)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.EstadoUser)
                .HasColumnName("estado_user")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.FechaModificacion)
                .HasColumnName("fecha_modificacion")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();


            // indice unico de nombre de empresa e email de usuario
            builder.HasIndex(x => new
            {
                x.EmpresaId,
                x.Email
            })
                .IsUnique();


            //explicame esto
            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
