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

        class Plant
        {
            public string Name { get; set; }
        }

        class CarnivorousPlant : Plant
        {
            public string TrapType { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
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

        public static void testConversion()
        {
            Plant[] plants = new Plant[] {
                new CarnivorousPlant { Name = "Venus Fly Trap", TrapType = "Snap Trap" },
                new CarnivorousPlant { Name = "Pitcher Plant", TrapType = "Pitfall Trap" },
                new CarnivorousPlant { Name = "Sundew", TrapType = "Flypaper Trap" },
                new CarnivorousPlant { Name = "Waterwheel Plant", TrapType = "Snap Trap" }
            };

            var query = from CarnivorousPlant cPlant in plants
                        where cPlant.TrapType == "Snap Trap"
                        select cPlant;

            foreach (var item in query)
            {
                Console.WriteLine("Name = {0}, Trap Type = {1}", item.Name, item.TrapType);
            }
            Console.ReadLine();
        }

        public static void testConcate()
        {
            Pet[] cats = {
                new Pet { Name="Barley", Age=8 },
                new Pet { Name="Boots", Age=4 },
                new Pet { Name="Whiskers", Age=1 }
            };

            Pet[] dogs = {
                new Pet { Name="Bounder", Age=3 },
                new Pet { Name="Snoopy", Age=14 },
                new Pet { Name="Fido", Age=9 }
            };

            IEnumerable<string> query = cats.Select(cat => cat.Name).Concat(dogs.Select(dog => dog.Name));
            foreach (var item in query)
            {
                Console.WriteLine("Name = {0}", item);
            }
            Console.ReadLine();
        }

        public static void testDefaultIfEmpty()
        {
            Pet barley = new Pet() { Name = "Barley", Age = 4 };
            Pet boots = new Pet() { Name = "Boots", Age = 1 };
            Pet whiskers = new Pet() { Name = "Whiskers", Age = 6 };
            Pet bluemoon = new Pet() { Name = "Blue Moon", Age = 9 };
            Pet daisy = new Pet() { Name = "Daisy", Age = 3 };

            List<Pet> pets = new List<Pet>() { barley, boots, whiskers, bluemoon, daisy };
            //List<Pet> pets = new List<Pet>();
            foreach (var item in pets.DefaultIfEmpty(new Pet() { Name = "dummy", Age = -1 }))
            {
                Console.WriteLine("Name = {0}", item.Name);
            }
            Console.ReadLine();
        }

        public static void testEnumRange()
        {
            // Generate a sequence of integers from 1 to 5  
            // and then select their squares.

            IEnumerable<int> squares = Enumerable.Range(1, 5).Select(x => x * x);
            foreach (var item in squares)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //testFilter();
            //testJoin();
            //testOrderBy();
            //testGroup();
            //testConversion();
            //testConcate();
            //testDefaultIfEmpty();
            testEnumRange();

        }        
    }
}

