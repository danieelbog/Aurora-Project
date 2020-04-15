using AuroraProject.Models;

namespace AuroraProject.Repositories
{
    public interface IWalletRepository
    {
        Wallet GetWallet(string userId);
        Wallet GetWalletForUpdate(string userId);
    }
}