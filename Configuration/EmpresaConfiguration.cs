using Api_BoxCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_BoxCenter.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {

        // configuracion de la tabla de la base de datos 
        public void Configure(EntityTypeBuilder<Empresa> builder) {

            // esti si entendi 

            // nombre de tabla 
            builder.ToTable("empresa_tbl");

            // definicion de primary key
            builder.HasKey(x => x.IdEmpresa); 

            // corresponder esta propiedad a la enmpresa en la tabla   
            builder.Property(x => x.IdEmpresa)
                .HasColumnName("id_empresa");

            // nombre de la empresa y sus validaciones 
            builder.Property(x => x.NombreEmpresa)
                .HasColumnName("nombre_empresa")
                .HasMaxLength(70)
                .IsUnicode(false)
                .IsRequired();


            // imagen de empresa y sus validaciones 
            builder.Property(x => x.UrlImgEmpresa)
                .HasColumnName("url_img_empresa")
                .HasMaxLength(300)
                .IsUnicode(false)
                .IsRequired();


            // estado
            builder.Property(x => x.EstadoEmpresa)
                .HasColumnName("estado_empresa")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(x => x.FechaCreacionEmpresa)
                .HasColumnName("fecha_creacion_empresa")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.FechaModificacion)
                .HasColumnName("fecha_modificacion")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            //implementacion de indice unico

           builder.HasIndex(x => x.NombreEmpresa)
                .IsUnique();


        }
    }
}
