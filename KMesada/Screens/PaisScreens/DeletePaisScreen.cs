using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens;

public class DeletePaisScreen
{
    public static int Load()
    {
        int id = 0;
        bool check = true;
        var sair = "sim";

        do 
        {
            Console.Clear();
            Console.WriteLine("Excluir Pais/Responsável");
            Console.WriteLine("-----------------");
            //---- poderia ser um método abstrato ???
            Console.WriteLine("Deseja listar os Pais/Responsável para saber o Id? (S/N)");
            var resposta = Console.ReadLine();
            if (resposta!.Equals("S", StringComparison.OrdinalIgnoreCase))
                ListPaisScreen.List();
            //---

            Console.WriteLine("Id: ");
            id = Tratamentos.EntradaInt();
            check = ListPaisScreen.consultaId(id);
            //-------- if para sair do loop em caso de erro do id
            if (!check)
            {
                Console.WriteLine($"Usuário de ID {id} inexistente!");
                Console.ReadKey();
                Console.WriteLine("para voltar ao Menu digite (menu) \nOu Digite qualquer tecla para continuar");
                sair = Console.ReadLine();
                if (sair!.Equals("menu", StringComparison.OrdinalIgnoreCase) )
                {
                    Console.ReadKey();
                    MenuPaisScreens.Load();
                    return 0;
                }
                    
            }
            //----------------
            else
            {
                Console.WriteLine($"Você tem certeza que quer excluir as informações de"
                + $" id - {id} - {ListPaisScreen.consulta(id).Nome} (s/n)");
                var res = Console.ReadLine();
                if (res!.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;
                else
                    check = false;
            }
        } while (check is false);

        Delete(id);
        Console.ReadKey();
        MenuPaisScreens.Load();

        return 0;
    }

    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Pais>();
            repository.Delete(id);
            Console.WriteLine("Pais/Responsável excluido com secesso!");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir os dados!");
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            Load();
        }
    }
}