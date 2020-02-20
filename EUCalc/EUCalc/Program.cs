using System;
using System.Collections.Generic;

//Made by Michael Boyce, Lewis Parkings and James Lumsden

namespace EUCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            static List<Country> makeCountries()
            {
                List<Country> Countries = new List<Country>();

                string[] content = System.IO.File.ReadAllLines(@"..\..\..\countryList.txt");
                foreach (string line in content)
                {
                    string[] words = line.Split(",");
                    Countries.Add(new Country(words[0], Double.Parse(words[1])));
                }

                return Countries;
            }

            List<Country> Countries = makeCountries();

            double YesTotal = 0;
            double NoTotal = 0;
            double AbstainTotal = 0;
            int Yes = 0;
            int No = 0;
            int Abstain = 0;
            int total = Countries.Count;

            foreach (Country country in Countries)
            {
                Console.WriteLine($"For {country.name}, would you like to abstain? (Y/N) \n");
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    country.abstain = true;
                    AbstainTotal += country.population;
                    Abstain += 1;
                    Console.WriteLine($"Abstained. Current percentages are: Yes - {YesTotal}%, No - {NoTotal}%, Abstain - {AbstainTotal}% \n");
                }
                else if(input == "N")
                {
                    country.abstain = false;
                }
                else
                {
                    Console.WriteLine($"{input} is not a valid answer. Defaulting to N... \n");
                    country.abstain = false;
                }

                if (country.abstain == false)
                {
                    Console.WriteLine($"Would you like to vote for {country.name}? (Y/N) \n");
                    input = Console.ReadLine().ToUpper();
                    if (input == "Y")
                    {
                        country.vote = true;
                        YesTotal += country.population;
                        Yes += 1;
                        Console.WriteLine($"Abstained. Current percentages are: Yes - {YesTotal}%, No - {NoTotal}%, Abstain - {AbstainTotal}% \n");
                    }
                    else if (input == "N")
                    {
                        country.vote = false;
                        NoTotal += country.population;
                        No += 1;
                        Console.WriteLine($"Abstained. Current percentages are: Yes - {YesTotal}%, No - {NoTotal}%, Abstain - {AbstainTotal}% \n");
                    }
                    else
                    {
                        Console.WriteLine($"{input} is not a valid answer. Defaulting to Y... \n");
                        country.vote = true;
                        YesTotal += country.population;
                        Yes += 1;
                        Console.WriteLine($"Abstained. Current percentages are: Yes - {YesTotal}%, No - {NoTotal}%, Abstain - {AbstainTotal}% \n");
                    }
                    if (YesTotal >= 65 && Yes >= 15)
                    {
                        Console.WriteLine("Current final result - Approved \n");
                    }
                    else
                    {
                        Console.WriteLine("Current final result - Rejected \n");
                    }
                }

            }
            Console.WriteLine($"Out of total {total}, {Yes} were voted for, giving {YesTotal}%. {No} were voted against, giving {NoTotal}%, and {Abstain} abstained giving {AbstainTotal}%. \n");

            if (YesTotal >= 65 && Yes >= 15)
            {
                Console.WriteLine("Final result - Approved");
            }
            else
            {
                Console.WriteLine("Final result - Rejected ");
            }
        }
    }
}
