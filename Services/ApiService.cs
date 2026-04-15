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
<div style='font-family: Arial, sans-serif; max-width: 700px; margin: auto; line-height: 1.6;'>

    <p style='text-align: right;'>
        Data: {DateTime.Now:dd/MM/yyyy}
    </p>
    <br/>

    <p>
        <strong>Destinatário:</strong> {email.ToName}
    </p>

    <p>
        <strong>Assunto:</strong> {email.Subject}
    </p>
    <br/>

    <p style='text-align: justify; text-indent: 40px;'>
        Prezado(a),
    </p>

    <p style='text-align: justify; text-indent: 40px;'>
        Venho por meio deste solicitar {email.ToName}.
    </p>

    <br/><br/>

    <p style='text-align: justify; text-indent: 40px;'>
        Agradeço pela atenção e fico no aguardo de um retorno.
    </p>
    <br/>
    <p>
        Atenciosamente,
    </p>
    <br/>
    <p>
        {email.ToName}
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