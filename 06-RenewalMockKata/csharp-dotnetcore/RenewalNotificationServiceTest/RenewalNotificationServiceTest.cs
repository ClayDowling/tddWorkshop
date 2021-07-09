using System;
using Xunit;
using NSubstitute;
using FluentAssertions;
using System.Collections.Generic;
using RenewalNotificationServiceTest;

namespace Katas
{
    public class RenewalNotificationServiceTest
    {
        [Fact]
        public void givenAtRiskSubscriberSendEmails()
        {
            var subscribeMockService = Substitute.For<ISubscriberService>();
            var emailMockService = new MockEmailService();
           
            var expectedEmailList = new List<string>() { "abc@abc.com", "xyz@xyz.com" };

            subscribeMockService.GetSubscribersThatWillExpireBetweenNowAndDate(new DateTime(2023, 12, 1)).Returns(expectedEmailList);

            RenewalNotificationService renewalNotificationService = new RenewalNotificationService(subscribeMockService, emailMockService);
            renewalNotificationService.notifyAtRiskSubscribers(new DateTime(2023, 12, 1));

            emailMockService.EmailList.Should().BeEquivalentTo(expectedEmailList);
            emailMockService.Message.Should().Be("You might think about renewing");
            emailMockService.NoOfTimesCalled.Should().Be(1);
		}

        [Fact]
        public void givenNoAtRiskSubscribersDontSendEmails()
        {
            var subscribeMockService = Substitute.For<ISubscriberService>();
            var emailMockService = new MockEmailService();

            subscribeMockService.GetSubscribersThatWillExpireBetweenNowAndDate(new DateTime(2023, 12, 1)).Returns((List<string>)null);

            RenewalNotificationService renewalNotificationService = new RenewalNotificationService(subscribeMockService, emailMockService);
            renewalNotificationService.notifyAtRiskSubscribers(new DateTime(2023, 12, 1));

            emailMockService.NoOfTimesCalled.Should().Be(0);            
        }
    }
}
