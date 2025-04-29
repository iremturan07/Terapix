using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terapix.SERVICE.Exceptions
{
    public class NotFoundException(string message): Exception(message)
    {
    }
}
