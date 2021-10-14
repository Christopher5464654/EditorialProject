namespace EditorialProject.Web.Data.Repositories
{
    using EditorialProject.Web.Data.Entities;
    public class EditionRepository : GenericRepository<Edition>, IEditionRepository
    {
        public EditionRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}