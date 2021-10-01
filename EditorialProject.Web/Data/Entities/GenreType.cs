namespace EditorialProject.Web.Data.Entities
{
    using System.Collections.Generic;
    public class GenreType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}