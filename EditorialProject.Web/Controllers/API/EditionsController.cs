namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("API/[Controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EditionsController : Controller
    {
        private readonly IEditionRepository editionRepository;

        public EditionsController(IEditionRepository editionRepository)
        {
            this.editionRepository = editionRepository;
        }

        [HttpGet]
        public IActionResult GetEditions()
        {
            return Ok(this.editionRepository.GetAll());
        }
    }
}