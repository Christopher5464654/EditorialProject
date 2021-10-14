namespace EditorialProject.Web.Controllers.API
{
    using EditorialProject.Web.Data.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("API/[Controller]")]
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