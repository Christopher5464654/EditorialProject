namespace EditorialProject.Web.Data.Entities
{
    using System.Collections.Generic;
    public class Moderator : IEntity
    {
        public int Id { get; set; }
        public ICollection<Validation> Validations { get; set; }
        public Status Status { get; set; }
        public User User { get; set; }
    }
}