namespace EditorialProject.Web.Data.Entities
{
    using System.Collections.Generic;
    public class Novel : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int NumberPages { get; set; }
        public Language Language { get; set; }
        public Edition Edition { get; set; }
        public FileFormat FileFormat { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Suscription> Suscriptions { get; set; }
        public ICollection<Validation> Validations { get; set; }
        public ICollection<RegisterNovel> RegisterNovels { get; set; }
    }
}