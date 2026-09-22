namespace Api_BoxCenter.Domain.Entities
{
    public class Sessiones
    {
        public int IdSessiones { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public DateTime? FechaRemovicion { get; set; }
        public DateTime? UltimaActividad { get; set; }
        public string? DireccionIp { get; set; } = string.Empty;
        public string? UserAgent { get; set; } = string.Empty;

        public Usuario Usuario { get; set; } = null!;
    }
}
