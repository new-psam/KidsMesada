using Dapper.Contrib.Extensions;

namespace KMesada.Models;

[Table("[Pontuacao]")]
public class Pontuacao
{
    public int Id { get; set; }
    public int IdAcoes { get; set; }
    public int IdParents { get; set; }
    public int IdFilhos { get; set; }
    public int Pontos {get; set;}
    public DateTime Data { get; set; }
}