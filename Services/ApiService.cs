using ChamadosPro.Models;
using RestSharp;

namespace ChamadosPro.Services
{
    public class ApiService : IEmailService
    {
        private readonly string _apiKey;

        public ApiService(IConfiguration config)
        {
            _apiKey = config["API_KEY2"];
        }

        public string EnviarEmail(Email email)
        {
            var client = new RestClient("https://api.brevo.com/v3/smtp/email");
            var request = new RestRequest("", Method.Post);

            request.AddHeader("api-key", _apiKey);
            request.AddHeader("Content-Type", "application/json");

            var body = new
            {
              htmlContent = $@"
<div style=font-family: Arial, sans-serif; font-size: 14px; max-width: 700px; margin: auto; line-height: 1.6; color: #333;
    
    <!-- Data -->
    <p style='text-align: right; margin-bottom: 30px;'>
        {DateTime.Now:dd/MM/yyyy}
    </p>

    <!-- Saudação -->
    <p>
        Prezado(a) {email.ToEmail},
    </p>

    <!-- Conteúdo -->
    <p style='text-align: justify;'>
        {email.Subject}
    </p>

    <!-- Fechamento -->
    <p style='margin-top: 30px;'>
        Agradeço pela atenção e fico no aguardo de seu retorno.
    </p>

    <!-- Assinatura -->
    <p style='margin-top: 40px;'>
        Atenciosamente,<br/><br/>
        <strong>Renan Wendel</strong><br/>
        Analista de Sistemas
    </p>
</div>",
                sender = new
                {
                    email = "darkrw100@gmail.com",
                    name = "GerenciamentoDeChamados"
                },
                subject = email.ToName,
                to = new[]
                {
                    new {
                        email = email.ToEmail,
                        name = email.Subject
                    }
                }
            };

            request.AddJsonBody(body);

            var response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                return $"Erro: {response.StatusCode} - {response.Content}";
            }

            return "Email enviado com sucesso!";
        }
    }
}