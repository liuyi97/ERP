using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BLL
{
    public static class t_AuthorityManages
    {
        public static DataTable getindexa(int a)
        {
            return t_AuthorityService.getindexa(a);
        }
        public static DataTable getindexb(int a)
        {
            return t_AuthorityService.getindexb(a);
        }
        public static DataTable getindexc(int a)
        {
            return t_AuthorityService.getindexc(a);
        }
        public static DataTable getindexd(int a)
        {
            return t_AuthorityService.getindexd(a);
        }
        }
}
