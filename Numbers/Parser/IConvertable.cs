using Numbers.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Parser
{
    public interface IConvertable
    {
        string Number { get; }

        Rank Rank { get; }

        bool IsEmpty { get; }
    }
}
