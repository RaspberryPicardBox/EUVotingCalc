using System;
using System.Collections.Generic;
using System.Text;

namespace EUCalc
{
    class Country
    {
        private string _name;
        private double _population;
        private bool _abstain;
        private bool _vote;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double population
        {
            get { return _population; }
            set { 
                if (value > 0)
                {
                    population = value;
                }
                                      }
        }
        public bool abstain
        {
            get { return _abstain; }
            set { _abstain = value; }
        }
        public bool vote
        {
            get { return _vote; }
            set { _vote = value; }
        }
        public Country(string newname, double newpopulation)
        {
            name = newname;
            population = newpopulation;
        }
    }
}
