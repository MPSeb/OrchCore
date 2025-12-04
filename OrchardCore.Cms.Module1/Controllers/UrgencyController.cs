using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Cms.Module1.Indexing;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql;
using YesSql.Services;

namespace OrchardCore.Cms.Module1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UrgencyController : Controller
    {
        private readonly IContentManager _contentManager;
        private readonly ISession _session;

        public UrgencyController(IContentManager contentManager, ISession session)
        {
            _contentManager = contentManager;
            _session = session;
        }


        [Route("Urgencies/Urgent")]
        public async Task<IActionResult> List()
        {
            var min = 5;
            ViewBag.Title = "Urgenct Notes";
            var urgencies = await _session
                .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "Note2")
                .With <UrgencyPartIndex>(urgencyPartIndex => urgencyPartIndex.UrgencyMeter > min)
                .ListAsync();

            return View(urgencies);
        }

        [Route("Urgencies/All")]
        public async Task<IActionResult> ListAll()
        {
            ViewBag.Title = "All Urgency Notes";

            var urgencies = await _session
                    .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "Note2" && index.Published)
                    .ListAsync();

            return View("List", urgencies);
        }
    }
}
