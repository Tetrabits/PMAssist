using PMAssist.Interfaces;
using System.Text.Json;

namespace PMAssist.Managers
{
    public class UserManager
    {
        private static IDataAccessRepository dataAccess;
        private static readonly string URL = @"users";
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
        }

        public static async Task<UserModel> GetUser(string userId)
        {

            var url = $"{URL}/{userId}";

            var userData = await dataAccess.GetAll("asdfsdf", url);

            var rawData = JsonSerializer.Deserialize<Dictionary<string, string>>(userData);

            if (rawData == null)
            {
                return new UserModel { Name = "Not Defined" };
            }

            return new UserModel { Name = rawData["name"] };
        }
    }
}
