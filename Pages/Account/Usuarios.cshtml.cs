using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Account
{
    public class UsuariosModel : PageModel
    {
        private readonly CSanosContext _dbContext;

        [BindProperty]
        public string Codigo { get; set; }

        public List<User> Usuarios { get; set; }

        public UsuariosModel(CSanosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Codigo != "admin")
            {
                ModelState.AddModelError("Codigo", "El código de acceso es incorrecto.");
                return Page();
            }

            Usuarios = await _dbContext.Users.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostEliminarAsync(int id)
        {
            var usuario = await _dbContext.Users.FindAsync(id);

            if (usuario != null)
            {
                _dbContext.Users.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}