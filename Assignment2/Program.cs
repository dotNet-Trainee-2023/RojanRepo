using Assignment2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\rojan.joshi\OneDrive - Cotiviti\Desktop\Dotnet\Dotnet\Assignment2\employees.csv";
        // Read the CSV file and create a list of Employee objects
        List<Employee> employees = File.ReadLines(filePath)
            .Skip(1) // Skip the header row
            .Select(line => line.Split(','))
            .Select(data => new Employee
            {
                FirstName = data[0],
                LastName = data[1],
                Email = data[2],
                Phone = data[3],
                Gender = data[4],
                Age = int.Parse(data[5]),
                JobTitle = data[6],
                YearsOfExperience = int.Parse(data[7]),
                Salary = decimal.Parse(data[8]),
                Department = data[9]
            })
            .ToList();

        // Now you have a list of Employee objects in the 'employees' variable.

        // Use LINQ to perform the requested operations.
        // 1. Group employees by department
        var departmentGroups = employees.GroupBy(emp => emp.Department);
        Console.WriteLine("Employees grouped by department:");
        foreach (var group in departmentGroups)
        {
            Console.WriteLine($"Department: {group.Key}, Count: {group.Count()}");
        }
        Console.WriteLine();

        // 2. Find the highest salary earning Project Manager
        var highestPaidPM = employees
            .Where(emp => emp.JobTitle == "Project Manager")
            .OrderByDescending(emp => emp.Salary)
            .FirstOrDefault();
        Console.WriteLine("Highest Paid Project Manager:");
        if (highestPaidPM != null)
        {
            Console.WriteLine($"Name: {highestPaidPM.FirstName} {highestPaidPM.LastName}");
            Console.WriteLine($"Salary: {highestPaidPM.Salary:C}");
        }
        else
        {
            Console.WriteLine("No Project Manager found.");
        }
        Console.WriteLine();

        // 3. Find the most experienced Web Developer
        var mostExperiencedWebDev = employees
            .Where(emp => emp.JobTitle == "Web Developer")
            .OrderByDescending(emp => emp.YearsOfExperience)
            .FirstOrDefault();
        Console.WriteLine("Most Experienced Web Developer:");
        if (mostExperiencedWebDev != null)
        {
            Console.WriteLine($"Name: {mostExperiencedWebDev.FirstName} {mostExperiencedWebDev.LastName}");
            Console.WriteLine($"Years of Experience: {mostExperiencedWebDev.YearsOfExperience}");
        }
        else
        {
            Console.WriteLine("No Web Developer found.");
        }
        Console.WriteLine();

        // 4. Find the average salary of all job titles
        var averageSalariesByJobTitle = employees
            .GroupBy(emp => emp.JobTitle)
            .Select(group => new
            {
                JobTitle = group.Key,
                AverageSalary = group.Average(emp => emp.Salary)
            });
        Console.WriteLine("Average Salaries by Job Title:");
        foreach (var result in averageSalariesByJobTitle)
        {
            Console.WriteLine($"Job Title: {result.JobTitle}, Average Salary: {result.AverageSalary:C}");
        }
        Console.WriteLine();

        // 5. Find the total number of male and female employees
        var genderCounts = employees
            .GroupBy(emp => emp.Gender)
            .Select(group => new
            {
                Gender = group.Key,
                Count = group.Count()
            });
        Console.WriteLine("Gender Counts:");
        foreach (var result in genderCounts)
        {
            Console.WriteLine($"Gender: {result.Gender}, Count: {result.Count}");
        }
        Console.WriteLine();
    }
}

