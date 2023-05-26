using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

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

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {
            var user = _context.Users.FirstOrDefault(u => u.CorreoElectronico == Email && u.Contrasena == Password);

            if (user != null)
            {
                // Las credenciales son correctas, iniciar sesión
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.CorreoElectronico) // Puedes personalizar los claims según tus necesidades
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

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
