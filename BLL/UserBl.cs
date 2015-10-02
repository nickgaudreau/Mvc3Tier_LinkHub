using System.Collections.Generic;
using BOL;
using DAL;

namespace BLL
{
    public class UserBl
    {
        // pass the data from BLL to DAL 

        private readonly UserDbRepository objDb;

        public UserBl()
        {
            objDb = new UserDbRepository();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return objDb.GetAll();
        }

        public tbl_User GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(tbl_User url)
        {
            objDb.Insert(url);
        }

        public void Delete(int id)
        {
           objDb.Delete(id);
        }

        public void Update(tbl_User url)
        {
            objDb.Update(url);
        }
    }
}
