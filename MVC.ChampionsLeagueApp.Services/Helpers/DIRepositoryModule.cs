using Microsoft.Extensions.DependencyInjection;
using MVC.ChampionsLeagueApp.DataAccess.Repositories;
using MVC.ChampionsLeagueApp.DataAccess.Repositories.CashRepositories;
using MVC.ChampionsLeagueApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.ChampionsLeagueApp.Services.Helpers
{
    public static class DIRepositoryModule
    {
        // Microsoft.Extensions.DependencyInjection 2.1.1
        public static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            //StaticDB
            services.AddTransient<IRepository<Ticket>, TicketRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Buy>, BuyRepository>();

            return services;
        }
    }
}
