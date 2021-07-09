using Katas;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewalNotificationServiceTest
{
    public class MockEmailService : IEmailService
    {
        void IEmailService.EmailMessage(string message, List<string> emails)
        {
            Message = message;
            EmailList = emails;
            NoOfTimesCalled++;
        }

        public string Message { get; set; }

        public List<string> EmailList { get; set; }

        public int NoOfTimesCalled { get; set; }
    }
}
