using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AmountOfKids { get; set; }
        public int InvoiceId { get; set; }
        public Byte[] File { get; set; }

        public InvoiceDTO Invoice { get; set; }

    }
}
