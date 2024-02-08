﻿using ShopProduct.Shared;

namespace ShopProduct.Server.Repository
{
    public interface IUserRepository
    {
        Task<int> GetUserIdByUsername(string username);
        Task<bool> CheckUserPassword(string password);
        Task<int> GetUserId(int userId);
        Task<bool> InsertUserToken(int userId, string token);
        Task<string> GetUserToken(int userId);
    }
}
