using Numbers.Logic;
using Numbers.Parser;
using Numbers.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class Application
    {
        private string _input = string.Empty;

        public Application()
        {
        }

        public Application(string input)
        {
            _input = input;
        }

        public Application(Application app)
            :this(app._input)
        {
        }

        public void Run()
        {
            NumberReader reader = new NumberReader(_input);
            if (reader.Read())
            {
                reader.OutputNumberToConsole();
            }
        }
    }
}
