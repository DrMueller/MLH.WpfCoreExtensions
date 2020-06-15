using System;
using System.Threading.Tasks;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services.Implementation;
using Mmu.Mlh.WpfCoreExtensions.UnitTests.TestingInfrastructure.ViewModelMocks;
using Moq;
using NUnit.Framework;

namespace Mmu.Mlh.WpfCoreExtensions.UnitTests.TestingAreas.Areas.MvvmShell.ViewModels.Services
{
    [TestFixture]
    public class ViewModelFactoryUnitTests
    {
        private Mock<IServiceLocator> _serviceLocatorMock;
        private ViewModelFactory _sut;

        [SetUp]
        public void Align()
        {
            _serviceLocatorMock = new Mock<IServiceLocator>();
            _sut = new ViewModelFactory(_serviceLocatorMock.Object);
        }

        [Test]
        public async Task Creating_ViewModelBeingInitializable_InitializesViewModel_WithPassedParameters()
        {
            // Arrange
            var viewModel = new InitializibleMockViewModel();

            var initParam1 = "Hello";
            var initParam2 = 12345;

            _serviceLocatorMock.Setup(f => f.GetService(It.IsAny<Type>())).Returns(viewModel);

            // Act
            var actualViewModel = await _sut.CreateAsync<InitializibleMockViewModel>(initParam1, initParam2);

            // Assert
            Assert.IsNotNull(actualViewModel);
            Assert.AreEqual(viewModel, actualViewModel);
            Assert.IsTrue(actualViewModel.WasInitialized);
            Assert.IsNotNull(actualViewModel.InitParams);
            Assert.AreEqual(initParam1, actualViewModel.InitParams[0]);
            Assert.AreEqual(initParam2, actualViewModel.InitParams[1]);
        }
    }
}