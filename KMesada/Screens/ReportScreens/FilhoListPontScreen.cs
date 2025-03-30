using System.ComponentModel;
using System.Linq.Expressions;
using System.Net;
using KMesada.Repositories;
using KMesada.Screens.AcoesScreens;
using KMesada.Screens.FilhosScreens;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens.ReportScreens;

public class FilhoListPontScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de Pontuações da crinaça");
        Console.WriteLine("-----------------------");

        Console.WriteLine("Deseja listar os filhos para saber o Id? (S/N)");
        var resposta = Console.ReadLine();
        if (resposta!.Equals("S", StringComparison.OrdinalIgnoreCase))
            ListFilhosScreen.List();
        
        Console.WriteLine("Id: ");
        var id = Tratamentos.EntradaInt();
        var check = ListFilhosScreen.consultaId(id);

        if (check)
        {
            Relatorio(id);
        }
        else
            Console.WriteLine("ERRO !!!!, Id de Criança inexistente!");
        Console.ReadKey();
        MenuReportScreen.Load();
    }

    public static void Relatorio(int id)
    {
        var repository = new FilhoPontRepository();
        var kid = repository.GetWIdPontos(id);
        foreach (var k in kid)
        {
            Console.Clear();
            Console.WriteLine($"id:: {k.Id} - nome: {k.Nome} - Pai: {ListPaisScreen.consulta(k.IdPais).Nome}" 
            + $" - Pontos: {k.TotalPontos} - Saldo {k.SaldoDinheiro}");
            Console.WriteLine();
            Console.WriteLine(@"                        Pontuações 
            
            -----------------------
            
            ");
            foreach (var ponto in k.Pontuacoes)
            {
                Console.WriteLine($"Data: {ponto.Data?.ToString("dd/MM/yyyy")} - Motivo:  {ListAcoesScreen.consulta(ponto.IdAcoes).Nome} - " 
                + $"Pontos: {ponto.Pontos}");
            }
        }
    }
}