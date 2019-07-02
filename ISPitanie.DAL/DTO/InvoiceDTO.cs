using System;

namespace DAL.DTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ContractId { get; set; }
        public Byte[] File { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
                              
        public ContractDTO Contract { get; set; }
    }
}