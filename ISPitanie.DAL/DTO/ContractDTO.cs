using System;

namespace DAL.DTO
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public string ResponsiblePerson { get; set; }
        public DateTime ConclusionDate { get; set; }
        public int PeriodInMonths { get; set; }
        public Byte[] File { get; set; }
        public float Total { get; set; }

        public SellerDTO Seller { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}