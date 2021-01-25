using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasklist.Core.DataObjects
{
    public class DomainExeption : Exception
    {
        public DomainExeption() { }

        public DomainExeption(string message) : base(message) { }

        public DomainExeption(string message, Exception innerexcEption) : base(message, innerexcEption) { }
    }
}
