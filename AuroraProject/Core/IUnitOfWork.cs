using AuroraProject.Core.Repositories;

namespace AuroraProject.Core
{
    public interface IUnitOfWork
    {
        IAdvancedPackageRepository AdvancedPackageRepository { get; set; }
        IApplicationUserRepository ApplicationUserRepository { get; set; }
        IAuctionRepository AuctionRepository { get; set; }
        IAuroraWalletRepository AuroraWalletRepository { get; set; }
        IBasicPackageRepository BasicPackageRepository { get; set; }
        IFavouriteGigRepository FavouriteGigRepository { get; set; }
        IFavouriteInfluencerRepository FavouriteInfluencerRepository { get; set; }
        IFileUploadRepository FileUploadRepository { get; set; }
        IGigRepository GigsRepository { get; }
        IInfluencerRepository InfluencerRepository { get; }
        IMembershipTypeRepository MembershipTypeRepository { get; set; }
        INotificationsRepository NotificationsRepository { get; set; }
        IPremiumPackageRepository PremiumPackageRepository { get; set; }
        ISpecificIndustryRepository SpecificIndustryRepository { get; set; }
        IUserNotificationsRepository UserNotificationsRepository { get; set; }
        IWalletRepository WalletRepository { get; set; }
        IIndustryRepository IndustryRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        IShoppingCartRepository ShoppingCartRepository { get; set; }

        void Complete();
    }
}