using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarPartial()
        {
            return PartialView(db.TblHakkimda.FirstOrDefault());
        }

        public PartialViewResult AboutPartial()
        {

            return PartialView(db.TblHakkimda.OrderByDescending(x=>x.ID).FirstOrDefault());
        }

        public PartialViewResult ExperiencePartial()
        {
            return PartialView(db.TblDeneyim.ToList());
        }

        public PartialViewResult EducationPartial()
        {
            return PartialView(db.TblEgitim.ToList());
        }

        public PartialViewResult SkillPartial()
        {
            return PartialView(db.TblYetenek.ToList());
        }
        public PartialViewResult InterestPartial()
        {
            return PartialView(db.TblHobilerim.ToList());
        }

        public PartialViewResult CertificationPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult ContactPartial(TblIletisim p)
        {
            p.Tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            db.TblIletisim.Add(p);
            db.SaveChanges();
            return PartialView();
        }

        public PartialViewResult SosyalMedyaPartial()
        {

            return PartialView(db.TblSosyalMedya.ToList());
        }

    }
}