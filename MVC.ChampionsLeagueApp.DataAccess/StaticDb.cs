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
                    MatchName = "Atalanta vs. Real Madrid",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 2,
                    MatchName = "Atalanta vs. Real Madrid",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 3,
                    MatchName = "Atalanta vs. Real Madrid",
                    Sector = SectorTicket.C,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 4,
                    MatchName = "Atletico Madrid vs. Chelsea",
                    Sector = SectorTicket.A,
                    Price = 80  
                },
                new Ticket()
                {
                    Id = 5,
                    MatchName = "Atletico Madrid vs. Chelsea",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 6,
                    MatchName = "Atletico Madrid vs. Chelsea",
                    Sector = SectorTicket.C,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 7,
                    MatchName = "Barcelona vs. Psg",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 8,
                    MatchName = "Barcelona vs. Psg",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 9,
                    MatchName = "Barcelona vs. Psg",
                    Sector = SectorTicket.B,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 10,
                    MatchName = "Gladbach vs. Manchetser City",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 11,
                    MatchName = "Gladbach vs. Manchetser City",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 12,
                    MatchName = "Gladbach vs. Manchetser City",
                    Sector = SectorTicket.C,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 13,
                    MatchName = "Laipzig vs. Liverpool",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 14,
                    MatchName = "Laipzig vs. Liverpool",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 15,
                    MatchName = "Laipzig vs. Liverpool",
                    Sector = SectorTicket.C,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 16,
                    MatchName = "Lazio vs. Bayern Munich",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 17,
                    MatchName = "Lazio vs. Bayern Munich",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 18,
                    MatchName = "Lazio vs. Bayern Munich",
                    Sector = SectorTicket.C,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 19,
                    MatchName = "Porto vs. Juventus",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 20,
                    MatchName = "Porto vs. Juventus",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 21,
                    MatchName = "Porto vs. Juventus",
                    Sector = SectorTicket.C,
                    Price = 35
                },
                new Ticket()
                {
                    Id = 22,
                    MatchName = "Sevilla vs. Borussia Durtmund",
                    Sector = SectorTicket.A,
                    Price = 80
                },
                new Ticket()
                {
                    Id = 23,
                    MatchName = "Sevilla vs. Borussia Durtmund",
                    Sector = SectorTicket.B,
                    Price = 60
                },
                new Ticket()
                {
                    Id = 24,
                    MatchName = "Sevilla vs. Borussia Durtmund",
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

