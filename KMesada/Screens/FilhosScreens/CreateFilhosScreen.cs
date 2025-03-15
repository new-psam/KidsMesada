using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.FilhosScreens;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens;


public class CreateFilhosScreen
{
    public static void Load()
    {
        Create();
        Console.ReadKey();
        MenuFilhosScreen.Load();

    }

    public static void Create()
    {
        try
        {
            var repository = new FilhosRepository();
            repository.CreateFilhos();
            Console.WriteLine("Filho cadastrado com sucesso!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar o novo cadastro!");
             Console.WriteLine(ex.Message);
             Console.ReadKey();
             Load();
        }
    }
}