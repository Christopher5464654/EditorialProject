namespace EditorialProject.Web.Data.Repositories
{
    using EditorialProject.Web.Data.Entities;
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}