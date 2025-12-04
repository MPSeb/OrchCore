using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesSql;
using YesSql.Services;
namespace MyNotesModule.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("Notes/[action]")]
    public class NotesController : Controller
    {
        private readonly IContentManager _contentManager;
        private readonly ISession _session;
        public NotesController(IContentManager contentManager, ISession session)
        {
            _contentManager = contentManager;
            _session = session;
        }
        // GET /Notes/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var projects = await _session.Query<ContentItem, ContentItemIndex>()
                .Where(x => x.ContentType == "ProjectNote" && x.Published)
                .ListAsync();

            ViewBag.Projects = projects ?? Enumerable.Empty<ContentItem>();
            return View();

        }

        // POST /Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string title, string description, string projectId)
        {
            var note = await _contentManager.NewAsync("Note");
            note.DisplayText = title ?? "Untitled";

            note.Content.Note = new
            {
                ProjectContent = new
                {
                    ContentItemIds = string.IsNullOrEmpty(projectId)
                        ? Array.Empty<string>()
                        : new[] { projectId }
                },
                Images = new
                {
                    Paths = Array.Empty<string>(),
                    MediaTexts = new[] { "" }
                },
                NoteText = new
                {
                    Text = description ?? string.Empty
                }
            };

            if (!string.IsNullOrEmpty(projectId))
            {
                note.Content.ContainedPart = new
                {
                    ListContentItemId = projectId,
                    ListContentType = "ProjectNote",
                    Order = 0
                };
            }

            await _contentManager.CreateAsync(note);

            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            IEnumerable<ContentItem> items = Enumerable.Empty<ContentItem>();

                var contentTypes = new [] { "Note", "ProjectNote"};
                items = await _session
                    .Query<ContentItem, ContentItemIndex>(x => x.ContentType.IsIn(contentTypes) && x.Published)
                    .ListAsync();

            foreach (var item in items)
            {
                await _contentManager.LoadAsync(item);
            }

            return View(items);
        }

    }
}