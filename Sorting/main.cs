using System.IO;
using System;
using System.Collections.Generic;

class Program
{
    static void Swap(int[] data, int pos1, int pos2)
    {
        Console.WriteLine($"Swapping pos{pos1} value {data[pos1]} and pos{pos2} value {data[pos2]}");
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
    
    static void IntArrayInsertionSort(int[] data)
    {
        for(int j = 1; j < data.Length; j++)
        {
            for(int i = j; i > 0; i--)
            {
                if(data[i] < data[i-1])
                {
                    Swap(data, i, i-1);
                    string numbers = String.Join(",", data);
                    Console.WriteLine(numbers);
                }
            }
        }
    }
    
    static void IntArrayQuickSortRecursive(int[] data, int left, int right)
    {
        int i = left;
        int j = right;
        int pivot = data[(left + right) / 2];
        Console.WriteLine(pivot);
        while (true)
        {
            while(data[i] < pivot)
            {
                Console.WriteLine($"i {i} value {data[i]} is less than pivot {pivot}");
                i++;
            }
            while(pivot < data[j])
            {
                Console.WriteLine($"pivot {pivot} is less than j {j} value {data[j]}");
                j--;
            }
            if(i <= j)
            {
                Console.WriteLine($"i {i} value {data[i]} is <= j {j} value {data[j]}");
                Swap(data, i, j);
                string numbers = String.Join(",", data);
                Console.WriteLine(numbers);
                i++;
                j--;
            }
            if(i > j)
            {
                Console.WriteLine("break");
                break;
            }
        }
        if(left < j)
        {
            Console.WriteLine($"Calling recursive left {left} and j {j}");
            IntArrayQuickSortRecursive(data, left, j);
        }
        if(i < right)
        {
            Console.WriteLine($"Calling recursive right {right} and i {i}");
            IntArrayQuickSortRecursive(data, i, right);
        }
    }
    
    static void IntArrayQuickSort(int [] data)
    {
        IntArrayQuickSort(data, 0, data.Length - 1);
    }
    
    static int Partition(int[] data, int left, int right)
    {
        int pivot = data[left];
        while(true)
        {
            while(data[left] < pivot)
            {
                left++;
            }
            while(data[right] > pivot)
            {
                right--;
            }
            
            if (left < right)
            {
                //Console.WriteLine($"left = {left} right = {right}");
                Swap(data, right, left);
            }
            else
            {
                Console.WriteLine($"Returning right {right}");
                return right;
            }
        }
    }
    
    struct QuickPosInfo
    {
        public int left;
        public int right;
    };
    
    static void IntArrayQuickSort(int[] data, int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        List<QuickPosInfo> list = new List<QuickPosInfo>();
        QuickPosInfo info;
        info.left = left;
        info.right = right;
        list.Insert(list.Count, info);
        
        //http://www.softwareandfinance.com/CSharp/QuickSort_Iterative.html
        while(true)
        {
            if(list.Count == 0)
            {
                break;
            }
            
            left = list[0].left;
            right = list[0].right;
            list.RemoveAt(0);
            
            int pivot = Partition(data, left, right);
            
            if (pivot > 1)
            {
                info.left = left;
                info.right = pivot - 1;
                list.Insert(list.Count, info);
            }
            
            if (pivot + 1 < right)
            {
                info.left = left + 1;
                info.right = right;
                list.Insert(list.Count, info);
            }
        }
    }
    
    static void Main()
    {
        int[] myArray = {6,4,1,8,5,7,3,0,9,2};
        
        string numbers = String.Join(",", myArray);
        Console.WriteLine(numbers);

        //Swap(myArray, 2, 3);
        //BubbleSort(myArray);
        //int minInArray = IntMinArray(myArray, 3);
        //IntArraySelectionSort(myArray);
        //IntArrayInsertionSort(myArray);
        IntArrayQuickSort(myArray);
        
        numbers = String.Join(",", myArray);
        Console.WriteLine(numbers);

    }
}
