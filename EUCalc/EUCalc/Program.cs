using System;
using System.Collections.Generic;

namespace EUCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int Yes = 0;
            int No = 0;
            int Abstain = 0;

            List<Country> Countries = new List<Country>();

            string[] content = System.IO.File.ReadAllLines(@"..\..\..\countryList.txt");
            foreach (string line in content)
            {
                string[] words = line.Split(",");
                Countries.Add(new Country(words[0], Double.Parse(words[1])));
            }

            int total = Countries.Count;

            foreach (Country country in Countries)
            {
                Console.WriteLine($"For {country.name}, would you like to abstain? (Y/N)");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    country.abstain = true;
                    Abstain += 1;
                }
                else if(input == "N")
                {
                    country.abstain = false;
                }
                else
                {
                    Console.WriteLine($"{input} is not a valid answer. Defaulting to N...");
                    country.abstain = false;
                }

                if (country.abstain == false)
                {
                    Console.WriteLine($"Would you like to vote for {country.name}? (Y/N)");
                    input = Console.ReadLine().ToUpper();
                    if (input == "Y")
                    {
                        country.vote = true;
                        Yes += 1;
                    }
                    else if (input == "N")
                    {
                        country.vote = false;
                        No += 1;
                    }
                    else
                    {
                        Console.WriteLine($"{input} is not a valid answer. Defaulting to Y...");
                        country.vote = true;
                        Yes += 1;
                    }
                }

            }

            int percentYes = (total / 100) * Yes;
            int percentNo = (total / 100) * No;
            int percentAbstain = (total / 100) * Abstain;
            Console.WriteLine($"Out of total {total}, {Yes} were voted for, giving {percentYes}%. {No} were voted against, giving {percentNo}%, and {Abstain} abstained giving {percentAbstain}%.");
        }
    }
}
