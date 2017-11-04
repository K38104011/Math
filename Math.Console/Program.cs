namespace Math.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(Math.Gcf(13));
            System.Console.WriteLine(Math.Gcf(30, 15, 45));
            System.Console.WriteLine(Math.Gcf(13, 11, 19));
            System.Console.WriteLine(Math.Gcf(20, 60));
            System.Console.WriteLine(Math.EuclidGcf(13));
            System.Console.WriteLine(Math.EuclidGcf(30, 15, 45));
            System.Console.WriteLine(Math.EuclidGcf(13, 11, 19));
            System.Console.WriteLine(Math.EuclidGcf(20, 60));
            System.Console.ReadKey();
        }
    }
}
