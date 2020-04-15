using AuroraProject.Models;

namespace AuroraProject.Repositories
{
    public interface IAdvancedPackageRepository
    {
        void AddAdvancedPackage(AdvancedPackage advancedPackage);
        AdvancedPackage GetAdvancedPackagePurchase(int? advancedPackageId);
        void RemoveAdvancedPackage(AdvancedPackage advancedPackage);
    }
}