using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Demo_FileHandling_Streams
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Ayush", Department = "HR" },
                new Employee { Id = 2, Name = "Nandani", Department = "IT" },
                new Employee { Id = 3, Name = "Charlie", Department = "Finance" }
            };

            string filePath = @"D:\Wipro .NET with React\Week 1\Day 5 - Demo\Demo_FileHandling_Streams\bin\Debug\employees.json";

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    // json serializer is used to serialize the employees list to json string 
                    // this can be used to share data between different systems or store it in a file
                    JsonSerializer.Serialize(fs, employees);
                }
               
                Console.WriteLine("Data written to file successfully. ");

                // Reading the data back from the file
                FileStream read = new FileStream(filePath, FileMode.Open);

                List<Employee> deserializedEmployees = JsonSerializer.Deserialize<List<Employee>>(read);
                // we have include ststem.Memory as reference in the project file
                // displaying the deserializedEmployees data
                if (deserializedEmployees != null)
                {
                    foreach (var emp in deserializedEmployees)
                    {
                        Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found in the file.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
        }
    }
