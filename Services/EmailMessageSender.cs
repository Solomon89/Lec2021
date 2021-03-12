using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send(string message)
        {
            return $"Sent by Email {message}";
        }

    }
}
