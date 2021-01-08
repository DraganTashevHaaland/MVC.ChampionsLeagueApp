using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MVC.ChampionsLeagueApp.ViewModels.Models
{
    public class GetBuyViewModel
    {
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Display(Name = "Address: ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone: ")]
        public long PhoneNumber { get; set; }

        public List<string> Matches { get; set; }

        [Display(Name = "Witch Sector: ")]
        public List<TicketViewModel> Tickets { get; set; }

        public List<string> TicketNames { get; set; }
    }
}
