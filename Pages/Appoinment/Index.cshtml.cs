using System.Collections.Generic;
using System.Threading.Tasks;
using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Appoinment
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CSanosContext _context;

        public IndexModel(CSanosContext context)
        {
            _context = context;
        }

        public IList<Service> Services { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Services = await _context.Services.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
