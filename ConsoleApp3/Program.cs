using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDbContext tdbc = new TestDbContext();

            var list = tdbc.Employees.ToList();
            
            list.ForEach(e => Console.WriteLine(e.Id + " " + e.FirstName));

            using (Stream st = File.Open("Employees.dat", FileMode.Create))
            {
                //Employee e1 = new Employee {
                //    Id = 101,
                //    FirstName = "Mark",
                //    LastName = "Smith",
                //    Salary = 1020,
                //    DepartmentId = 1
                //};

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, list);
            }

            using (Stream st = File.Open("Employees.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                var res = bf.Deserialize(st) as List<Employee>;

                foreach (var e in res)
                {
                    Console.WriteLine(e);
                }
                // Console.WriteLine(res);
            }
        }
    }
}
