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
}