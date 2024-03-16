using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrixTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 4;
            List<List<int>> result = generateMatrix(input);
            Console.Read();
        }
        public static List<List<int>> generateMatrix(int A)
        {

            List<List<int>> lstResult = new List<List<int>>();

            for (int m = 0; m < A; m++)
            {
                List<int> lstItems = new List<int>();
                for (int n = 0; n < A; n++)
                {
                    lstItems.Add(0);
                }

                lstResult.Add(lstItems);
            }

            int setArrayItem = 1;
            int spiralNum = A-1;
            int spiralIteration = 0;

           

            if (A == 1)
            {
                lstResult[0][0] = 1;
            }

            while (spiralNum > 0)
            {
                int spiralItemCount = spiralNum;

                //Left to Right Set Item
                int i = spiralIteration;
                while (spiralItemCount > 0)
                {
                    lstResult[spiralIteration][i] = setArrayItem;
                    setArrayItem++;
                    i++;
                    spiralItemCount--;
                }


                //Top to Bottom set item
                spiralItemCount = spiralNum;
                int j = spiralIteration;
                while (spiralItemCount > 0)
                {
                    lstResult[j][spiralIteration+ spiralNum] = setArrayItem;
                    setArrayItem++;
                    j++;
                    spiralItemCount--;
                }


                //Right to Left set item
                spiralItemCount = spiralNum;
                int k = spiralIteration+ spiralNum;
                while (spiralItemCount > 0)
                {
                    lstResult[spiralIteration + spiralNum][k] = setArrayItem;
                    setArrayItem++;
                    k--;
                    spiralItemCount--;
                }

                //Bottom to top set item
                spiralItemCount = spiralNum;
                int l = spiralIteration + spiralNum;
                while (spiralItemCount > 0)
                {
                    lstResult[l][spiralIteration] = setArrayItem;
                    setArrayItem++;
                    l--;
                    spiralItemCount--;
                }               

                spiralNum-=2;
                spiralIteration++;
            }

            if (A % 2 == 1)
            {
                lstResult[A / 2][A / 2] = setArrayItem;
            }

            

            return lstResult;



        }
    }
}
