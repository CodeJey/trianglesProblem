using System;

namespace trianglesProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Въведете страни на триъгълник.");

                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c = ");
                double c = double.Parse(Console.ReadLine());

                if (Existing(a, b, c))
                {
                    Console.WriteLine($"Има триъгълник с посочените от вас страни. {Environment.NewLine} Лицето му е {Area(a, b, c)}");
                }
                else Console.WriteLine("Триъгълник с такива старни не съществува. Опитакте пак.");
            }
            catch
            {
                Console.WriteLine("Въвели сте подвеждащи входни данни!");
            }
        }

        static bool Existing (double a, double b, double c)
        {
            bool exist = false;
            if (a + b >= c && a + c >= b && c + b >= a) exist = true;
            return exist;
        }

        static string Area (double a, double b, double c)
        {
            double areaCalc = 0;
            //Тук се проверяват трите случая при правоъгълен триъгълник и единият при равностранен
            if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2)) areaCalc = (a*b) / 2;
                else if (Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2)) areaCalc = (a*c) / 2;
                    else if(Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2)) areaCalc = (b*c) / 2;
                        else if(a == b && b == c) areaCalc = (Math.Sqrt(3)*Math.Pow(a, 2)) / 4;
            //За тук остават всички останали, които ще се смятат по херонова формула.
            else
            {
                //p stands for semi perimeter
                double p = (a+b+c) / 2;
                areaCalc = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }

            string area = Math.Round(areaCalc, 2).ToString("0.00");
            return area;

            /*При подаване на параметри като 8, 6, например, където сборът от две страни е равен на третата на практика 
            триъгълник съществува, просто лицето му е 0, защото лежи в една права, някои математици смятат, че тогава не съществува, защото 
            дъгите на по-късите страни се пресичат в точка от най-дългата, но абстрактно погледнато го има.*/
        }
    }
}
