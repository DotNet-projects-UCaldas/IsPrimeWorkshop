using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeWorkShop.Models
{
    public class MyTask
    {
        public int NumberOfThreads { get; set; }
        public long NumberToEvaluate { get; set; }
        public static List<string> PrimeMessages = new List<string>();

        public MyTask(int NT, long NE)
        {
            NumberOfThreads = NT;
            NumberToEvaluate = NE;
        }
        public static void IsPrime(long num)
        {
            bool isPrime = false;
            long countDiv = 2;
            long limit = (long)(Math.Sqrt(num));

            if (num > 1)
            {
                if (num % 2 != 0)
                {
                    for (long k = 3; k <= limit && countDiv < 3; k += 2)
                    {
                        if (num % k == 0)
                        {
                            countDiv++;
                        }
                    }
                }
                else if (num != 2)
                {
                    countDiv = 3;
                }

                isPrime = (countDiv == 2);
            }
            string message = "The number -" + num + "-" + "it\'s "; 
            message += isPrime ? "Prime" : "Not Prime";

            lock (PrimeMessages)
            {
                PrimeMessages.Add(message);
            }

        }

        public void ExecuteThreads()
        {
            Thread[] theThreads = new Thread[NumberOfThreads];

            for (int i = 0; i < NumberOfThreads; i++)
            {
                theThreads[i] = new Thread(() => IsPrime(NumberToEvaluate));
                theThreads[i].Name = "Thread " + i;
            }

            foreach (var thread in theThreads)
            {
                thread.Start();
                thread.Join();
            }
        }

        public string GetMessages(int position)
        {
            string message = "";

            if(PrimeMessages.Count > 0)
            {
                message = PrimeMessages[position];
            }
            return message;
        }
    }
}
