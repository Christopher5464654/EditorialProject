namespace EditorialProject.Web.Data.Repositories
{
    using EditorialProject.Web.Data.Entities;
    public class FileFormatRepository : GenericRepository<FileFormat>, IFileFormatRepository
    {
        public FileFormatRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}