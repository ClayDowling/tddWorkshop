using System;
using System.Collections.Generic;
using Xunit;
using NSubstitute;
using FluentAssertions;

namespace Katas
{
    public class RenewalNotificationServiceTest
    {
	    private readonly SubscriberService _subscriberService;
	    private readonly EmailService _emailService;
	    private readonly RenewalNotificationService _renewalNotificationService;

	    [Fact]
        public void NotifyingAtRiskSubscribersShouldSendEmails()
        {
			var expectedEmailAddresses = new List<string>{"foo@bar.com", "baz@blah.com"};
			_subscriberService.GetSubscribersThatWillExpireBetweenNowAndDate(25, 12, 2022).Returns(expectedEmailAddresses);
			List<string> capturedEmailAddresses = null;
			_emailService.EmailMessage(Arg.Any<string>(), Arg.Do<List<string>>(x => capturedEmailAddresses = x));

			_renewalNotificationService.NotifyAtRiskSubscribers();

			_emailService.Received(1).EmailMessage("foo", Arg.Any<List<string>>());
			capturedEmailAddresses.Should().BeEquivalentTo(expectedEmailAddresses);
        }

        public RenewalNotificationServiceTest()
        {
	        _subscriberService = Substitute.For<SubscriberService>();
	        _emailService = Substitute.For<EmailService>();
	        _renewalNotificationService = new RenewalNotificationService(_subscriberService, _emailService);
        }
    }
}
