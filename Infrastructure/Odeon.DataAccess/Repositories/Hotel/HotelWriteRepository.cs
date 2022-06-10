﻿using Odeon.Application.Repositories;
using Odeon.DataAccess.Contexts;
using Odeon.Entities;

namespace Odeon.DataAccess.Repositories
{
    public class HotelWriteRepository : WriteRepository<Hotel>, IHotelWriteRepository
    {
        public HotelWriteRepository(OdeonDbContext context) : base(context) { }
    }
}
