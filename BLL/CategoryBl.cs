using System.Collections.Generic;
using BOL;
using DAL;

namespace BLL
{
    public class CategoryBl
    {
        // pass the data from BLL to DAL 

        private readonly CategoryDbRepository objDb;

        public CategoryBl()
        {
            objDb = new CategoryDbRepository();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return objDb.GetAll();
        }

        public tbl_Category GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(tbl_Category url)
        {
            objDb.Insert(url);
        }

        public void Delete(int id)
        {
           objDb.Delete(id);
        }

        public void Update(tbl_Category url)
        {
            objDb.Update(url);
        }
    }
}
