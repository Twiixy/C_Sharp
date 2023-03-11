using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ScoreData
    {

        public string _Name { get; set; }
        public double _Clicks { get; set; }

        public ScoreData(string name, double clicks)
        {
            _Clicks = clicks;
            _Name = name;
        }

    }
}
