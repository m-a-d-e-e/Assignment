using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FindMinMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 11, 21, 3, 13, 10, 35, 6 };
            int m1, m2;                                      //uninitialized variables
            MinMaxClass.Find_UsingOut(num, out m1, out m2);
            Console.WriteLine($"Min : {m1}, Max : {m2}");


            int x=0, y=0;                                  //initialized variables
            MinMaxClass.Find_UsingRef(num, ref x, ref y);
            Console.WriteLine($"Min : {x}, Max : {y}");


            ArrayStruct aStruct = MinMaxClass.Find_UsingStruct(num);
            Console.WriteLine($"Min : {aStruct.MinS}, Max : {aStruct.MaxS}");


            (int a, int b) = MinMaxClass.Find_UsingTuple(num);
            Console.WriteLine($"Min : {a}, Max : {b}");


            int[] arrayMinMax = MinMaxClass.Find_UsingArray(num);
            Console.WriteLine($"Min : {arrayMinMax[0]}, Max : {arrayMinMax[1]}");

            Console.ReadLine();
        }
    }
}
