namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("API/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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