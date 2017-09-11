using Blogifier.Core.Controllers;
using Blogifier.Core.Data.Domain;
using Blogifier.Core.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace WebApp.Controllers.Api.Public
{
    [Route("blogifier/api/public/[controller]")]
    public class AuthorsController : Controller
    {
        IUnitOfWork _db;
        private readonly ILogger _logger;

        public AuthorsController(IUnitOfWork db, ILogger<BlogController> logger)
        {
            _db = db;
            _logger = logger;
        }

        protected void Sanitize(Profile profile)
        {
            profile.Assets = null;
            profile.BlogPosts = null;
            profile.IsAdmin = false;
            profile.AuthorEmail = "";
            profile.IdentityName = "";
        }

        [Route("{slug}")]
        public IEnumerable<Profile> Get(string slug)
        {

            IEnumerable<Profile> profiles;

            if (String.IsNullOrEmpty(slug))
            {
                profiles = _db.Profiles.Find(p => p.LastUpdated >= DateTime.MinValue);
            }
            else
            {
                profiles = _db.Profiles.Find(p => p.Slug == slug);
            }

            // sanitize: remove any private info and remove other items which aren't directly related to author info
            foreach(Profile profile in profiles)
            {
                Sanitize(profile);
            }

            return profiles;
        }
    }
}
