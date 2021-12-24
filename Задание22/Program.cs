using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание22
{
    class Program
    {
        /*   
             Сформировать массив случайных целых чисел (размер  задается пользователем). 
            Вычислить сумму чисел массива и максимальное число в массиве.  Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.

              */

        static void Main(string[] args)
        {

            Console.Write(" Введите колличество чисел в одномерном массиве:  ");

            int n = Convert.ToInt32(Console.ReadLine());

            Task<object> task1 = new Task<object>(() =>
            {
                
                Random rand = new Random();
                int[] arr = new int[n];
                for (int k = 0; k < n; k++)
                {
                    arr[k] = rand.Next(0, 10);
                    Console.Write(arr[k] + " ");
                }

                return arr;
            });


               // задача продолжения
            Task task2 = task1.ContinueWith((Task<object> t) =>
            {
                 
                var arr = (int[])t.Result;
                int S = 0;
                for (int k = 0; k < n; k++)

                {
                    // сумма чисел в массиве 
                    S += arr[k];
                }
                Console.WriteLine();
                Console.WriteLine($"Сумма чисел в массиве: {S}");
            });

            Task task3 = task1.ContinueWith((Task<object> t) =>
            {
                var arr = (int[])t.Result;
                int max = int.MinValue;

                for (int k = 0; k < n; k++)

                {
                    if (arr[k] > max)
                    {
                        //  максимально число в массиве 
                        max = arr[k];
                    }
                }
                Console.WriteLine($"Максимальное значение в массиве: {max}");
            });



            task1.Start();





            Console.ReadKey();
        }


    }

}
