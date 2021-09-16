namespace EditorialProject.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Moderator : IEntity
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
        public int NumberExt { get; set; }

        [Display(Name = "Número Interior")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        public int NumberInt { get; set; }

        [Display(Name = "Colonia")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string Town { get; set; }

        [Display(Name = "Código Postal")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public int PostalCode { get; set; }
    }
}
