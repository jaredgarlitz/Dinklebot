using System;
using DestinyApi.Models.Enum;
using DestinyApi.Models.Results;
using DestinyApi.SearchDestinyPlayer;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DestinyApiTest
{
    public class SearchPlayer
    {
        SearchDestinyPlayer _playerSearch;
        public SearchPlayer()
        {
            _playerSearch = new SearchDestinyPlayer();  
        }

        ///<summary>
        ///searches for gamertag and test for account retrieval
        /// </summary>
        public void SearchPlayer()
        {
            var holyBreadstickXbox = GetHolyBreadStick();

            Assert.IsTrue(holyBreadstickXbox.ContainsPlayer("Holy Breadstick"));
        }

        public SearchPlayerResult GetHolyBreadstick()
        {
            var displayName = "Holy Breadstick";
            return _playerSearch.SearchDestinyPlayerAsync(displayName, BungieMembershipType.TigerXbox).Result;
        }
    }
}