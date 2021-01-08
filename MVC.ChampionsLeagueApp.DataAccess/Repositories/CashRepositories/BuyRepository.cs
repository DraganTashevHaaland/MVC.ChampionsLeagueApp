using MVC.ChampionsLeagueApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.ChampionsLeagueApp.DataAccess.Repositories.CashRepositories
{
    public class BuyRepository : IRepository<Buy>
    {
        public List<Buy> GetAll()
        {
            return StaticDb.Buys;
        }

        public Buy GetById(int id)
        {
            return StaticDb.Buys.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Buy entity)
        {
            StaticDb.Buys.Add(entity);
            return entity.Id;             
        }

        public void Update(Buy entity)
        {
           var buy = StaticDb.Buys.FirstOrDefault(x => x.Id == entity.Id);
           if(buy != null)
           {
                var index = StaticDb.Buys.IndexOf(buy);
                StaticDb.Buys[index] = entity;
           }
        }

        public void DeleteById(int id)
        {
            var buy = StaticDb.Buys.FirstOrDefault(x => x.Id == id);
            if(buy != null)
            {
                StaticDb.Buys.Remove(buy);
            }            
        }
    }
}
