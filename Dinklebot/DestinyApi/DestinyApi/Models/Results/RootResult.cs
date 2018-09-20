using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;

namespace DestinyApi.Models.Results
{
    public class RootResult
    {
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public Messagedata Messagedata { get; set; }
    }

    public class Messagedata
    {

    }
}