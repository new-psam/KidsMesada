using System.Runtime.InteropServices;
using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens;

public class UpdatePaisScreen
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
            Console.WriteLine("Atualização de Pais ou Responsáveis");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Deseja listar os Pais/Responsável para saber o Id? (S/N)");
            var resposta = Console.ReadLine();
            if (resposta!.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                ListPaisScreen.List();
                //Console.ReadKey();
            }
                
            Console.WriteLine("Informe o ID do Pai ou Responsável");
            id = Tratamentos.EntradaInt();
            check = ListPaisScreen.consultaId(id);
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
            
        } while (check is false);

        
        Console.WriteLine("Nome: ");
        var nome = Console.ReadLine();

        Console.WriteLine("Email: ");
        var email = Console.ReadLine();

        Console.WriteLine("Senha: ");
        var senha = Console.ReadLine();

        Console.WriteLine("Celular: ");
        var celular = Console.ReadLine();

        Update(new Pais
        {
            Id = id,
            Nome = nome!,
            Email = email!,
            Senha = senha!,
            Celular = celular!
        });

        Console.ReadKey();
        MenuPaisScreens.Load();
        return 1;       

    }

    public static void Update(Pais pais)
    {
        try
        {
            var repository = new Repository<Pais>();
            repository.Update(pais);
            Console.WriteLine("Informações sobre Pais/Responsavel atualizado com sucesso");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar os dados Pais responsável");
            Console.WriteLine(ex.Message);
            Console.ReadKey();
            Load();
        }
    }
}