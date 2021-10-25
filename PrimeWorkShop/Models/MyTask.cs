using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeWorkShop.Models
{
    public class MyTask
    {
        private static long NumberToEvaluate { get; set; }
        private static bool IsComposite = false;


        public MyTask(long NE)
        {
            NumberToEvaluate = NE;
        }

        public static void IsPrimeGoingUp(long num)
        {
            long limit = (long)(Math.Sqrt(num)) / 2;
            Debug.WriteLine("Limit: " + limit);

            if (num % 2 == 0) IsComposite = true;
            else
            {
                for (long k = 2; k <= limit; k += 2)
                {
                    if (num % k == 0)
                    {
                        IsComposite = true;
                    }
                    if (IsComposite) return;
                }
            }
        }

        public static void IsPrimeGoingDown(long num)
        {
            long limit = (long)(Math.Sqrt(num));
            long end = limit / 2;
            Debug.WriteLine("Limit: " + limit + " end: " + end);
 
            if(num % 2 == 0) IsComposite = true;
            else
            {
                for (long k = limit; k > end; k -= 2)
                {
                    if (num % k == 0)
                    {
                        IsComposite = true;
                    }
                    if (IsComposite) return;
                }
            }
        }

        public void Start()
        {
            Thread[] theThreads = new Thread[3];

            theThreads[0] = new Thread(() => IsPrimeGoingUp(NumberToEvaluate));
            theThreads[0].Name = "Thread N° 1 First Loop";
            theThreads[0].Start();

            theThreads[1] = new Thread(() => IsPrimeGoingDown(NumberToEvaluate));
            theThreads[1].Name = "Thread N° 2 Second Loop";
            theThreads[1].Start();

        }

        public bool IsPrime()
        {
            return IsComposite;
        }

    }
}
