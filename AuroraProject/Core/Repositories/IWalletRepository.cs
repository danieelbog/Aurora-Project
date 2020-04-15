using AuroraProject.Core.Models;

namespace AuroraProject.Core.Repositories
{
    public interface IWalletRepository
    {
        Wallet GetWallet(string userId);
        Wallet GetWalletForUpdate(string userId);
    }
}