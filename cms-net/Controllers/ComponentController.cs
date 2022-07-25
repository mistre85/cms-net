using cms_net.Context;
using cms_net.Models;
using cms_net.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace cms_net.Controllers
{
    public class ComponentController : Controller
    {
        // GET: ComponentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComponentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComponentController/Create
        public ActionResult Select(int id)
        {
            CMSContext ctx = new CMSContext();

            List<ComponentDefinition> installedComponents = ctx.ComponentsDefinitions.ToList();

            ViewData["pageId"] = id;

            return View(installedComponents);
        }

        // GET: ComponentController/Create
        public ActionResult Create(string key,int pageId)
        {
            // ??
     
            string[] fieldsList = ComponentHelper.GetFieldsFromComponentFile(key);

            ViewData["key"] = key;
            ViewData["pageId"] = pageId;

            return View(fieldsList);
        }

        // POST: ComponentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id,string key,IFormCollection collection)
        {
            CMSContext context = new CMSContext();

            Component c = new Component();
            c.PageId = id;
            c.fields = new List<Field>();
            c.ComponentDefinitionKey = key; 

            foreach (string field in collection.Keys)
            {
                
                c.fields.Add(new Field(field, collection[field]));
            }

            context.Components.Add(c);

            context.SaveChanges();

            return RedirectToAction("Edit", "Page", new { id = id });
        }

        // GET: ComponentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComponentController/Edit/5
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

        // GET: ComponentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComponentController/Delete/5
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
