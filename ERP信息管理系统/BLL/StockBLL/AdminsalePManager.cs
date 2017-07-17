using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.NewFolder1;
using DAL.NewFolder1;
using System.Data;
namespace BLL.NewFolder1
{
   public class AdminsalePManager
    {
        //状态显示
        public static DataTable GetSatate()
        {
           return adminInPService.GetSatate();
        }
        //单据号显示
        public static DataTable GetOutID()
        {
             return adminInPService.GetOutID();
        }
        //分页显示总行数
        public static List<addorder> GetAll(int rows, int page)
        {
            return adminInPService.GetAll(rows,page);
        }
        //获取总行数
        public static int GetHang()
        {
           return adminInPService.GetHang();
        }
        //判断条件
        //判断条件,多者满足其中之一即可,通过statename来查询
        public static List<addorder> GetS(int rows, int page, int statename)
        {
            return adminInPService.GetS(rows,page,statename);
        }

        //判断条件,多者满足其中之一即可,通过outid来查询
        public static List<addorder> GetSe(int rows, int page, string outid)
        {
            return adminInPService.GetSe(rows,page,outid);
        }
        //判断条件,多者满足其中之一即可,通过createtime来查询
        public static List<addorder> GetSel(int rows, int page, string create, string tradetime)
        {
            return adminInPService.GetSel(rows,page,create,tradetime);
        }
        //判断条件,多者满足其中之一即可,通过outid 和createtime 来查询
        public static List<addorder> GetSele(int rows, int page, string outid, string create, string tradetime)
        {
            return adminInPService.GetSele(rows, page,outid, create, tradetime);
        }
        //判断条件,多者满足其中之一即可,通过outid 和statename 来查询
        public static List<addorder> GetSelec(int rows, int page, string outid, int statename)
        {
            return adminInPService.GetSelec(rows,page,outid,statename);
        }
        //判断条件,多者满足其中之一即可,通过statename 和createtime 来查询
        public static List<addorder> GetSelectd(int rows, int page, string create, string tradetime, int statename)
        {
            return adminInPService.GetSelectd(rows,page,create,tradetime,statename);
        }
        //修改
        public static bool GteUpdata(addorder ad)
        {
            return adminInPService.GteUpdata(ad);
        }
        //删除
        public static bool GetDelete(string outid)
        {
            return adminInPService.GetDelete(outid);
        }
        //删除
        public static bool GetDelete1(string outid)
        {
           return adminInPService.GetDelete1(outid);
        }
    }
}
