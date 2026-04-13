using Microsoft.AspNetCore.Mvc;

namespace ChamadosPro.Controllers
{
    public class ChamadosController : Controller
    {
        // private readonly ILogger<ChamadosController> _logger;

        // public ChamadosController(ILogger<ChamadosController> logger)
        // {
        //     _logger = logger;
        // }
        public IActionResult Index()
        {
            return View();
        }
    }
}