namespace ConsoleArrayListPerformance
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Text;

    public class Program
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static void Main(string[] args)
        {
            int capacity = 20;
            ArrayList arrayList = new ArrayList(capacity);

            for (int c = 0; c < arrayList.Capacity; c++)
            {
                arrayList.Add(RandomString(c));
            }

            arrayList.Sort();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long sum = 0;

            for (int i = 0; i < 100000; ++i)
            {
                for (int c = 0; c < capacity; c++)
                {
                    if (arrayList.Contains('a'))
                    {
                        sum++;
                    }
                }
            }

            stopWatch.Stop();

            if (!stopWatch.IsRunning)
            {
                Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds.ToString());
                Console.WriteLine("sum = " + sum);
            }
        }

        private static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}