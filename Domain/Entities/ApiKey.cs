namespace Api_BoxCenter.Domain.Entities
{
    public class ApiKey
    {
        public int IdApiKey { get; set; }
        public int UserId {  get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string KeyPrefix { get; set; } = string.Empty;
        public string KeyHash { get; set; } = string.Empty;

        public DateTime FechaDeCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public DateTime? FechaRevocacion { get; set; }
        public DateTime? UltimoUso {  get; set; }

        public Usuario Usuario { get; set; } = null!;

    }
}
