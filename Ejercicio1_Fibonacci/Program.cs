using System;

namespace Ejercicio1_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un número para calcular la secuencia de Fibonacci hasta ese valor:");
            int n = int.Parse(Console.ReadLine());

            int[] valores = FibonacciHasta(n);

            Console.WriteLine("Secuencia de Fibonacci:");
            for (int i = 0; i < valores.Length; i++)
            {
                Console.Write(valores[i] + " ");
            }

            int[] primos = NumerosPrimosEnFibonacci(valores);

            Console.WriteLine("\nNúmeros primos dentro de la secuencia:");
            for (int i = 0; i < primos.Length; i++)
            {
                Console.Write(primos[i] + " ");
            }
        }

        static int[] FibonacciHasta(int n)
        {
            int[] temp = new int[100];
            int a = 0, b = 1, count = 0;

            while (a <= n)
            {
                temp[count] = a;
                int siguiente = a + b;
                a = b;
                b = siguiente;
                count++;
            }

            int[] resultado = new int[count];
            Array.Copy(temp, resultado, count);
            return resultado;
        }

        static int[] NumerosPrimosEnFibonacci(int[] fibonacci)
        {
            int[] temp = new int[fibonacci.Length];
            int count = 0;

            for (int i = 0; i < fibonacci.Length; i++)
            {
                if (EsPrimo(fibonacci[i]))
                {
                    temp[count] = fibonacci[i];
                    count++;
                }
            }

            int[] resultado = new int[count];
            Array.Copy(temp, resultado, count);
            return resultado;
        }

        static bool EsPrimo(int numero)
        {
            if (numero < 2) return false;
            for (int i = 2; i * i <= numero; i++)
            {
                if (numero % i == 0) return false;
            }
            return true;
        }
    }
}

