using NUnit.Framework;
using NinjectAndStuff;
using Moq;

namespace NUnitTesting
{
    [TestFixture]
    public class EngineTest
    {
        IFuel _fuel;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<IFuel>();
            mock.Setup(fuel => fuel.ToString()).Returns("Premium Petrol");
            mock.Setup(fuel => fuel.IsCompatible(It.IsAny<IEngine>()))
                .Returns((IEngine engine) => engine.GetType().Name.StartsWith("Petrol"));
            _fuel = mock.Object;
        }

        [Test]
        public void ShouldPrintOutFuelType()
        {
            var sut = new PetrolEngine(new PremiumPetrol());
            var result = sut.ToString();
            Assert.AreEqual(result, "Premium Petrol Engine");
        }

        [Test]
        public void MockShouldPrintOutFuelType()
        {
            var sut = new PetrolEngine(_fuel);
            var result = sut.ToString();
            Assert.AreEqual(result, "Premium Petrol Engine");
        }

        [Test]
        public void DieselShouldTellPrice()
        {
            var sut = new PetrolEngine(new Diesel());
            var result = sut.ToString();
            Assert.AreEqual(result, "Diesel(1.1) Engine");
        }

        [Test]
        public void PremiumPetrolNotCompatibleWithDieselEngines()
        {
            var sut = new PremiumPetrol();
            var result = sut.IsCompatible(new DieselEngine(new Diesel()));
            Assert.IsFalse(result);
        }

        [Test]
        public void MockPetrolFuelCompatibleWithAnyEngines()
        {
            var sut = _fuel;
            var result = sut.IsCompatible(new PetrolEngine(new Petrol()));
            Assert.IsTrue(result);
        }
    }
}
