using System.Collections.Generic;
using System.Threading.Tasks;
using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Historial
{
    public class ListaServiciosModel : PageModel
    {
        private readonly CSanosContext _dbContext;

        public List<Service> Services { get; set; }

        public ListaServiciosModel(CSanosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            Services = await _dbContext.Services.ToListAsync();
        }
    }
}
