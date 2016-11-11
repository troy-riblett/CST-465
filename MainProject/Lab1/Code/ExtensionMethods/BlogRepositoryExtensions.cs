using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465
{
    public static class BlogRepositoryExtensions
    {
        public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> repo, string filter)
        {
            List<BlogPost> blogList = repo.GetList();

            return blogList.Where(blog => blog.Title.Contains(filter) || blog.Content.Contains(filter)).ToList();
        }
    }
}