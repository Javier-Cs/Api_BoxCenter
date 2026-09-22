namespace Api_BoxCenter.Domain.Entities
{
    public class Folder
    {
        public int IdFolder { get; set; }
        public int BucketId {  get; set; }
        public int? ParentFolderId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaDeCreacion { get; set; }


        public Buckets Buckets { get; set; } = null!;+

        // carpeta Padre
        public Folder? parentFolder { get; set; }
        //carpeta hija
        public ICollection<Folder> children { get; set; } = new List<Folder>(); 
    }
}
