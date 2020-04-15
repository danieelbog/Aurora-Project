using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.DTO
{
    public class InfluencerDto
    {
        public int InfluencerID { get; set; }

        public string MainLanguage { get; set; }

        public string MainPlatform { get; set; }

        public string Exposure { get; set; }

        public string MainTopic { get; set; }

        public string AudienceAge { get; set; }

        public string AudienceMainCountry { get; set; }

        public string AudienceMainState { get; set; }

        public string AudienceMainTrait { get; set; }

        public string AboutTheInfluencer { get; set; }

        // RELATION WITH MEMBERSHIPTYPE
        public int MembershipTypeID { get; set; }
    }
}