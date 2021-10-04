using System;
using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    class PersonView : BaseView
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Eesnime pikkus võib olla maksimaalselt 50 tähte")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Eesnimi")]
        public string firstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2,ErrorMessage = "Perekonnanime pikkus võib olla maksimaalselt 50 tähte")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Perekonnanimi")]
        public string lastName { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Isikukood peab koosnema 11st numbrist")]
        [RegularExpression("^[0-9]")]
        [Display(Name = "Isikukood")]
        public string idCode { get; set; }

        [Required]
        [Display(Name = "Sünnikuupäev")]
        public DateTime dateOfBirth { get; set; }

        public string contactId { get; set; }
    }
}
