using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLastFiveCarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLastFiveCarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetLastFiveCarsWithBrandQueryResult> Handle()
        {
            var values = _repository.GetLastFiveCarsBrand();
            return values.Select(x => new GetLastFiveCarsWithBrandQueryResult
            {
                CarId = x.CarId,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name
            }).ToList();
        }
    }
}
