using Dapper;
using KMesada.Models;
using System.Data.Common;

namespace KMesada.Repositories;

public class FilhosRepository : Repository<Filhos>
{
    public void CreateFilhos()
    {
        var createSql = @"INSERT INTO [filhos]
                        ([Nome], [UserName], [Data_nascimento], [Senha], [Celular], [IdPais])
                        VALUES(
                        @Nome,
                        @UserName,
                        @Data_Nascimento,
                        @Senha,
                        @Celular,
                        @IdPais)";

        List<string> nomesColuna = new List<string>
        {"Nome", "UserName", "Data_Nascimento", "Senha", "Celular", "IdPais"};
        string[] filho = new string[6];
        Console.Clear();
        Console.WriteLine("Cadastrar FIlho");
        Console.WriteLine("--------------------");

        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"{nomesColuna[i]}: ");
            filho[i] = Console.ReadLine()!;
        }

        var nome = filho[0];
        var userName = filho[1];
        var dataNascimento = filho[2];
        var senha = filho[3];
        var celular = filho[4];
        var idPais = int.Parse(filho[5]);

        DataBase.Connection!.Execute(createSql,
        new{
            Nome = nome,
            UserName = userName,
            Data_Nascimento  = dataNascimento,
            Senha = senha,
            Celular = celular,
            IdPais = idPais
        }
        );
    }

    public void UpdateFilhos(int id_)
    {
        var updateSql = @"UPDATE [filhos]
                        SET
                            [Nome] = @nome,
                            [UserName] = @username,
                            [Data_Nascimento] = @datanascimento,
                            [Senha] = @senha,
                            [Celular] = @celular,
                            [IdPais] = @idpais
                        WHERE
                            [Id] = @id";
        
        List<string> nomesColuna = new List<string>
        {"Nome", "UserName", "Data_Nascimento", "Senha", "Celular", "IdPais"};
        string[] filho = new string[6];
        Console.Clear();
        Console.WriteLine("Editar cadastro Filho");
        Console.WriteLine("--------------------");
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"{nomesColuna[i]}: ");
            filho[i] = Console.ReadLine()!;
        }

        var nome_ = filho[0];
        var userName_ = filho[1];
        var dataNascimento_ = filho[2];
        var senha_ = filho[3];
        var celular_ = filho[4];
        var idPais_ = int.Parse(filho[5]);

        DataBase.Connection!.Execute(updateSql,
        new
        {
            nome = nome_,
            username = userName_,
            datanascimento  = dataNascimento_,
            senha = senha_,
            celular = celular_,
            idpais = idPais_,
            id = id_
        }
        );
    }
}