using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.SysDAL;
using Model.SysModel;
using System.Data;

namespace BLL.SysBLL
{
    public class GroupManager
    {
        public static int GroupInsert(Group s)
        {
            return GroupService.GroupInsert(s);
        }
        public static List<Group> GroupALL(int index, int rows)
        {
            return GroupService.GroupALL(index, rows);
        }
        
        public static int Groupzong()
        {
            return GroupService.Groupzong();
        }

        public static int GroupDelete(int id)
        {
            return GroupService.GroupDelete(id);
        }
        public static int GroupUpdate(Group s)
        {
            return GroupService.GroupUpdate(s);
        }
        public static List<Group> GroupID(int id)
        {
            return GroupService.GroupID(id);
        }
        //public static DataTable xuan(int index, int rows) {
        //    return GroupService.xuan(index,rows);
        //}
        public static DataTable xuan() {
            return GroupService.xuan();
        }
        public static int xuanzong() {
            return GroupService.xuanzong();
        }
        public static DataTable ckxuan(int id) {
            return GroupService.ckxuan(id);
        }
        public static int ckzeng(int id1, int id2)
        {
            return GroupService.ckzeng(id1,id2);
        }
        public static int ckshan(int id1, int id2)
        {
            return GroupService.ckshan(id1,id2);
        }
    }
}
