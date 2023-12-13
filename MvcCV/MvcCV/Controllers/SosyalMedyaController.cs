using MvcCV.Models.Entity;
using MvcCV.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class SosyalMedyaController : Controller
    {
        SosyalMedyaRepository repo = new SosyalMedyaRepository();
        public ActionResult Index()
        {
            return View(repo.GetList());
        }

        public ActionResult Sil(int id)
        {
            repo.Sil(repo.GetById(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Guncelle(TblSosyalMedya p)
        {
            var value = repo.GetById(p.ID);
            value.Ad = p.Ad;
            value.Link = p.Link;
            value.Icon = p.Icon;

            repo.Guncelle(value);

            return RedirectToAction("Index");
        }




    }
}