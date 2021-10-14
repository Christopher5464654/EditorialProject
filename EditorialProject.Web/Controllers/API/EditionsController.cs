namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("API/[Controller]")]
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