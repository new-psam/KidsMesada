using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.AcoesScreens;
using KMesada.Screens.FilhosScreens;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens.PontuacaoScreens;

public class ListPontuacaoScreen
{
    public static void Load() 
    {
        Console.Clear();
        Console.WriteLine("Lista de Pontos");
        Console.WriteLine("----------------------");
        List();
        Console.ReadKey();
        MenuPontuacaoScreen.Load();
    }

    public static void List()
    {
        //var repository = new Repository<Pontuacao>();
        
        var pontos = PontuacaoRepository.ListaPorData();
        foreach (var item in pontos)
        {
           var data = item.Data?.ToString("dd/MM/yyyy") ?? "Data não informada";
           var kids = ListFilhosScreen.consulta(item.IdFilhos).Nome;
           var parents = ListPaisScreen.consulta(item.IdParents).Nome;
           var action = ListAcoesScreen.consulta(item.IdAcoes).Nome;
           Console.WriteLine($"id: {item.Id} - data: {data} - criança: {kids} - Responsável: {parents}"); 
           Console.WriteLine($"ocorrido: {action} - pontos: {item.Pontos}\n");  
        }
    }

    public static bool consultaId(int id)
    {
        var repository = new Repository<Pontuacao>();
        var user = repository.Get(id);
        if (user == null)
            return false;
        else    
            return true;
    }


    public static Pontuacao consulta(int id)
    {
        var repository = new Repository<Pontuacao>();
        var pontos = repository.Get(id);
        return pontos;
    }

}