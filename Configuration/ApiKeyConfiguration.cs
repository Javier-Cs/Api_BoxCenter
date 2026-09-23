using Api_BoxCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_BoxCenter.Configuration
{
    public class ApiKeyConfiguration: IEntityTypeConfiguration<ApiKey>
    {
        public void Configure(EntityTypeBuilder<ApiKey> builder) {

            builder.ToTable("api_key_tbl");

            builder.HasKey(x => x.IdApiKey);

            builder.Property(x => x.IdApiKey)
                .HasColumnName("id");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.KeyPrefix)
                .HasColumnName("key_prefix")
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.KeyHash)
                .HasColumnName("key_hash")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(x => x.FechaDeCreacion)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.FechaExpiracion)
                .HasColumnName("expires_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.FechaRevocacion)
                .HasColumnName("revoked_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.UltimoUso)
                .HasColumnName("last_used_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();


            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.ApiKey)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);






        }
    }
}
