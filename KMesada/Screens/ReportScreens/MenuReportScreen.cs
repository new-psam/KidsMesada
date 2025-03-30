namespace KMesada.Screens.ReportScreens;

public class MenuReportScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Relatorios");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine();
        Console.WriteLine("1 - Pontuações por criança(todas)");
        Console.WriteLine("2 - Pontuações de uma criança");
        Console.WriteLine("3 - ");
        Console.WriteLine("4 - ");
        Console.WriteLine("0 - ");
        Console.WriteLine();
        Console.WriteLine();

        var option = Tratamentos.EntradaInt();

        switch (option)
        {
            case 1:
                AllKidsListPontScreen.Load();
                break;
            case 2:
                FilhoListPontScreen.Load();
                break;
            case 3:
                
                break;
            case 4:
                
                Console.ReadKey();
                Load();
                break;
            case 0:
                Program.Load();
                break;
            default:
                Console.WriteLine("Alternativa incorreta!!!\nDigite alternativa válida...");
                Console.ReadKey(); Load(); break;
        }
    }

}