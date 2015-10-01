using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class UrlBl
    {
        // pass the data from BLL to DAL 

        private readonly UrlDbRepository objDb;

        public UrlBl()
        {
            objDb = new UrlDbRepository();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return objDb.GetAll();
        }

        public tbl_Url GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(tbl_Url url)
        {
            objDb.Insert(url);
        }

        public void Delete(int id)
        {
           objDb.Delete(id);
        }

        public void Update(tbl_Url url)
        {
            objDb.Update(url);
        }


    }
}
