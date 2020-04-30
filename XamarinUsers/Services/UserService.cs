using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinUsers.Model;

namespace XamarinUsers.Services
{
    public class UserService: IUserService
    {
        protected readonly HttpClient _client;

        #region constants

        private const string BASE_USER_URL = "https://gorest.co.in";
        private const string GET_USERS_URL = "/public-api/users";
        private const string API_ACC_TOKEN = "Bearer cKpStBnRZxI6bU6kUMfuU9QX_Lb9hDvZFZ_w";

        #endregion

        #region constructor

        public UserService(HttpClient client)
        {
            _client = client;
            _client.DefaultRequestHeaders.Add("Authorization", API_ACC_TOKEN);
        }

        #endregion

        #region public methods

        public async Task<List<User>> GetUsers()
        {
            try
            {
                var content = await _client.GetStringAsync($"{BASE_USER_URL}{GET_USERS_URL}");
                var root = JsonConvert.DeserializeObject<RootObject>(content);

                return root.Users;
            }
            catch(JsonSerializationException jse)
            {
                Console.WriteLine("JsonSerializationException: " + jse.Message);
            }
            catch(HttpRequestException hre)
            {
                Console.WriteLine("HttpRequestException: " + hre.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return null;
        }

        //public async Task<User> GetUsersByName(string name)
        //{

        //}

        #endregion
    }
}
