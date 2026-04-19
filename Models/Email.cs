namespace ChamadosPro.Models
{
    public class Email
    {
    public string ToEmail { get; set; }
    public string? ToName { get; set; }
    public string? Subject { get; set; }
    public string Tipo { get; set; } // "requisicao" ou "incidente"
    }
}