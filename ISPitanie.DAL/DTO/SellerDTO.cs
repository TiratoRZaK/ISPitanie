using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class SellerDTO
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public string FullNameCompany { get; set; }
        public string AddressCompany { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long INN { get; set; }
        public long KPP { get; set; }
        public long BIK { get; set; }
        public string Bank { get; set; }
        public string PersonalAccount { get; set; }
        public string BankAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public string NameSeller { get; set; }
        public string NameSellerSpec { get; set; }
    }
}
