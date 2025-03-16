using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.FilhosScreens;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens.PontuacaoScreens;


public class CreatePontuacaoScreen
{
    public static void Load()
    {
        Create();
        Console.ReadKey();
        MenuPontuacaoScreen.Load();

    }

    public static void Create()
    {
        try
        {
            var repository = new PontuacaoRepository();
            repository.CreatePontuacao();
            Console.WriteLine("pontos cadastrado com sucesso!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível realizar o novo cadastro!");
             Console.WriteLine(ex.Message);
             Console.ReadKey();
             Load();
        }
    }
}