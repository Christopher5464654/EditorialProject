namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("API/[Controller]")]
    public class GenreTypesController : Controller
    {
        private readonly IGenreTypeRepository genreTypeRepository;

        public GenreTypesController(IGenreTypeRepository genreTypeRepository)
        {
            this.genreTypeRepository = genreTypeRepository;
        }

        [HttpGet]
        public IActionResult GetGenreTypes()
        {
            return Ok(this.genreTypeRepository.GetAll());
        }
    }
}