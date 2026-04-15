using ChamadosPro.Models;

namespace ChamadosPro.Services
{
    public interface IEmailService
    {
        string EnviarEmail(Email email);
    }
}