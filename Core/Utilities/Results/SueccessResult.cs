using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SueccessResult : Result
    {
        public SueccessResult(string message) : base(true, message)
        {

        }
        public SueccessResult() : base(true)
        {

        }
    }
}
