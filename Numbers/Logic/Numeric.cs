using Numbers.Parser;
using Numbers.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Logic
{
    public class Numeric : BaseNumeral
    {
        public string NUMERIC = "Numeric";

        public Numeric()
            :base()
        {
        }

        public Numeric(string number)
            :base(number)
        {
        }

        public Numeric(Numeric numeric)
            :base(numeric)
        {
        }
       
        public override Rank Rank
        {
            get
            {
                return _rank;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", NUMERIC, _number);
        }

        public override bool IsEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(_number))
                {
                    return true;
                }

                return false;
            }
        }

        public void Init()
        {
            ClearOutNumber();
            _rank = GetRank();
        }

        protected bool ClearOutNumber()
        {
            if (!string.IsNullOrEmpty(_number))
            {
                _number = TextParser.PickOutNumerals(_number);
                _number = TextParser.StartZerosTrim(_number);

                return true;
            }

            return false;
        }
     
    }
}
