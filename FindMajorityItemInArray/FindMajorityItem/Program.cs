// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

Test.Start();
Stopwatch stopwatch = new Stopwatch();
List<long> timeElapsedM1 = new List<long>();
List<long> timeElapsedM2 = new List<long>();
//for (int i = 0; i < 10; i++)
//{
//    stopwatch.Restart();
//    Test.Calc();
//    stopwatch.Stop();
//    Console.WriteLine($"Time elapsed for Method1[{i}]: {stopwatch.ElapsedMilliseconds}");
//    timeElapsedM1.Add(stopwatch.ElapsedMilliseconds);

//    stopwatch.Restart();
//    Test.Calc2();
//    stopwatch.Stop();
//    Console.WriteLine($"Time elapsed For Method2[{i}]: {stopwatch.ElapsedMilliseconds}");
//    timeElapsedM2.Add(stopwatch.ElapsedMilliseconds);

//    Console.WriteLine("#");
//}
//Console.WriteLine($"average time elapsed for Metod1 is {timeElapsedM1.Sum() / timeElapsedM1.Count}");
//Console.WriteLine($"average time elapsed for Metod2 is {timeElapsedM2.Sum() / timeElapsedM2.Count}");
stopwatch.Restart();
Test.Calc();
stopwatch.Stop();
Console.WriteLine($"Time elapsed for Method1: {stopwatch.ElapsedMilliseconds}");
timeElapsedM1.Add(stopwatch.ElapsedMilliseconds);

stopwatch.Restart();
Test.Calc2();
stopwatch.Stop();
Console.WriteLine($"Time elapsed For Method2: {stopwatch.ElapsedMilliseconds}");
timeElapsedM2.Add(stopwatch.ElapsedMilliseconds);
Console.ReadKey();

public static class Test
{
    static List<int> arr = new List<int>();
    static Test()
    {
        int randCount = 100000;
        Random r = new Random();

        //for (int i = 0; i < randCount/2; i++)
        //{
        //    arr.Add(r.Next(1, 11));
        //    arr.Add(r.Next(10, 10));
        //}
        for (int i = 0; i < randCount; i++)
        {
            arr.Add(r.Next(1, 11));
        }
    }

    public static void Start()
    {
        Console.WriteLine("Start: Please wait for both methods completion");
    }

    public static void Calc()
    {
        HashSet<int> set = new HashSet<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            set.Add(arr[i]);
        };
        int count = 0;
        int maxCount = 0;
        int maxNumber = 0;
        for (int i = 0; i < set.Count; i++)
        {
            for (int j = 0; j < arr.Count; j++)
            {
                if (arr[i] == arr[j]) count++;
            }

            if (count > maxCount)
            {
                maxCount = count;
                maxNumber = arr[i];
            }
            count = 0;
            if (maxCount >= (arr.Count / 2) + 1)
                break;
        }
        if (maxCount >= (arr.Count / 2) + 1)
            Console.WriteLine($"Majority number is {maxNumber} and count is {maxCount}");
        else
            Console.WriteLine($"There was not any majority in array.The most iterated number is {maxNumber} and count is {maxCount} and array lenght is {arr.Count}");
    }

    public static void Calc2()
    {
        int count = 0;
        int maxCount = 0;
        int maxNumber = 0;
        int starCount = 100;
        int starIx = arr.Count / starCount;
        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = i; j < arr.Count; j++)
            {
                if (arr[i] == arr[j]) count++;
            }

            if (count > maxCount)
            {
                maxCount = count;
                maxNumber = arr[i];
            }
            count = 0;
            if (maxCount >= (arr.Count / 2) + 1)
                break;

            if (i % starIx == 0)
                Console.Write("#");
        }
        Console.WriteLine();
        if (maxCount >= (arr.Count / 2) + 1)
            Console.WriteLine($"Majority number is {maxNumber} and count is {maxCount}");
        else
            Console.WriteLine($"There was not any majority in array.The most iterated number is {maxNumber} and count is {maxCount} and array lenght is {arr.Count}");
    }
}

