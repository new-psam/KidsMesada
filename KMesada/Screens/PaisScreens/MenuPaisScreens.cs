namespace KMesada.Screens.PaisScreens;

public class MenuPaisScreens
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Configurações Pais");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar Pais");
        Console.WriteLine("2 - Cadastrar Pai ou Mãe");
        Console.WriteLine("3 - Editar Informações Pais");
        Console.WriteLine("4 - Excluir Pais");
        Console.WriteLine("5 - Vincular Filhos a Pais");
        //Console.WriteLine("6 - Desvincular Perfil ao Usuário");
        Console.WriteLine("0 - Retornar ao Menu Principal");
        Console.WriteLine();
        Console.WriteLine();

        var option = Tratamentos.EntradaInt();

        switch (option)
        {
            case 1:
                ListPaisScreen.Load();
                break;
            case 2:
                CreatePaisScreen.Load();
                break;
            case 3:
                Console.WriteLine("opção 3");Console.ReadKey(); Load();
                break;
            case 4:
                Console.WriteLine("opção 4");Console.ReadKey(); Load();
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