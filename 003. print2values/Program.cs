using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003.print2values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int v1 = 100;
            double v2 = 1.234;

            //Console.WriteLine(v1, v2);
            Console.WriteLine("v1= " + v1 + ", v2= " + v2);
            Console.WriteLine("v1= {0:#.##}, v2= {1,#.##}", v1, v2); 
            Console.WriteLine($"v1= {v1}, v2= {v2}");
        }
    }
}

//D->십진수, N->숫자, F->소수 {0,10,D}->0번을 10자리로 십진수로 출력
// {0:#.##}-> 0번을 소수점 및 두자리까지 출력(반올림!!)
