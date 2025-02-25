using Microsoft.Data.SqlClient;


namespace KMesada;

class Program
{
    static void Main(string[] args)
    {
       const string connectionString = @"Server=localhost, 1433; Database=Kidsmesada; User Id=sa; Password=1q2w3e4r@#$;
       Encrypt=True;TrustServerCertificate=True;";


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
       }
       //connection.Open();


       //connection.Close();

       Console.WriteLine("Hello, World!");
    }
}
