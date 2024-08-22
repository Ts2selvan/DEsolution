using DEApp.Models.DTOs;
using DEApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DEApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }




        [HttpPost]
        public ActionResult<ApplicantDTO> AddApplicant([FromBody] ApplicantDTO applicantDTO)
        {
            if (applicantDTO == null)
            {
                return BadRequest("Applicant data is null.");
            }

            var createdApplicant = _applicantService.AddApplicant(applicantDTO);
            return CreatedAtAction(nameof(GetApplicantById), new { id = createdApplicant.ApplicantId }, createdApplicant);
        }

        [HttpDelete("{id}")]
        public ActionResult<ApplicantDTO> DeleteApplicantById(int id)
        {
            var applicantDTO = _applicantService.DeleteApplicantById(id);
            if (applicantDTO == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(applicantDTO);
        }


        [HttpGet("{id}")]
        public ActionResult<ApplicantDTO> GetApplicantById(int id)
        {
            var applicantDTO = _applicantService.GetApplicantById(id);
            if (applicantDTO == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(applicantDTO);
        }

        [HttpPut("{id}")]
        public ActionResult<ApplicantDTO> UpdateApplicant(int id, [FromBody] ApplicantDTO applicantDTO)
        {
            if (applicantDTO == null || applicantDTO.ApplicantId != id)
            {
                return BadRequest("Applicant data is null or ID mismatch.");
            }

            var updatedApplicant = _applicantService.UpdateApplicant(applicantDTO);
            if (updatedApplicant == null)
            {
                return NotFound($"Applicant with ID {id} not found.");
            }

            return Ok(updatedApplicant);
        }

        [HttpGet("GetAllApplicantByCreatedPersonData")]
        public ActionResult<List<ApplicantDTO>> GetAllApplicantByCreatedPersonData()
        {
            var applicants = _applicantService.GetAllApplicantByCreatedPersonData();
            return Ok(applicants);
        }

        [HttpGet("vendor/{vendorId}")]
        public ActionResult<List<ApplicationGridDTO>> GetApplicantsByVendorId(int vendorId)
        {
            var applicants = _applicantService.GetApplicantsByVendorId(vendorId);
            if (applicants == null || applicants.Count == 0)
            {
                return NotFound();
            }

            return Ok(applicants);
        }


        [HttpGet("GetAll")]
        public ActionResult<List<ApplicationGridDTO>> GetAllApplicants()
        {
            var applicants = _applicantService.GetAllApplicants();
            if (applicants == null || applicants.Count == 0)
            {
                return NoContent();
            }
            return Ok(applicants);
        }

        [HttpGet("GetAllApplicantsOnly")]
        public ActionResult<List<ApplicationGridDTO>> GetAllApplicantsOnly()
        {
            var applicants = _applicantService.GetAllApplicantsOnly();
            if (applicants == null || applicants.Count == 0)
            {
                return NoContent();
            }
            return Ok(applicants);
        }

        [HttpPut("UpdateApplication/{applicantId}/{vendorId}")]
        public IActionResult UpdateApplicationByUsingVendorId(int applicantId, int vendorId)
        {
            try
            {
                var updatedApplication = _applicantService.UpdateApplicationByUsingVendorId(applicantId, vendorId);
                return Ok(updatedApplication);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }


        [HttpGet("search")]
        public ActionResult<List<ApplicationGridDTO>> GetApplicantsByGridUsingIDandName([FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("Search term cannot be empty.");
            }

            int applicantId;
            bool isNumeric = int.TryParse(searchTerm, out applicantId);

            var result = _applicantService.GetApplicantsByGridUsingIDandName(isNumeric ? applicantId : 0, !isNumeric ? searchTerm : null).ToList();

            if (result == null || !result.Any())
            {
                return NotFound("No applicants found.");
            }

            return Ok(result);
        }

        [HttpGet("status")]
        public ActionResult<List<ApplicationGridDTO>> GetApplicationByGridUsingStatus([FromQuery] string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return BadRequest("Status cannot be empty.");
            }

            var applications = _applicantService.GetApplicationByGridUsingStatus(status);

            if (applications == null || applications.Count == 0)
            {
                return NotFound("No application found with the specified status.");
            }

            return Ok(applications);
        }

        [HttpGet("date")]
        public ActionResult<List<ApplicationGridDTO>> GetApplicationByGridUsingDate([FromQuery] DateTime applicantDate)
        {
            var applications = _applicantService.GetApplicationByGridUsingDate(applicantDate);

            if (applications == null || applications.Count == 0)
            {
                return NotFound("No application found for the specified date.");
            }

            return Ok(applications);
        }

    }


}



