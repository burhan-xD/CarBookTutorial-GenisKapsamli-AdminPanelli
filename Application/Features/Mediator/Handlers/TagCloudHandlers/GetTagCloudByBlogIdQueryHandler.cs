using Application.Features.Mediator.Queries.TagCloudQueries;
using Application.Features.Mediator.Results.TagCloudResults;
using Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRespository _tagCloudRespository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRespository tagCloudRespository)
        {
            _tagCloudRespository = tagCloudRespository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _tagCloudRespository.GetTagCloudsByBlogId(request.Id);
            return values.Select(x=> new GetTagCloudByBlogIdQueryResult
            {
                BlogId = x.BlogId,
                TagCloudId = x.TagCloudId,
                Title = x.Title,
            }).ToList();
        }
    }
}
