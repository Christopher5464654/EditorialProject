namespace EditorialProject.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres")]
        [Required]
        public string NameState { get; set; }
    }
}