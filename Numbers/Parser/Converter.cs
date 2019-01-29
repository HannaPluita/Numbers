using Numbers.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Parser
{
    public class Converter : Reader, IPrintable
    {
        #region    Constants
        public const byte UNITS_LENGTH = 1;
        public const byte TENS_LENGTH = 2;
        public const byte HUNDREDS_LENGTH = 3;
        public const byte THOUSANDS_LENGTH = 6;
        public const byte MILLIONS_LENGTH = 9;
        public const byte MAX_LENGTH = 9;

        public const byte TRIPLE_LENGTH = 3;
        #endregion

        public Converter()
        {
        }

        public Converter(IConvertable iconvert)
        {
            _convert = iconvert;
        }

        public Converter(Converter c)
            : this(c._convert)
        {
        }

        protected readonly IConvertable _convert;

        protected Queue<char> _queueDigits = new Queue<char>();
        protected Rank _rank;

        public bool IsEmpty
        {
            get
            {
                return _convert.IsEmpty;
            }
        }

        public string WordExpression
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach (string item in _wordExpression)
                {
                    sb.Append(item);
                }

                return sb.ToString().TrimEnd(EMPTY_SPACE);
            }
        }

        public string NumberInDigits
        {
            get
            {
                return _convert.Number;
            }
        }

        public bool Init()
        {
            _rank = _convert.Rank;
            return StrNumberToQueue();
        }

        public void ReadAllNumber()                                     //Calls ReadParts() depending on its parameters
        {
            switch (_convert.Rank)
            {
                case Rank.Unit:
                case Rank.Ten:
                case Rank.Hundred:
                    ReadParts((byte)Rank.Hundred);
                    break;

                case Rank.Thousand:
                    ReadParts((byte)Rank.Thousand);
                    break;

                case Rank.Million:
                    ReadParts((byte)Rank.Million);
                    break;

                default:
                    break;
            }
        }

        protected bool StrNumberToQueue()
        {
            if (_convert != null && !_convert.IsEmpty && _convert.Number.Length != 0)
            {
                for (int i = 0; i < _convert.Number.Length; ++i)
                {
                    _queueDigits.Enqueue(_convert.Number[i]);
                }

                return true;
            }

            return false;
        }

        protected byte CountResidueOfTriplesDiv()
        {
            if (_queueDigits.Count < TRIPLE_LENGTH)
            {
                return (byte)_queueDigits.Count;
            }

            return (byte)(_queueDigits.Count % TRIPLE_LENGTH);
        }

        protected byte CountQuotientOfTripleDiv()
        {
            if(_queueDigits.Count < TRIPLE_LENGTH)
            {
                return 0;
            }

            return (byte)(_convert.Number.Length / TRIPLE_LENGTH);
        }

        protected bool GetResidueString(out string residueLine)         //Works with _queueDigits
        {
            byte residue = CountResidueOfTriplesDiv();

            if (residue == 0)
            {
                residueLine = String.Empty;
                return false;
            }

            StringBuilder bufSrt = new StringBuilder();

            for (byte i = 0; i < residue; ++i)
            {
                bufSrt.Append(_queueDigits.Dequeue());
            }

            residueLine = bufSrt.ToString();

            return true;
        }

        protected bool GetTriple(out string tripleLine)                 //Works with _queueDigits
        {
            if (_queueDigits.Count == 0 )
            {
                tripleLine = String.Empty;
                return false;
            }

            StringBuilder bufTriple = new StringBuilder();

            for (byte i = 0; i < TRIPLE_LENGTH; ++i)
            {
                bufTriple.Append(_queueDigits.Dequeue());
            }

            tripleLine = bufTriple.ToString();

            return true;
        }

        protected bool ReadParts(byte index)                            //Launches reading a number by triple parts
        {
            bool readResidue = false;
            string residueStr = string.Empty;
            string tripleStr = string.Empty;

            if(index < (byte)Rank.Hundred || index > (byte)Rank.Million)
            {
                return false;
            }

            while (_queueDigits.Count > 0)   //index != 1
            {
                if(!readResidue && (CountResidueOfTriplesDiv() != 0) && (GetResidueString(out residueStr)))
                {
                    ReadTripleOfDigits(residueStr, (Rank)index);
                    readResidue = true;
                    --index;
                    continue;
                }

                if(GetTriple(out tripleStr))
                {
                    ReadTripleOfDigits(tripleStr, (Rank)index);
                    --index;
                }
            }

            return true;
        }
    }
}
