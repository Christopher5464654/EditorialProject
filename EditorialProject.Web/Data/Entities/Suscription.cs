namespace EditorialProject.Web.Data.Entities
{
    using System;
    public class Suscription : IEntity
    {
        public int Id { get; set; }
        public DateTime SuscriptionDate { get; set; }
        public Reader Reader { get; set; }
        public Novel Novel { get; set; }
        public Status Status { get; set; }
    }
}