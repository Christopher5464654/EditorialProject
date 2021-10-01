namespace EditorialProject.Web.Data.Entities
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public GenreType GenreType { get; set; }
        public Novel Novel { get; set; }
    }
}