namespace EditorialProject.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;

    public class Reader : IEntity
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Suscription> Suscriptions { get; set; }
        public User User { get; set; }
    }
}