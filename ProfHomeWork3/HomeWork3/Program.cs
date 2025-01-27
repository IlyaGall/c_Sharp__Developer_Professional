﻿using System.Diagnostics;

namespace HomeWork3
{
    internal class Program
    {
        static void Main(string[] args)
        {

          
            List<int[]> ints = new List<int[]>() 
            {
                CreateArrayInt(100_000),
                CreateArrayInt(1_000_000),
                CreateArrayInt(10_000_000)
            };


            foreach (var arrayItem in ints)
            {

                // Sequential Sum
                Stopwatch sw = Stopwatch.StartNew();
                long sequentialSum = SequentialSum(arrayItem);
                sw.Stop();
                long sequentialTime = sw.ElapsedMilliseconds;

                // Parallel Sum
                sw.Restart();
                long parallelSum = ParallelSum(arrayItem);
                sw.Stop();
                long parallelTime = sw.ElapsedMilliseconds;

                // LINQ Sum
                sw.Restart();
                long linqSum = arrayItem.AsParallel().Sum();
                sw.Stop();
                long linqTime = sw.ElapsedMilliseconds;

                Console.WriteLine($"{arrayItem.Count()}, Без потоков: {sequentialTime}, thread: {parallelTime}, linq: {linqTime}");
            }



            /*
            Описание/Пошаговая инструкция выполнения домашнего задания:
            Напишите вычисление суммы элементов массива интов:
            Обычное
            Параллельное (для реализации использовать Thread, например List)
            Параллельное с помощью LINQ
            Замерьте время выполнения для 100 000, 1 000 000 и 10 000 000

            Укажите в таблице результаты замеров, указав:

            Окружение (характеристики компьютера и ОС)
            Время выполнения последовательного вычисления
            Время выполнения параллельного вычисления
            Время выполнения LINQ
            Пришлите в чат с преподавателем помимо ссылки на репозиторий номера своих строк в таблице.
             */
        }

        static int[] CreateArrayInt(int countElement) 
        {
            int[] array = new int[countElement];
            for (int i = 0; i < countElement; i++)
            {
                array[i] = 1;
            }
            return array;
        }
        static long SequentialSum(int[] array)
        {
            long sum = 0;
            foreach (var num in array)
            {
                sum += num;
            }
            return sum;
        }

        static long ParallelSum(int[] array)
        {
            long sum = 0;
            int partitionSize = array.Length / Environment.ProcessorCount;
            Task[] tasks = new Task[Environment.ProcessorCount];
            long[] partialSums = new long[tasks.Length];

            for (int i = 0; i < tasks.Length; i++)
            {
                int start = i * partitionSize;
                int end = (i == tasks.Length - 1) ? array.Length : start + partitionSize;
                tasks[i] = Task.Run(() =>
                {
                    long localSum = 0;
                    for (int j = start; j < end; j++)
                    {
                        localSum += array[j];
                    }
                    partialSums[i-1] = localSum;
                });
            }

            Task.WaitAll(tasks);
            foreach (var partialSum in partialSums)
            {
                sum += partialSum;
            }

            return sum;
        }

    }
}
