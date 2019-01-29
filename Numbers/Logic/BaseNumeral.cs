using Numbers.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Logic
{
    public abstract class BaseNumeral : IConvertable
    {
        protected Rank _rank;

        protected string _number = string.Empty;

        public BaseNumeral()
            :this("")
        {
            _rank = Rank.Default;
        }

        public BaseNumeral(string number)
        {
            _number = number;
        }

        public BaseNumeral(BaseNumeral numeral)
            :this(numeral._number)
        {
            _rank = numeral._rank;
        }

        public abstract Rank Rank { get; }
        public abstract bool IsEmpty { get; }

        public string Number
        {
            get { return _number; }
        }
        
        protected Rank GetRank() 
        {
            if (string.IsNullOrEmpty(_number))
            {
                return Rank.Default;
            }

            if (TextParser.IsUnits(_number))
            {
                return Rank.Unit;
            }

            if (TextParser.IsTens(_number))
            {
                return Rank.Ten;
            }

            if (TextParser.IsHundreds(_number))
            {
                return Rank.Hundred;
            }

            if (TextParser.IsThousands(_number))
            {
                return Rank.Thousand;
            }

            if (TextParser.IsMillions(_number))
            {
                return Rank.Million;
            }

            return Rank.Default;
        }
    }
}
