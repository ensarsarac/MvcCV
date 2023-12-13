using MvcCV.Models.Entity;
using MvcCV.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository repo = new AdminRepository();
        public ActionResult Index()
        {
            AboutRepository a = new AboutRepository();
            return View(a.GetList());
        }

        public ActionResult HakkimdaDetay(int id)
        {
            AboutRepository a = new AboutRepository();
            return View(a.GetById(id));
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            AboutRepository a = new AboutRepository();
            var value = a.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult Guncelle(TblHakkimda p)
        {
            AboutRepository a = new AboutRepository();
            var value = a.GetById(p.ID);
            value.Ad = p.Ad;
            value.Soyad = p.Soyad;
            value.Adres = p.Adres;
            value.Telefon = p.Telefon;
            value.Mail = p.Mail;
            value.Aciklama = p.Aciklama;

            a.Guncelle(value);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HakkimdaEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult HakkimdaEkle(TblHakkimda p)
        {
            AboutRepository a = new AboutRepository();
            a.Add(p);
            return RedirectToAction("Index");
        }

        public ActionResult HakkimdaSil(int id)
        {
            AboutRepository a = new AboutRepository();
            a.Sil(a.GetById(id));
            return RedirectToAction("Index");
        }

        public ActionResult AdminIslemler()
        {
            
            var liste = repo.GetList();
            return View(liste);
        }

        public ActionResult AdminSil(int id)
        {
            repo.Sil(repo.GetById(id));
            return RedirectToAction("AdminIslemler");
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TblAdmin p)
        {
            repo.Add(p);
            return RedirectToAction("AdminIslemler");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {

            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult AdminGuncelle(TblAdmin p)
        {
            var value = repo.GetById(p.ID);
            value.KullaniciAdi = p.KullaniciAdi;
            value.Sifre = p.Sifre;
            repo.Guncelle(value);
            return RedirectToAction("AdminIslemler");
        }





    }
}