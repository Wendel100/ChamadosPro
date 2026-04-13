using ChamadosPro.Models;
using RestSharp;

namespace ChamadosPro.Services
{
    public class ApiService
    {
         private readonly string _apiKey = Environment.GetEnvironmentVariable("API_KEY2");

    public string EnviarEmail(Email email)
    {
        var client = new RestClient("https://api.brevo.com/v3/smtp/email");
        var request = new RestRequest("", Method.Post);

        request.AddHeader("api-key", _apiKey);
        request.AddHeader("Content-Type", "application/json");

        var body = new
        {
           htmlContent = @"
<html>
  <head>
    <style>
      body {
        font-family: Arial, sans-serif;
        background-color: #ffffff;
        margin: 0;
        padding: 0;
      }
      .container {
        max-width: 600px;
        margin: 20px auto;
        background-color: #8fa3ff;
        padding: 20px;
        border-radius: 8px;
        text-align: center;
      }
      .logo {
        max-width: 120px;
        margin-bottom: 20px;
      }
      h1 {
        color: #000000;
      }
      p {
        color: #ffffff;
        font-size: 16px;
      }
      .button {
        display: inline-block;
        margin-top: 20px;
        padding: 12px 20px;
        background-color: #28a745;
        color: #fff;
        text-decoration: none;
        border-radius: 5px;
        font-weight: bold;
      }
      .footer {
        margin-top: 20px;
        font-size: 12px;
        color: #fc4747bd;
      }
    </style>
  </head>

  <body>
  <body>
  <div class='container'>

    <h1>⚠️ Simulação de Phishing (Treinamento)</h1>

<p>
Este e-mail faz parte de um treinamento de conscientização em cibersegurança.
</p>

<p>
O objetivo é mostrar como golpes virtuais funcionam na prática.
</p>

<p>
🔒 Nunca clique em links suspeitos ou informe seus dados pessoais.
</p>

<a href='https://te-peguei.vercel.app/' class='button'>
Ver explicação do exercício
</a>
</body>
</html>",
            sender = new
            {
                email = "darkrw100@gmail.com",
                name = "LojaFanfic"
            },
            subject = email.Subject,
            to = new[]
            {
                new {
                    email = email.ToEmail,
                    name = email.ToName
                }
            }
        };

        request.AddJsonBody(body);

        var response = client.Execute(request);

        return response.Content;
    }
}
    }