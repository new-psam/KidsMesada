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
        var idFilho = int.Parse(Console.ReadLine()!);
        // atualização de pontos incluindo pontos diários
        AtualizaData(idFilho);


        
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
// -------------------------------------------------------------
    public static IEnumerable<Pontuacao> ListaPorData()
    {
        string sql = @"SELECT * FROM [Pontuacao] ORDER BY [data]";
        IEnumerable<Pontuacao> pontos = DataBase.Connection!.Query<Pontuacao>(sql);
        return pontos;
    }



//--------------------------------------------------------------
    public static  int AtualizaData(int _id)
    {
        var pontos = ListaPorData();
        var diarios = pontos.LastOrDefault(x => x.IdAcoes == 1);
        DateTime data;
        if (diarios == null)
            data = DateTime.Today.AddDays(-31);
        else
            data = diarios.Data!.Value;
        
        TimeSpan difDias = DateTime.Today - data;
        
        int dias = difDias.Days;
        if (dias > 31)
        {
            data = DateTime.Today.AddDays(-31);
            dias = 31;
        }

        DateTime novaData = data.AddDays(1);
        for (int i = 0; i < dias;i++)
        {
            try
            {
                var createSql = @"INSERT INTO [Pontuacao]
                            ([Data], [Pontos], [IdAcoes], [IdParents], [IdFilhos])
                            VALUES(
                            @data_,
                            @pontos_,
                            @iDacoes_,
                            @idParents_,
                            @idFilhos_)";

                DataBase.Connection!.Execute(createSql,
                new{
                    data_ = novaData.ToString("MM/dd/yyyy"),
                    pontos_ = 35,
                    iDacoes_ = 1,
                    idParents_  = ListFilhosScreen.consulta(_id).IdPais,
                    idFilhos_ = _id
                });

                    Console.WriteLine("pontos cadastrado com sucesso!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível realizar o novo cadastro!");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return 0;
            }
            novaData = novaData.AddDays(1);
        }
        
        //Console.WriteLine(novaData);

        


        return 1;
    }
}







//TimeSpan difDias = DateTime.Today - data;
        // int dias = difDias.Days;

        // for (int i = 0; i < dias; i++)
        // {
        //     try
        //     {
        //         //var repository = new PontuacaoRepository();
        //         //var retorno = repository.CreatePontuacao();

        //         var createSql = @"INSERT INTO [Pontuacao]
        //                     ([Data], [Pontos], [IdAcoes], [IdParents], [IdFilhos])
        //                     VALUES(
        //                     @data_,
        //                     @pontos_,
        //                     @iDacoes_,
        //                     @idParents_,
        //                     @idFilhos_)";

        //     DataBase.Connection!.Execute(createSql,
        //     new{
        //         data_ = data,
        //         pontos_ = 35,
        //         iDacoes_ = 1,
        //         idParents_  = ListFilhosScreen.consulta(_id).IdPais,
        //         idFilhos_ = _id
        //     });

        //         Console.WriteLine("pontos cadastrado com sucesso!!");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine("Não foi possível realizar o novo cadastro!");
        //         Console.WriteLine(ex.Message);
        //         Console.ReadKey();
        //         return 0;
        //     }
            
        // }

        // Console.WriteLine("!!");
        // Console.WriteLine("!!");
        // Console.WriteLine($"{dias} dias de  Pontos diários cadastrados com sucesso ");
        // return 1;
      