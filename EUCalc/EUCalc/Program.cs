using System;
using System.Collections.Generic;

namespace EUCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Country> Countries = new List<Country> { new Country("Germany", 22), new Country("France", 50) } ;

            foreach (Country x in Countries)
            {
                Console.WriteLine($"{x.name} & {x.population}");
            }

        }
    }
}
