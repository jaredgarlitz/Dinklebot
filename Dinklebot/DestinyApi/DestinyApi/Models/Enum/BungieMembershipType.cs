﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;

namespace DestinyApi.Models.Enum
{
    public enum BungieMembershipType
    {
        None = 0,
        TigerXbox = 1,
        TigerPsn = 2,
        TigerBlizzard = 4,
        TigerDemon = 10,
        BungieNext = 254,
        All = -1
    }
}