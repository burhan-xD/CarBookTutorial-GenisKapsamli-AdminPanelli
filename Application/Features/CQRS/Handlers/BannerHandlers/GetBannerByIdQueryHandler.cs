﻿using Application.Features.CQRS.Queries.AboutQueries;
using Application.Features.CQRS.Queries.BannerQueries;
using Application.Features.CQRS.Results.AboutResult;
using Application.Features.CQRS.Results.BannerResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerId = values.BannerId,
                VideoUrl = values.VideoUrl,
                VideoDescription = values.VideoDescription,
                Title = values.Title,
                Description = values.Description,
            };
        }
    }
}
