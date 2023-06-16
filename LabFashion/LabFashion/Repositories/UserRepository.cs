using LabFashion.Context;
using LabFashion.Models;
using LabFashion.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace LabFashion.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LCCContext _lccContext;

        public UserRepository(LCCContext lccContext)
        {
            _lccContext = lccContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _lccContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int IdUser)
        {
            return await _lccContext.Users.Where(x => x.IdPerson == IdUser).FirstOrDefaultAsync();
        }

        public void CreateUser(User user)
        {
            _lccContext.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _lccContext.Entry(user).State = EntityState.Modified;
        }

        public async Task UpdateUserStatus(int IdPerson, JsonPatchDocument user)
        {
            var us = await _lccContext.People.FindAsync(IdPerson);
            if (us != null)
            {
                user.ApplyTo(us);
                await _lccContext.SaveChangesAsync();
            }
        }

        public void DeleteUser(User user)
        {
            _lccContext.Users.Remove(user);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _lccContext.SaveChangesAsync() > 0;
        }
    }
}
