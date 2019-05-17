////using System.Windows.Media.Imaging;
////using Mmu.Mlh.TestingExtensions.Areas.ConstructorTesting.Services;
////using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
////using NUnit.Framework;

////namespace Mmu.Mlh.WpfCoreExtensions.UnitTests.TestingAreas.Areas.Initialization.Orchestration.Models
////{
////    [TestFixture]
////    public class WpfAppConfigUnitTests
////    {
////        [Test]
////        public void Constructor_Works()
////        {
////            const string AppTitle = "Title";
////            var assembly = typeof(WpfAppConfigUnitTests).Assembly;
////            var icon = new BitmapImage();

////            ConstructorTestBuilderFactory.Constructing<WpfAppConfig>()
////                    .UsingDefaultConstructor()
////                    .WithArgumentValues(null, AppTitle, icon).Fails()
////                    .WithArgumentValues(assembly, null, icon).Fails()
////                    .WithArgumentValues(assembly, AppTitle, null).Fails()
////                    .WithArgumentValues(assembly, AppTitle, icon)
////                    .Maps()
////                    .ToProperty(f => f.AppTitle).WithValue(AppTitle)
////                    .ToProperty(f => f.Icon).WithValue(icon)
////                    .ToProperty(f => f.WpfAssembly).WithValue(assembly)
////                    .BuildMaps()
////                    .Assert();
////        }

////        [Test]
////        public void CreatingWithDefaultIcon_UsesDefaultIcon()
////        {
////            // Arrange
////            var assembly = typeof(WpfAppConfigUnitTests).Assembly;

////            // Act
////            var actualConfig = WpfAppConfig.CreateWithDefaultIcon(assembly, "Hello");

////            // Assert
////            Assert.AreEqual(500, actualConfig.Icon.Width);
////            Assert.AreEqual(600, actualConfig.Icon.Height);
////        }
////    }
////}