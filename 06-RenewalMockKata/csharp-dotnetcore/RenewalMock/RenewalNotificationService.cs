using System;
using System.Collections.Generic;

namespace Katas
{
    public class RenewalNotificationService
    {
		private readonly SubscriberService _subscriberService;
		private readonly EmailService _emailService;

		public RenewalNotificationService(SubscriberService subscriberService, EmailService emailService)
		{
			this._subscriberService = subscriberService;
			_emailService = emailService;
		}

		public void NotifyAtRiskSubscribers()
		{
			var emailAddresses = _subscriberService.GetSubscribersThatWillExpireBetweenNowAndDate(25, 12, 2022);
			_emailService.EmailMessage("foo", emailAddresses);
		}
    }
}
