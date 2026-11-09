using System;
using System.Text;

namespace Problema_1_Parcial_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("PROBLEMA 1 - FIGURAS GEOMÉTRICAS");
            Console.WriteLine();

            
            Figura[] figuras = new Figura[]
            {
                new Rectangulo(8, 5),
                new Cuadrado(4),
                new Triangulo(3, 4, 4, 5)
            };

           
            foreach (Figura figura in figuras)
            {
                Console.WriteLine($"Figura: {figura.GetType().Name}");
                Console.WriteLine($"Área: {figura.CalcularArea():0.##} unidades cuadradas");
                Console.WriteLine($"Perímetro: {figura.CalcularPerimetro():0.##} unidades");
                Console.WriteLine();
            }
        }
    }
}
