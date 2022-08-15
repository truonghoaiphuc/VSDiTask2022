using Microsoft.EntityFrameworkCore;
using VSDiTask.Common.Extensions;
using VSDiTask.Infrastructure;
using VSDiTask.Users.Models;

namespace VSDiTask.Users.Services
{
    public interface IUserService
    {

        Task<bool> IsValidUserAccountAsync(UserLogin user);

        Task<UserToken> GetUserInfoAsync(string username);
    }
    public class UserService : IUserService
    {
        private readonly IVSDiTaskDbContextFactory _dbContextFactory;
        public UserService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<UserToken> GetUserInfoAsync(string username)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.Users
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
            var hashed = user.Password.Hash();
            var valid = await context.Users
                    .Where(x => x.UserName == user.UserName && x.Password == hashed)
                    .AnyAsync();
            return valid;
        }
    }
}
