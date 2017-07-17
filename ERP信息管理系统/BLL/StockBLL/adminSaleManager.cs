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
   public class adminSaleManager
    {
        //状态显示
        public static DataTable GetSatate()
        {
           return adminSaleService.GetSatate();
        }
        //单据号显示
        public static DataTable GetOutID()
        {
            return adminSaleService.GetOutID();
        }
        //分页显示总行数
        public static List<addorder> GetAll(int rows, int page)
        {
            return adminSaleService.GetAll(rows,page);
        }
        //获取总行数
        public static int GetHang()
        {
           return adminSaleService.GetHang();
        }
        //判断条件,多者满足其中之一即可,通过statename来查询
        public static List<addorder> GetS(int rows, int page, int statename)
        {
            return adminSaleService.GetS(rows, page, statename);
        }

        //判断条件,多者满足其中之一即可,通过outid来查询
        public static List<addorder> GetSe(int rows, int page, string saleid)
        {
            return adminSaleService.GetSe(rows, page, saleid);
        }
        //判断条件,多者满足其中之一即可,通过createtime来查询
        public static List<addorder> GetSel(int rows, int page, string create, string tradetime)
        {
            return adminSaleService.GetSel(rows, page, create, tradetime);
        }
        //判断条件,多者满足其中之一即可,通过outid 和createtime 来查询
        public static List<addorder> GetSele(int rows, int page, string saleid, string create, string tradetime)
        {
            return adminSaleService.GetSele(rows, page, saleid, create, tradetime);
        }
        //判断条件,多者满足其中之一即可,通过outid 和statename 来查询
        public static List<addorder> GetSelec(int rows, int page, string saleid, int statename)
        {
            return adminSaleService.GetSelec(rows, page, saleid, statename);
        }
        //判断条件,多者满足其中之一即可,通过statename 和createtime 来查询
        public static List<addorder> GetSelectd(int rows, int page, string create, string tradetime, int statename)
        {
            return adminSaleService.GetSelectd(rows, page, create, tradetime, statename);
        }
        //修改
        public static bool GteUpdata(addorder ad)
        {
            return adminSaleService.GteUpdata(ad);
        }
        //删除
        public static bool GetDelete(string saleid)
        {
            return adminSaleService.GetDelete(saleid);
        }
        //删除
        public static bool GetDelete1(string saleid)
        {
            return adminSaleService.GetDelete1(saleid);
        }
    }
}
