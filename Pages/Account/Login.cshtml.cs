using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CiudadanosSanos.Data;
using CiudadanosSanos.Models;

namespace CiudadanosSanos.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly CSanosContext _context;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(CSanosContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            var user = _context.Users.FirstOrDefault(u => u.CorreoElectronico == Email && u.Contrasena == Password);

            if (user != null)
            {
                // Las credenciales son correctas, redirigir a la página principal
                return RedirectToPage("/Index");
            }
            else
            {
                // Las credenciales son incorrectas, mostrar mensaje de error
                ErrorMessage = "Credenciales inválidas.";
                return Page();
            }
        }
    }
}