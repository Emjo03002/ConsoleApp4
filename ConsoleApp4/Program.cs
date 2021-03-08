using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        
            static void BubbleSort(List<int> minlista)
            {

                for (int i = 0; i < minlista.Count; i++)
                {
                    for (int j = 0; j < minlista.Count - 1 - i; j++)
                    {
                        if (minlista[j] > minlista[j + 1])
                        {
                            int temp = minlista[j];
                            minlista[j] = minlista[j + 1];
                            minlista[j + 1] = temp;
                        }

                    }
                }
            }

            static void SelectionSort(List<int> minlista)
            {
                for (int i = 0; i < minlista.Count - 1; i++)
                {
                    int smallest = i;
                    for (int j = i + 1; j < minlista.Count; j++)
                    {
                        if (minlista[j] < minlista[smallest])
                            smallest = j;
                    }
                    int temp = minlista[smallest];
                    minlista[smallest] = minlista[i];
                    minlista[i] = temp;

                }
            }
        private static List<int> MergeSort(List<int> lista)
        {
            if (lista.Count <= 1)
                return lista;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = lista.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(lista[i]);
            }
            for (int i = middle; i < lista.Count; i++)
            {
                right.Add(lista[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }

        static List<int> QuickSort(List<int> lista)
        {
            if (lista.Count <= 1)
                return lista;
            int pivotIndex = lista.Count / 2;
            int pivot = lista[pivotIndex];
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < lista.Count; i++)
            {
                if (i == pivotIndex) continue;

                if (lista[i] <= pivot)
                {
                    left.Add(lista[i]);
                }
                else
                {
                    right.Add(lista[i]);
                }
            }

            List<int> sorted = QuickSort(left);
            sorted.Add(pivot);
            sorted.AddRange(QuickSort(right));
            return sorted;
        }

        static void Main(string[] args)
        {
                var tallista = new List<int>();
                var nummerlista = new List<int>();
                var sifferlista = new List<int>();
                var antalslista = new List<int>();
                Random slump = new Random();

                int antal = 0;
                Console.Write("Antal tal att sotera: ");
                antal = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < antal; i++)
                {
                    tallista.Add(slump.Next(10000));
                    nummerlista.Add(slump.Next(10000));
                    sifferlista.Add(slump.Next(10000));
                    antalslista.Add(slump.Next(10000));
                }

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                BubbleSort(tallista);
                stopWatch.Stop();
                TimeSpan timespan = stopWatch.Elapsed;
                Console.Write("Bubblesort ");
                Console.WriteLine("Tid: {0}m {1}s {2}ms", timespan.Minutes, timespan.Seconds, timespan.Milliseconds);
                stopWatch.Reset();

                stopWatch.Start();
                SelectionSort(nummerlista);
                stopWatch.Stop();
                TimeSpan timespan2 = stopWatch.Elapsed;
                Console.Write("SelectionSort ");
                Console.WriteLine("Tid: {0}m {1}s {2}ms", timespan2.Minutes, timespan2.Seconds, timespan2.Milliseconds);
                stopWatch.Reset();

                stopWatch.Start();
                MergeSort(sifferlista);
                stopWatch.Stop();
                TimeSpan timespan3 = stopWatch.Elapsed;
                Console.Write("MergeSort ");
                Console.WriteLine("Tid: {0}m {1}s {2}ms", timespan3.Minutes, timespan3.Seconds, timespan3.Milliseconds);
                stopWatch.Reset();

                stopWatch.Start();
                QuickSort(antalslista);
                stopWatch.Stop();
                TimeSpan timespan4 = stopWatch.Elapsed;
                Console.Write("QuickSort ");
                Console.WriteLine("Tid: {0}m {1}s {2}ms", timespan4.Minutes, timespan4.Seconds, timespan4.Milliseconds);
                stopWatch.Reset();
   



        }
        
    }
}
