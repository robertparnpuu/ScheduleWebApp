using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PageModels
{
    [Authorize(Roles = "Admin, Viewer")]
    public class CalendarModel : PageModel
    {

        public IActionResult OnGetIndex()
        {
            return Page();
        }
    }
}
