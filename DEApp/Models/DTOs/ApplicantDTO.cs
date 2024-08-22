namespace DEApp.Models.DTOs
{
    public class ApplicantDTO
    {
        public int ApplicantId { get; set; }

        public int? VendorId { get; set; }

        public string? Applicant1 { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? MaritalStatus { get; set; }

        public string? OccupationType { get; set; }

        public string? HouseNo { get; set; }

        public string? City { get; set; }

        public string? District { get; set; }

        public string? State { get; set; }

        public string? Landmark { get; set; }

        public int? Pincode { get; set; }

        public string? Country { get; set; }
        public decimal? LoanAmount { get; set; }
        public int? LoanTerm { get; set; }

        public decimal? InterestRate { get; set; }

        public decimal? MonthlyPayment { get; set; }
    }
}
