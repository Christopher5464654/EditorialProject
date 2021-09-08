namespace EditorialProject.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Admin : IEntity
    {
        public int Id { get; set; }

        public User User { get; set; }
        
        [Display(Name = "Calle")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string Street { get; set; }

        [Display(Name = "Número exterior")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string NumberExt { get; set; }

        [Display(Name = "Número interior")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string NumberInt { get; set; }

        [Display(Name = "Colonia")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string Town { get; set; }

        [Display(Name = "Calle")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string PostalCode { get; set; }
    }
}
