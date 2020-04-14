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


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            GigsRepository = new GigRepository(context);
            InfluencerRepository = new InfluencerRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

    }
}