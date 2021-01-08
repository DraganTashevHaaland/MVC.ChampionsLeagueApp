using MVC.ChampionsLeagueApp.DataAccess.Repositories;
using MVC.ChampionsLeagueApp.DomainModels.Models;
using MVC.ChampionsLeagueApp.Services.Services.Interfaces;
using MVC.ChampionsLeagueApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC.ChampionsLeagueApp.Services.Services.Classes
{
    public class BuyService : IBuyService
    {
        private IRepository<Buy> _buyRepository;

        public BuyService(IRepository<Buy> buyRepository)
        {
            _buyRepository = buyRepository;
        }

        public List<BuyViewModel> GetAllBuys()
        {
            var dbBuys = _buyRepository.GetAll();

            var buys = new List<BuyViewModel>();

            foreach (var buy in dbBuys)
            {
                var tempBuys = new BuyViewModel()
                {
                    Id = buy.Id,
                    FullName = buy.User.FirstName + " " + buy.User.LastName,
                    Address = buy.User.Address,
                    Contact = buy.User.PhoneNumber,
                    Price = buy.Price,
                    IsSuccessfullyBuying = buy.IsSuccessfullyBuying,
                    Tickets = new List<TicketViewModel>()
                };

                foreach (var ticket in buy.Tickets)
                {
                    var tempTicket = new TicketViewModel()
                    {
                        MatchName = ticket.MatchName,
                        Price = ticket.Price,
                        Sector = ticket.Sector,
                    };

                    tempBuys.Tickets.Add(tempTicket);
                    
                }

                buys.Add(tempBuys);

            }

            return buys;

        }

        public string GetFirstMatchName()
        {
            return _buyRepository.GetAll().First().Tickets[0].MatchName;
        }

        public string GetFirstCustomer()
        {
            var firstCustomerName = _buyRepository.GetAll().First().User.FirstName;
            var firstCustomerSurname = _buyRepository.GetAll().First().User.LastName;
            return $"{firstCustomerName} {firstCustomerSurname}";
                
        }

        public int GetAllNumberOfBuys()
        {
            return _buyRepository.GetAll().Count;
        }

        public string GetMostPopularMatch()
        {
            var buy = _buyRepository.GetAll();

            var tickets = buy
                .SelectMany(x => x.Tickets)
                .ToList();

            var mostPolularMatch = tickets
                .GroupBy(x => x.MatchName)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault()
                .Select(x => x.MatchName)
                .FirstOrDefault();

            return mostPolularMatch;                         
        }

        public BuyViewModel GetBuyById(int id)
        {
            var dbBuys = _buyRepository.GetById(id);

            var buyViewModel = new BuyViewModel()
            {
                FullName = dbBuys.User.FirstName + " " + dbBuys.User.LastName,
                Address = dbBuys.User.Address,
                Contact = dbBuys.User.PhoneNumber,
                IsSuccessfullyBuying = dbBuys.IsSuccessfullyBuying,
                Price = dbBuys.Price,
                Tickets = new List<TicketViewModel>(),        
            };

            foreach (var ticket in dbBuys.Tickets)
            {
                var tempTicket = new TicketViewModel()
                {
                    MatchName = ticket.MatchName,
                    Price = ticket.Price,
                    Sector = ticket.Sector
                };

                buyViewModel.Tickets.Add(tempTicket);
            }

            return buyViewModel;
        }

        public void FinishBuying(int id)
        {
            var dbBuys = _buyRepository.GetById(id);
            dbBuys.IsSuccessfullyBuying = true;
            _buyRepository.Update(dbBuys);
        }

        public void CreateBuyModel(Buy buy)
        {
            buy.Id = _buyRepository.GetAll().Last().Id + 1;
            _buyRepository.Insert(buy);
        }
                   
    }
}
