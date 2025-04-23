using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoAssignment
{
    
    
        public class InsufficientFundException : Exception
        {
            public InsufficientFundException(string message) : base(message) { }


        }



    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }


    public class OverDraftLimitExcededException : Exception
    {
        public OverDraftLimitExcededException(string message) : base(message) { }
    }

    public class NullPointerException : Exception
    {
        public NullPointerException(string message) : base(message) { }
    }
}

