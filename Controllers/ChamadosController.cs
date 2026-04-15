using ChamadosPro.Models;
using ChamadosPro.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChamadosPro.Controllers
{
    public class ChamadosController : Controller
    {
        private readonly IEmailService _emailService;

        public ChamadosController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnviarEmail(Email request)
        {
            var resposta = _emailService.EnviarEmail(request);

            TempData["Mensagem"] = resposta;

            return RedirectToAction("Index");
        }
    }
}