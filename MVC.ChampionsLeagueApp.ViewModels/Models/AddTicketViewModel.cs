using MVC.ChampionsLeagueApp.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.ChampionsLeagueApp.ViewModels.Models
{
    public class AddTicketViewModel
    {
        //public int Id { get; set; }
        public string MatchName { get; set; }
        public double Price { get; set; }
        public SectorTicket Sector { get; set; }
    }
}
