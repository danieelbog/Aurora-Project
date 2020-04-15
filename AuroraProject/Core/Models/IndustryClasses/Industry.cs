using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class Industry
    {
        public int ID { get; set; }
        public string IndustryName { get; set; }

        // NAVIGATION PROPERTY TO SPECIFIC INDUSTRIES
        public ICollection<SpecificIndustry> SpecificIndustries { get; set; }
    }
}