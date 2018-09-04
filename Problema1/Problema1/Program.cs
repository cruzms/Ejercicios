using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1
{
    class Program
    {
        static void Main(string[] args)
        {
            string archivo = System.IO.File.ReadAllText(@"C:\Users\santi\Desktop\Entrada.txt");
            var palabras= archivo.Split('\n').ToList();

            Console.WriteLine("0. No desea ordenar \n 1. Orden alfabetico ascendente \n 2. Orden alfabetico descendente \n");
            var seleccion = Console.ReadLine();
           if(seleccion != "0")
            {
                palabras.Sort();
            }
                


            
            Console.WriteLine("Desea filtrar la lista \n 1 si \n 2 no");
            var filtrar = Console.ReadLine();
            if(filtrar == "1")
            {
                Console.WriteLine("Ingrese el filtro");
                var caracteres = Console.ReadLine();
                palabras=palabras.Where(p => p.ToLower().Contains(caracteres.ToLower())).ToList();
                
            }
            if (palabras.Count == 0)
            {
                Console.WriteLine("No existen coincidencia de busqueda");
            }
            else
            {
                if (seleccion == "1")
                {

                    foreach (var item in palabras)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    palabras.Reverse();
                    foreach (var item in palabras)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            Console.ReadKey();
            
        }
    }
}
