using CFTrackerServices.Data;
using CFTrackerServices.Models;
using Microsoft.EntityFrameworkCore;

namespace CFTrackerServices
{
    public class UserDB
    {
        private readonly CFTrackerContext _context;

        public UserDB()
        {
        }

        public UserDB(CFTrackerContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> GetUserAsync(string userEmail)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.EmailAddress == userEmail);
        }

        public async Task<UserInfo> GetUserWithLungFunctionsAsync(string userEmail)
        {
            return await _context.Users
                .Include(u => u.LungFunctions)
                .FirstOrDefaultAsync(u => u.EmailAddress == userEmail);
        }

        public async Task<UserInfo> GetUserWithBodyMassIndexesAsync(string userEmail)
        {
            return await _context.Users
                .Include(u => u.BodyMassIndexes)
                .FirstOrDefaultAsync(u => u.EmailAddress == userEmail);
        }

        public async Task AddUserAsync(UserInfo newUser)
        {
            try
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task AddLungFunctionAsync(LungFunction newLungFunction)
        {
            try
            {
                await _context.LungFunctions.AddAsync(newLungFunction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task AddBodyMassIndexAsync(BodyMassIndex newBodyMassIndex)
        {
            try
            {
                await _context.BodyMassIndexes.AddAsync(newBodyMassIndex);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task UpdateUserAsync(UserInfo updatedUserInfo)
        {
            try
            {
                _context.Update(updatedUserInfo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task UpdateLungFunctionAsync(LungFunction lungFunction)
        {
            try
            {
                _context.Update(lungFunction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task UpdateBodyMassIndexAsync(BodyMassIndex bodyMassIndex)
        {
            try
            {
                _context.Update(bodyMassIndex);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task DeleteLungFunctionAsync(LungFunction lungFunction)
        {
            try
            {
                _context.Remove(lungFunction);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task DeleteBodyMassIndexAsync(BodyMassIndex bodyMassIndex)
        {
            try
            {
                _context.Remove(bodyMassIndex);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public bool LungFunctionExists(int id)
        {
            return (_context.LungFunctions?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public bool BodyMassIndexExists(int id)
        {
            return (_context.BodyMassIndexes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        
            //public async Task<bool> HasUserInfoBeenUpdatedOnDBAsync(UserInfo userInfo)
            //{
            //    var dbUserInfo = await GetUserAsync(userInfo.EmailAddress);

            //    if (userInfo == dbUserInfo)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
    }
}