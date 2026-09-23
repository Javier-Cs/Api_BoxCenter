namespace Api_BoxCenter.Domain.Entities
{
    public class Files
    {
        public int Idfiles { get; set; }
        public int BucketId {  get; set; }
        public int? FolderId { get; set; }
        public int UsuarioId { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string ObjetoKey { get; set; } = string.Empty;
        public string ContentType {  get; set; } = string.Empty;


        // si el tipo es BIGINT  en la base de datos es long
        public long Size { get; set; }
        public string? Extencion {  get; set; }
        public bool IsPublic { get; set; } = false;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public Buckets Buckets { get; set; } = null!;
        public Folder Folder { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;

        public ICollection<Permisos> Permisos { get; set; } = new List<Permisos>();

    }
}
