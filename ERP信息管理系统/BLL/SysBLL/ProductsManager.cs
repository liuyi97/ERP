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
    public class ProductsManager
    {
        public static List<Products> ProductsALL(int index, int rows)
        {
            return ProductsService.ProductsALL(index,rows);
        }

        public static List<ProductsType> ProductsTypeDrop()
        {
            return ProductsService.ProductsTypeDrop();
        }

        public static List<ProductsBrand> ProductsBrandDrop()
        {
            return ProductsService.ProductsBrandDrop();
        }
        public static int Productszong() {
            return ProductsService.Productszong();
        }
        public static List<Products> ProductsALL1(int index, int rows, string d1, string d2, string t) {
            return ProductsService.ProductsALL1(index,rows,d1,d2,t);
        }
        public static int Productszong1(string d1, string d2, string t) {
            return ProductsService.Productszong1(d1,d2,t);
        }
        public static List<Products> ProductsALL2(int index, int rows, string d1, string d2) {
            return ProductsService.ProductsALL2(index, rows, d1, d2);
        }
        public static int Productszong2(string d1, string d2) {
            return ProductsService.Productszong2(d1, d2);
        }
        public static List<Products> ProductsALL3(int index, int rows, string d1, string t)
        {
            return ProductsService.ProductsALL3(index, rows, d1, t);
        }
        public static int Productszong3(string d1, string t)
        {
            return ProductsService.Productszong3(d1, t);
        }
        public static List<Products> ProductsALL4(int index, int rows, string d1)
        {
            return ProductsService.ProductsALL4(index, rows, d1);
        }
        public static int Productszong4(string d1)
        {
            return ProductsService.Productszong4(d1);
        }
        public static List<Products> ProductsALL5(int index, int rows, string d2, string t)
        {
            return ProductsService.ProductsALL5(index, rows, d2, t);
        }
        public static int Productszong5( string d2, string t)
        {
            return ProductsService.Productszong5( d2, t);
        }
        public static List<Products> ProductsALL6(int index, int rows, string d2)
        {
            return ProductsService.ProductsALL6(index, rows, d2);
        }
        public static int Productszong6(string d2)
        {
            return ProductsService.Productszong6(d2);
        }
        public static List<Products> ProductsALL7(int index, int rows, string t)
        {
            return ProductsService.ProductsALL7(index, rows, t);
        }
        public static int Productszong7( string t)
        {
            return ProductsService.Productszong7( t);
        }
        public static int ProductsDelete(int id) {
            return ProductsService.ProductsDelete(id);
        }
        public static int ProductsInsert(Products s) {
            return ProductsService.ProductsInsert(s);
        }
        public static List<Products> ProductsID(int id) {
            return ProductsService.ProductsID(id);
        }
        public static int ProductsUpdate(Products s) {
            return ProductsService.ProductsUpdate(s);
        }
        public static int ProductsTuPianUpdate(Products s) {
            return ProductsService.ProductsTuPianUpdate(s);
        }
        public static DataTable ProductserjiList(int id) {
            return ProductsService.ProductserjiList(id);
        }
        public static int tiaojiaUpdate(int typeid, double price) {
            return ProductsService.tiaojiaUpdate(typeid,price);
        }
    }
}
