using KMesada.Models;
using KMesada.Repositories;

namespace KMesada.Screens;


public class CreateAcoesScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Cadastrar Acoes");
        Console.WriteLine("---------------------");
        Console.WriteLine("Nome: ");
        var nome = Console.ReadLine();

        Console.WriteLine("Valor: ");
        var valor = int.Parse(Console.ReadLine()!);

        Create(new Acoes
        {
            Nome = nome!,
            Valor = valor
            
        });

        Console.ReadKey();
        MenuAcoesScreen.Load();

    }

    public static void Create(Acoes acoes)
    {
        try
        {
            var repository = new Repository<Acoes>();
            repository.Create(acoes);
            Console.WriteLine("Acoes dos filhos cadastrado com sucesso!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar o novo cadastro,");
             Console.WriteLine(ex.Message);
             Console.ReadKey();
             Load();
        }
    }
}