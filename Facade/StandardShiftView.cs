﻿using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class StandardShiftView: BaseView
    {
        [Required]
        public string occupationId { get; set; }
        [Required]
        public string locationId { get; set; }


        [Required]
        [Display(Name = "Ametikoht")]
        public string occupationName { get; set; }

        [Required]
        [Display(Name = "Asukoht")]
        public string locationName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Vahetuse algusaeg")]
        public DateTime startTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Vahetuse lõpuaeg")]
        public DateTime endTime { get; set; }
    }
}
