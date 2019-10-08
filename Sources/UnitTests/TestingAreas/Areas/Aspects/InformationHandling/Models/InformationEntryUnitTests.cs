using System;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.InformationHandling.Models;
using NUnit.Framework;

namespace Mmu.Mlh.WpfCoreExtensions.UnitTests.TestingAreas.Areas.Aspects.InformationHandling.Models
{
    [TestFixture]
    public class InformationEntryUnitTests
    {
        [Test]
        public void CreatingEmpty_CreatesEmptyInfoEntry()
        {
            // Act
            var actualInfoEntry = InformationEntry.CreateEmpty();

            // Assert
            Assert.AreEqual(false, actualInfoEntry.ShowBusy);
            Assert.AreEqual(string.Empty, actualInfoEntry.Message);
            Assert.IsNull(actualInfoEntry.DisplayLengthInSeconds);
            Assert.AreEqual(InformationEntryType.Info, actualInfoEntry.EntryType);
        }

        [Test]
        public void CreatingExeption_CreatesErrorEntry_WithExceptionMessage_AsMessage()
        {
            // Arrange
            const string Message = "Hello Exception";
            var exception = new ArgumentException(Message);

            // Act
            var actualInfoEntry = InformationEntry.CreateError(exception);

            // Assert
            Assert.AreEqual(false, actualInfoEntry.ShowBusy);
            Assert.AreEqual(Message, actualInfoEntry.Message);
            Assert.IsNull(actualInfoEntry.DisplayLengthInSeconds);
            Assert.AreEqual(InformationEntryType.Error, actualInfoEntry.EntryType);
        }

        [Test]
        public void CreatingInfo_CreatesInfoEntry_WithPassedParameters()
        {
            // Arrange
            const bool ShowBusy = true;
            const string Message = "Hello";
            const int DisplayLengthInSeconds = 4;

            // Act
            var actualInfoEntry = InformationEntry.CreateInfo(Message, ShowBusy, DisplayLengthInSeconds);

            // Assert
            Assert.AreEqual(ShowBusy, actualInfoEntry.ShowBusy);
            Assert.AreEqual(Message, actualInfoEntry.Message);
            Assert.AreEqual(DisplayLengthInSeconds, actualInfoEntry.DisplayLengthInSeconds);
            Assert.AreEqual(InformationEntryType.Info, actualInfoEntry.EntryType);
        }

        [Test]
        public void CreatingSuccess_CreatesSuccessEntry_WithPassedParameters()
        {
            // Arrange
            const bool ShowBusy = true;
            const string Message = "Hello";

            // Act
            var actualInfoEntry = InformationEntry.CreateSuccess(Message, ShowBusy, null);

            // Assert
            Assert.AreEqual(ShowBusy, actualInfoEntry.ShowBusy);
            Assert.AreEqual(Message, actualInfoEntry.Message);
            Assert.IsNull(actualInfoEntry.DisplayLengthInSeconds);
            Assert.AreEqual(InformationEntryType.Success, actualInfoEntry.EntryType);
        }
    }
}