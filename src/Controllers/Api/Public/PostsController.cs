using Blogifier.Core.Common;
using Blogifier.Core.Data.Interfaces;
using Blogifier.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace WebApp.Controllers.Api.Public
{
    [Route("blogifier/api/public/[controller]")]
    public class PostsController : Controller
    {
        IUnitOfWork _db;

        public PostsController(IUnitOfWork db)
        {
            _db = db;
        }

        // gets posts by category in single-blog mode. Blogifier.Core at the moment requires a profile
        [HttpGet("[action]/{cat}")]
        public BlogPostsModel Category(string cat, int page = 1)
        {
            var pager = new Pager(page);
            IEnumerable<PostListItem> posts = _db.BlogPosts.ByCategory(cat, pager).Result.OrderByDescending(p => p.Published);

            if (page < 1 || page > pager.LastPage)
                return null;

            foreach (PostListItem post in posts)
            {
                post.AuthorEmail = "";
            }

            return new BlogPostsModel
            {
                Posts = posts,
                Pager = pager
            };
        }
    }
}