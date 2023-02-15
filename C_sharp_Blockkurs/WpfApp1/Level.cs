using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Level
    {
        public int currentLevel { get; set; }
        private enum levels
        {
            leicht = 0,
            mittel = 1,
            schwer = 2
        }
        public string getLevelAsString()
        {

             return ((levels)currentLevel).ToString(); 
           
        }
    }
}
