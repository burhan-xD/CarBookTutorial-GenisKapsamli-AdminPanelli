﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRespository
    {
        List<TagCloud> GetTagCloudsByBlogId(int id);
    }
}
