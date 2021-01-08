using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.ChampionsLeagueApp.ViewModels.Models
{
    public class BuysViewModel
    {
        public string FirstPersonName { get; set; }
        public string FirstTicket { get; set; }
        public int NumberOfBuyedTickets { get; set; }
        public string MostBuyedTicketMatch { get; set; }
        public List<BuyViewModel> Buys { get; set; }
    }
}
