using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IBasicPackageRepository
    {
        void AddBasicPackage(BasicPackage basicPackage);
        BasicPackage GetBasicPackagePurchase(int? basicPackageId);
        void RemoveBasicPackage(BasicPackage basicPackage);
    }
}