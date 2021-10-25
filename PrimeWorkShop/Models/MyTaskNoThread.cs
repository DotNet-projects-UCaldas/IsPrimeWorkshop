using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeWorkShop.Models
{
    public class MyTaskNoThread
    {
        private long num { get; set; }
        private bool IsPrimeResult = false;


        public MyTaskNoThread(long NE)
        {
            num = NE;
        }

        public void IsPrime()
        {
            long countDiv = 2;
            long limit = (long)(Math.Sqrt(num)) / 2;

            if (num > 1)
            {
                if (num % 2 != 0)
                {
                    for (long k = 3; k <= Math.Floor((double)limit) && countDiv < 3; k += 2)
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

                IsPrimeResult = (countDiv == 2);
            }
        }

        public bool GetIsPrime()
        {
            return IsPrimeResult;
        }
    }
}
