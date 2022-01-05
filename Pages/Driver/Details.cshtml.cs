using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Pages.Driver
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Data.WebApplicationContext _context;

        public DetailsModel(WebApplication.Data.WebApplicationContext context)
        {
            _context = context;
        }

        public Driver_Detailss Driver { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver = await _context.Driver.FirstOrDefaultAsync(m => m.License_Id == id);

            if (Driver == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
