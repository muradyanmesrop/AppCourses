using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCourses.Core.Exceptions
{
    public class LogicException : Exception
    {
        public LogicException(string massage) : base(massage)
        {
        }
    }
}
