using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Catalyst.Controllers
{
    public class IndexController 
		: Controller
    {
        public ActionResult 
		Index()
        {
			ViewBag.Message = "Index page.";
			return View();
        }
    }
}