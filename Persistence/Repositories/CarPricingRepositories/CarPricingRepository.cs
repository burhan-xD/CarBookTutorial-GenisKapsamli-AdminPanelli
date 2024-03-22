using Application.Interfaces.CarPricingInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRespository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(p => p.Car).ThenInclude(y => y.Brand).Include(x=> x.Pricing).Where(z=>z.PricingId==3).ToList();
            return values;
        }
    }
}
