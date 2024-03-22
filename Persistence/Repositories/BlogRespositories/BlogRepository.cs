using Application.Interfaces.BlogInterfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.BlogRespositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            var values = _context.Blogs.Include(b => b.Author).Include(c=>c.Category).ToList();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values = _context.Blogs.Include(b => b.Author).Where(a=>a.BlogId == id).ToList();
            return values;
        }

        public List<Blog> GetLastThreeBlogsWithAuthor()
        {
            var values = _context.Blogs.Include(b => b.Author).OrderByDescending(x=> x.BlogId).Take(3).ToList();
            return values;
        }
    }
}
