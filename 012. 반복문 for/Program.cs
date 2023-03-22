using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _012.반복문_for
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. 1~100까지 더하기
            int sum = 0;
            

            for (int i=1; i<=100; i++)
            {
                sum = sum + i;
            }
            Console.WriteLine("1~100까지의 합: "+ sum);
            Console.WriteLine("1~100까지의 합: {0}" , sum);


            //2. 1~100까지 홀수의 합
            sum = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 1)
                {
                    sum = sum + i;
                }
            }
            Console.WriteLine("1~100까지 홀수의 합: " + sum);
            Console.WriteLine("1~100까지 홀수의 합: {0}" , sum);


            //3. 1~100까지 역수의 합
            double rsum = 0;
            for (int i = 1; i <= 100; i++)
            {
                rsum = rsum + (1.0 / i);
            }
            Console.WriteLine("1~100까지 역수의 합: " + rsum);
            Console.WriteLine("1~100까지 역수의 합: {0}" , rsum);

            //구구단
            Console.Write("구구단의 단을 입력: ");
            int n= int.Parse(Console.ReadLine());

            for(int i=1; i<=9; i++)
            {
                int num = n * i;
                Console.WriteLine($"{n} * {i} = {num}");
            }

            //x의 y승 = x를 y번 곱한다.

            Console.WriteLine("x값 입력: ");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine("y값 입력: ");
            int y = int.Parse(Console.ReadLine());
            int exp = 1;


            for (int i=1; i<=y; i++)
            {
                exp = exp * x;
            }
            Console.WriteLine("{0}의 {1}승={2}", x,y,exp);

            //팩토리얼(3/22)
            //n!= 1*2*...*n
            Console.WriteLine("n! 계산, n을 입력: ");
            n = int.Parse(Console.ReadLine());

            int fact = 1;

            for (int i = 1; i < n; i++)
            {
                fact = fact * i;
            }
            Console.WriteLine("{0}! = {1}", n, fact);
        }
    }
}
