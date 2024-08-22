using DEApp.Data;
using DEApp.Interfaces;
using DEApp.Models;

namespace DEApp.Repositories
{
    public class LoanRepository : ILoanRepository<int, Loan>
    {
        private readonly DeappContext _context;
        public LoanRepository(DeappContext context)
        {
            _context = context;
        }
        public Loan Add(Loan item)
        {
            _context.Loans.Add(item);
            _context.SaveChanges();
            return item;
        }

      

        public Loan Delete(int key)
        {
            var Loan = Get(key);
            if (Loan != null)
            {
                _context.Loans.Remove(Loan);
                _context.SaveChanges();
                return Loan;
            }
            return null;
        }

        public Loan Get(int key)
        {
            var Loan = _context.Loans.FirstOrDefault(l => l.LoanId == key);
            return Loan;
        }

        public List<Loan> GetAll()
        {
            return _context.Loans.ToList();
        }

        public Loan Update(Loan item)
        {
            _context.Entry<Loan>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
