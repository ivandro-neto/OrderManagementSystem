using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Exceptions;
public class OrderManagementSystemException : SystemException
{
    public OrderManagementSystemException(string message) : base(message) { }
}