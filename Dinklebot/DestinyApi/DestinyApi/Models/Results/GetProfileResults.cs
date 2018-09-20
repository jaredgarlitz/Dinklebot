using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;

namespace DestinyApi.Models.Results
{
    public class GetProfileResults : RootResult
    {
        public Response Response { get; set; }
    }

    public class Response
    {
        public Profile profile { get; set; }
        public ProfileCurrencies profileCurrencies { get; set; }
        public Itemcomponents itemcomponents { get; set; }
    }

    public class ProfileCurrencies
    {
        public int privacy { get; set; }
    }

    public class Profile
    {
        public Data data { get; set; }
        public int privacy { get; set; }
    }

    public class Data
    {
        public UserInfo userInfo { get; set; }
        public DateTime dateLastPlayed { get; set; }
        public int versionsOwned { get; set; }
        public string[] characterIds { get; set; }
    }
    public class UserInfo
    {
        public int membershipType { get; set; }
        public string membershipId { get; set; }
        public string displayName { get; set; }
    }

    public class Itemcomponents
    {

    }
}