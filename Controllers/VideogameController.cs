using AWS_gamehub_front.Models.DTOs;
using AWS_gamehub_front.Services.HttpServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS_gamehub_front.Controllers
{
    public class VideogameController : Controller
    {
        private readonly VideogameService _videogameService;
        private readonly CommentsService _commentsService;

        public VideogameController(VideogameService videogameService, CommentsService commentsService)
        {
            _videogameService = videogameService;
            _commentsService = commentsService;
        }

        // GET: VideogameController
        public ActionResult Index()
        {
            var games = _videogameService.GetAllVideogamesAsync().Result;

            return View(games);
        }

        // GET: VideogameController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                var videogame = await _videogameService.GetVideogameByIdAsync(id);

                if (videogame == null)

                    return NotFound();

                var comments = await _commentsService.GetCommentsByVideogameIdAsync(id, 1, 10);

                //verificar si hay comentarios y almacenarlos en ViewBag
                ViewBag.Comments = comments ?? new List<CommentDto>();


                return View(videogame);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
