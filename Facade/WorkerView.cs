﻿using System.ComponentModel.DataAnnotations;
using Facade.Common;

namespace Facade
{
    public class WorkerView:BaseView
    {
        [Required]
        public string personId { get; set; }

        [Required]
        [Display(Name = "Töötaja nimi")]
        public string workerName { get; set; }
        
        public string roleAssignmentId { get; set; }
        public string occupationAssignmentId { get; set; }

        public string departmentId { get; set; }
    }
}
