namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("API/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LanguagesController : Controller
    {
        private readonly ILanguageRepository languageRepository;

        public LanguagesController(ILanguageRepository languageRepository)
        {
            this.languageRepository = languageRepository;
        }

        [HttpGet]
        public IActionResult GetLanguages()
        {
            return Ok(this.languageRepository.GetAll());
        }
    }
}