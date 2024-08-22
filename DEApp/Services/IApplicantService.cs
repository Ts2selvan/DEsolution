using DEApp.Models;
using DEApp.Models.DTOs;

namespace DEApp.Services
{
    public interface IApplicantService
    {
        List<ApplicationGridDTO> GetApplicantsByVendorId(int vendorId);
        List<ApplicationGridDTO> GetAllApplicants();
        List<Applicant> GetAllApplicantsOnly();
        public ApplicantDTO UpdateApplicationByUsingVendorId(int applicantId, int vendorId);
        public List<ApplicantDTO> GetAllApplicantByCreatedPersonData();
        public ApplicantDTO GetApplicantById(int ApplicantId);
        public ApplicantDTO AddApplicant(ApplicantDTO applicantDTO);
        public ApplicantDTO UpdateApplicant(ApplicantDTO applicantDTO);
        public ApplicantDTO DeleteApplicantById(int ApplicantId);
        public IEnumerable<ApplicationGridDTO> GetApplicantsByGridUsingIDandName(int applicantId, string applicant1);
        List<ApplicationGridDTO> GetApplicationByGridUsingStatus(string status);
        List<ApplicationGridDTO> GetApplicationByGridUsingDate(DateTime applicantDate);
    }
}
