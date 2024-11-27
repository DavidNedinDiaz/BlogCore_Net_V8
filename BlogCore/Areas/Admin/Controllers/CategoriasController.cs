using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTranajo;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTranajo = contenedorTrabajo; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() { return View(); }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria ) 
        {
            if (ModelState.IsValid)
            {
                //Logica para guardar en DataBase
                _contenedorTranajo.Categoria.Add(categoria);
                _contenedorTranajo.Save();
                return RedirectToAction("Index");   
            }

            return View(categoria);

        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTranajo.Categoria.Get(id);

            if (categoria == null)
            {
                return NoContent();
            }
            return View(categoria); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                //Logica para guardar en DataBase
                _contenedorTranajo.Categoria.Update(categoria);
                _contenedorTranajo.Save();
                return RedirectToAction("Index");
            }

            return View(categoria);

        }


        #region llamadas a la API

        [HttpGet]
        public IActionResult GetAll() 
        {
        
            return Json(new {data = _contenedorTranajo.Categoria.GetAll()});
        }

        #endregion 


    }
}
