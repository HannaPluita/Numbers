using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Parser
{
    public interface IReadable: IConsoleOutput
    {
        string NumberInWords { get; }

        string NumberInDigits { get; }

        bool Read();

        bool IsEmpty { get; }
    }
}
