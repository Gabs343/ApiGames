﻿using ApiGames.Models;
using ApiGames.Repositories;


namespace ApiGames.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> FindById(long id) {
            User? user = await _repository.FindById(id);
            if (user != null) { return user; }
            throw new Exception($"Cannot find the user with the id: {id}");
        }

        public async Task<User> FindByMail(string mail)
        {
            return await _repository.FindByMail(mail);
        }

        public async Task<bool> ExistByMail(string mail)
        {
            return await _repository.ExistByMail(mail);
        }

        public async Task<User> Save(User user)
        {
            _repository.Insert(user);
            await _repository.Save();
            return user;
        }
    }
}
