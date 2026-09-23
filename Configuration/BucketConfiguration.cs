using Api_BoxCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_BoxCenter.Configuration
{
    public class BucketConfiguration : IEntityTypeConfiguration<Buckets>
    {
        public void Configure(EntityTypeBuilder<Buckets> builder) {

            builder.ToTable("buckets_tbl");

            builder.HasKey(x => x.IdBucket);

            builder.Property(x => x.IdBucket)
                .HasColumnName("id_bucket")
                .IsRequired();

            builder.Property(x => x.EmpresaId)
                .HasColumnName("empresa_id")
                .IsRequired();

            builder.Property(x => x.CreadoPorUserId)
                .HasColumnName("created_by_user_id")
                .IsRequired();

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.EsPublico)
                .HasColumnName("is_public")
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Buckets)
                .HasForeignKey(x => x.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // commo deberia de implementar la fk
            builder.HasOne(x => x.CreateByUsuario)
                .WithMany(x => x.CreatedBuckets)
                .HasForeignKey(x => x.CreadoPorUserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
