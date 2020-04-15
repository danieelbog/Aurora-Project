using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IAdvancedPackageRepository
    {
        void AddAdvancedPackage(AdvancedPackage advancedPackage);
        AdvancedPackage GetAdvancedPackagePurchase(int? advancedPackageId);
        void RemoveAdvancedPackage(AdvancedPackage advancedPackage);
    }
}