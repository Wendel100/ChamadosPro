using ChamadosPro.Models;
using ChamadosPro.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChamadosPro.Controllers
{
    public class ChamadosController : Controller
    {
      private readonly ApiService _emailService;
        public ChamadosController()
    {
        _emailService = new ApiService();
    }

    [HttpPost("enviar")]
    public IActionResult EnviarEmail(Email request)
    {
        var resposta = _emailService.EnviarEmail(request);
        return Ok(resposta);
    }
        public IActionResult Index()
        {
            return View();
        }
    }
}