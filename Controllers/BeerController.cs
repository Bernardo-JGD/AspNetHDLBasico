using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    public class BeerController : Controller
    {

        private readonly PubContext _context;

        public BeerController(PubContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var beers = _context.Beers.Include(b => b.Brand);

            return View(await beers.ToListAsync());
        }

        public IActionResult Create()
        {
            //Obtengo la lista de marcas, muestro el nombre pero se selecciona el id
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Nombre" );
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Evita que entre información de otro sitio, solo del dominió propio
        public async Task<IActionResult>  Create(BeerViewModel model)
        {

            if (ModelState.IsValid)
            {
                var beer = new Beer()
                {
                    Nombre = model.nombre,
                    BrandId = model.BrandId
                };
                _context.Add(beer);//se carga el objeto que se insertará en la base de datos
                await _context.SaveChangesAsync();//con el await se inserta en la base de datos
                return RedirectToAction(nameof(Index));
            }

            //Obtengo la lista de marcas, muestro el nombre pero se selecciona el id
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Nombre", model.BrandId);
            return View(model);
        }

    }
}
