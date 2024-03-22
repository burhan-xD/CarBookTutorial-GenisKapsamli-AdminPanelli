using Application.Interfaces.CarInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsWithBrands()
        {   
            var values = _context.Cars.Include(x=>x.Brand).ToList();
            return values;
        }

        public List<Car> GetLastFiveCarsBrand()
        {                                                   // son eklenen 5 aracin getirilmesi
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x=>x.CarId).Take(5).ToList();
            return values;
        }
    }
}
