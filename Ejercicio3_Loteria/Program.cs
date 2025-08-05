using System;

namespace Ejercicio3_loteria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Número apostado (4 cifras): ");
            int numeroApostado = int.Parse(Console.ReadLine());

            Console.Write("Número ganador (4 cifras): ");
            int numeroGanador = int.Parse(Console.ReadLine());

            Console.Write("Monto apostado: ");
            int monto = int.Parse(Console.ReadLine());

            int premio = CalcularPremio(numeroApostado, numeroGanador, monto);
            Console.WriteLine(premio > 0 ? $"¡Ganaste ${premio}!" : "No ganaste.");
        }

        static int CalcularPremio(int apostado, int ganador, int monto)
        {
            string a = apostado.ToString("D4");
            string g = ganador.ToString("D4");

            if (a == g)
                return monto * 4500;

            if (SonDigitosIgualesDesordenados(a, g))
                return monto * 200;

            if (a.Substring(1) == g.Substring(1))
                return monto * 400;

            if (a.Substring(2) == g.Substring(2))
                return monto * 50;

            if (a[3] == g[3])
                return monto * 5;

            return 0;
        }

        static bool SonDigitosIgualesDesordenados(string a, string g)
        {
            int[] digitos = new int[10];

            foreach (char c in a)
                digitos[c - '0']++;

            foreach (char c in g)
                digitos[c - '0']--;

            foreach (int n in digitos)
                if (n != 0) return false;

            return true;
        }
    }
}
