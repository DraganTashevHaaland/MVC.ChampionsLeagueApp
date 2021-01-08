using MVC.ChampionsLeagueApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.ChampionsLeagueApp.DataAccess.Repositories.CashRepositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        public List<Ticket> GetAll()
        {
            return StaticDb.Matches;
        }

        public Ticket GetById(int id)
        {
            return StaticDb.Matches.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Ticket entity)
        {
            StaticDb.Matches.Add(entity);
            return entity.Id;
        }

        public void Update(Ticket entity)
        {
            var ticket = StaticDb.Matches.FirstOrDefault(x => x.Id == entity.Id);
            if (ticket != null)
            {
                var index = StaticDb.Matches.IndexOf(ticket);
                StaticDb.Matches[index] = entity;
            }
        }

        public void DeleteById(int id)
        {
            var ticket = StaticDb.Matches.FirstOrDefault(x => x.Id == id);
            if (ticket != null)
            {
                StaticDb.Matches.Remove(ticket);
            }
        }
    }
}
