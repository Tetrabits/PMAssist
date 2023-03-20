using System;
using System.Text;
using PMAssist.Interfaces;

namespace PMAssist
{
    public class DataAccessRepository : IDataAccessRepository
    {

        string BaseUrl = "https://teamthoughtful17matrix-default-rtdb.firebaseio.com/";


        public async Task<string> GetAll(string token, string url)
        {
            using var client = new HttpClient();
            var geturl = BaseUrl + url + ".json" + "?auth=" + token;

            var response = await client.GetAsync(geturl);
            var result = await response.Content.ReadAsStringAsync();


            return result;

        }

        public async Task<string> GetData(string token, string url, string uid)
        {
            using var client = new HttpClient();
            string geturl = BaseUrl + url + "/" + uid + ".json" + "?auth=" + token;

            var response = await client.GetAsync(geturl);
            string result = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(result);
            return result;
        }

        public async Task<string> PostData(string token, string url, string data)
        {

            //var postData = new StringContent(data, Encoding.UTF8, "application/json");

            //var posturl = BaseUrl + url + "/.json";
            //using var client = new HttpClient();

            //var response = await client.PostAsync(posturl, postData);
            //string result = response.Content.ReadAsStringAsync().Result;

            //return result;

            ////for uid based constraint
            var postData = new StringContent(data, Encoding.UTF8, "application/json");

            var posturl = BaseUrl + url + "/.json?auth=" + token;
            using var client = new HttpClient();

            var response = await client.PostAsync(posturl, postData);
            string result = await response.Content.ReadAsStringAsync();

            return result;

        }

        public async Task<string> PutData(string token, string url, string data)
        {

            var putData = new StringContent(data, Encoding.UTF8, "application/json");

            var puturl = BaseUrl + url + "/.json?auth=" + token;
            using var client = new HttpClient();

            var response = await client.PutAsync(puturl, putData);
            string result = await response.Content.ReadAsStringAsync();

            return result;

        }

        public async Task<string> PatchData(string token, string url, string data)
        {

            var patchData = new StringContent(data, Encoding.UTF8, "application/json");

            var patchurl = BaseUrl + url + "/.json?auth=" + token;
            using var client = new HttpClient();

            var response = await client.PatchAsync(patchurl, patchData);
            string result = await response.Content.ReadAsStringAsync();

            return result;

        }

        public async Task<string> DeleteData(string token, string url)
        {

            var patchurl = BaseUrl + url + "/.json?auth=" + token;
            using var client = new HttpClient();

            var response = await client.DeleteAsync(patchurl);
            string result = await response.Content.ReadAsStringAsync();

            return result;

        }

        //public async Task<string> PatchData(string token, EffortModel data)
        //{
        //    var json = $"{{\"{data.taskId}\":\"{data.howMuch}\"}}";
        //    string url = "/" + data.when.Year + "/" + data.when.Month + "/" + data.userId + "/" + data.when.Day;
        //    var patchData = new StringContent(json, Encoding.UTF8, "application/json"); var patchurl = BaseUrl + url + "/.json?auth=" + token;
        //    using var client = new HttpClient(); var response = await client.PatchAsync(patchurl, patchData);
        //    string result = await response.Content.ReadAsStringAsync(); return result;
        //}

    }
}
