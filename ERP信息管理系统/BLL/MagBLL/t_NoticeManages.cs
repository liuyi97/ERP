using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.MagDAL;
namespace BLL.MagBLL
{
    public static class t_NoticeManages
    {
        public static DataTable geta()
        {
            return t_NoticeService.geta();
        }
        public static DataTable getb()
        {
            return t_NoticeService.getb();
        }
        public static DataTable getc()
        {
            return t_NoticeService.getc();
        }
        public static DataTable getid(int id)
        {
            return t_NoticeService.getid(id);
        }
    }
}
