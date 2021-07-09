using System;
using System.Collections.Generic;

namespace Katas
{
    public interface IEmailService
    {
        void EmailMessage(String message, List<String> emails);
    }
}
