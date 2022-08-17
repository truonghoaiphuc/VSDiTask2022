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
        public Task<UserToken> GetUserTokenInfoAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            throw new NotImplementedException();
        }
    }
}
