namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("API/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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