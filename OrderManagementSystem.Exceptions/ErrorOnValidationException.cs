using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Exceptions
{
    public class ErrorOnValidationException : OrderManagementSystemException
    {
        public ErrorOnValidationException(string message) : base(message){ }
    }
}
