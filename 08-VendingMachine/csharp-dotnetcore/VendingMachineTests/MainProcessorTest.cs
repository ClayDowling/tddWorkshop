using FluentAssertions;
using Xunit;

namespace VendingMachineTests
{
    public class MainProcessorTest
    {
        [Fact]
        public void ProcessorHasButtonPanelAttached()
        {
            var mainProcessor = new MainProcessor();
            mainProcessor.ProductSelectionPanel.Should().NotBeNull();
        }
    }
}