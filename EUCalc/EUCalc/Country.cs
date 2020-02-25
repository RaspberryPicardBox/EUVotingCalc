using System;
using System.Collections.Generic;
using System.Text;

namespace EUCalc
{
    class Country
    {
        //All values are abstracted away from the user, and only the "abstain" and "vote" booleans are controlled by the console interface.
        private string _name;
        private double _population;
        private bool _abstain;
        private bool _vote;

        public string name //These two variables are controlled by the makeCountries() method which reads their data from the external list.
        {
            get { return _name; }
            set { _name = value; }
        }
        public double population
        {
            get { return _population; }
            set { _population = value; }
        }
        public bool abstain //These two variables are set by the program user through the console when prompted.
        {
            get { return _abstain; }
            set { _abstain = value; }
        }
        public bool vote
        {
            get { return _vote; }
            set { _vote = value; }
        }
        public Country(string newname, double newpopulation) //This constructor is used upon first creation in the makeCountries() method.
        {
            //It ensures all necessary info about the country pre-vote is included.
            name = newname;
            population = newpopulation;
        }
    }
}
