using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SysModel
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SubClassID { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string SubClassName { get; set; }
        public string Character { get; set; }
        public string RealName { get; set; }
        public string Sex { get; set; }
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string CompanyInfo { get; set; }
        public string Dept { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string WangWang { get; set; }
        public string Bankname { get; set; }
        public string BankAccount { get; set; }
        public string LatelyLogin { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
    }
}
