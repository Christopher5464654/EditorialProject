namespace EditorialProject.Web.Data.Entities
{
    using System.Collections.Generic;
    public class Status : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Suscription> Suscriptions { get; set; }
        public ICollection<Validation> Validations { get; set; }
        public ICollection<Moderator> Moderators { get; set; }
    }
}