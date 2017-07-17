using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MagMdl
{
  public   class t_Products
    {
      public int ProductsID { get; set; }
        public string ProductsName { get; set; }
        public int TypeID    { get; set; }
        public int BrandID { get; set; }
        public string BeginEnterDate { get; set; }
        public string FinalEnterDate { get; set; }
        public string LatelyOFSDate { get; set; }
        public string LoadingDate { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }

        public string Color { get; set; }
        public string Weight { get; set; }
        public string Material { get; set; }
        public string Spec { get; set; }
        public string UpperLimit { get; set; }
        public string UnshelveDate { get; set; }

        public string LowerLimit { get; set; }
        public string PhotoUrl { get; set; }
        public string TotalSalesNum { get; set; }
        public string StocksNum { get; set; }
        public string Description { get; set; }
        public int State { get; set; }
    }
}
