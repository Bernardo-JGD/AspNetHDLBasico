using IntroASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BrandController : Controller
    {
        //el guion bajo ayuda a identificar un atributo privado
        private readonly PubContext _context;

        public BrandController(PubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {
            //await baseDedDatos.Tabla.listaDeObjetos-tipoTabla
            return View(await _context.Brands.ToListAsync());
        }
    }
}
