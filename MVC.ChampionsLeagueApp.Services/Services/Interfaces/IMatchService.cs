using MVC.ChampionsLeagueApp.DomainModels.Enums;
using MVC.ChampionsLeagueApp.DomainModels.Models;
using MVC.ChampionsLeagueApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.ChampionsLeagueApp.Services.Services.Interfaces
{
    public interface IMatchService
    {
        List<Ticket> GetMatches();
        Ticket GetTicketByMatchNameAndSector(string matchName, SectorTicket sector);
        int AddTicketInMatch(AddTicketViewModel ticketModel);
    }
}


