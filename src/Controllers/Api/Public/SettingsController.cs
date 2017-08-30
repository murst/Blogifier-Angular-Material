using Blogifier.Core.Controllers;
using Blogifier.Core.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers.Api.Public
{
    [Route("blogifier/api/public/[controller]/[action]")]
    public class SettingsController : Controller
    {
        IUnitOfWork _db;
        private readonly ILogger _logger;

        public SettingsController(IUnitOfWork db, ILogger<BlogController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public string Head()
        {
            var field = _db.CustomFields.Single(f => f.CustomKey == "Head");
            if (field != null)
            {
                return field.CustomValue;
            }
            return string.Empty;
        }

        public string Post()
        {
            var field = _db.CustomFields.Single(f => f.CustomKey == "Post");
            if(field != null)
            {
                return field.CustomValue;
            }
            return string.Empty;
        }

        public string Footer()
        {
            var field = _db.CustomFields.Single(f => f.CustomKey == "Footer");
            if (field != null)
            {
                return field.CustomValue;
            }
            return string.Empty;
        }
    }
}
