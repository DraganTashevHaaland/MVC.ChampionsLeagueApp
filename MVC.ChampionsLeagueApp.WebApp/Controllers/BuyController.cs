using Microsoft.AspNetCore.Mvc;
using MVC.ChampionsLeagueApp.DomainModels.Models;
using MVC.ChampionsLeagueApp.Services.Services.Interfaces;
using MVC.ChampionsLeagueApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ChampionsLeagueApp.WebApp.Controllers
{
    public class BuyController : Controller
    {
        private IMatchService _matchService;
        private IBuyService _buyService;
        private IUserService _userService;

        public BuyController(IUserService userService,
                             IBuyService buyService,
                             IMatchService matchService)
        {
            _matchService = matchService;
            _buyService = buyService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Buys()
        {
            var buys = _buyService.GetAllBuys();
            var firtTicket = _buyService.GetFirstMatchName();
            var firstCustomer = _buyService.GetFirstCustomer();
            var numberOfBuys = _buyService.GetAllNumberOfBuys();
            var mostPopularTicket = _buyService.GetMostPopularMatch();

            var buysViewModel = new BuysViewModel()
            {
                Buys = buys,
                FirstTicket = firtTicket,
                FirstPersonName = firstCustomer,
                NumberOfBuyedTickets = numberOfBuys,
                MostBuyedTicketMatch = mostPopularTicket
                
            };

            return View(buysViewModel);
        }

        [HttpGet]
        //Postman link: https://localhost:5001/Buy/Details
        public IActionResult Details(int id)
        {
            var buy = _buyService.GetBuyById(id);

            if (buy == null) return RedirectToAction("Index");

            return View(buy);
        }

        [HttpGet]
        //Postman link: https://localhost:5001/Buy/CompleteBuy
        public IActionResult CompleteBuy(int id)
        {
            _buyService.FinishBuying(id);
            return RedirectToAction("Details", new { id = id });
        }

        [HttpGet]
        public IActionResult Buy(string error, int? tickets)
        {
            var match = _matchService.GetMatches();

            var ticketNames = new List<string>();

            foreach (var ticket in match)
            {
                ticketNames.Add(ticket.MatchName);
            }

            var filteredTicketNames = ticketNames.Distinct().ToList();

            var viewModel = new GetBuyViewModel()
            {
                TicketNames = filteredTicketNames,
                Tickets = new List<TicketViewModel>()
            };

            for (int i = 0; i < tickets; i++)
            {
                viewModel.Tickets.Add(new TicketViewModel());
            }

            ViewBag.Error = error;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Buy(GetBuyViewModel model)
        {
            try
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,  
                };

                _userService.AddUser(user);

                var buy = new Buy()
                {
                    User = user,
                    IsSuccessfullyBuying = false,
                    Price = 0,
                    Tickets = new List<Ticket>()
                };

                foreach (var ticket in model.Tickets)
                {
                    var tempTicket = _matchService.GetTicketByMatchNameAndSector(ticket.MatchName, ticket.Sector);
                    buy.Price += tempTicket.Price;
                    buy.Tickets.Add(tempTicket);
                }

                _buyService.CreateBuyModel(buy);

                return View("_ThankYou");

            }
            catch (Exception ex)
            {
                var message = "We don't have selected ticket/s at this moment, pease select another one.";
                return RedirectToAction("Buy", "Buy", new { error = message, tickets = model.Tickets.Count });
                
            }
        }
    }
}
