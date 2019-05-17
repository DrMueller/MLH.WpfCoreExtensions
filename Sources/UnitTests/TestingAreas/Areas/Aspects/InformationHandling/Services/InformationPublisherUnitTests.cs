////using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
////using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
////using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services.Implementation;
////using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services.Servants;
////using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.ViewData;
////using Moq;
////using NUnit.Framework;

////namespace Mmu.Mlh.WpfCoreExtensions.UnitTests.TestingAreas.Areas.Aspects.InformationHandling.Services
////{
////    [TestFixture]
////    public class InformationPublisherUnitTests
////    {
////        private Mock<IInformationSubscriptionService> _subscriptionServiceMock;
////        private InformationPublisher _sut;
////        private Mock<IInformationEntryViewDataAdapter> _viewDataAdapterMock;

////        [SetUp]
////        public void Align()
////        {
////            _viewDataAdapterMock = new Mock<IInformationEntryViewDataAdapter>();
////            _subscriptionServiceMock = new Mock<IInformationSubscriptionService>();
////            _sut = new InformationPublisher(_viewDataAdapterMock.Object, _subscriptionServiceMock.Object);
////        }

////        [Test]
////        public void Publishing_PublishedToSubscrptionService()
////        {
////            // Arrange

////            var viewData = new InformationEntryViewData("Hello", true, Brushes.Black, 5);
////            _viewDataAdapterMock.Setup(f => f.Adapt(It.IsAny<InformationEntry>())).Returns(viewData);

////            InformationEntryViewData actualInfoViewData = null;
////            _subscriptionServiceMock.Setup(f => f.OnInformationReceived(It.IsAny<InformationEntryViewData>())).Callback<InformationEntryViewData>(e => actualInfoViewData = e);

////            // Act
////            _sut.Publish(null);

////            // Assert
////            Assert.AreEqual(viewData, actualInfoViewData);
////        }
////    }
////}