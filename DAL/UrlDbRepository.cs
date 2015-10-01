using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BOL;

namespace DAL
{
    public class UrlDbRepository
    {
        private Mvc3TierEntities db;

        public UrlDbRepository()
        {
            db = new Mvc3TierEntities();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return db.tbl_Url.ToList();
        }

        public tbl_Url GetById(int id)
        {
            return db.tbl_Url.Find(id);
        }

        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            Save();
        }

        public void Delete(int id)
        {
            tbl_Url url = db.tbl_Url.Find(id);
            db.tbl_Url.Remove(url);
            Save();
        }

        public void Update(tbl_Url url)
        {
            db.Entry(url).State = EntityState.Modified;
        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
