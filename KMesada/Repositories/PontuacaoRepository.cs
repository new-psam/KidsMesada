using Dapper;
using KMesada.Models;
using KMesada.Screens;
using KMesada.Screens.AcoesScreens;
using KMesada.Screens.FilhosScreens;
using KMesada.Screens.PaisScreens;
using KMesada.Screens.PontuacaoScreens;
using Microsoft.Identity.Client;
using System.Data;
using System.Data.Common;

namespace KMesada.Repositories;

public class PontuacaoRepository : Repository<Pontuacao>
{
    public int CreatePontuacao()
    {
        var createSql = @"INSERT INTO [Pontuacao]
                        ([Data], [Pontos], [IdAcoes], [IdParents], [IdFilhos])
                        VALUES(
                        @data_,
                        @pontos_,
                        @iDacoes_,
                        @idParents_,
                        @idFilhos_)";

        Console.Clear();
        Console.WriteLine("Cadastrar Pontuação");
        Console.WriteLine("--------------------");
        

        var data = Tratamentos.DataPresPast();

        ListAcoesScreen.List();
        Console.WriteLine("A ação está na listagem? (S/N): ");
        var resposta = Console.ReadLine();
        if (resposta!.Equals("N", StringComparison.OrdinalIgnoreCase))
        {
            CreateAcoesScreen.Load();
            return 0;
        }

        Console.WriteLine("Id ação: ");
        var idAcao = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Pontos: ");
        var pontos = int.Parse(Console.ReadLine()!);     

        ListFilhosScreen.List();
        Console.WriteLine("Id criança: ");

        // atualização de pontos incluindo pontos diários
        
        var idFilho = int.Parse(Console.ReadLine()!);
        var idPai = ListFilhosScreen.consulta(idFilho).IdPais;

        DataBase.Connection!.Execute(createSql,
        new{
            data_ = data,
            pontos_ = pontos,
            iDacoes_ = idAcao,
            idParents_  = idPai,
            idFilhos_ = idFilho
        }
        );
        return 1;
    }

    public void UpdatePontuacao(int id_)
    {
        var updateSql = @"UPDATE [pontuacao]
                        SET
                            [Data] = @data_,
                            [Pontos] = @pontos_,
                            [IdAcoes] = @iDacoes_,
                            [IdParents] = @idParents_,
                            [idFilhos] = @idFilhos_
                        WHERE
                            [Id] = @id";
        
        Pontuacao pontuacao = ListPontuacaoScreen.consulta(id_);
        var data = pontuacao.Data?.ToString("MM/dd/yyyy") ?? "Data não Informada";

        Console.Clear();
        Console.WriteLine("Editar cadastro Filho");
        Console.WriteLine("--------------------");
   
        var check = Tratamentos.pergunta($"data: {data}  deseja alterar? (S/N): ", "S");
        if (check) 
        {
            Console.WriteLine("Data(MM/dd/yyyy): ");
            data = Console.ReadLine()!;
        }
        
        Console.Clear();
        var pontos = pontuacao.Pontos;
        check = Tratamentos.pergunta($"pontos: {pontos}  deseja alterar? (S/N): ", "S");
        if (check) 
        {
            Console.WriteLine("pontos: ");
            pontos = int.Parse(Console.ReadLine()!);
        }

        Console.Clear();
        var iDacoes = pontuacao.IdAcoes;
        check = Tratamentos.pergunta($"pontos: {ListAcoesScreen.consulta(iDacoes).Nome}  deseja alterar? (S/N): ", "S");
        if (check) 
        {
            ListAcoesScreen.List();
            Console.WriteLine("id ação: ");
            iDacoes = int.Parse(Console.ReadLine()!);
        }

        Console.Clear();
        var idFilhos = pontuacao.IdFilhos;
        check = Tratamentos.pergunta($"pontos: {ListFilhosScreen.consulta(idFilhos).Nome}  deseja alterar? (S/N): ", "S");
        if (check) 
        {
            ListFilhosScreen.List();
            Console.WriteLine("id criança: ");
            idFilhos = int.Parse(Console.ReadLine()!);
        }
        var idParents = ListFilhosScreen.consulta(idFilhos).IdPais;


        DataBase.Connection!.Execute(updateSql,
        new
        {
            data_ = data,
            pontos_ = pontos,
            idAcoes_  = iDacoes,
            idParents_ = idParents,
            idFilhos_ = idFilhos,
            id = id_
            
        }
        );
    }

    public static IEnumerable<Pontuacao> ListaPorData()
    {
        string sql = @"SELECT * FROM [Pontuacao] ORDER BY [data]";
        IEnumerable<Pontuacao> pontos = DataBase.Connection!.Query<Pontuacao>(sql);
        return pontos;
    }
}