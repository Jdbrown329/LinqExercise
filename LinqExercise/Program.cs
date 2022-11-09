using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine(numbers.Sum());
            //TODO: Print the Average of numbers
            Console.WriteLine(numbers.Average());
            //TODO: Order numbers in ascending order and print to the console
            var ascArray = numbers.OrderBy(i => i);
            foreach (var num in ascArray)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in decsending order and print to the console
            var decArray = from num in numbers orderby num descending select num;
            foreach (var num in decArray)
            {
                Console.WriteLine(num);
            }
            //TODO: Print to the console only the numbers greater than 6
            var over6 = from num in numbers where num > 6 orderby num select num;
            foreach (var num in over6)
            {
                Console.WriteLine(num);
            }
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var randomFour = numbers.OrderBy(num => num).Take(4);
            foreach (var num in randomFour)
            {
                Console.WriteLine(num);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[3] = 32;
            var jordanAge = numbers.OrderByDescending(num => num);
            Console.WriteLine("--------------");
           
            foreach (var num in jordanAge)
            {
                Console.WriteLine(num);
            }
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var startsCS = employees.Select(name => name.FirstName).Where(name => name.StartsWith("S") || name.StartsWith("C")).OrderBy(name => name);

            foreach (var emp in startsCS)
            {
                Console.WriteLine(startsCS);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var olderEmps = employees.Select(employees => employees).Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FullName).ToArray();

            foreach (var emp in olderEmps)
            {
              Console.WriteLine($"Full Name: {emp.FullName}, Age:{emp.Age}");
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var experiencedEmp = employees
                .Select(employees => employees)
                .Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35)
                .Select(emp => emp.YearsOfExperience)
                .ToArray();

            Console.WriteLine($"Sum: {experiencedEmp.Sum()}, Average: {experiencedEmp.Average()}");

            //TODO: Add an employee to the end of the list without using employees.Add()
            var newEmp = new Employee("Jason", "Biggs", 38, 0);
            employees.Insert(employees.Count, newEmp);

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FullName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        
        }

    #region CreateEmployeesMethod
    private static List<Employee> CreateEmployees ()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
