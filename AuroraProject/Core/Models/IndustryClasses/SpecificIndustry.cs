using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class SpecificIndustry
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phrase { get; set; }

        //Relation With Industry
        public int IndustryID { get; set; }
        public Industry Industry { get; set; }
    }
}