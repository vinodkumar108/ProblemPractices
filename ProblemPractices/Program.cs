using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            int answer = 0;
            answer = 0;
            Console.WriteLine("Find Count Factor");
            int totalCount = FactorCount(67010446483);
            
            if(totalCount == 2)
            {
                answer = 1;
            }

            Console.WriteLine("Answer:"+Convert.ToString(totalCount));
            Console.Read();
        }

        public static int FactorCount(long A)
        {
            int answer = 0;

            for(int i=1;i*i<=A;i++)
            {
                if((A%i)==0)
                {
                    if(A/i == i)
                    {
                        answer++;
                    }
                    else
                    {
                        answer += 2;
                    }                    
                }
                if (answer > 2) break;
            }
            return answer;
        }
    }
}
