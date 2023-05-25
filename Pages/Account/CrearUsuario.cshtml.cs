using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CiudadanosSanos.Pages.Account
{
    public class CrearUsuarioModel : PageModel
    {
        private readonly CSanosContext _dbContext;

        [BindProperty]
        public User User { get; set; }

        public CrearUsuarioModel(CSanosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            User = new User();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Codigo != "admin")
            {
                ModelState.AddModelError("User.Codigo", "El código es incorrecto.");
                return Page();
            }

            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(User);
                await _dbContext.SaveChangesAsync();

                // Redirigir a la página de inicio de sesión después de crear el usuario
                return RedirectToPage("/Account/Login");
            }

            return Page();
        }
    }
}