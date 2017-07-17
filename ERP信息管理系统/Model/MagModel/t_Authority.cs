using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class t_Authority
    {
        public int AuthorityID { get; set; }
        public int TypeID { get; set; }
        public string AuthorityName  { get; set; }
        public string ModuleUrl { get; set; }
        public string WebUrl { get; set; }
        public string Description { get; set; }

    }
}
