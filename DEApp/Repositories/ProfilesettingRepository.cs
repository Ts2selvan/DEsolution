using DEApp.Data;
using DEApp.Interfaces;
using DEApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DEApp.Repositories
{
    public class ProfilesettingRepository : IProfilesettingRepository<int, ProfileSetting>
    {
        private readonly DeappContext _context;

        public ProfilesettingRepository(DeappContext context) 
        { 
            _context = context;        
        }

        public ProfileSetting Add(ProfileSetting item)
        {

           _context.ProfileSettings.Add(item);
            _context.SaveChanges();
            return item;
        }

        public ProfileSetting Delete(int key)
        {
            var ProfileSetting = Get(key);
            if (ProfileSetting != null)
            {
                _context.ProfileSettings.Remove(ProfileSetting);
                _context.SaveChanges(true);
                return (ProfileSetting);
            }
            return null;

        }
           

        public ProfileSetting Get(int key)
        {
            var ProfileSetting = _context.ProfileSettings.FirstOrDefault(p => p.UserId == key);
            return ProfileSetting;
        }

        public List<ProfileSetting> GetAll()
        {
           return _context.ProfileSettings.ToList();
        }

        //public ProfileSetting GetUserName(string key)
        //{
        //    var ProfileSetting = _context.ProfileSettings.FirstOrDefault(p => p.Username == key);
        //    return ProfileSetting;
        //}

        public ProfileSetting GetUserName(string key)
        {
            var ProfileSetting = _context.ProfileSettings.AsNoTracking().FirstOrDefault(p => p.Username == key);
            return ProfileSetting;
        }

        public ProfileSetting Update(ProfileSetting item)
        {
            // Fetch the existing entity from the database
            var existingItem = _context.ProfileSettings.Find(item.UserId);

            if (existingItem == null)
            {
                throw new Exception("The entity does not exist in the database.");
            }

            // Optionally, compare properties and update only if necessary
            _context.Entry(existingItem).CurrentValues.SetValues(item);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflict
                var entry = ex.Entries.Single();
                var clientValues = (ProfileSetting)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();

                if (databaseEntry == null)
                {
                    throw new Exception("The entity has been deleted by another user.");
                }
                else
                {
                    var databaseValues = (ProfileSetting)databaseEntry.ToObject();

                    // You can choose to merge changes, overwrite, or alert the user
                    throw new Exception("A concurrency conflict occurred.");
                }
            }

            return item;
        }

        public ProfileSetting UpdatePrfl(ProfileSetting item, int key)
        {
            
            var existingItem = _context.ProfileSettings.Find(key);

            if (existingItem != null)
            {
                existingItem.Email = item.Email;
                existingItem.FirstName = item.FirstName;
                existingItem.LastName = item.LastName;
                existingItem.Username = item.Username;
                existingItem.MobileNumber = item.MobileNumber;
                existingItem.RoleId = item.RoleId;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflict
                var entry = ex.Entries.Single();
                var clientValues = (ProfileSetting)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();

                if (databaseEntry == null)
                {
                    // The entity has been deleted by another user
                    throw new Exception("The entity has been deleted by another user.");
                }
                else
                {
                    var databaseValues = (ProfileSetting)databaseEntry.ToObject();

                    // Handle the conflict, e.g., by notifying the user or merging changes
                    throw new Exception("A concurrency conflict occurred.");
                }
            }

            return existingItem;
        }
    }
}
