using Lab1;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerTree
{
    class Program
    {
        private static List<int> ArrayList;

        static void Main(string[] args)
        {

            Begginnig:
            Console.WriteLine("Por favor ingrese el grado del árbol multicamino");
            try
            {
                int order = Convert.ToInt32(Console.ReadLine());
                MultipathTree<int> MultiPathTree = new MultipathTree<int>(order);
                Console.WriteLine($"{Environment.NewLine}Se ha creado un árbol de grado {order}");
                bool HasMoreValues = true;
                do
                {
                    Insert:
                    Console.WriteLine($"{Environment.NewLine}Por favor ingrese un valor para insertar en el árbol");
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        MultiPathTree.AddValue(Convert.ToInt32(Console.ReadLine()));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Si desea insertar otro valor, presione 'Y'. De lo contrario, presione cualquier otra tecla. ");
                        if (Console.ReadKey().Key != ConsoleKey.Y)
                        {
                            HasMoreValues = false;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Por favor ingrese un valor válido");
                        Console.ReadLine();
                        goto Insert;
                    }

                } while (HasMoreValues);
                
                bool Pathings = true;
                do
                {
                    Order:
                    Console.Clear();
                    Console.WriteLine("Por favor ingrese el número correspondiente al tipo de recorrido que desea realizar en el árbol");
                    Console.WriteLine("1. PreOrder");
                    Console.WriteLine("2. InOrder");
                    Console.WriteLine("3. PostOrder");
                    try
                    {
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                ArrayList = MultiPathTree.GetPathing(0);

                                break;
                            case 2:
                                ArrayList = MultiPathTree.GetPathing(1);

                                break;
                            case 3:
                                ArrayList = MultiPathTree.GetPathing(2);

                                break;
                        }
                        if (ArrayList != null)
                        {
                            foreach (var item in ArrayList)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(item.ToString());
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Por favor ingrese un recorrido válido");
                        Console.ReadLine();
                        goto Order;
                        throw;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("¿Quisieras ordenarla de otra manera? | Presione 'Y'. De lo contrario, presione cualquier otra tecla.");
                    if (Console.ReadKey().Key != ConsoleKey.Y)
                    {
                        Pathings = false;
                    }
                }
                while (Pathings);
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
