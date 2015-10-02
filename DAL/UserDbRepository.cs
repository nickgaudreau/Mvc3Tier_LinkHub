using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BOL;

namespace DAL
{
    public class UserDbRepository
    {
        private Mvc3TierEntities db;

        public UserDbRepository()
        {
            db = new Mvc3TierEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetById(int id)
        {
            return db.tbl_User.Find(id);
        }

        public void Insert(tbl_User url)
        {
            db.tbl_User.Add(url);
            Save();
        }

        public void Delete(int id)
        {
            tbl_User url = db.tbl_User.Find(id);
            db.tbl_User.Remove(url);
            Save();
        }

        public void Update(tbl_User url)
        {
            db.Entry(url).State = EntityState.Modified;
        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
