using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        
        int sum = 0;
        int max = numbers[0];
        
        foreach (int number in numbers)
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
        }

        float average = ((float)sum) / numbers.Count;

        Console.WriteLine($"the sum is: {sum}");
        Console.WriteLine($"the average is: {average}");
        Console.WriteLine($"the largest number is: {max}");

        
        int smallestPositive = int.MaxValue; 
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }
        Console.WriteLine($"the smallest positive number is: {smallestPositive}");

        
        numbers.Sort(); 

        Console.WriteLine("the sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}