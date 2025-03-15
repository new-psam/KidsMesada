using KMesada.Models;
using KMesada.Repositories;

namespace KMesada.Screens.AcoesScreens;

public class ListAcoesScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Lista de Ações");
        Console.WriteLine("----------------------");
        List();
        Console.ReadKey();
        MenuAcoesScreen.Load();
    }

    public static void List()
    {
        var repository = new Repository<Acoes>();
        var acoes = repository.Get();
        foreach (var item in acoes)
            Console.WriteLine($"{item.Id} - {item.Nome} ->   {item.Valor}");

    }

    public static bool consultaId(int id)
    {
        var repository = new Repository<Acoes>();
        var user = repository.Get(id);
        if (user == null)
            return false;
        else    
            return true;
    }


    public static Acoes consulta(int id)
    {
        var repository = new Repository<Acoes>();
        var acoes = repository.Get(id);
        return acoes;
    }

}