

using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens;


public class CreatePaisScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Cadastrar Pais/Responsável");
        Console.WriteLine("---------------------");
        Console.WriteLine("Nome: ");
        var nome = Console.ReadLine();

        Console.WriteLine("Email: ");
        var email = Console.ReadLine();

        Console.WriteLine("Senha: ");
        var senha = Console.ReadLine();

        Console.WriteLine("Celular: ");
        var celular = Console.ReadLine();

        Create(new Pais
        {
            Nome = nome!,
            Email = email!,
            Senha = senha!,
            Celular = celular!
        });

        Console.ReadKey();
        MenuPaisScreens.Load();

    }

    public static void Create(Pais pais)
    {
        try
        {
            var repository = new Repository<Pais>();
            repository.Create(pais);
            Console.WriteLine("Pais/Responsável cadastrado com sucesso!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar o novo cadastro," +
             "provavelmente Email já existente");
             Console.WriteLine(ex.Message);
             Console.ReadKey();
             Load();
        }
    }
}