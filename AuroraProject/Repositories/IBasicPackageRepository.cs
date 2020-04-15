using AuroraProject.Models;

namespace AuroraProject.Repositories
{
    public interface IBasicPackageRepository
    {
        void AddBasicPackage(BasicPackage basicPackage);
        BasicPackage GetBasicPackagePurchase(int? basicPackageId);
        void RemoveBasicPackage(BasicPackage basicPackage);
    }
}