using System.Threading.Tasks;
using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiudadanosSanos.Pages.Appoinment
{
    public class CreateModel : PageModel
    {
        private readonly CSanosContext _context;

        public CreateModel(CSanosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Service Service { get; set; }

        public IActionResult OnGet()
        {
            Service = new Service();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Services.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}