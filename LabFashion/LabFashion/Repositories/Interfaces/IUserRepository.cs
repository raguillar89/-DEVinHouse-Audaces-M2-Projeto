﻿using LabFashion.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace LabFashion.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int IdUser);
        void CreateUser(User user);
        void UpdateUser(User user);
        Task UpdateUserStatus(int IdPerson, JsonPatchDocument user);
        void DeleteUser(User user);
        Task<bool> SaveAllAsync();
    }
}
