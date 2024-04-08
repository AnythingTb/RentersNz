namespace RentersNz.Models
{
    public class Lease
    {
        public int LeaseId { get; set; }
        public int PropertyId { get; set; }
        public int RenterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal MonthlyRent { get; set; }
        public string AdditionalTerms { get; set; }
    }
}
