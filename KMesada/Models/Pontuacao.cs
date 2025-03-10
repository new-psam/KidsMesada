using Dapper.Contrib.Extensions;

namespace KMesada.Models;

[Table("[Pontuacao]")]
public class Pontuacao
{
    public int Id { get; set; }
    public int IdAcoes { get; set; }
    public int IdParents { get; set; }
    public int idFilhos { get; set; }
    public DateTime Data { get; set; }
}