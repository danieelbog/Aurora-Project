using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.DTO
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int? BasicPackageID { get; set; }
        public int? AdvancedPackageID { get; set; }
        public int? PremiumPackageID { get; set; }
        public int GigID { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public string SellerInstructions { get; set; }
        public string Coupon { get; set; }
        public string PackageName { get; set; }

    }
}