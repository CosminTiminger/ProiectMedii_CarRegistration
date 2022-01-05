using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Pages.Car
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Data.WebApplicationContext _context;

        public IndexModel(WebApplication.Data.WebApplicationContext context)
        {
            _context = context;
        }

        public IList<Cars> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }
    }
}
