using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IPremiumPackageRepository
    {
        void AddPremiumPackage(PremiumPackage premiumPackage);
        PremiumPackage GetPremiumPackagePurchase(int? premiumPackageId);
        void RemovePremiumPackage(PremiumPackage premiumPackage);
    }
}