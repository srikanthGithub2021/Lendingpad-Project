using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class CreateUserService : ICreateUserService
    {
        private readonly IUpdateUserService _updateUserService;
        private readonly IIdObjectFactory<User> _userFactory;
        private readonly IUserRepository _userRepository;

        public CreateUserService(IIdObjectFactory<User> userFactory, IUserRepository userRepository, IUpdateUserService updateUserService)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _updateUserService = updateUserService;
        }

        public User Create(Guid id, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            //added the logic for verify this record exists
            var existingByemail = _userRepository.Get(null, null, email).FirstOrDefault();
            if (existingByemail != null)
            {
                throw new InvalidOperationException($" A user with this email '{email} already exists.");
            }

            var user = _userFactory.Create(id);
            _updateUserService.Update(user, name, email, type, annualSalary, tags);
            _userRepository.Save(user);
            return user;
        }
    }
}