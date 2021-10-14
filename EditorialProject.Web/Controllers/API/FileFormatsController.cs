namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("API/[Controller]")]
    public class FileFormatsController : Controller
    {
        private readonly IFileFormatRepository fileFormatRepository;

        public FileFormatsController(IFileFormatRepository fileFormatRepository)
        {
            this.fileFormatRepository = fileFormatRepository;
        }

        [HttpGet]
        public IActionResult GetFileFormats()
        {
            return Ok(this.fileFormatRepository.GetAll());
        }
    }
}