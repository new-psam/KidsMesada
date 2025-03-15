using KMesada.Models;
using KMesada.Repositories;

namespace KMesada.Screens.PaisScreens;

public class ListPaisScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Lista de Pais");
        Console.WriteLine("----------------------");
        List();
        Console.ReadKey();
        MenuPaisScreens.Load();
    }

    public static void List()
    {
        var repository = new Repository<Pais>();
        var papais = repository.Get();
        foreach (var item in papais)
            Console.WriteLine($"{item.Id} - {item.Nome} - {item.Email} - {item.Celular}");

    }

    public static bool consultaId(int id)
    {
        var repository = new Repository<Pais>();
        var user = repository.Get(id);
        if (user == null)
            return false;
        else    
            return true;
    }


    public static Pais consulta(int id)
    {
        var repository = new Repository<Pais>();
        var pais = repository.Get(id);
        return pais;
    }

}