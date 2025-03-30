using System.Data.Common;
using Dapper.Contrib.Extensions;

namespace KMesada.Models;


[Table("[Filhos]")]
public class Filhos
{
    public Filhos()
    => Pontuacoes = new List<Pontuacao>();
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? UserName { get; set; }
    public DateTime Data_nascimento { get; set; }
    public string? Senha { get; set; }
    public string? Celular { get; set; }
    public int TotalPontos { get; set; }
    public decimal SaldoDinheiro { get; set; }
    public int IdPais { get; set; }

    [Write(false)]
    public List<Pontuacao> Pontuacoes {get; set;}

   
}