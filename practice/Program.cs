using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    class Program
    {

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
        

        static void Main(string[] args)
        {
            testFilter();
        }        
    }
}

