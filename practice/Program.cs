using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class Program
    {
        class DepartmentClass
        {
            public int DepartmentId { get; set; }
            public string Name { get; set; }
        }

        class EmployeeClass
        {
            public int EmployeeId { get; set; }
            public string EpmployeeName { get; set; }
            public int DepartmentId { get; set; }
        }


        public static void testFilter()
        {
            List<string> words = new List<string>() { "an", "apple", "a", "day" };

            var query = from word in words select word.Substring(0, 1);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

            List<string> phrases = new List<string>() { "an apple a day", "the quick brown fox" };

            var query2 = from phrase in phrases
                         from word in phrase.Split(' ')
                         select word;

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public static void testJoin()
        {
            List<DepartmentClass> departments = new List<DepartmentClass>();
            departments.Add(new DepartmentClass { DepartmentId = 1, Name = "Account" });
            departments.Add(new DepartmentClass { DepartmentId = 2, Name = "Sales" });
            departments.Add(new DepartmentClass { DepartmentId = 3, Name = "Marketing" });

            List<EmployeeClass> employees = new List<EmployeeClass>();
            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 1, EpmployeeName = "William" });
            employees.Add(new EmployeeClass { DepartmentId = 2, EmployeeId = 2, EpmployeeName = "Miley" });
            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 3, EpmployeeName = "Benjamin" });
            employees.Add(new EmployeeClass { DepartmentId = 3, EmployeeId = 4, EpmployeeName = "William" });

            var list = (from e in employees
                        join d in departments on e.DepartmentId equals d.DepartmentId
                        select new { EmployeeName = e.EpmployeeName, DepartmentName = d.Name }
                );

            foreach (var e in list)
            {
                Console.WriteLine("Employee Name = {0} , Department Name = {1}", e.EmployeeName, e.DepartmentName);
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public static void testOrderBy()
        {
            int[] num = { -20, 12, 6, 10, 0, -3, 1 };

            var posNums = from n in num
                          orderby n
                          select n;

            Console.WriteLine("Values in ascending order: ");
            foreach (int i in posNums)
            {
                Console.Write(i + "\n");
            }

            var posNumDesc = from n in num
                             orderby n descending
                             select n;

            Console.WriteLine("\nValues in descending  order: ");
            foreach (int i in posNumDesc)
            {
                Console.Write(i + "\n");
            }
            Console.ReadLine();
        }

        public static void testGroup()
        {
            List<int> numbers = new List<int>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };
            IEnumerable<IGrouping<int, int>> query = from number in numbers
                                                     group number by number % 2;

            foreach (var group in query)
            {
                Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");

                foreach (int i in group)
                    Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //testFilter();
            //testJoin();
            //testOrderBy();
            testGroup();
        }        
    }
}

