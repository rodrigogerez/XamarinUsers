using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XamarinUsers.Model
{
    public class User
    {
        [JsonProperty("_links")]
        public Avatar AvatarImage { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("result")]
        public List<User> Users { get; set; }
    }

    public class Avatar
    {
        [JsonProperty("avatar")]
        public ProfileImageObject AvatarObject { get; set; }
    }

    public class ProfileImageObject
    {
        [JsonProperty("href")]
        public string ProfileImageUrl { get; set; }
    }
}
