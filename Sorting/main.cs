using System.IO;
using System;

class Program
{
    static void Swap(int[] data, int pos1, int pos2)
    {
        int temp = data[pos1];
        data[pos1] = data[pos2];
        data[pos2] = temp;
    }
    
    static void BubbleSort(int[] data)
    {
        for(int j = data.Length-1; j > 0; j--)
        {
            for(int i = 0; i < j; i++)
            {
                //Console.WriteLine($"i = {i}, j = {j}");
                if (data[i] > data[i+1])
                {
                    Swap(data, i, i+1);
                    string numbers = String.Join(",", data);
                    Console.WriteLine(numbers);
                }
            }
        }
    }
    
    static int IntMinArray(int[] data, int start)
    {
        int min = start;
        for(int i = start + 1; i < data.Length; i++)
        {
            if(data[i] < data[min])
            {
                min = i;
            }
        }
        return min;
    }
    
    static void IntArraySelectionSort(int[] data)
    {
        for(int i = 0; i < data.Length - 1; i++)
        {
            int min = IntMinArray(data, i);
            if(i != min)
            {
                Swap(data, i, min);
                string numbers = String.Join(",", data);
                Console.WriteLine(numbers);
                
            }
        }
    }
    
    static void Main()
    {
        int[] myArray = {6,4,1,5,7,3,9,2};
        
        string numbers = String.Join(",", myArray);

        Console.WriteLine(numbers);

        //Swap(myArray, 2, 3);
        //BubbleSort(myArray);
        IntArraySelectionSort(myArray);
        //int minInArray = IntMinArray(myArray, 3);
    }
}
