using MVC.ChampionsLeagueApp.DomainModels.Enums;
using MVC.ChampionsLeagueApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.ChampionsLeagueApp.DataAccess
{
    public static class StaticDb
    {
        public static List<Buy> Buys { get; set; }
        public static List<Ticket> Matches { get; set; }
        public static List<User> Users { get; set; }

        static StaticDb()
        {
            Users = new List<User>()
            {
               new User()
               {
                   Id = 1,
                   FirstName = "Albert",
                   LastName = "Halsberger",
                   Address = "Laipziger Strase 35",
                   Email = "albert88@yahoo.com",
                   PhoneNumber = 078345777
               },
            };

            Matches = new List<Ticket>()
            {
                new Ticket()
                {
                    Id = 1,
                    MatchName = "Juventus vs. Barcelona",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 2,
                    MatchName = "Juventus vs. Barcelona",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 3,
                    MatchName = "Juventus vs. Barcelona",
                    Sector = SectorTicket.C,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 4,
                    MatchName = "PSG vs. Liverpool",
                    Sector = SectorTicket.A,
                    Price = 80  
                },
                new Ticket()
                {
                    Id = 5,
                    MatchName = "PSG vs. Liverpool",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 6,
                    MatchName = "PSG vs. Liverpool",
                    Sector = SectorTicket.C,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 7,
                    MatchName = "Real Madrid vs. Bayern Munich",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 8,
                    MatchName = "Real Madrid vs. Bayern Munich",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 9,
                    MatchName = "Real Madrid vs. Bayern Munich",
                    Sector = SectorTicket.B,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 10,
                    MatchName = "Borussia Dormund vs. Napoli",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 11,
                    MatchName = "Borussia Dormund vs. Napoli",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 12,
                    MatchName = "Borussia Dormund vs. Napoli",
                    Sector = SectorTicket.C,
                    Price = 35
                },
            };

            Buys = new List<Buy>()
            {
                new Buy()
                {
                    Id = 1,
                    User = Users[0],
                    Tickets = new List<Ticket>{ Matches[0] },
                    IsSuccessfullyBuying = true,
                },
            };
            
        }
    }
}

