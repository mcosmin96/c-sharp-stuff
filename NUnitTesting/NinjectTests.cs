using Ninject;
using NinjectAndStuff;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTesting
{
    [TestFixture]
    class NinjectTests
    {
        IKernel Container;

        [OneTimeSetUp]
        public void setup()
        {
            Container = new StandardKernel();
            Container.Bind<IEngine>().To<DieselEngine>();
            Container.Bind<IFuel>().To<PremiumPetrol>().InSingletonScope();
        }

        [Test, Order(0)]
        public void NinjectShouldPrintOutFuelType()
        {
            var sut = Container.Get<Car>();
            var result = sut.Engine.ToString();
            Assert.AreEqual(result, "Premium Petrol Engine");
        }

        [Test, Order(1)]
        public void NinjectSingletonFuelShouldRememberFuelLevel()
        {
            var sut = Container.Get<Car>();

            sut.Engine.FuelType.Level -= 5;
            var result = sut.Engine.FuelType.Level;
            Assert.AreEqual(result, 45);

            sut.Engine.FuelType.Level -= 5;
            result = sut.Engine.FuelType.Level;
            Assert.AreEqual(result, 40);

            sut = Container.Get<Car>();
            sut.Engine.FuelType.Level -= 5;
            result = sut.Engine.FuelType.Level;
            Assert.AreEqual(result, 35);
        }

        [Test, Order(2)]
        public void NinjectSingletonFuelShouldRememberFuelLevelFromOtherTest()
        {
            var sut = Container.Get<Car>();

            sut.Engine.FuelType.Level -= 5;
            var result = sut.Engine.FuelType.Level;
            Assert.AreEqual(result, 30);
        }
    }
}
