using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace FunctionsAndProcedures
{
	/// <summary>
	/// Tasks 1-9 from page 347 of the book "Fundamentals of Computer Programming with C# (The Bulgarian C# Book)"
	/// </summary>
	internal class Program
	{
		private static void Main()
		{
			// Sample data to test program operation
			int[] digitArray = {1, 7, 2, 4, 7, 1, 2, 7, 4, 4};
			BigInteger[] bigDigitArray1 = { 1, 5, 8, 2, 6 };
			BigInteger[] bigDigitArray2 = { 7, 9, 8, 0, 9 };
			const int digitOperableValue = 4;

			// Program Testing
			Task1("Peter");
			Task2(9, 12, 8);
			Console.WriteLine(Task3(198765));
			Console.WriteLine("The value {0} was found in the array {1} times.", digitOperableValue, Task4(digitArray, digitOperableValue));
			Task5(digitArray, 5);
			Console.WriteLine("The first occurence of a greater-than-both value is at index: {0}", Task6(digitArray));
			Console.WriteLine("1234567890 backwards is {0}", Task7(1234567890));
			Console.WriteLine("{0} + {1} is equal to {2}", StupidIntArrayToInt(bigDigitArray1), StupidIntArrayToInt(bigDigitArray2), Task8(bigDigitArray1, bigDigitArray2));

			Console.Write("The descending of var digitArray is: [{0}] \n", string.Join(",", Task9(digitArray)));
		}

		/// <summary>
		/// Write a code that by given name prints on the console "Hello, <name>!" (for example: "Hello, Peter!").
		/// </summary>
		/// <param name="name">The name to output along with the text</param>
		private static void Task1(string name) => Console.WriteLine("Hello, {0}!", name);

		/// <summary>
		/// Create a method GetMax() with two integer (int) parameters, that returns maximal of the two numbers. 
		/// Write a program that reads threenumbers from the console and prints the biggest of them. 
		/// Use the GetMax() method you just created. Write a test program that validates that the methods works correctly.
		/// </summary>
		/// <param name="var1">First integer value</param>
		/// <param name="var2">Sedcond integer value</param>
		/// <param name="var3">Third Integer Value</param>
		private static void Task2(int var1, int var2, int var3)
		{
			int max1 = GetMax(var1, var2), max2 = GetMax(max1, var3);
			Console.WriteLine("From the values {0}, {1}, and {2}; {3} was the largest.", var1, var2, var3, max2);
		}

		/// <summary>Returns maximal of two numbers.</summary>
		/// <remarks>Uses a lambda expression to shorten code length</remarks>
		/// <param name="var1">First Integer Value</param>
		/// <param name="var2">Second Integer Value</param>
		private static int GetMax(int var1, int var2) => var1 > var2 ? var1 : var2;

		/// <summary>
		/// Write a method that returns the English name of the last digit of a given number.
		/// </summary>
		/// <remarks>The last digit is found using the module operator '%' which is used to find remainders</remarks>
		/// <param name="number">Number to find digit-name of</param>
		/// <returns>Sting name of last digit</returns>
		private static string Task3(int number)
		{
			switch (number%10)
			{
				case 0:
					return "zero";
				case 1:
					return "one";
				case 2:
					return "two";
				case 3:
					return "three";
				case 4:
					return "four";
				case 5:
					return "five";
				case 6:
					return "six";
				case 7:
					return "seven";
				case 8:
					return "eight";
				case 9:
					return "nine";
				default:
					return "Invalid Value";
			}
		}

		/// <summary>
		/// Write a method that finds how many times certain number can be found in a given array. 
		/// </summary>
		/// <remarks>This example uses LINQ expressions as well as lambda expressions to shorten code.</remarks>
		/// <param name="intArray">The array to find a value from</param>
		/// <param name="valueToFind">The int value to search for in the given array</param>
		/// <returns>How many times the value is found as an int</returns>
		private static int Task4(IEnumerable<int> intArray, int valueToFind) => intArray.Count(t => t == valueToFind);

		/// <summary>
		/// Write a method that checks whether an element, from a certain position in an array is greater than its two neighbors.
		/// </summary>
		/// <param name="intArray">The array to check from</param>
		/// <param name="index">The index of the specified array value</param>
		/// <returns></returns>
		private static void Task5(IReadOnlyList<int> intArray, int index)
		{
			if (index == 0 || index == intArray.Count - 1 || index >= intArray.Count)
			{
				Console.WriteLine("Invalid index value: {0}", index);
				return;
			}

			int prevNeighbour = intArray[index - 1];
			int nextNeighbour = intArray[index + 1];

			Console.WriteLine(GetMax(prevNeighbour, index) == index && GetMax(nextNeighbour, index) == index ?
				$"The value at index {index} is greater than each of it's neighbours." :
				$"The value at index {index} is not greater than one or more of it's neighbours.");
		}

		/// <summary>
		/// Write a method that returns the position of the first occurrence of an element from an array,
		/// such that it is greater than its two neighbors simultaneously.
		/// Otherwise the result must be -1.
		/// </summary>
		/// <param name="intArray"></param>
		/// <returns></returns>
		private static int Task6(IReadOnlyList<int> intArray)
		{
			for (int index = 0; index < intArray.Count; index++)
			{
				if (index == 0 || index == intArray.Count - 1 || index >= intArray.Count) continue;
				int prevNeighbour = intArray[index - 1];
				int nextNeighbour = intArray[index + 1];
				if (GetMax(prevNeighbour, intArray[index]) == intArray[index] &&
				    GetMax(nextNeighbour, intArray[index]) == intArray[index])
				{
					return index;
				}
			}
			return -1;
		}

		/// <summary>
		/// Write a method that prints the digits of a given decimal number in a reversed order. 
		/// For example 256, must be printed as 652.
		/// </summary>
		/// <param name="num">Number to be reversed</param>
		private static int Task7(int num)
		{
			char[] charArray = num.ToString().ToCharArray();
			Array.Reverse(charArray);
			return int.Parse(new string(charArray));
		}

		/// <summary>
		/// Write a method that calculates the sum of two very long positive 
		/// integer numbers.The numbers are represented as array digits and
		/// the last digit (the ones) is stored in the array at index 0. Make the
		/// method work for all numbers with length up to 10,000 digits.
		/// </summary>
		/// <param name="integer1"></param>
		/// <param name="integer2"></param>
		/// <returns></returns>
		private static BigInteger Task8(BigInteger[] integer1, BigInteger[] integer2)
		{
			return StupidIntArrayToInt(integer1) + StupidIntArrayToInt(integer2);
		}

		/// <summary>
		/// Helper method for Task 8 to convert arrays to big ints
		/// </summary>
		/// <param name="intArray">BigInt array to convert</param>
		/// <returns>Special bigint value of array</returns>
		private static BigInteger StupidIntArrayToInt(BigInteger[] intArray)
		{
			string intString = "";
			for (int index = 0; index < intArray.Length; index++)
			{
				BigInteger t = intArray[index];
				if (index == 0)	continue;
				if (index == intArray.Length - 1)
				{
					intString += t.ToString();
					intString += intArray[0].ToString();
				}
				else
				{
					intString += t.ToString();
				}
			}
			return BigInteger.Parse(intString);
		}

		/// <summary>
		/// Write a method that finds the biggest element of an array. 
		/// Use that method to implement sorting in descending order.
		/// </summary>
		/// <param name="arrayToSort">The array to sort in descending order.</param>
		/// <returns>A sorted integer array.</returns>
		private static IEnumerable<int> Task9(IReadOnlyCollection<int> arrayToSort)
		{
			List<int> oldArray = arrayToSort.ToList();
			List<int> newArray = new List<int>();

			for (int index = 0; index < arrayToSort.Count; index++)
			{
				newArray.Add(oldArray.Max());
				oldArray.RemoveAt(oldArray.IndexOf(oldArray.Max()));
			}
			return newArray.ToArray();
		}
	}
}
