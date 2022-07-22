using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            //1.    leggere la lista della sottocartelle di /Views/Components 

            //todo: mettere cartella relativa e non assoluta
            string component_path = "/Users/mistre/Projects/cms-net/cms-net/Views/Page/Components";

            //todo: gestire exception su mancaze dir
            string[] dirs = Directory.GetDirectories(component_path, "*", SearchOption.TopDirectoryOnly);

            List<string> componentNameList = new List<string>();

            foreach (string dir in dirs)
            {
                string[] dirSplit = dir.Split("/");
                string componentName = dirSplit.Last();

                componentNameList.Add(componentName);
            }

            ViewData["componentNameList"] = componentNameList;

            return View();
        }



        public IActionResult InstallComponent(string name)
        {



            return View();

        }
    }
}

