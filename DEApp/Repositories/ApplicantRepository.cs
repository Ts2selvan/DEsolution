using System.Collections.Generic;
using System.Linq;
using DEApp.Data;
using DEApp.Models;
using DEApp.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DEApp.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly DeappContext _context;

        public ApplicantRepository(DeappContext context)
        {
            _context = context;
        }


        public Applicant Add(Applicant item)
        {
            _context.Applicants.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Applicant Delete(int key)
        {
            var Applicant = Get(key);
            if (Applicant != null)
            {
                _context.Applicants.Remove(Applicant);
                _context.SaveChanges();
                return Applicant;
            }
            return null;
        }

        public Applicant Get(int key)
        {
            var Applicants = _context.Applicants.FirstOrDefault(app => app.ApplicantId == key);
            return Applicants;
        }

        public List<Applicant> GetAll()
        {
            return _context.Applicants.ToList();
        }

        public Applicant Update(Applicant item)
        {
            _context.Entry<Applicant>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
        public IEnumerable<Applicant> GetApplicantsByVendorId(int vendorId)
        {
            return _context.Applicants
                .Where(a => a.VendorId == vendorId)
                .Include(a => a.Vendor)
                .Include(a => a.Loans)
                .ToList();
        }

        public List<Applicant> GetAllApplicants()
        {
            return _context.Applicants
                .Include(a => a.Vendor)
                .Include(a => a.Loans)   
                .ToList();
        }
        public List<Applicant> GetAllApplicantsOnly()
        {
            return _context.Applicants.ToList();
        }
        public IEnumerable<Applicant> GetApplicantsByGridUsingIDandName(int applicantId, string applicant1)
        {
            return _context.Applicants
                .Where(a => a.ApplicantId == applicantId || a.Applicant1 == applicant1)
                .Include(a => a.Vendor)
                .Include(a => a.Loans)
                .ToList();
        }

        public IEnumerable<Applicant> GetApplicantsByStatus(string status)
        {
            return _context.Applicants
                .Include(a => a.Vendor)
                .Include(a => a.Loans)
                .Where(a => a.Loans.Any(l => l.Status == status))
                .ToList();
        }

        public IEnumerable<Applicant> GetApplicantsByDate(DateTime applicantDate)
        {
            return _context.Applicants
                .Include(a => a.Vendor)
                .Include(a => a.Loans)
                .Where(a => a.Loans.Any(l => l.ApplicantDate.HasValue && l.ApplicantDate.Value.Date == applicantDate.Date))
                .ToList();
        }

        public int getLastAppId()
        {
            var lastApplicant = _context.Applicants
           .OrderByDescending(a => a.ApplicantId) 
           .FirstOrDefault();

            return lastApplicant.ApplicantId;
        }
    }
}
