using MyCollections;

namespace Laba5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> testList = new MyList<int>();
            for (int i = 0; i < 10; i++)
            {
                testList.Add(i * 2);
                Console.WriteLine($"Count: {testList.Length}, Capacity: {testList.Capacity}");
            }

            Console.WriteLine(testList[0]);
            Console.WriteLine(testList[6]);

            try
            {
                Console.WriteLine(testList[999]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            MyList<string> zeroList = new MyList<string>(0);
            zeroList.Add("Hello");

            try
            {
                zeroList = new MyList<string>(-1);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            MyList<double> emptyList = new MyList<double>(0);
            try
            {
                emptyList.RemoveAt(0);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                emptyList.Insert(0, 3.14);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                emptyList.Insert(emptyList.Length + 1, 2.71);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                emptyList.Insert(-1, 2.71);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                emptyList.RemoveAt(emptyList.Length-1);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                emptyList.RemoveAt(emptyList.Length);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
