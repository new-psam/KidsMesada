using KMesada.Models;
using KMesada.Repositories;
using KMesada.Screens.AcoesScreens;
using KMesada.Screens.FilhosScreens;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens.PontuacaoScreens;

public class DeletePontuacaoScreen
{
    public static int Load()
    {
        int id = 0;
        bool check = true;
        var sair = "sim";

        do 
        {
            Console.Clear();
            Console.WriteLine("Excluir cadastro Pontuação");
            Console.WriteLine("-----------------");
            //---- poderia ser um método abstrato ???
            Console.WriteLine("Deseja listar as pontuações para saber o Id? (S/N)");
            var resposta = Console.ReadLine();
            if (resposta!.Equals("S", StringComparison.OrdinalIgnoreCase))
                ListPontuacaoScreen.List();
            //---

            Console.WriteLine("Id: ");
            id = Tratamentos.EntradaInt();
            check = ListPontuacaoScreen.consultaId(id);
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
                    MenuPontuacaoScreen.Load();
                    return 0;
                }
                    
            }
            //----------------
            else
            {
                Console.WriteLine($"Você tem certeza que quer excluir as informações de: \n");
                Pontuacao pontuacao = ListPontuacaoScreen.consulta(id);
                var data = pontuacao.Data.ToString("dd/MM/yyyy");
                var kids = ListFilhosScreen.consulta(pontuacao.IdFilhos).Nome;
                var parents = ListPaisScreen.consulta(pontuacao.IdParents).Nome;
                var action = ListAcoesScreen.consulta(pontuacao.IdAcoes).Nome;
                Console.WriteLine($"id: {id} - data: {data} - criança: {kids} - Responsável: {parents}"); 
                Console.WriteLine($"ocorrido: {action} - pontos: {pontuacao.Pontos}\n"); 
                
                Console.WriteLine("(S/N)");
                var res = Console.ReadLine();
                if (res!.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;
                else
                    check = false;
            }
        } while (check is false);

        Delete(id);
        Console.ReadKey();
        MenuPontuacaoScreen.Load();

        return 0;
    }

    public static void Delete(int id)
    {
        try
        {
            var repository = new Repository<Pontuacao>();
            repository.Delete(id);
            Console.WriteLine("cadastro excluido com sucesso!");

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