using System;
using System.Text;

namespace ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int[] hedgehogsPopulation = new int[3];
            Console.WriteLine("0 - червоний\t1 - зелений\t2 - синій");
            Console.Write("Виберіть колір -> ");
            int targetColor = Convert.ToInt32(Console.ReadLine());

            while (targetColor < 0 || targetColor > 2)
            {
                Console.WriteLine("\nПотрібно ввести ціле число на вибір від 0 до 2");
                Console.WriteLine("0 - червоний\t1 - зелений\t2 - синій");
                Console.Write("Виберіть колір -> ");
                targetColor = Convert.ToInt32(Console.ReadLine());
            }

            Random random = new Random();
            for(int j = 0; j<100;j++)
            {
                arrayFilling(hedgehogsPopulation, random);

                Console.WriteLine("\nРезультат -> "+MakhinationWithColor(hedgehogsPopulation, targetColor));
            }
        }
        static void arrayFilling(int[] arr,Random random)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(0, int.MaxValue/3);
            }

            if (arr.Sum() < 1)
                arrayFilling(arr, random);
        }
        static int MakhinationWithColor(int[] arr,int targetColor)
        {
            int count = 0;

            if (arr[(targetColor + 1) % 3] == 0 && arr[(targetColor + 2) % 3] == 0)
                return 0;

            if (arr[targetColor] == 0 && (arr[(targetColor + 2) % 3] == 0 || arr[(targetColor + 1) % 3] == 0))
                return -1;

            int maxIndex = 0;
            int minIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > arr[maxIndex] && targetColor != i)
                    maxIndex = i;
                if (arr[i] < arr[minIndex] && targetColor != i)
                    minIndex = i;
            }
        
            if (arr[maxIndex] == arr[minIndex])
            {
                return arr[maxIndex];
            }
            else if((arr[maxIndex] - arr[minIndex]) % 3 == 0)
            {
                while(arr[maxIndex] != arr[minIndex])
                {
                    if (arr[targetColor] == 0)
                    {
                        arr[maxIndex] -= 1;
                        arr[minIndex] -= 1;
                        arr[targetColor] += 2;
                        count++;
                    }

                    arr[maxIndex] -= 1;
                    arr[targetColor] -= 1;
                    arr[minIndex] += 2;
                    count++;
                }
                return count + arr[maxIndex];
            }
            else
            {
                return -1;
            }
        }

        /* 
         * 
         * Зробив цикл на 100 ітерацій для того щоб показати одразу розвязки при великій різноманітності вхідних данних
         * Мій алгоритм рішення цієї задачі полягає у тому щоб зрівняти кількість їжачків обох кольорів які будем перефарбовувати в потрібний нам колір, але знайшов закономірність, що задача має відповідь тільки при однакових значеннях 2 невибраних кольорів або коли їхня різниця при ділені на 3 видає остачу 0
         * 
         */
    }
}