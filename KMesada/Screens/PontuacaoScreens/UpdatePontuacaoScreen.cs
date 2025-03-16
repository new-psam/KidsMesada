using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.FilhosScreens;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens.PontuacaoScreens;


public class UpdatePontuacaoScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Editar pontuação Filho");
        Console.WriteLine("---------------------------");
        ListPontuacaoScreen.List();
        Console.WriteLine("Id: ");
        var id = Tratamentos.EntradaInt();
        
        Update(id);
        Console.ReadKey();
        MenuPontuacaoScreen.Load();

    }

    public static void Update(int id)
    {
        try
        {
            var repository = new PontuacaoRepository();
            repository.UpdatePontuacao(id);
            Console.WriteLine("Cadastro atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualiar o cadastro!!");
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            Load();
        }
    }
}