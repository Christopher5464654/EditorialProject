namespace EditorialProject.Web.Data.Repositories
{
    using EditorialProject.Web.Data.Entities;
    public class GenreTypeRepository : GenericRepository<GenreType>, IGenreTypeRepository
    {
        public GenreTypeRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}