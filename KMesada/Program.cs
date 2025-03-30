using Microsoft.Data.SqlClient;
using Dapper;
using KMesada.Screens.PaisScreens;
using KMesada.Screens;
using KMesada.Screens.FilhosScreens;
using KMesada.Screens.PontuacaoScreens;
using KMesada.Screens.ReportScreens;


namespace KMesada;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost, 1433; Database=Kidsmesada; User Id=sa; Password=1q2w3e4r@#$;
       Encrypt=True;TrustServerCertificate=True;";
    static void Main(string[] args)
    {
       DataBase.Connection = new SqlConnection(CONNECTION_STRING);
       DataBase.Connection.Open();

       Load();
       Console.ReadKey();
       DataBase.Connection.Close();
       Environment.Exit(0);
       
    }

    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("Controle de Pontos Crianças");
        Console.WriteLine("----------------------");
        Console.WriteLine("Menu Principal");
        Console.WriteLine("");
        Console.WriteLine("1 - Config Pais");
        Console.WriteLine("2 - Config Filhos");
        Console.WriteLine("3 - Config Comportamento (Ações) Filhos");
        Console.WriteLine("4 - Controle Pontos");
        Console.WriteLine("5 - Relatórios");
        Console.WriteLine("6 - Atalho");
        //Console.WriteLine("7 - Vincular post/tag");
        //Console.WriteLine("8 - Relatórios");
        Console.WriteLine("0 - Sair");
        Console.WriteLine("");
        Console.WriteLine("");

        var option = Tratamentos.EntradaInt();

        switch (option)
        {
            case 1:
                MenuPaisScreens.Load();
                break;
            case 2:
                MenuFilhosScreen.Load();
                break;
            case 3:
                MenuAcoesScreen.Load();
                break;
            case 4:
                MenuPontuacaoScreen.Load();
                break;
            case 5:
                MenuReportScreen.Load();
                break;
            case 6:
                Console.WriteLine("opção 6");Console.ReadKey(); Load();
                break;
            
            case 0:
                Console.WriteLine("Aperte qualquer tecla para sair do Programa...");

                break;
            default:
                Console.WriteLine("Alternativa incorreta!!!\nDigite alternativa válida...");
                Console.ReadKey(); Load(); break;
        }
        
    }
}

/*
       using (var connection = new SqlConnection(connectionString))
       {
            Console.WriteLine("Conectado!");
            connection.Open();

            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [Id], [Nome] FROM [Pais]";

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)} - {reader.GetString(1)}");
                }
            }
       }*/