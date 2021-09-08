using EditorialProject.Web.Data.Entities;
using EditorialProject.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EditorialProject.Web.Data
{
    public class Seeder
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Writer");
            await this.userHelper.CheckRoleAsync("Reader");
            if (!this.dataContext.Admins.Any())
            {
                var user = await CheckUserAsync("Doe", "John", "john.doe@gmail.com", "8888888888", "123456", "Admin");
                await CheckAdminAsync(user, "Conocida", "156", "55", "Pable Neruda", "54587");
            }
            if (!this.dataContext.Writers.Any())
            {
                var user = await CheckUserAsync("Doe", "Jane", "jane.doe@gmail.com", "54654654", "123456", "Writer");
                await CheckWriterAsync(user);
            }
            if (!this.dataContext.Readers.Any())
            {
                var user = await CheckUserAsync("Doe", "Gus", "gus.doe@gmail.com", "6465454", "123456", "Reader");
                await CheckReaderAsync(user);
            }
        }

        private async Task<User> CheckUserAsync(string lastName, string firstName, string mail, string phone, string password, string rol)
        {
            var user = await userHelper.GetUserByEmailAsync(mail);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = mail,
                    UserName = mail,
                    PhoneNumber = phone,
                };
                var result = await userHelper.AddUserAsync(user, password);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se puede crear el usuario en la base de datos");
                }
                await userHelper.AddUserToRoleAsync(user, rol);
            }
            return user;
        }

        private async Task CheckAdminAsync(User user, string street, string numberExt, string numberInt, string town, string postalCode)
        {
            this.dataContext.Admins.Add(new Admin { User = user, Street = street, NumberExt = numberExt, NumberInt = numberInt, Town = town, PostalCode= postalCode });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckWriterAsync(User user)
        {
            this.dataContext.Writers.Add(new Writer { User = user });
            await this.dataContext.SaveChangesAsync();
        }

        private async Task CheckReaderAsync(User user)
        {
            this.dataContext.Readers.Add(new Reader { User = user });
            await this.dataContext.SaveChangesAsync();
        }
    }
}
