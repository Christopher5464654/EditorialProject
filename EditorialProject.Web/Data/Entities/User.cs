namespace EditorialProject.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Celular")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public override string PhoneNumber { get; set; }

        [Display(Name = "Nombre completo")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
