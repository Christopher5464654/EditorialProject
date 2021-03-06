namespace EditorialProject.Web.Data
{
    using EditorialProject.Web.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<FileFormat> FileFormats { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreType> GenreTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Novel> Novels { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<RegisterNovel> RegisterNovels { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Suscription> Suscriptions { get; set; }
        public DbSet<Validation> Validations { get; set; }
        public DbSet<Writer> Writers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
        }
    }
}
