﻿using Application.Features.CQRS.Results.BrandResults;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Brands.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBrandQueryResult()
            {
                BrandId = x.BrandId,
                Name = x.Name,           
            }).ToList();
        }
    }
}
