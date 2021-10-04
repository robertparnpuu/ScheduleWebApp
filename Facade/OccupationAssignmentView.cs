using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    class OccupationAssignmentView : BaseView
    {
        [Required]
        public string workerId { get; set; }
        
        [Required]
        public string occupationId { get; set; }

        [Required]
        [Display(Name = "Töötaja nimi")]
        public string workerName { get; set; }

        [Required]
        [Display(Name = "Ametikoht")]
        public string occupationName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Kehtiv alates")]
        public DateTime validFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Kehtiv kuni")]
        public DateTime validTo { get; set; }
    }
}
