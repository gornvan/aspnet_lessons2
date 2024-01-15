using lesson6_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson6_MVC.Controllers
{
    public class ShowelController : Controller
    {
        static List<ShowelViewModel> Showels = new List<ShowelViewModel>();


        // GET: ShowelController
        public ActionResult Index()
        {
            // the View method will search for the cshtml view implementation
            // in /Views/{controller}/{action}.cshtml
            return View(Showels);
        }

        // GET: ShowelController/Details/5
        public ActionResult Details(int? id)
        {
            if (! id.HasValue) {
                return NotFound("Empty id supplied!");
            }
            
            ViewBag.HelloMessage = "Hello it's the Details page!";

            var showel = Showels[id.Value];

            return View(showel);
        }

        // GET: ShowelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowelViewModel showel)
        {
            try
            {
                showel.Id = Showels.Count;

                Showels.Add(showel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShowelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShowelViewModel showel)
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

        // GET: ShowelController/Delete/5
        public ActionResult ConfirmDeleteView(int id)
        {
            return View();
        }

        // POST: ShowelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
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

        public JsonResult GetAllShowels() {
            return Json(Showels);
        }

        public ActionResult<List<ShowelViewModel>> GetAllShowels2()
        {
            return Ok(Showels);
        }

        public ContentResult GetAllShowels_c()
        {
            return Content("Result content is just text we want to pass to the client, it can be html as well");
        }
    }
}
