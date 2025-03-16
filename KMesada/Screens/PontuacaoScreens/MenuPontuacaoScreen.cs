namespace KMesada.Screens.PontuacaoScreens;

public class MenuPontuacaoScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Pontuação das ações");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Listar pontuações feitas");
        Console.WriteLine("2 - Cadastrar Pontuação");
        Console.WriteLine("3 - Editar Pontuação");
        Console.WriteLine("4 - Excluir Pontuação");
        //Console.WriteLine("5 - Vincular Filhos a Pais");
        //Console.WriteLine("6 - Desvincular Perfil ao Usuário");
        Console.WriteLine("0 - Retornar ao Menu Principal");
        Console.WriteLine();
        Console.WriteLine();

        var option = Tratamentos.EntradaInt();

        switch (option)
        {
            case 1:
                ListPontuacaoScreen.Load();
                break;
            case 2:
                CreatePontuacaoScreen.Load();
                break;
            case 3:
                UpdatePontuacaoScreen.Load();
                break;
            case 4:
                DeletePontuacaoScreen.Load();
                break;
            case 5:
                //Console.WriteLine("opção 5");Console.ReadKey(); Load();
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