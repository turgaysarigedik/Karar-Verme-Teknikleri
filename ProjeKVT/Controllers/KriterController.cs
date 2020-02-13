using ProjeKVT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeKVT.Controllers
{
    public class KriterController : Controller
    {
        // GET: Kriter
        public ActionResult Kriterler(IntermediateMatris model)
        {
            return View(model);
        }
      
    }
}