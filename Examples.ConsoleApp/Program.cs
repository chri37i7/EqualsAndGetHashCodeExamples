using Examples.Entities;
using System;

namespace Examples.ConsoleApp
{
    /// <summary>
    /// https://aaronstannard.com/overriding-equality-in-dotnet/
    /// </summary>
    public class Program
    {
        #region Static Fields
        // Employee objects
        static readonly Employee firstEmployee = new Employee("Hans", "Hansen", 27, new DateTime(1993, 8, 13));
        static readonly Employee secondEmployee = new Employee("Hans", "Hansen", 27, new DateTime(1993, 8, 13));
        static readonly Employee thirdEmployee = new Employee("Lars", "Larsen", 74, new DateTime(1946, 8, 13)); 
        #endregion

        static void Main()
        {
            // Test object equality
            TestObjectEquality();

            //Console.Clear();

            //// Test Employee equality
            //TestEmployeeEquality();

            //Console.Clear();

            //// Test GetHashCode
            //TestGetHashCode();
        }

        #region Object.Equals Test
        /// <summary>
        /// Tests <see cref="Employee.Equals(object)"/>
        /// </summary>
        static void TestObjectEquality()
        {
            // Create two different objects
            Random random = null;

            // Equal checks
            bool isfirstSameAsRandom = firstEmployee.Equals(random);

            // Output results
            Console.WriteLine($"First is same as random: {isfirstSameAsRandom}");

            Console.ReadLine();
        }
        #endregion

        #region IEquatable Implementation Test
        /// <summary>
        /// Tests <see cref="Employee.Equals(Employee)"/>
        /// </summary>
        static void TestEmployeeEquality()
        {
            // Equal checks
            bool isSecondSameAsfirst = secondEmployee.Equals(firstEmployee);
            bool isThirdSameAsFirst = thirdEmployee.Equals(firstEmployee);

            // Output results
            Console.WriteLine($"First is same as second: {isSecondSameAsfirst}");
            Console.WriteLine($"\nFirst is same as third: {isThirdSameAsFirst}");

            Console.ReadLine();
        }
        #endregion

        #region Object.GetHashCode Test
        /// <summary>
        /// Tests <see cref="Employee.GetHashCode()"/>
        /// </summary>
        static void TestGetHashCode()
        {
            // Get object hash codes
            int firstHashCode = firstEmployee.GetHashCode();
            int secondHashCode = secondEmployee.GetHashCode();
            int thirdHashCode = thirdEmployee.GetHashCode();

            // Output results
            Console.WriteLine($"First:  {firstHashCode}");
            Console.WriteLine($"Second: {secondHashCode}");
            Console.WriteLine($"Third:  {thirdHashCode}");
        } 
        #endregion
    }
}