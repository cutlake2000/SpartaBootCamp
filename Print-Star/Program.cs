using System;

namespace PrintStar
{
    class Program
    {
        static void Main(string[] args)
        {
            // 오른쪽으로 기울어진 직각삼각형 출력하기
            //    1    |    2   |   3   |   4   |   5     <= i
            //    1    |  1 ~ 2 | 1 ~ 3 | 1 ~ 4 | 1 ~ 5   <= j

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            // 역직각삼각형 출력하기
            //    5    |    4   |   3   |   2   |   1   <= i
            //  1 ~ 5  |  1 ~ 4 | 1 ~ 3 | 1 ~ 2 |   1   <= j

            for (int i = 5; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            // 피라미드 출력하기
            //    4    |    3   |   2   |   1   |   0  <= i
            //    4    |    3   |   2   |   1   |   0  <= j
            //    1    |    3   |   5   |   7   |   9  <= k

            for (int i = 4; 0 <= i; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(" ");
                }

                for (int k = 1; k <= (9 - 2 * i); k++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Console.Write("\n");

            // Simple is Best
            Console.WriteLine("*");
            Console.WriteLine("**");
            Console.WriteLine("***");
            Console.WriteLine("****");
            Console.WriteLine("*****\n");

            Console.WriteLine("*****");
            Console.WriteLine("****");
            Console.WriteLine("***");
            Console.WriteLine("**");
            Console.WriteLine("*\n");

            Console.WriteLine("    *");
            Console.WriteLine("   ***");
            Console.WriteLine("  *****");
            Console.WriteLine(" *******");
            Console.WriteLine("*********\n");
        }
    }
}
