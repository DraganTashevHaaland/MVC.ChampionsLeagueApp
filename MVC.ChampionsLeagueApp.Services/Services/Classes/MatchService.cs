using MVC.ChampionsLeagueApp.DataAccess.Repositories;
using MVC.ChampionsLeagueApp.DataAccess.Repositories.CashRepositories;
using MVC.ChampionsLeagueApp.DomainModels.Enums;
using MVC.ChampionsLeagueApp.DomainModels.Models;
using MVC.ChampionsLeagueApp.Services.Services.Interfaces;
using MVC.ChampionsLeagueApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.ChampionsLeagueApp.Services.Services.Classes
{
    public class MatchService : IMatchService
    {
        private IRepository<Ticket> _ticketRepository;

        public MatchService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository; 
        }
        public List<Ticket> GetMatches()
        {
            return _ticketRepository.GetAll();
        }

        public Ticket GetTicketByMatchNameAndSector(string name, SectorTicket sector)
        {
            return _ticketRepository.GetAll().FirstOrDefault(x => x.MatchName == name && x.Sector == sector);
        }
        public int AddTicketInMatch(AddTicketViewModel model)
        {
            var LastTicketId = GetMatches().Last().Id;

            var ticket = new Ticket()
            {
                Id = LastTicketId + 1,
                MatchName = model.MatchName,
                Price = model.Price,
                Sector = model.Sector
            };

            var response = _ticketRepository.Insert(ticket);
            return response;
        }
    }
}
