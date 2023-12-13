using MvcCV.Models.Entity;
using MvcCV.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository d = new DeneyimRepository();
        public ActionResult Index()
        {
            return View(d.GetList());
        }


        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TblDeneyim p)
        {
            d.Add(p);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult DeneyimGuncelle(int id)
        {

            return View(d.GetById(id));
        }
        [HttpPost]
        public ActionResult DeneyimGuncelle(TblDeneyim p)
        {
            var value = d.GetById(p.ID);
            value.Baslik = p.Baslik;
            value.AltBaslik = p.AltBaslik;
            value.Aciklama = p.Aciklama;
            value.Tarih = p.Tarih;

            d.Guncelle(value);

            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            d.Sil(d.GetById(id));
            return RedirectToAction("Index");
        }


    }
}