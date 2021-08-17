using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionPredicate_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action1 = Show;
            action1();

            Action<string> action2 = Disp;
            action2("madee");

            Predicate<int> predicate = IsEven;

            

            Func<int,int,int> func = Add;

            //using Anonymous method
            Func<int,int> GetCube = delegate (int n)
            {
                return n * n * n;
            };

            
            Console.WriteLine("IsEven : " + predicate(3));
            Console.WriteLine("Addition = " + func(11,10));
            Console.WriteLine("Cube = " + GetCube(3));
            Console.ReadLine();

        }


        static void Show()
        { Console.WriteLine("Hello"); }

        static void Disp(string str)
        {
            Console.WriteLine(str);
        }

        static int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        static bool IsEven(int num)
        {
            if(num%2==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
