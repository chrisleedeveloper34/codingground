//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Swap<T>(List<T> data, int pos1, int pos2)
        {
            T temp = data[pos1];
            data[pos1] = data[pos2];
            data[pos2] = temp;
        }
        
        public static void BubbleSort<T>(List<T> data)
        {
            for(int j = data.Count - 1; j > 0; j--)
            {
                for(int i = 0; i < j; i++)
                {
                    if(Comparer<T>.Default.Compare(data[i], data[i+1]) > 0)
                    {
                        Swap<T>(data, i, i+1);
                    }
                }
            }
        }
        
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int> {9,4,5,3,2,6,8,1,0,7};
            string strNumbers = String.Join(",", numbers);
            Console.WriteLine(strNumbers);
            BubbleSort<int>(numbers);
            strNumbers = String.Join(",", numbers);
            Console.WriteLine(strNumbers);
            
            List<char> chars = new List<char> {'i','d','h','a','g','c','j','f','e','b'};
            string strChars = String.Join(",", chars);
            Console.WriteLine(strChars);
            BubbleSort<char>(chars);
            strChars = String.Join(",", chars);
            Console.WriteLine(strChars);
        }
    }
}