using MVC.ChampionsLeagueApp.DataAccess.Repositories;
using MVC.ChampionsLeagueApp.DomainModels.Models;
using MVC.ChampionsLeagueApp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.ChampionsLeagueApp.Services.Services.Classes
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(User user)
        {
            user.Id = _userRepository.GetAll().Last().Id + 1;
            _userRepository.Insert(user);
        }
    }
}


