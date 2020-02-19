using System;
using System.Collections.Generic;
using System.Text;

namespace EUCalc
{
    class Country
    {
        private string _name;
        private int _population;
        private bool _abstain;
        private bool _vote;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int population
        {
            get { return _population; }
            set { _population = value; }
        }

        public Country(string newname, int newpopulation)
        {
            name = newname;
            population = newpopulation;
        }
    }
}
