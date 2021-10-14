namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("API/[Controller]")]
    public class StatusController : Controller
    {
        private readonly IStatusRepository statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(this.statusRepository.GetAll());
        }
    }
}