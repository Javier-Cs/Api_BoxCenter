using Api_BoxCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api_BoxCenter.Configuration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Sessiones>
    {
        public void Configure(EntityTypeBuilder<Sessiones> builder) {
            builder.ToTable("session_tbl ");

            builder.HasKey(x => x.IdSessiones);

            builder.Property(x => x.IdSessiones)
                .HasColumnName("id_session ")
                .IsRequired();

            builder.Property(x => x.UsuarioId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("created_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.FechaExpiracion)
                .HasColumnName("expire_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.FechaRemovicion)
                .HasColumnName("removed_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.UltimaActividad)
                .HasColumnName("last_activity_at")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(x => x.DireccionIp)
                .HasColumnName("ip_address")
                .HasMaxLength(45)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.UserAgent)
                .HasColumnName("user_agent")
                .HasMaxLength(500)
                .IsUnicode(true)
                .IsRequired();


            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Sessiones)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasIndex(x => new {
                x.UsuarioId
            });
        }
    }
}
