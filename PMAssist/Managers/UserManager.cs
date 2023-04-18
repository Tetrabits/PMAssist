using PMAssist.Interfaces;
using PMAssist.Models;
using System.Text.Json;

namespace PMAssist.Managers
{
    public class UserManager : IUserManager
    {
        private static IDataAccessRepository dataAccess;
        private static readonly string URL = @"users";
        private static IList<UserModel> Users;

        internal UserManager(IDataAccessRepository dataAccessRepository)
        {
            dataAccess = dataAccessRepository;
        }

        public UserManager()
        {

        }


        static UserManager()
        {
            dataAccess = new DataAccessRepository();
            Users = new List<UserModel>();

            var userData = dataAccess.GetAll("asdfsdf", URL).GetAwaiter().GetResult();
            var rawData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(userData);

            foreach (var data in rawData)
            {
                Users.Add(new UserModel
                {
                    UID = data.Key,
                    Name = data.Value["name"],
                    Status = data.Value["active"] == "true"
                });

            }

        }

        public async Task<UserModel> GetUser(string userId)
        {
            return await Task.Run(() =>
            {
                var user = Users.FirstOrDefault(n => n.UID == userId);
                if (user is not null)
                {
                    return user;
                }
                else
                {
                    return new UserModel { Name = "Undefined" };
                }
            });

        }

        public Task<IEnumerable<UserModel>> GetUsers()
        {
            return Task.Run(() =>
            {
                return Users.AsEnumerable();
            });
        }
    }
}
