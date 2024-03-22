using Domain.Entities;

namespace Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public List<Blog> GetLastThreeBlogsWithAuthor();
        public List<Blog> GetAllBlogsWithAuthor();
        public List<Blog> GetBlogByAuthorId(int id);
    }
}
