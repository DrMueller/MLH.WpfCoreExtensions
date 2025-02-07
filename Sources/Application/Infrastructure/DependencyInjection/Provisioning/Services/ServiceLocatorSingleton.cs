﻿using JetBrains.Annotations;

namespace Mmu.Mlh.WpfCoreExtensions.Infrastructure.DependencyInjection.Provisioning.Services
{
    [PublicAPI]
    public static class ServiceLocatorSingleton
    {
        public static IServiceLocator Instance { get; private set; }

        public static void Initialize(IServiceLocator instance)
        {
            Instance = instance;
        }
    }
}