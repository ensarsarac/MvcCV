using MvcCV.Models.Entity;
using MvcCV.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    [Authorize]
    public class EgitimController : Controller
    {
        EgitimRepository er = new EgitimRepository();
        public ActionResult Index()
        {
            return View(er.GetList());
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitim p)
        {
            if (ModelState.IsValid)
            {
                er.Add(p);
                return RedirectToAction("Index");

            }
            else
            {
                return View(p);
            }
        }

        [HttpGet]
        public ActionResult EgitimGuncelle(int id)
        {
            var value = er.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult EgitimGuncelle(TblEgitim p)
        {
            var value = er.GetById(p.ID);
            value.Baslik = p.Baslik;
            value.AltBaslik1 = p.AltBaslik1;
            value.AltBaslik2 = p.AltBaslik2;
            value.GNO = p.GNO;
            value.Tarih = p.Tarih;
            er.Guncelle(value);

            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            er.Sil(er.GetById(id));
            return RedirectToAction("Index");
        }



    }
}