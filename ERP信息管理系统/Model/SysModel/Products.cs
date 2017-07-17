using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SysModel
{
    public class Products
    {
        public int ProductsID { get; set; }
        public string ProductsName { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string BeginEnterDate { get; set; }
        public string FinalEnterDate { get; set; }
        public string LatelyOFSDate { get; set; }
        public string LoadingDate { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public string UnshelveDate { get; set; }
        public string ProductsUints { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
        public string Material { get; set; }
        public string Spec { get; set; }
        public int UpperLimit { get; set; }
        public int LowerLimit { get; set; }
        public string PhotoUrl { get; set; }
        public int TotalSalesNum { get; set; }
        public int StocksNum { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
    }
}
