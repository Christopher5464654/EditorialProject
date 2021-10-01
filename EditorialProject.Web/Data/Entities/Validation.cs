namespace EditorialProject.Web.Data.Entities
{
    using System;
    public class Validation : IEntity
    {
        public int Id { get; set; }
        public DateTime ValidationDate { get; set; }
        public string Comments { get; set; }
        public Novel Novel { get; set; }
        public Status Status { get; set; }
        public Moderator Moderator { get; set; }
    }
}