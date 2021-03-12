using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Services
{
    public class SmsMessageSender : IMessageSender
    {
        public string Send(string message)
        {
            return $"Sent by SMS{message}";
        }

    }
}
