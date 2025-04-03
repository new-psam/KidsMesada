namespace KMesada;

public class Tratamentos
{
    public static int EntradaInt()
    {
        int valor;
        bool ehnumero;
        do{
            Console.WriteLine("Digite um numero inteiro: ");
            var entrada = Console.ReadLine();
            ehnumero = int.TryParse(entrada, out valor);

        } while (!ehnumero);

        return valor;
    }

    public static bool pergunta(string pergunta, string respostaAtiva)
    {
        var aswer = false;
        Console.WriteLine(pergunta);
        var resposta = Console.ReadLine();
        if (resposta!.Equals(respostaAtiva, StringComparison.OrdinalIgnoreCase))
            aswer = true;
        return aswer;
    }

    public static string DataPresPast()
    {
        var check = false;
        string data;
        do
        {
            check = false;
            Console.WriteLine("Data do comportamento: mm/dd/yyyy: ");
            data = Console.ReadLine()!;
            if (data == "")
                return DateTime.Today.ToString("MM-dd-yyyy");

            DateTime checkFututro = DateTime.Parse(data);
            if (checkFututro > DateTime.Now)
            {
                Console.WriteLine("Erro essa data está no futuro! informe uma data no presente ou no passado");
                check = true;
            }
        }while (check);

        return data;
            
    }

   
}