using System;
using System.Collections.Generic;

//Made by Michael Boyce, Lewis Parkings and James Lumsden
//This program is designed to emulate the EU voting calculator in a console based form.
//Further information about the calculator can be found at: https://www.consilium.europa.eu/en/council-eu/voting-system/voting-calculator/

namespace EUCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            static List<Country> makeCountries() //A method for importing the countries and adding them to a list.
            {
                List<Country> Countries = new List<Country>(); //We create a new List<Country> instance.

                string[] content = System.IO.File.ReadAllLines(@"..\..\..\countryList.txt");
                foreach (string line in content)
                {
                    string[] words = line.Split(",");
                    Countries.Add(new Country(words[0], Double.Parse(words[1]))); //And add every name, population comma delineated value.
                }

                return Countries;
            }

            List<Country> Countries = makeCountries(); //The Country object is a class that hold details about the country.

            //We define variables to keep track of the percentages of countries votes, as well as the total votes for each catagory.
            double YesTotal = 0;
            double NoTotal = 0;
            double AbstainTotal = 0;
            int Yes = 0;
            int No = 0;
            int Abstain = 0;
            int total = Countries.Count; //Plus the total countries.

            foreach (Country country in Countries) //Looping through each country in the list:
            {
                Console.WriteLine($"For {country.name}, would you like to abstain? (Y/N) \n"); //We check if they'd like to abstain them from the vote.
                string input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    //If abstained, we:
                    country.abstain = true; //Set the country's internal var "abstain" true,
                    AbstainTotal += country.population; //Add it to our abstain total population,
                    Abstain += 1; //And count it as an abstained country.
                    Console.WriteLine($"Abstained. Current percentages are: Yes - {YesTotal}%, No - {NoTotal}%, Abstain - {AbstainTotal}% \n"); 
                    //Each time a change is made, we show the "on the fly" percentages and totals ^^^
                }
                else if(input == "N")
                {
                    country.abstain = false;
                }
                else
                {
                    //We need to capture the input if it is something other than a legal value.
                    Console.WriteLine($"{input} is not a valid answer. Defaulting to N... \n");
                    country.abstain = false; //We just default to a sensible value in this case.
                }

                if (country.abstain == false) //We will only continue to ask for votes on said country if they haven't abstained.
                {
                    Console.WriteLine($"Would you like to vote for {country.name}? (Y/N) \n");
                    input = Console.ReadLine().ToUpper();  //We make sure the inputs are what we expect by making sure they're upper case, to eliminate lower case mismatches.
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
                    if (YesTotal >= 65 && Yes >= 15) //Here we give our running verdict if it was passed, or rejected. Only if both criteria are met will it be approved.
                    {
                        Console.WriteLine("Current final result - Approved \n");
                    }
                    else
                    {
                        Console.WriteLine("Current final result - Rejected \n");
                    }
                }

            }

            //From here, we give our final verdicts, including percentages, totals and Approved/Rejected status.
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
