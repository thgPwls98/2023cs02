using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _001.BMI_계산기
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double weight, height;

            Console.Write("키(cm): ");
            height = double.Parse(Console.ReadLine());

            Console.Write("몸무게(kg): ");
            weight = double.Parse(Console.ReadLine());


            double bmi = weight / (height / 100 * height / 100);
            string a;
            if (bmi < 20){
                a = "저체중";
            } else if(bmi>=20&& bmi < 25)
            {
                a = "정상체중";
            } else if(bmi >= 25 && bmi < 30)
            {
                a = "경도비만";
            } else if(bmi >= 30 && bmi < 40)
            {
                a = "비만";
            }
            else
            {
                a = "고도비만";
            }
            Console.WriteLine("BMI= " + bmi);
            Console.WriteLine($"당신은 {a} 입니다!");

        }
    }
}
