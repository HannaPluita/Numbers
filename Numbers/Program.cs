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
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            if (args.Length == 0 || string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                Output.OutputMessage(Output.EMPTY_ARGS);
            }
            else
            {
                input = args[0];
                Application app = new Application(input);
                app.Run();
                Input.Wait();
            }
            
            if (!Input.Continue())
            {
                Output.OutputMessage(Output.FINISH_APP);
                Input.Wait();
                return;
            }
           
            if (Input.ConsoleInputParameter(out input))
            {
                Application app = new Application(input);
                app.Run();

                Output.OutputMessage(Output.FINISH_APP);
                Input.Wait();
                return;
            }
            
            Output.OutputMessage(Output.FINISH_APP);
            Input.Wait();
        }
    }
}
