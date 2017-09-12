using Blogifier.Core.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;
using System;

namespace WebApp.Controllers.Api.Public
{
    public class SitemapController : Controller
    {

        IUnitOfWork _db;

        public SitemapController(IUnitOfWork db)
        {
            _db = db;
        }

        public string GetUrl(Blogifier.Core.Data.Domain.BlogPost post)
        {
            return String.Format("{0}://{1}/#!/post/{2}", Request.IsHttps ? "https" : "http", Request.Host, post.Slug);
        }

        [Produces("text/xml")]
        [Route("sitemap.xml")]
        public IActionResult Sitemap()
        {
            XNamespace sitemap = XNamespace.Get("http://www.sitemaps.org/schemas/sitemap/0.9");

            var posts = _db.BlogPosts.Find(p => p.Published > DateTime.MinValue).OrderByDescending(p => p.Published);

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(sitemap + "urlset", 
                    from post in posts
                    select new XElement(sitemap + "url", 
                        new XElement(sitemap + "loc", GetUrl(post)),
                        new XElement(sitemap + "lastmod", post.LastUpdated.ToString("yyyy-M-d")),
                        new XElement(sitemap + "changefreq", "monthly")
                    )
                )
            );
            
            return this.Content(doc.Declaration.ToString() + Environment.NewLine + doc.ToString(), "text/xml");
        }
    }
}