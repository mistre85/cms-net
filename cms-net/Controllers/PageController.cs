using cms_net.Context;
using cms_net.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cms_net.Controllers
{
    public class PageController : Controller
    {

        private readonly CMSContext _context;

        public PageController()
        {
            _context = new CMSContext();
        }
        // GET: PageController
        public ActionResult Index()
        {

            List<Page> pages = _context.Pages.ToList();
            return View(pages);

        }

        public ActionResult Details(int id)
        {
            Page p = _context.Pages.Where(p => p.Id == id).Include(p => p.Components).FirstOrDefault();
            return View(p);
        }

        // GET: PageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PageController/Create
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

        // GET: PageController/Edit/5
        public ActionResult Edit(int id)
        {
            Page p = _context.Pages.Where(p => p.Id == id).Include(p => p.Components).FirstOrDefault();
            ViewData["pageId"] = p.Id;
            return View(p);
        }

        // POST: PageController/Edit/5
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

        // GET: PageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PageController/Delete/5
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
