using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.ChampionsLeagueApp.ViewModels.Models
{
    public class BuyViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set;}
        public string Address { get; set; }
        public long Contact { get; set; }   
        public List<TicketViewModel> Tickets { get; set; }
        public double Price { get; set; }
        public bool IsSuccessfullyBuying { get; set; }

    }
}
