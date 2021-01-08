using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.ChampionsLeagueApp.DomainModels.Models
{
    public class Buy
    {
        public int Id { get; set; }
        public List<Ticket> Tickets { get; set; }
        public double Price { get; set; }
        public User User { get; set; }
        public bool IsSuccessfullyBuying { get; set; }

    }
}
