using AuroraProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraProject.Interfaces
{
    public interface ISellingPackage
    {
        int ID { get; set; }

        int Price { get; set; }

        string PackageName { get; set; }

        string PackageDescreption { get; set; }

        int DeliveryTime { get; set; }

        void SellPackage(ApplicationUser user, Wallet toUserWallet, AuroraWallet toAuroraWallet);
    }
}
