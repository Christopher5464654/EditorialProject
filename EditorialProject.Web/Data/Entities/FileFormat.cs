namespace EditorialProject.Web.Data.Entities
{
    using System.Collections.Generic;
    public class FileFormat : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Novel> Novels { get; set; }
    }
}