using System;
using System.Collections.Generic;

namespace Katas
{
    public class RenewalNotificationService
    {
		ISubscriberService _subscriberService;
		IEmailService _emailService;

		public RenewalNotificationService(ISubscriberService subscriberService, IEmailService emailService)
		{
			_subscriberService = subscriberService;
			_emailService = emailService;
		}

		public void notifyAtRiskSubscribers(DateTime selectedDate)
		{
			var emailList = _subscriberService.GetSubscribersThatWillExpireBetweenNowAndDate(selectedDate);
			if (emailList != null)
			{
				_emailService.EmailMessage("You might think about renewing", emailList);
			}
		}

    }
}
