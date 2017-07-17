using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SysModel
{
    public class UserType
    {
        public int SubClassID { get; set; }
        public int UserTypeID { get; set; }
        public string TypeName { get; set; }
        public string SubClassName { get; set; }
        public string State { get; set; }
    }
}
