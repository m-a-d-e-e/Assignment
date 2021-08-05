using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMinMax
{
    public struct ArrayStruct
    {
        private int minS, maxS;

        public int MinS
        {
            get { return minS; }
            set { minS = value; }
        }
        public int MaxS
        {
            get { return maxS; }
            set { maxS = value; }
        }

    }

    public static class MinMaxClass
    {

        public static void Find_UsingOut(int[] arr, out int min, out int max)
        {
            min = max = arr[0];
            int i;
            for(i=1; i <arr.Length; i++)
            {
                if (arr[i] < min)
                { min = arr[i]; }
            }

            for (i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                { max = arr[i]; }
            }
        }

        public static void Find_UsingRef(int[] arr, ref int m1, ref int m2)
        {
            Find_UsingOut(arr, out m1, out m2);
        }

        public static ArrayStruct Find_UsingStruct(int[] arr)
        {
            ArrayStruct arrayStruct = new ArrayStruct();
            int min, max;
            Find_UsingOut(arr, out min, out max);
            arrayStruct.MinS = min;
            arrayStruct.MaxS = max;
            return arrayStruct;
        }

        public static (int, int) Find_UsingTuple(int[] arr)
        {
            int min, max;
            Find_UsingOut(arr, out min, out max);
            return (min, max);  
        }

        public static int[] Find_UsingArray(int[] arr)
        {
            int[] tempArray = new int[2];
            int m1, m2;
            Find_UsingOut(arr, out m1, out m2);
            tempArray[0] = m1;
            tempArray[1] = m2;
            return tempArray;
        }
    }
}
