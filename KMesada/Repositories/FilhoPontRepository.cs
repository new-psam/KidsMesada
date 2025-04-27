using Dapper;
using KMesada.Models;

namespace KMesada.Repositories;

public class FilhoPontRepository
{
    public List<Filhos> GetWithPontos()
    {
        var query = @"SELECT [Filhos].*, [Pontuacao].*
                      FROM [Filhos]
                      LEFT JOIN [Pontuacao] ON [Pontuacao].[IdFIlhos] = [Filhos].[Id]";

        var kids = new List<Filhos>();

        var items = DataBase.Connection!.Query<Filhos, Pontuacao, Filhos>(
            query,
            (filhos, pontuacao) =>
            {
                var fills = kids.FirstOrDefault(x => x.Id == filhos.Id);
                if (fills == null)
                {
                    fills = filhos;
                    if (pontuacao != null)
                        fills.Pontuacoes!.Add(pontuacao);
                    kids.Add(fills);

                }
                else
                    fills.Pontuacoes!.Add(pontuacao);
                return filhos;
            }, splitOn: "Data");
        return kids; 
    }

    public List<Filhos> GetWIdPontos(int id)
    {
        var query = @$"SELECT [Filhos].*, [Pontuacao].*
                      FROM [Filhos]
                      LEFT JOIN [Pontuacao] ON [Pontuacao].[IdFIlhos] = [filhos].[id]
                      WHERE [filhos].[Id] = {id}
                      ORDER BY [pontuacao].[data]";

        var kids = new List<Filhos>();

        var items = DataBase.Connection!.Query<Filhos, Pontuacao, Filhos>(
            query,
            (filhos, pontuacao) =>
            {
                var fills = kids.FirstOrDefault(x => x.Id == filhos.Id);
                if (fills == null)
                {
                    fills = filhos;
                    if (pontuacao != null)
                        fills.Pontuacoes!.Add(pontuacao);
                    kids.Add(fills);

                }
                else
                    fills.Pontuacoes!.Add(pontuacao);
                return filhos;
            }, splitOn: "Data");
        return kids; 
    }
}