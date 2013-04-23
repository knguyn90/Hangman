using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ProgrammingTests.Examples
{
    [TestFixture]
    public class PolymorphismTests
    {
        [Test]
        public void AbstractBaseVehicle_Create_CanNotCreateAbstractClassDirectly()
        {
            // NOTE this does not compile, can not create an AbstractBaseVehicle
            //AbstractBaseVehicle vehicle = new AbstractBaseVehicle("Car");
        }

        [Test]
        public void FourWheelVehicle_CreateFourWheelVehicle_NameIsCar()
        {
            FourWheelVehicle vehicle = new FourWheelVehicle("Car");
            Assert.AreEqual("Car", vehicle.Name);
        }

        [Test]
        public void Car_CreateCar_NameIsCar()
        {
            Car vehicle = new Car();
            Assert.AreEqual("Car", vehicle.Name);
        }

        [Test]
        public void IVehicle_CreateCar_NameIsCar()
        {
            IVehicle vehicle = new Car();
            Assert.AreEqual("Car", vehicle.Name);
        }

        [Test]
        public void IVehicle_AccelerateCar_OutputsFourWheelAcceleration()
        {
            IVehicle vehicle = new Car();
            vehicle.Accelerate();
        }

        [Test]
        public void IVehicle_BrakeCar_OutputsCarBraking()
        {
            IVehicle vehicle = new Car();
            vehicle.Brake();
        }
    }
}
