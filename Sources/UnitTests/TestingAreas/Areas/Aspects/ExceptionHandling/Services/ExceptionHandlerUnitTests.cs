using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ExceptionHandling.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.Logging.Services;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.WpfCoreExtensions.UnitTests.TestingAreas.Areas.Aspects.ExceptionHandling.Services
{
    [TestFixture]
    public class ExceptionHandlerUnitTests
    {
        private ExceptionHandler _sut;
        private Mock<ILoggingService> _loggingServiceMock;
        private Mock<IInformationPublisher> _informationPublisherMock;

        [SetUp]
        public void Align()
        {
            _loggingServiceMock = new Mock<ILoggingService>();
            _informationPublisherMock = new Mock<IInformationPublisher>();

            _sut = new ExceptionHandler(_loggingServiceMock.Object, _informationPublisherMock.Object);
        }

        [Test]
        public void HandlingException_LogsExceptionOnce()
        {
            // Arrange
            var exception = new Exception("Hello Test");

            // Act
            _sut.Handle(exception);

            // Assert
            _loggingServiceMock.Verify(f => f.LogException(exception), Times.Once);
        }

        [Test]
        public void HandlingException_PublishesExceptionOnce_WithExceptionMessageAsText()
        {
            // Arrange
            const string ExcpetionText = "Hello Tra";
            var exception = new Exception(ExcpetionText);

            InformationEntry actualInfoEntry = null;

            _informationPublisherMock.Setup(f => f.Publish(It.IsAny<InformationEntry>())).Callback<InformationEntry>(e => actualInfoEntry = e);

            // Act
            _sut.Handle(exception);

            // Assert
            Assert.IsNotNull(actualInfoEntry);
            Assert.AreEqual(ExcpetionText, actualInfoEntry.Message);
            Assert.AreEqual(InformationEntryType.Exception, actualInfoEntry.EntryType);
        }
    }
}