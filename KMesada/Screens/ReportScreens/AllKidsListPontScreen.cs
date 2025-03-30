using KMesada.Repositories;
using KMesada.Screens.AcoesScreens;
using KMesada.Screens.PaisScreens;

namespace KMesada.Screens.ReportScreens;

public class AllKidsListPontScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de Pontuações de todas as crianças");
        Console.WriteLine("--------------------");
        Relatorio();
        Console.ReadKey();
        MenuReportScreen.Load();
    }

    public static void Relatorio()
    {
        var repository = new FilhoPontRepository();
        var fills = repository.GetWithPontos();
        foreach (var filho in fills)
        {
            
            Console.WriteLine();
            Console.WriteLine("******************");
            Console.WriteLine($"id:: {filho.Id} - nome: {filho.Nome} - Pai: {ListPaisScreen.consulta(filho.IdPais).Nome}" 
            + $" - Pontos: {filho.TotalPontos} - Saldo {filho.SaldoDinheiro}");
            Console.WriteLine();
            Console.WriteLine(@"                        Pontuações 
            
            -----------------------
            
            ");
            foreach (var ponto in filho.Pontuacoes)
            {
                Console.WriteLine($"Data: {ponto.Data?.ToString("dd/MM/yyyy")} - Motivo:  {ListAcoesScreen.consulta(ponto.IdAcoes).Nome} - " 
                + $"Pontos: {ponto.Pontos}");
            }
            Console.WriteLine("/n             -------------------------");
        }
    }
}