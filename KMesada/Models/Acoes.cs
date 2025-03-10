using Dapper.Contrib.Extensions;

namespace KMesada.Models;


[Table("[Acoes]")]
public class Acoes
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Valor { get; set; }
}