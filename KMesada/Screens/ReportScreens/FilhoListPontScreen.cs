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

        // falta fazer tratamento adequado para mês e ano
        Console.WriteLine("mês");
        var mes = Tratamentos.EntradaInt();
        if (mes > 12 || mes < 1)
        {
            Console.WriteLine("Mês inexistente!");
            check = false;
        }
        var ano = Tratamentos.EntradaInt();

        if (check)
        {
            Relatorio(id, mes, ano);
        }
        else
            Console.WriteLine("ERRO !!!!, Id de Criança inexistente!");
        Console.ReadKey();
        MenuReportScreen.Load();
    }

    public static void Relatorio(int id, int mes, int ano)
    {
        var repository = new FilhoPontRepository();
        var kid = repository.GetWIdPontos(id, mes, ano);
        foreach (var k in kid)
        {
            Console.Clear();
            Console.WriteLine($"id:: {k.Id} - nome: {k.Nome} - Pai: {ListPaisScreen.consulta(k.IdPais).Nome}" 
            + $" - Pontos: {k.TotalPontos} - Saldo {k.SaldoDinheiro}");
            Console.WriteLine();
            Console.WriteLine(@"                        Pontuações 
            
            -----------------------
            
            ");
            Console.WriteLine($"{"Data",-12} {"Motivo",-40} {"Pontos",15}");
            int somaPontos = 0;
            foreach (var ponto in k.Pontuacoes)
            {
                
                Console.WriteLine(@$"{ponto.Data?.ToString("dd/MM/yyyy"),-12} " +
                $"{ListAcoesScreen.consulta(ponto.IdAcoes).Nome,-40} {ponto.Pontos,15}");
                somaPontos += ponto.Pontos;
            }

            Console.WriteLine();
            Console.WriteLine(@"                        Total Pontos e Dinheiro 
            
            -----------------------
            
            ");
            Console.WriteLine($"total de Pontos = {somaPontos}");
            double TotalMoney = somaPontos * 0.1;
            Console.WriteLine($"Total Dinheiro  R$  {TotalMoney.ToString("F2")}");
        }
    }
}