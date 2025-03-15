namespace KMesada.Screens.FilhosScreens;

public class MenuFilhosScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Configurações Filhos");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar Filhos");
        Console.WriteLine("2 - Cadastrar Filhos");
        Console.WriteLine("3 - Editar Informações dos Filhos");
        Console.WriteLine("4 - Excluir Filhos");
        Console.WriteLine("5 - Vincular Filhos a Pais");
        //Console.WriteLine("6 - Desvincular Perfil ao Usuário");
        Console.WriteLine("0 - Retornar ao Menu Principal");
        Console.WriteLine();
        Console.WriteLine();

        var option = Tratamentos.EntradaInt();

        switch (option)
        {
            case 1:
                ListFilhosScreen.Load();
                break;
            case 2:
                CreateFilhosScreen.Load();
                break;
            case 3:
                UpdateFilhosScreen.Load();
                break;
            case 4:
                DeleteFilhosScreen.Load();
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