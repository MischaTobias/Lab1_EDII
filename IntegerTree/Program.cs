using Lab1;
using System;
using System.Collections;

namespace IntegerTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Begginnig:
            Console.WriteLine("Por favor ingrese el grado del árbol multicamino");
            try
            {
                int order = Convert.ToInt32(Console.ReadLine());
                MultipathTree<int> multipathTree = new MultipathTree<int>(order);
                Console.WriteLine($"{Environment.NewLine}Se ha creado un árbol de grado {order}");
                bool hasMoreValues = true;
                do
                {
                    Insert:
                    Console.WriteLine($"{Environment.NewLine}Por favor ingrese un valor para insertar en el árbol");
                    try
                    {
                        multipathTree.AddValue(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Si desea insertar otro valor, presione 'Y'. De lo contrario, presione cualquier otra tecla. ");
                        if (Console.ReadKey().Key != ConsoleKey.Y)
                        {
                            hasMoreValues = false;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Por favor ingrese un valor válido");
                        Console.ReadLine();
                        goto Insert;
                    }

                } while (hasMoreValues);
            }
            catch
            {
                Console.WriteLine("Por favor ingrese un grado válido.");
                Console.ReadLine();
                Console.Clear();
                goto Begginnig;
            }
        }
    }
}
