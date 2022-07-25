using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cms_net.Context;
using cms_net.Models;
using cms_net.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cms_net.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult ComponentList()
        {

            
            try
            {
                
                ViewData["componentNameList"] = ComponentHelper.GetComponentDirectoryList();

            }
            catch (DirectoryNotFoundException e)
            {
                ViewData["error"] = "Impossibile trovare la dei componenti al path " + ComponentHelper.COMPONENT_PATH;
            }


            return View();

        }



        public IActionResult InstallComponent(string name)
        {
 
            CMSContext ctx = new CMSContext();
            ComponentDefinition cd = new ComponentDefinition(name);

            ctx.ComponentsDefinitions.Add(cd);

            ctx.SaveChanges();


            return RedirectToAction("ComponentList");

        }

        public IActionResult UninstallComponent(string name)
        {


            CMSContext ctx = new CMSContext();
            ComponentDefinition cd = ctx.ComponentsDefinitions.Where(cd => cd.Key == name).FirstOrDefault();

            ctx.ComponentsDefinitions.Remove(cd);

            ctx.SaveChanges();


            return RedirectToAction("ComponentList");

        }
    }
}

