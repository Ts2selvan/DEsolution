using DEApp.Models;
using DEApp.Models.DTOs;
using System.Collections.Generic;

namespace DEApp.Repositories
{
    public interface IApplicantRepository : IRepository<int, Applicant>
    {
        IEnumerable<Applicant> GetApplicantsByVendorId(int vendorId);
        List<Applicant> GetAllApplicants();
        List<Applicant> GetAllApplicantsOnly();
        int getLastAppId();
        public IEnumerable<Applicant> GetApplicantsByGridUsingIDandName(int applicantId, string applicant1);
        IEnumerable<Applicant> GetApplicantsByStatus(string status);
        IEnumerable<Applicant> GetApplicantsByDate(DateTime applicantDate);
    }
}
