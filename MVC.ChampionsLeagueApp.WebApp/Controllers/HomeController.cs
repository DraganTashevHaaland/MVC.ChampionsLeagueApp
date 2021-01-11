using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.ChampionsLeagueApp.Services.Services.Interfaces;
using MVC.ChampionsLeagueApp.ViewModels.Helpers;
using MVC.ChampionsLeagueApp.ViewModels.Models;

namespace MVC.ChampionsLeagueApp.WebApp.Controllers
{
    public class HomeController : Controller
    {

        private IMatchService _matchService;
        private readonly IHostingEnvironment _webhost;

        public HomeController(IMatchService matchService,
                              IHostingEnvironment webhost)
        {
            _matchService = matchService;
            _webhost = webhost;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //Postman link: https://localhost:5001/Home
        public IActionResult Index(HomeViewModel model)
        {
            return RedirectToAction("Buy", "Buy", new { tickets = model.NumberOfTickets});
        }

        [HttpGet]
        //Postman link: https://localhost:5001/Home/About
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        //Postman link: https://localhost:5001/Home/Contact
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        //Postman link:  https://localhost:5001/Home/Matches
        public IActionResult Matches()
        {
            var dbMatches = _matchService.GetMatches();

            var matches = new List<TicketViewModel>();

            foreach (var ticket in dbMatches)
            {

                var tempMatch = new TicketViewModel()
                {
                    MatchName = ticket.MatchName,
                    Price = ticket.Price,
                    Sector = ticket.Sector
                };

                matches.Add(tempMatch);

            }

            var matchesViewModel = new MatchesViewModel()
            {
                Matches = matches,
            };

            return View(matchesViewModel);
        }

        [HttpGet]
        //Postman link: https://localhost:5001/Home/AddTicket
        public IActionResult AddTicket()
        {
            return View();
        }

        [HttpPost]
        //Postman link: https://localhost:5001/Home/AddTicket
        public IActionResult AddTicket(AddTicketViewModel model)
        {
            _matchService.AddTicketInMatch(model);
            return RedirectToAction("Matches");
        }

        [HttpGet]
        //Postman link: https://localhost:5001/Home/UploadImg
        public IActionResult UploadImg()
        {
            var ic = new ImageClass();
            var fileInfo = AccessWWWRoot();
            ic.FileImages = fileInfo;
            return View(ic);
        }

        [HttpPost]
        //Postman link: https://localhost:5001/Home/UploadImg
        public IActionResult UploadImg(IFormFile imgfile)
        {
            ImageClass ic = new ImageClass();
            var fileInfo = AccessWWWRoot();
            ic.FileImages = fileInfo;

            if(imgfile == null)
            {
                ic.Message = "Please selct valid image.";
                return View(ic);
            }

            var saveimg = Path.Combine(_webhost.WebRootPath, "images/tickets", imgfile.FileName);

            var imgtext = Path.GetExtension(imgfile.FileName);
            if(imgtext == ".jpg" || imgtext == ".png")
            {
                using (var uploadimg = new FileStream(saveimg, FileMode.Create))
                {
                    imgfile.CopyTo(uploadimg);
                    ic.Message = $"This selected file {imgfile.FileName} is saved successfully!";
                }
            }
            else
            {
                ic.Message = $"Only the img file types .jpg and .png can be uploaded!";
            }

            fileInfo = AccessWWWRoot();
            ic.FileImages = fileInfo;

            return View(ic);
        }
        public List<FileInfo> AccessWWWRoot()
        {
            var displayImg = Path.Combine(_webhost.WebRootPath, "images/tickets");
            DirectoryInfo di = new DirectoryInfo(displayImg);
            List<FileInfo> fileInfo = di.GetFiles().ToList();
            return fileInfo;
        }       

        [HttpGet] 
        public IActionResult DeleteImg(string imgdelete)
        {
            imgdelete = Path.Combine(_webhost.WebRootPath, "images/tickets", imgdelete);
            FileInfo fi = new FileInfo(imgdelete);
            
                if(fi != null)
                {
                    System.IO.File.Delete(imgdelete);
                    fi.Delete();
                }

            return RedirectToAction("UploadImg");
        }
    }
}


