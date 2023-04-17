using PMAssist.Models;

namespace PMAssist.Interfaces
{
    public interface IUserManager
    {
        Task<UserModel> GetUser(string userId);
        Task<IEnumerable<UserModel>> GetUsers();
    }
}