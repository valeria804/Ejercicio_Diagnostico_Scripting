namespace Ejercicio2__formatoHHMMSS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una cantidad de segundos:");
            int segundos = int.Parse(Console.ReadLine());

            string tiempoFormateado = ConvertirASegundos(segundos);
            Console.WriteLine("Formato HH:MM:SS = " + tiempoFormateado);
        }

        static string ConvertirASegundos(int totalSegundos)
        {
            int horas = totalSegundos / 3600;
            int minutos = (totalSegundos % 3600) / 60;
            int segundos = totalSegundos % 60;

            return $"{horas:D2}:{minutos:D2}:{segundos:D2}";
        }
    }
}
