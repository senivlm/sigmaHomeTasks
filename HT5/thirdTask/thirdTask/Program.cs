using System;

namespace thirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FileElementsFinder.GetRootNameWithSplit(@"F:\my_study\sigma\p5\thirdTask\thirdTask\bin\Debug\netcoreapp3.1\thirdTask.exe"));
            Console.WriteLine(FileElementsFinder.GetRootName(@"F:\my_study\sigma\p5\thirdTask\thirdTask\bin\Debug\netcoreapp3.1\thirdTask.exe"));
            Console.WriteLine(FileElementsFinder.GetFileName(@"F:\my_study\sigma\p5\thirdTask\thirdTask\bin\Debug\netcoreapp3.1\thirdTask.exe"));
            Console.WriteLine(FileElementsFinder.GetFileNameWithSplit(@"F:\my_study\sigma\p5\thirdTask\thirdTask\bin\Debug\netcoreapp3.1\thirdTask.exe"));


        }
    }
}
