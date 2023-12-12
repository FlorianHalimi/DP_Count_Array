
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of elements of the array: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter number between 1 and k: ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter the last element of the array: ");
        int x = int.Parse(Console.ReadLine());
        int rez1 = CountArraysDP(n, k, x);
        int rez2 = CountArrays(n, k, x);
        Console.WriteLine("Result using DP: " + rez1);
        Console.WriteLine("Result using Recursion: " + rez2);

    }

    // Time Complexity: O(n)
    // Space Complexity: O(n)
    public static int CountArraysDP(int n, int k, int x)
    {
        int[] arraysEndingWithX = new int[n];
        arraysEndingWithX[0] = 0;
        arraysEndingWithX[1] = 1;

        if (n <= 2)
        {
            return arraysEndingWithX[n - 1];
        }
        for (int i = 2; i < n; i++)
            arraysEndingWithX[i] = (k - 1) * arraysEndingWithX[i - 2] + (k - 2) * arraysEndingWithX[i - 1];

        return (x == 1 ? (k - 1) * arraysEndingWithX[n - 2] : arraysEndingWithX[n - 1]);
    }


    //Time Complexity: O(2^n)
    //Space Complexity: O(n)
    public static int CountArrays(int n, int k, int x)
    {

        int[] arraysEndingWithX = new int[n];
        arraysEndingWithX[0] = 0;
        arraysEndingWithX[1] = 1;

        return RecursiveCount(n, k, x, arraysEndingWithX);
    }
    private static int RecursiveCount(int n, int k, int x, int[] arraysEndingWithX)
    {
        if (n <= 2)
        {
            return arraysEndingWithX[n - 1];
        }


        arraysEndingWithX[n - 1] = (k - 1) * RecursiveCount(n - 2, k, x, arraysEndingWithX) +
                                   (k - 2) * RecursiveCount(n - 1, k, x, arraysEndingWithX);

        return (x == 1 ? (k - 1) * arraysEndingWithX[n - 2] : arraysEndingWithX[n - 1]);
    }
}
