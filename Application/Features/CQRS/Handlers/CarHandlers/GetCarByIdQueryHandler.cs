using Application.Features.CQRS.Queries.CarQueries;
using Application.Features.CQRS.Results.CarResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarId = values.CarId,
                BrandId = values.BrandId,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Model = values.Model,
                Luggage = values.Luggage,
                Km = values.Km,
                Fuel = values.Fuel,
                CoverImageUrl = values.CoverImageUrl,
                BigImageUrl = values.BigImageUrl,
            };
        }
    }
}
