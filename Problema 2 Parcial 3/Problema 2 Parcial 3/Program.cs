using System;
using Newtonsoft.Json;

namespace Problema_2_Parcial_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var persona = new
            {
                Nombre = "Cristell",
                Edad = 20,
                Carrera = "Ingenieria en Sistemas"
            };

            
            string json = JsonConvert.SerializeObject(persona);

            
            Console.WriteLine(json);
        }
    }
}