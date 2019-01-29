using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Parser
{
    public interface IPrintable
    {
        string NumberInDigits { get; }

        string WordExpression { get; }
    }
}
