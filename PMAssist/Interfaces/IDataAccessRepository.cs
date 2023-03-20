namespace PMAssist.Interfaces
{
    public interface IDataAccessRepository
    {
        Task<string> DeleteData(string token, string url);
        Task<string> GetAll(string token, string url);
        Task<string> GetData(string token, string url, string uid);
        Task<string> PatchData(string token, string url, string data);
        Task<string> PostData(string token, string url, string data);
        Task<string> PutData(string token, string url, string data);
    }
}