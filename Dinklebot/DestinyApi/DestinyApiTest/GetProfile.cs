using System;
using DestinyApi.Profile;
using DestinyApi.Models.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DestinyApiTest
{
    public class GetProfile
    {
        public void GetProfile()
        {
            var _profile = new GetProfile();
            var playerTest = new SearchPlayerTest();
            var holyBreadstickXbox = playerTest.GetHolyBreadstick().Response.First();

            var holyBreadstickProfile = _profile.GetProfileWithComponentsAsync(
                (BungieMembershipType)holyBreadstickXbox.membershipType,
                holyBreadstickXbox.membershipId,
                DestinyComponentType.Profiles,
                DestinyComponentType.ProfileCurrencies).Result;
        }
    }
}