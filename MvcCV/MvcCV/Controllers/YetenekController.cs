using MvcCV.Models.Entity;
using MvcCV.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class YetenekController : Controller
    {
        YetenekRepository y = new YetenekRepository();
        public ActionResult Index()
        {
            return View(y.GetList());
        }

        [HttpGet]
        public ActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YetenekEkle(TblYetenek p)
        {
            y.Add(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            y.Sil(y.GetById(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YetenekGuncelle(int id)
        {
            var value = y.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult YetenekGuncelle(TblYetenek p)
        {
            var value = y.GetById(p.ID);
            value.Yetenek = p.Yetenek;
            value.Oran = p.Oran;
            y.Guncelle(value);
            return RedirectToAction("Index");
        }


    }
}