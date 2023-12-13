using MvcCV.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        HobiRepository repo = new HobiRepository();
        public ActionResult Index()
        {
            return View(repo.GetList()); ;
        }
    }
}