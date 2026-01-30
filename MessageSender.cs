using System.Collections.Generic;

namespace SWENG421_Lab3
{
    //Send messages to multiple employees
    public interface MessageSender
    {
        void Send(string message, IEnumerable<Employee> recipients);
    }
}
