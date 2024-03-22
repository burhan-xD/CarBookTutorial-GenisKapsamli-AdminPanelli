using Application.Interfaces.TagCloudInterfaces;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRespository : ITagCloudRespository
    {
        private readonly CarBookContext _carBookContext;

        public TagCloudRespository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<TagCloud> GetTagCloudsByBlogId(int id)
        {
            var values = _carBookContext.TagClouds.Where(x=>x.BlogId == id).ToList();
            return values;
        }
    }
}
