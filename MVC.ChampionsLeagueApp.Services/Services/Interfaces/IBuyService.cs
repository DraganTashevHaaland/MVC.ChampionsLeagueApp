using MVC.ChampionsLeagueApp.DomainModels.Models;
using MVC.ChampionsLeagueApp.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVC.ChampionsLeagueApp.Services.Services.Interfaces
{
    public interface IBuyService
    {
        List<BuyViewModel> GetAllBuys();
        string GetFirstMatchName();
        string GetFirstCustomer();
        int GetAllNumberOfBuys();
        string GetMostPopularMatch();
        BuyViewModel GetBuyById(int id);
        void FinishBuying(int id);
        void CreateBuyModel(Buy buy);
    }
}
