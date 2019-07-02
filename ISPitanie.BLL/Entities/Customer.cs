using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string FullNameCompany { get; set; }
        public string AddressCompany { get; set; }
        public long INN { get; set; }
        public long KPP { get; set; }
        public long BIK { get; set; }
        public string Bank { get; set; }
        public string PersonalAccount { get; set; }
        public string BankAccount { get; set; }
        public string NameCustomer { get; set; }
        public string NameCustomerSpec { get; set; }

        public override string ToString()
        {
            return NameCompany;
        }
    }
}
