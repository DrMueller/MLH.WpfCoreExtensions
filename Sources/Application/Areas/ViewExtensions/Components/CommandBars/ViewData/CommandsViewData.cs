﻿using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Commands;

namespace Mmu.Mlh.WpfCoreExtensions.Areas.ViewExtensions.Components.CommandBars.ViewData
{
    public class CommandsViewData
    {
        public IReadOnlyCollection<ViewModelCommand> Entries { get; }

        public CommandsViewData(params ViewModelCommand[] entries)
        {
            Guard.ObjectNotNull(() => entries);
            Entries = entries;
        }
    }
}