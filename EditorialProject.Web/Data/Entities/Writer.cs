namespace EditorialProject.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Writer : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Required]
        public DateTime Date { get; set; }
    }
}
