using Blogifier.Core.Controllers;
using Blogifier.Core.Data.Domain;
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

        private string GetCustomFieldValue(string name, int? profileId)
        {
            CustomField field;
            if (profileId.HasValue)
                field = _db.CustomFields.Single(f => f.CustomKey == name && f.ParentId == profileId.Value);
            else
                field = _db.CustomFields.Single(f => f.CustomKey == name);

            if (field != null)
                return field.CustomValue;
            else
                return string.Empty;
        }

        public string Head(int? profileId)
        {
            return GetCustomFieldValue("Head", profileId);
        }

        public string Post(int? profileId)
        {
            return GetCustomFieldValue("Post", profileId);
        }

        public string Footer(int? profileId)
        {
            return GetCustomFieldValue("Footer", profileId);
        }

        public string Google(int? profileId)
        {
            return GetCustomFieldValue("Google", profileId);
        }

        public string Twitter(int? profileId)
        {
            return GetCustomFieldValue("Twitter", profileId);
        }

        public string Github(int? profileId)
        {
            return GetCustomFieldValue("Github", profileId);
        }

        public string Facebook(int? profileId)
        {
            return GetCustomFieldValue("Facebook", profileId);
        }

        public string Instagram(int? profileId)
        {
            return GetCustomFieldValue("Instagram", profileId);
        }
    }
}
