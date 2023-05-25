using System.Collections.Generic;
using System.Threading.Tasks;
using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Patient
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CSanosContext _context;

        public IndexModel(CSanosContext context)
        {
            _context = context;
        }

        public IList<Models.Patient> Patients { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Patients = await _context.Patients.ToListAsync();
            return Page();
        }
    }
}
