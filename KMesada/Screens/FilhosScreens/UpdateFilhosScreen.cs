using KMesada.Repositories;
using KMesada.Screens.FilhosScreens;

namespace KMesada.Screens;

public class UpdateFilhosScreen
{
    public static int Load()
    {
        int id = 0;
        bool check = true;
        var sair = "sim";
        //interessante imprimir a lista com o Id antes
        do
        {
            Console.Clear();
            Console.WriteLine("Editar cadastro Filho");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Deseja listar os Filhos para saber o Id? (S/N)");
            var resposta = Console.ReadLine();
            if (resposta!.Equals("S", StringComparison.OrdinalIgnoreCase))
                ListFilhosScreen.List();
                            
            Console.WriteLine("Informe o ID do Filho");
            id = Tratamentos.EntradaInt();
            check = ListFilhosScreen.consultaId(id);
            if (!check)
            {
                Console.WriteLine($"Usuário de ID {id} inexistente!");
                Console.ReadKey();
                Console.WriteLine("para voltar ao Menu digite (menu) \nOu Digite qualquer tecla para continuar");
                sair = Console.ReadLine();
                if (sair!.Equals("menu", StringComparison.OrdinalIgnoreCase) )
                {
                    Console.ReadKey();
                    MenuFilhosScreen.Load();
                    return 0;
                }
                    
            }
            
        } while (check is false);

        Update(id);
        Console.ReadKey();
        MenuFilhosScreen.Load();
        return 1;
    }

    public static void Update(int id)
    {
        try
        {
            var repository = new FilhosRepository();
            repository.UpdateFilhos(id);
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