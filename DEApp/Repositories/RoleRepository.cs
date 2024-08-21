using DEApp.Data;
using DEApp.Interfaces;
using DEApp.Models;

namespace DEApp.Repositories
{
    public class RoleRepository : IRoleRepository<string, Role>
    {
        private readonly DeappContext _context;

        public RoleRepository(DeappContext context)
        {
            _context = context;
        }
        public Role Add(Role item)
        {
            throw new NotImplementedException();
        }

        public Role Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Role Delete(string key)
        {
            throw new NotImplementedException();
        }

        public Role Get(string key)
        {
            return _context.Roles.SingleOrDefault(r => r.RoleName == key);
        }

        public List<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Role Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}
