namespace EditorialProject.Web.Data.Repositories
{
    using EditorialProject.Web.Data.Entities;
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(DataContext dataContext) : base(dataContext)
        {
                
        }
    }
}