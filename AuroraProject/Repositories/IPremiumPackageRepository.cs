using AuroraProject.Models;

namespace AuroraProject.Repositories
{
    public interface IPremiumPackageRepository
    {
        void AddPremiumPackage(PremiumPackage premiumPackage);
        PremiumPackage GetPremiumPackagePurchase(int? premiumPackageId);
        void RemovePremiumPackage(PremiumPackage premiumPackage);
    }
}