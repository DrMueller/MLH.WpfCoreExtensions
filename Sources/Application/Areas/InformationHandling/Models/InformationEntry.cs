using System;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.InformationHandling.Models
{
    public class InformationEntry
    {
        public bool ShowBusy { get; }
        public int? LengthInSeconds { get; }
        public string Message { get; }

        private InformationEntry(string message, bool isBusy, int? lengthInSeconds)
        {
            Message = message;
            ShowBusy = isBusy;
            LengthInSeconds = lengthInSeconds;
        }

        public static InformationEntry CreateEmpty()
        {
            return new InformationEntry(string.Empty, false, null);
        }

        public static InformationEntry CreateInfo(string infoMessage, bool isBusy, int? lengthInSeconds = null)
        {
            return new InformationEntry(infoMessage, isBusy, lengthInSeconds);
        }

        public static InformationEntry CreateException(Exception exception)
        {
            return new InformationEntry(exception.Message, false, null);
        }

        public static InformationEntry CreateSuccess(string successMessage, bool isBusy, int? lengthInSeconds = null)
        {
            return new InformationEntry(successMessage, isBusy, lengthInSeconds);
        }
    }
}