using MVC.ChampionsLeagueApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.ChampionsLeagueApp.DataAccess.Repositories.CashRepositories
{
    public class UserRepository : IRepository<User>
    {
        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            StaticDb.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            var user = StaticDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                var index = StaticDb.Users.IndexOf(user);
                StaticDb.Users[index] = entity;
            }
        }

        public void DeleteById(int id)
        {
            var user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                StaticDb.Users.Remove(user);
            }
        }
    }
}
