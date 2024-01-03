using lesson6_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson6_MVC.Controllers
{
    public class ShowelController : Controller
    {
        // GET: ShowelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShowelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
    }
}
