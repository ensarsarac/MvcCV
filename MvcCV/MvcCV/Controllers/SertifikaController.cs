using MvcCV.Models.Entity;
using MvcCV.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository repo = new SertifikaRepository();
        public ActionResult Index()
        {
            return View(repo.GetList());
        }

        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {

            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult SertifikaGuncelle(TblSertifika p)
        {
            var value = repo.GetById(p.ID);
            value.Aciklama = p.Aciklama;
            value.Tarih = p.Tarih;

            repo.Guncelle(value);

            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            repo.Sil(repo.GetById(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SertifikaEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SertifikaEkle(TblSertifika p)
        {
            repo.Add(p);
            return RedirectToAction("Index");
        }



    }
}