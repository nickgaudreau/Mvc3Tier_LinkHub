using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBl
    {
        public CategoryBl categoryBl { get; set; }
        public UrlBl urlBl { get; set; }
        public UserBl userBl { get; set; }

        public BaseBl()
        {
            categoryBl = new CategoryBl();
            urlBl = new UrlBl();
            userBl = new UserBl();
        }
    }
}
