using AWS_gamehub_front.Services.HttpServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS_gamehub_front.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentsService _commentsService;

        public CommentController(CommentsService commentsService)
        {
            _commentsService = commentsService;
        }
        // GET: CommentController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("Comment/ByVideogame/{id}")]
        public async Task<IActionResult> ByVideogame(string id, int page = 1, int size = 10)
        {
            var comments = await _commentsService.GetCommentsByVideogameIdAsync(id, page, size);

            return View(comments); // O retorna PartialView, JSON, etc. según tu necesidad
        }

        // GET: CommentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
