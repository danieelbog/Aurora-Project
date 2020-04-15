using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.DTO
{
    public class GigDto
    {
        public int ID { get; set; }
        public bool IsDisabled { get; set; }

        public int? BasicPackageID { get; set; }
        public BasicPackageDto BasicPackageDto { get; set; }

        public int? AdvancedPackageID { get; set; }
        public AdvancedPackageDto AdvancedPackagedDto { get; set; }

        public int? PremiumPackageID { get; set; }
        public PremiumPackageDto PremiumPackagedDto { get; set; }

    }
}