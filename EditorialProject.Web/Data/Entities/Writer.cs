namespace EditorialProject.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Writer : IEntity
    {
        public int Id { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<RegisterNovel> RegisterNovels { get; set; }
        public User User { get; set; }
    }
}