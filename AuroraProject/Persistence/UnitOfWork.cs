using AuroraProject.Models;
using AuroraProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuroraProject.Persistence
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public GigRepository GigsRepository { get; private set; }
        public InfluencerRepository InfluencerRepository { get; private set; }
        public SpecificIndustryRepository SpecificIndustryRepository { get; set; }
        public FavouriteGigRepository FavouriteGigRepository { get; set; }
        public FavouriteInfluencerRepository FavouriteInfluencerRepository { get; set; }
        public ApplicationUserRepository ApplicationUserRepository { get; set; }
        public BasicPackageRepository BasicPackageRepository { get; set; }
        public AdvancedPackageRepository AdvancedPackageRepository { get; set; }
        public PremiumPackageRepository PremiumPackageRepository { get; set; }
        public FileUploadRepository FileUploadRepository { get; set; }
        public MembershipTypeRepository MembershipTypeRepository { get; set; }
        public AuroraWalletRepository AuroraWalletRepository { get; set; }
        public NotificationsRepository NotificationsRepository { get; set; }
        public UserNotificationsRepository UserNotificationsRepository { get; set; }

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
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}