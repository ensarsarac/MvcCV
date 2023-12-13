using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCV.Models.Repository
{
    public class GenericRepository<T> where T:class
    {
        DbCvEntities db = new DbCvEntities();
        public List<T> GetList()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var value = db.Set<T>().Find(id);
            return value;
        }

        public void Guncelle(T t)
        {
            db.SaveChanges();
        }

        public void Add(T t)
        {
            db.Set<T>().Add(t);
            db.SaveChanges();
        }
        public void Sil(T t)
        {
            db.Set<T>().Remove(t);
            db.SaveChanges();
        }

    }
}