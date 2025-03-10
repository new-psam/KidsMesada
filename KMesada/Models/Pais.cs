using Dapper.Contrib.Extensions;

namespace KMesada.Models;

[Table("[Pais]")]
public class Pais
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Celular { get; set; }
}