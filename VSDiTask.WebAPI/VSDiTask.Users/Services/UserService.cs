using Microsoft.EntityFrameworkCore;
using VSDiTask.Common.Extensions;
using VSDiTask.Core.Data;
using VSDiTask.Users.Models;

namespace VSDiTask.Users.Services
{
    public interface IUserService
    {

        Task<bool> IsValidUserAccountAsync(UserLogin user);

        Task<UserToken> GetUserTokenInfoAsync(string username);
    }
    public class UserService : IUserService
    {
        private readonly IVSDiTaskDbContextFactory _dbContextFactory;
        public UserService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Task<UserToken> GetUserTokenInfoAsync(string username)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return context.AppUsers
                .Where(x => x.UserName == username)
                .Select(x => new UserToken
                {
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var hash = HashExtensions.Hash(user.Password);
            var valid = await context.AppUsers
                .Where(u => u.UserName == user.UserName && u.Password == hash)
                .AnyAsync();
            return valid;
        }
    }
}
