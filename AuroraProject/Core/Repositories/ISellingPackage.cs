using AuroraProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraProject.Core.Repositories
{
    public interface ISellingPackage
    {
        int ID { get; set; }

        int Price { get; set; }

        string PackageName { get; set; }

        string PackageDescreption { get; set; }

        int DeliveryTime { get; set; }

        void SellPackage(ApplicationUser buyerUser, ApplicationUser sellerUser, AuroraWallet toAuroraWallet);
    }
}
