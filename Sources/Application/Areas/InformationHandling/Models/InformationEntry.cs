using System;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models
{
    public class InformationEntry
    {
        public int? DisplayLengthInSeconds { get; }
        public InformationEntryType EntryType { get; }
        public string Message { get; }
        public bool ShowBusy { get; }

        private InformationEntry(string message, InformationEntryType entryType, bool isBusy, int? lengthInSeconds)
        {
            Message = message;
            EntryType = entryType;
            ShowBusy = isBusy;
            DisplayLengthInSeconds = lengthInSeconds;
        }

        public static InformationEntry CreateEmpty()
        {
            return new InformationEntry(string.Empty, InformationEntryType.Info, false, null);
        }

        public static InformationEntry CreateException(Exception exception)
        {
            return new InformationEntry(exception.Message, InformationEntryType.Exception, false, null);
        }

        public static InformationEntry CreateInfo(string infoMessage, bool isBusy, int? lengthInSeconds = null)
        {
            return new InformationEntry(infoMessage, InformationEntryType.Info, isBusy, lengthInSeconds);
        }

        public static InformationEntry CreateSuccess(string successMessage, bool isBusy, int? lengthInSeconds = null)
        {
            return new InformationEntry(successMessage, InformationEntryType.Success, isBusy, lengthInSeconds);
        }
    }
}