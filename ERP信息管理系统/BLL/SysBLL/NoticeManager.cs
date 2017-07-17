using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using System.Data;

namespace BLL.SysBLL
{
    public class NoticeManager
    {
        public static int NoticeInsert(int type, string Title, string UserName, string CreateDate, string Info) {
            return NoticeService.NoticeInsert(type,Title,UserName,CreateDate,Info);
        }
        public static DataTable LogAll(int index, int rows) {
            return NoticeService.LogAll(index,rows);
        }
        public static int LogZong() {
            return NoticeService.LogZong();
        }
        public static int LogInsert(string time, string del) {
            return NoticeService.LogInsert(time,del);
        }
    }
}
