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

   
}