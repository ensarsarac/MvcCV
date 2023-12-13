using MvcCV.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class IletisimController : Controller
    {
        IletisimRepository repo = new IletisimRepository();
        public ActionResult Index()
        {
            return View(repo.GetList());
        }

        public ActionResult MesajSil(int id)
        {
            repo.Sil(repo.GetById(id));
            return RedirectToAction("Index");
        }
    }
}