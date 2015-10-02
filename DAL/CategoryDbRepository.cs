using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BOL;

namespace DAL
{
    public class CategoryDbRepository
    {
        private Mvc3TierEntities db;

        public CategoryDbRepository()
        {
            db = new Mvc3TierEntities();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }

        public tbl_Category GetById(int id)
        {
            return db.tbl_Category.Find(id);
        }

        public void Insert(tbl_Category url)
        {
            db.tbl_Category.Add(url);
            Save();
        }

        public void Delete(int id)
        {
            tbl_Category url = db.tbl_Category.Find(id);
            db.tbl_Category.Remove(url);
            Save();
        }

        public void Update(tbl_Category url)
        {
            db.Entry(url).State = EntityState.Modified;
        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
