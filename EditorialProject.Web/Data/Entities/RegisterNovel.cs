namespace EditorialProject.Web.Data.Entities
{
    using System;
    public class RegisterNovel : IEntity
    {
        public int Id { get; set; }
        public DateTime PublishDate { get; set; }
        public Novel Novel { get; set; }
        public Writer Writer { get; set; }
    }
}