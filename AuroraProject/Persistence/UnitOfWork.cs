using AuroraProject.Core;
using AuroraProject.Core.Repositories;
using AuroraProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGigRepository GigsRepository { get; private set; }
        public IInfluencerRepository InfluencerRepository { get; private set; }
        public ISpecificIndustryRepository SpecificIndustryRepository { get; set; }
        public IFavouriteGigRepository FavouriteGigRepository { get; set; }
        public IFavouriteInfluencerRepository FavouriteInfluencerRepository { get; set; }
        public IApplicationUserRepository ApplicationUserRepository { get; set; }
        public IBasicPackageRepository BasicPackageRepository { get; set; }
        public IAdvancedPackageRepository AdvancedPackageRepository { get; set; }
        public IPremiumPackageRepository PremiumPackageRepository { get; set; }
        public IFileUploadRepository FileUploadRepository { get; set; }
        public IMembershipTypeRepository MembershipTypeRepository { get; set; }
        public IAuroraWalletRepository AuroraWalletRepository { get; set; }
        public INotificationsRepository NotificationsRepository { get; set; }
        public IUserNotificationsRepository UserNotificationsRepository { get; set; }
        public IWalletRepository WalletRepository { get; set; }
        public IAuctionRepository AuctionRepository { get; set; }
        public IIndustryRepository IndustryRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IShoppingCartRepository ShoppingCartRepository { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            GigsRepository = new GigRepository(context);
            InfluencerRepository = new InfluencerRepository(context);
            SpecificIndustryRepository = new SpecificIndustryRepository(context);
            FavouriteGigRepository = new FavouriteGigRepository(context);
            FavouriteInfluencerRepository = new FavouriteInfluencerRepository(context);
            ApplicationUserRepository = new ApplicationUserRepository(context);
            BasicPackageRepository = new BasicPackageRepository(context);
            AdvancedPackageRepository = new AdvancedPackageRepository(context);
            PremiumPackageRepository = new PremiumPackageRepository(context);
            FileUploadRepository = new FileUploadRepository(context);
            MembershipTypeRepository = new MembershipTypeRepository(context);
            AuroraWalletRepository = new AuroraWalletRepository(context);
            NotificationsRepository = new NotificationsRepository(context);
            UserNotificationsRepository = new UserNotificationsRepository(context);
            WalletRepository = new WalletRepository(context);
            AuctionRepository = new AuctionRepository(context);
            IndustryRepository = new IndustryRepository(context);
            OrderRepository = new OrderRepository(context);
            ShoppingCartRepository = new ShoppingCartRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}