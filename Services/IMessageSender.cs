using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec2021.Services
{
    public interface IMessageSender
    {
        string Send(string message);
    }
}
