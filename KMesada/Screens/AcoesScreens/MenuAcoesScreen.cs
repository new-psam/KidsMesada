using KMesada.Screens.AcoesScreens;


namespace KMesada.Screens;


public class MenuAcoesScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Configurações Açoes do Filhos");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar Ações");
        Console.WriteLine("2 - Cadastrar Ações");
        Console.WriteLine("3 - Editar Ações");
        Console.WriteLine("4 - Excluir Ações");
        //Console.WriteLine("5 - Vincular Filhos a Pais");
        //Console.WriteLine("6 - Desvincular Perfil ao Usuário");
        Console.WriteLine("0 - Retornar ao Menu Principal");
        Console.WriteLine();
        Console.WriteLine();

        var option = Tratamentos.EntradaInt();

        switch (option)
        {
            case 1:
                ListAcoesScreen.Load();
                break;
            case 2:
                CreateAcoesScreen.Load();
                break;
            case 3:
                UpdateAcoesScreen.Load();
                break;
            case 4:
                DeleteAcoesScreen.Load();
                break;
            case 5:
                Console.WriteLine("opção 5");Console.ReadKey(); Load();
                break;
            //case 6:
                //DesvincUserRoleScreen.Load();
                //break;
            case 0:
                Program.Load();
                break;
            default:
                Console.WriteLine("Alternativa incorreta!!!\nDigite alternativa válida...");
                Console.ReadKey(); Load(); break;
        }
    }

}