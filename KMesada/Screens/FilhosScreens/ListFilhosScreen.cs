using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens.FilhosScreens;

public class ListFilhosScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Lista de Filhos");
        Console.WriteLine("----------------------");
        List();
        Console.ReadKey();
        MenuFilhosScreen.Load();
    }

    public static void List()
    {
        var repository = new Repository<Filhos>();
        var filhos = repository.Get();
        foreach (var item in filhos)
        {
           var dataNasc = item.Data_nascimento.ToString("dd/MM/yyyy");
           Console.WriteLine($"id: {item.Id} - nome: {item.Nome} - username: {item.UserName} - data nascimento: {dataNasc}"); 
           Console.WriteLine($"pontos: {item.TotalPontos} - saldo: {item.SaldoDinheiro}; "
            + $" Pai/Responsael: {ListPaisScreen.consulta(item.IdPais).Nome}\n"); 
        }
    }

    public static bool consultaId(int id)
    {
        var repository = new Repository<Filhos>();
        var user = repository.Get(id);
        if (user == null)
            return false;
        else    
            return true;
    }


    public static Filhos consulta(int id)
    {
        var repository = new Repository<Filhos>();
        var filhos = repository.Get(id);
        return filhos;
    }

}