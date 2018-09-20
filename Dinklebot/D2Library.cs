﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dinklebot.ClassLibrary
{
    public class D2Library
    {
        private static HttpClient _Web = new HttpClient();
        const String BaseAddress = "https://www.bungie.net/Platform";

        public D2Library(string apiKey)
        {
            if (!_Web.DefaultRequestHeaders.Contains("X-API-Key"))
            {
                _Web.DefaultRequestHeaders.Add("X-API-Key", apiKey);
            }
        }
        private string FormatWithParameters(string input, Dictionary<string, string> ParamKeyPairs)
        {
            if (ParamKeyPairs == null)
            {
                return input;
            }
            var workingOutput = input;
            foreach (var param in ParamKeyPairs)
            {
                workingOutput = workingOutput.Replace("{" + param.Key + "}", param.Value);
            }
            return workingOutput;
        }


        ///<summary>
        ///Loads a bungienet user by membership id.
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> User_GetBungieNetUserByIdAsync(long id)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/User/GetBungieNetUserById/{id}/", new Dictionary<string, string>() { { "id", id.ToString() } }));
        }

        public String User_GetBungieNetUserById(long id)
        {
            return User_GetBungieNetUserByIdAsync(id).Result;
        }

        ///<summary>
        ///Loads aliases of a bungienet membership id
        ///</summary>
        ///<returns>A jsong string for this endpoint</returns>
        public async Task<String> User_GetUserAliasesAsync(long id)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/User/GetUserAliases/{id}/", new Dictionary<string, string>() { { "id", id.ToString() } }));
        }

        public String User_GetUserAliases(long id)
        {
            return User_GetUserAliasesAsync(id).Result;
        }

        public async Task<String> User_SearchUsersAsync()
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/User/SearchUsers/", null));
        }

        ///<summary>
        ///Returns a list of all available user themes.
        /// </summary>
        ///<return>A json string for this endpoint</return> 
        public async Task<string> User_GetAvailableThemesAsync()
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/User/GetAvailableThemes/", null));
        }

        public String User_GetAvailableThemes()
        {
            return User_GetAvailableThemesAsync().Result;
        }

        ///<summary>
        ///Returns a list of accounts associated with the supplied membership ID and membership type. This will include all linked accounts (even when hidden) if supplied credentials permit it.
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> User_GetMembershipDataByIdAsync(long membershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/User/GetMembershipsById/{membershipId}/{membershipType}/", new Dictionary<string, string>() { { "membershipId", membershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String User_GetmembershipDataById(long membershipId, int membershipType)
        {
            return User_GetMembershipDataByIdAsync(membershipId, membershipType).Result;
        }

        ///<summary>
        ///Returns a list of accounts with signed in user. This is useful for OAuth implementations that do not give you access to the token response
        /// </summary>
        /// <returns></returns>
        public async Task<String> User_GetMembershipDataForCurrentUserAsync()
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/User/GetMembershipsForCurrentUser/", null));
        }

        public String User_GetMembershipDataForCurrentUser()
        {
            return User_GetMembershipDataForCurrentUserAsync().Result;
        }

        ///<summary>
        ///Returns a user's linked Partnerships
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> User_GetPartnershipsAsync(long membershipId)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/User/{membershipId}/Partnerships",new Dictionary<string, string>() { { "membershipId",membershipId.ToString() } }));
        }

        public String User_GetPartnerships(long membershipId)
        {
            return User_GetAvailableThemesAsync().Result;
        }

        ///<summary>
        ///Get topics from any forum
        /// </summary>
        /// <return>a json string for this endpoint</return>
        public async Task<String> Forum_GetTopicsPagedAsync(int categoryFilter, long group, int page, int pageSize, int quickDate, object sort)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/GetTopicsPaged/{page}/{pageSize}/{group}/{sort}/{quickDate}/{categoryFilter}/", new Dictionary<string, string>() { { "categoryFilter", categoryFilter.ToString() }, { "group", group.ToString() }, { "page", page.ToString() }, { "pageSize", pageSize.ToString() }, { "quickDate", quickDate.ToString() }, { "sort", sort.ToString() } }));
        }

        public String Forum_GetTopicsPaged(int categoryFilter,long group,int page,int pagesize,int quickDate,object sort)
        {
            return Forum_GetTopicsPagedAsync(categoryFilter, group, page, pagesize, quickDate, sort).Result;
        }

        ///<summary>
        ///Gets a listing of all topics marked as part of the core group
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Forum_GetCoreTopicsPagedAsync(int categoryFilter,int page,int quickDate,object sort)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/GetCoreTopicsPaged/{page}/{sort}/{quickDate}/{categoryFilter}/", new Dictionary<string, string>() { { "categoryFilter", categoryFilter.ToString() }, { "page", page.ToString() }, { "quickDate", quickDate.ToString() }, { "sort", sort.ToString() } }));
        }

        public String Forum_GetCoreTopicsPaged(int categoryfilter,int page,int quickDate,object sort)
        {
            return Forum_GetCoreTopicsPagedAsync(categoryfilter, page, quickDate, sort).Result;
        }

        ///<summary>
        ///Returns a thread of posts at the given parent, optionally return replies to those posts as well as the original parent
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Forum_GetPostsThreadedPagedAsync(object getParentPost,int page,int pageSize,object parentPostId,int replySize,object rootThreadMode,int sortMode)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/GetPostsThreadedPage/{parentPostId}/{page}/{pageSize}/{replySize}/{getParentPost}/{rootThreadMode}/{sortMode}/", new Dictionary<string, string>() { { "getParentPost", getParentPost.ToString() }, { "page", page.ToString() }, { "pageSize", pageSize.ToString() }, { "parentPostId", parentPostId.ToString() }, { "replySize", replySize.ToString() }, { "rootThreadMode", rootThreadMode.ToString() }, { "sortMode", sortMode.ToString() }, }));
        }

        public String Forum_GetPostsThreadedPaged(object getParentPost,int page,int pageSize,object parentPostId,int replySize,object rootThreadMode,int sortMode)
        {
            return Forum_GetPostsThreadedPagedAsync(getParentPost, page, pageSize, parentPostId, replySize, rootThreadMode, sortMode).Result;
        }

        ///<summary>
        ///Returns a thread of posts starting at the topicId of the input childPostId, optionally returning replies to those posts as well as the original parent.
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Forum_GetPostsThreadedPagedFromChildAsync(object childPostId,int page,int pageSize,int replySize,object rootThreadMode,int sortMode)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/GetPostsThreadedPagedFromChild/{childPostId}/{page}/{pageSize}/{replySize}/{rootThreadMode}/{sortMode}/", new Dictionary<string, string>() { { "childPostId", childPostId.ToString() }, { "page", page.ToString() }, { "pageSize", pageSize.ToString() }, { "replySize", replySize.ToString() }, { "rootThreadMode", rootThreadMode.ToString() }, { "sortMode", sortMode.ToString() } }));
        }

        public String Forum_GetPostsThreadedPagedFromChild(object childPostId,int page,int pageSize,int replySize,object rootThreadMode,int sortMode)
        {
            return Forum_GetPostsThreadedPagedFromChildAsync(childPostId, page, pageSize, replySize, rootThreadMode, sortMode).Result;
        }

        ///<summary>
        ///Returns the post specified and its immediate parent
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Forum_GetPostAndParentAsync(object childPostId)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/GetPostAndParent/{childPostId}/", new Dictionary<string, string>() { { "childPostId", childPostId.ToString() } }));
        }

        public String Forum_GetPostAndParent(object childPostId)
        {
            return Forum_GetPostAndParentAsync(childPostId).Result;
        }

        ///<summary>
        ///Returns the post specified and its immediate parent of posts that are awaiting approval
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Forum_GetPostAndParentAwaitingApprovalAsync(object childPostId)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/GetPostAndParentAwaitingApproval/{childPostId}/", new Dictionary<string, string>() { { "childPostId", childPostId.ToString() } }));
        }

        public String Forum_GetPostAndParentAwaitingApproval(object childPostId)
        {
            return Forum_GetPostAndParentAsync(childPostId).Result;
        }

        ///<summary>
        ///Gets the post Id for the given content item's comments, it if exists
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Forum_GetTopicForContentAsync(long contentId)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/GetTopicForcontent/{contentId}/", new Dictionary<string, string>() { { "contentId", contentId.ToString() } }));
        }

        public String Forum_GetTopicForContent(long contentId)
        {
            return Forum_GetTopicForContentAsync(contentId).Result;
        }

        ///<summary>
        ///Gets tag suggestion based on partial text entry, matching them with other tags previously used in the forums
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Forum_GetForumTagSuggestionsAsync()
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/GetForumTagSuggestions/", null));
        }

        public String Forum_GetForumTagSuggestions()
        {
            return Forum_GetForumTagSuggestionsAsync().Result;
        }

        ///<summary>
        ///Gets the specified forum poll
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Forum_GetPollAsync(long topicId)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Forum/Poll/{topicId}/", new Dictionary<string, string>() { { "topicId", topicId.ToString() } }));
        }

        public String ForumGetPoll(long topicId)
        {
            return Forum_GetPollAsync(topicId).Result;
        }

        ///<summary>
        ///Gets the current version of the manifest as a json object
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetDestinyManifestAsync()
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/Manifest/", null));
        }

        public String Destiny2_GetDestinyManifest()
        {
            return Destiny2_GetDestinyManifestAsync().Result;
        }

        ///<summary>
        ///Returns a list of Destiny memberships given a full Gamertag or PSN ID
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_SearchDestinyPlayerAsync(object displayName,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/SearchDestinyPlayer/{membershipType}/{displayName}/", new Dictionary<string, string>() { { "displayName", displayName.ToString() },{ "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_SearchDestinyPlayer(object displayName,int membershipType)
        {
            return Destiny2_SearchDestinyPlayerAsync(displayName, membershipType).Result;
        }

        ///<summary>
        ///Returns Destiny Profile information for the supplied membership
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetProfileAsync(long destinyMembershipId, int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Profile/{destinyMembershipId}/", new Dictionary<string, string>() { { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetProfile(long destinyMembershipId,int membershipType)
        {
            return Destiny2_GetProfileAsync(destinyMembershipId, membershipType).Result;
        }

        ///<summary>
        ///Returns character information for the supplied character
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetCharacterAsync(long characterId,long destinyMembershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Profile/{destinyMembershipType}/Character/{characterId}/", new Dictionary<string, string>() { { "characterId", characterId.ToString() }, { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetCharacter(long characterId,long destinyMembershipId,int membershipType)
        {
            return Destiny2_GetCharacterAsync(characterId, destinyMembershipId, membershipType).Result;
        }

        ///<summary>
        ///Returns information on the weekly clan rewards and if the clan has earned them or not. Note this will always report rewards as not redeemed
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetClanWeeklyRewardStateAsync(long groupId)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/Clan/{groupId}/WeelyRewardState/", new Dictionary<string, string>() { { "groupId", groupId.ToString() } }));
        }

        public String Destiny2_GetClanWeeklyRewardState(long groupId)
        {
            return Destiny2_GetClanWeeklyRewardStateAsync(groupId).Result;
        }

        ///<summary>
        ///Retrieve the details of an instances Destiny Item. An instanced Destiny item is one with an ItemInstanceId. Non-instanced items, such as materials, have no useful instance-specific details and thus are not queryable here.
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetItemAsync(long destinyMembershipId,long itemInstanceId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Profile/{destinyMembershipId}/", new Dictionary<string, string>() { { "destinyMembershipId", destinyMembershipId.ToString() }, { "itemInstanceId", itemInstanceId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetItem(long destinyMembershipId, long itemInstanceId, int membershipType)
        {
            return Destiny2_GetItemAsync(destinyMembershipId, itemInstanceId, membershipType).Result;
        }

        ///<summary>
        ///Get currently available vendors. Preview: this service is not yet active, but we are returning the planned schema of the endpoint
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetVendorsAsync(long characterId,long destinyMembershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/", new Dictionary<string, string>() { { "characterId", characterId.ToString() }, { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetVendors(long characterId, long destinyMembershipId, int membershipType)
        {
            return Destiny2_GetVendorsAsync(characterId, destinyMembershipId, membershipType).Result;
        }

        ///<summary>
        ///get the details of a specific vendor Preview: this service is not yet active, but we are returning the planned schema of the endpoint
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetVendorAsync(long characterId,long destinyMembershipId,int membershipType,object vendorHash)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/Vendors/{vendorHash}/", new Dictionary<string, string>() { { "characterId", characterId.ToString() }, { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() }, { "vendorHash", vendorHash.ToString() } }));
        }

        public String Destiny2_GetVendor(long characterId, long destinyMembershipId, int membershipType, object vendorHash)
        {
            return Destiny2_GetVendorAsync(characterId, destinyMembershipId, membershipType, vendorHash).Result;
        }

        ///<summary>
        ///Gets the available post game carnage report for the activity ID.
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetPostGameCarnageReportAsync(long activityId)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/Stats/PostGameCarnageReport/{activityId}/", new Dictionary<string, string>() { { "activityId", activityId.ToString() } }));
        }

        public String Destiny2_GetPostGameCarnageReport(long activityId)
        {
            return Destiny2_GetPostGameCarnageReportAsync(activityId).Result;
        }

        ///<summary>
        ///Gets historical stats definitions
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetHistoricalStatsDefinitionAsync( )
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/Stats/Definition/", null));
        }

        public String Destiny2_GetHistoricalStatsDefinition()
        {
            return Destiny2_GetHistoricalStatsDefinitionAsync().Result;
        }

        ///<summary>
        ///Gets leaderboards with the signed in user's friends and the supplied destinyMembershipId as the focus
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task <String> Destiny2_GetLeaderboardsForCharacterAsync(long characterId,long destinyMembershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/Stats/Leaderboards/{membershipType}/{destinyMembershipId}/{characterId}/", new Dictionary<string, string> { { "charaterId", characterId.ToString() }, { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetLeaderboardsForCharacter(long characterId,long destinyMemberhsipId,int membershipType)
        {
            return Destiny2_GetCharacterAsync(characterId, destinyMemberhsipId, membershipType).Result;
        }


        ///<summary>
        ///Gets a page list of Destiny items
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_SearchDestinyEntitiesAsync(object searchTerm,object type)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/Armory/Search/{type}/{searchTerm}/", new Dictionary<string, string>() { { "searchTerm", searchTerm.ToString() }, { "type", type.ToString() } }));
        }

        public String Destiny2_SearchDestinyEntities(object searchTerm, object type)
        {
            return Destiny2_SearchDestinyEntitiesAsync(searchTerm, type).Result;
        }

        ///<summary>
        ///Gets historical stats for indicated character. PREVIEW
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetHistoricalStatsAsync(long characterId,long destinyMembershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/", new Dictionary<string, string>() { { "characterId", characterId.ToString() }, { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetHistoricalStats(long characterId,long destinyMembershipId,int membershipType)
        {
            return Destiny2_GetHistoricalStatsAsync(characterId, destinyMembershipId, membershipType).Result;
        }

        ///<summary>
        ///Gets aggregate historical stats organized around each character for a given account
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task <String> Destiny2_GetHistoricalStatsForAccountAsync(long destinyMembershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Account/{destinyMembershipId}/Stats/", new Dictionary<string, string>() { { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetHistoricalStatsForAccount(long destinyMembershipId,int membershipType)
        {
            return Destiny2_GetHistoricalStatsForAccountAsync(destinyMembershipId, membershipType).Result;
        }

        ///<summary>
        ///Gets activity history for indicated character. PREVIEW
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetActivityHistoryAsync(long characterId,long destinyMembershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Account/{destinyMembershipId}/character/{characterId}/Stats/Activities/", new Dictionary<string, string>() { { "characterId", characterId.ToString() }, { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetActivityHistory(long characterId,long destinyMembershipId,int membershipType)
        {
            return Destiny2_GetActivityHistoryAsync(characterId, destinyMembershipId, membershipType).Result;
        }

        ///<summary>
        ///Gets details about unique weapon usage, including all exotic weapons PREVIEW
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetUniqueWeaponHistoryAsync(long characterId,long destinyMembershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/UniqueWeapons/", new Dictionary<string, string>() { { "characterId", characterId.ToString() }, { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetUniqueWeaponHistory(long characterId,long destinyMembershipId,int membershipType)
        {
            return Destiny2_GetUniqueWeaponHistoryAsync(characterId, destinyMembershipId, membershipType).Result;
        }

        ///<summary>
        ///Gets all activities the character has participated in together with aggregate statistics for those activities PREVIEW
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetDestinyAggregateActivityStatsAsync(long characterId,long destinyMembershipId,int membershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/{membershipType}/Account/{destinyMembershipId}/Character/{characterId}/Stats/AggregateActivityStats/", new Dictionary<string, string>() { { "characterId", characterId.ToString() }, { "destinyMembershipId", destinyMembershipId.ToString() }, { "membershipType", membershipType.ToString() } }));
        }

        public String Destiny2_GetDestinyAggregateActivityStats(long characterId,long destinyMemberhipId,int membershipType)
        {
            return Destiny2_GetDestinyAggregateActivityStatsAsync(characterId, destinyMemberhipId, membershipType).Result;
        }

        ///<summary>
        ///Gets custom localized content for the milestone of the given has, if it exists
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetPublicMilestoneContentAsync(object milestoneHash)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/Milestones/{milestones}/Content/", new Dictionary<string, string>() { { "milestoneHash", milestoneHash.ToString() } }));
        }

        public String Destiny2_GetPublicMilestoneContent(object milestoneHash)
        {
            return Destiny2_GetPublicMilestoneContentAsync(milestoneHash).Result;
        }

        ///<summary>
        ///Gets public information about currently available Milestones
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Destiny2_GetPublicMilestonesAsync()
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Destiny2/Milestones/", null));
        }

        public String Destiny2_GetPublicMilestones()
        {
            return Destiny2_GetPublicMilestonesAsync().Result;
        }

        ///<summary>
        ///Returns community content
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> CommunityContent_GetCommunityContentAsync(int mediaFilter,int page,object sort)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/CommunityContent/Get/{sort}/{mediaFilter}/{page}/", new Dictionary<string, string>() { { "mediaFilter", mediaFilter.ToString() }, { "page", page.ToString() }, { "sort", sort.ToString() } }));
        }

        public String CommunityContent_GetCommunityContent(int mediaFilter,int page,object sort)
        {
            return CommunityContent_GetCommunityContentAsync(mediaFilter, page, sort).Result;
        }

        ///<summary>
        ///Returns info about community members who are live streaming
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> CommunityContent_GetCommunityLiveStatusesAsync(int page,int partnershipType,int sort)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/CommunityContent/Live/All/{partnershipType}/{sort}/{page}/", new Dictionary<string, string>() { { "page", page.ToString() }, { "partnershipType", partnershipType.ToString() }, { "sort", sort.ToString() } }));
        }

        public String CommunityContent_GetCommunityLiveStatuses(int page,int partnershipType,int sort)
        {
            return CommunityContent_GetCommunityLiveStatusesAsync(page, partnershipType, sort).Result;
        }

        ///<summary>
        ///Returns info about community members who are live streaming in your clans
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> CommunityContent_GetCommunityLiveStatusesForClanmatesAsync(int page,int partnershipType,int sort)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/CommunityContent/Live/Clan/{partnershipType}/{sort}/{page}/", new Dictionary<string, string>() { { "page", page.ToString() }, { "partnershipType", partnershipType.ToString() }, { "sort", sort.ToString() } }));
        }

        public String CommunityContent_GetCommunityLiveStatusesForClanmates(int page,int partnershipType,int sort)
        {
            return CommunityContent_GetCommunityLiveStatusesForClanmatesAsync(page, partnershipType, sort).Result;
        }

        ///<summary>
        ///Returns info about community members who are live streaming among your friends
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> CommunityContent_GetCommunityLiveStatusesForFriendsAsync(int page,int partnershipType,int sort)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/CommunityContent/Live/Friends/{partnershipType}/{sort}/{page}/", new Dictionary<string, string>() { { "page", page.ToString() }, { "partnershipType", partnershipType.ToString() }, { "sort", sort.ToString() } }));
        }

        public String CommunityContent_GetCommunityLiveStatusesForFriends(int page,int partnershipType,int sort)
        {
            return CommunityContent_GetCommunityLiveStatusesForFriendsAsync(page, partnershipType, sort).Result;
        }

        ///<summary>
        ///Returns info about featured live streams
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> CommunityContent_GetFeaturedCommunityLiveStatusesAsync(int page,int partnershipType,int sort)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/CommunityContent/Live/Featured/{partnershipType}/{sort}/{page}/", new Dictionary<string, string>() { { "page", page.ToString() }, { "partnershipType", partnershipType.ToString() }, { "sort", sort.ToString() } }));
        }

        public String CommunityContent_GetFeaturedCommunityLiveStatuses(int page,int partnershipType,int sort)
        {
            return CommunityContent_GetFeaturedCommunityLiveStatusesAsync(page, partnershipType, sort).Result;
        }

        ///<summary>
        ///Gets the Live Streaming status of a particular Account and Membership Type
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> CommunityContent_GetStreamingStatusForMemberAsync(long membershipId,int membershipType,int partnershipType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/CommunityContent/Live/Users/{partnershipType}/{membershipType}/{membershipId}/",new Dictionary<string, string>() { { "membershipId", membershipId.ToString() }, { "membershipType", membershipType.ToString() }, { "partnershipType", partnershipType.ToString() } } ));
        }

        public String CommunityContent_GetStreamingStatusForMember(long membershipId,int membershipType,int partnershipType)
        {
            return CommunityContent_GetStreamingStatusForMemberAsync(membershipId, membershipType, partnershipType).Result;
        }

        ///<summary>
        ///Returns trending items for Bungie.net, collapsed into the first page of items per category. For pagination within a category call GetTrendingCategory
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Trending_GetTrendingCategoriesAsync()
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Trending/Categories/", null));
        }

        public String Trending_GetTrendingCategories()
        {
            return Trending_GetTrendingCategoriesAsync().Result;
        }

        ///<summary>
        ///GGets paginated lists of trending items for a category
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Trending_GetTrendingCategoryAsync(object categoryId,int pageNumber)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Trending/Categories/{categoryId}/{pageNumber}/", new Dictionary<string, string>() { { "categoryId", categoryId.ToString() }, { "pageNumber", pageNumber.ToString() } }));
        }

        public String Trending_GetTrendingCategory(object categoryId,int pageNumber)
        {
            return Trending_GetTrendingCategoryAsync(categoryId, pageNumber).Result;
        }

        ///<summary>
        ///Returns the detailed results for a specific trending entry.  NOte that trending entries are uniquely identified by a combination of *both* the TrendingEntryType *and* the identifier: the identifier alone is not guaranted to be globally unique
        /// </summary>
        /// <returns>A json string for this endpoint</returns>
        public async Task<String> Trending_GetTrendingEntryDetailAsync(object identifier, int trendingEntryType)
        {
            return await _Web.GetStringAsync(BaseAddress + FormatWithParameters("/Trending/Details/{trendingEntryType}/{identifier}/", new Dictionary<string, string>() { { "identifier", identifier.ToString() }, { "trendingEntryType", trendingEntryType.ToString() } }));
        }

        public String Trending_GetTrendingEntryDetail(object identifier,int trendingEntryType)
        {
            return Trending_GetTrendingEntryDetailAsync(identifier, trendingEntryType).Result;
        }



    }

}