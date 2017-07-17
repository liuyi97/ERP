using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MagMdl
{
     public  class t_TransferringOrder
    {
        public string ID { get; set; }
        public string inStoreName { get; set; }
        public string outStoreName { get; set; }
        public string Username { get; set; }
        public string State { get; set; }
        public string Productname { get; set; }
    }
}
