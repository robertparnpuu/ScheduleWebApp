﻿using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class LocationView:BaseView
    {
        [Required]
        [Display(Name = "Location name")]
        public string name { get; set; }
        [Display(Name = "Address")]
        public string fullAddress { get; set; }
        [Display(Name = "Contacts")]
        public string fullContact { get; set; }
        [Required]
        [Display(Name = "PartyContactId")]
        public string partyContactId { get; set; }
    }
}
