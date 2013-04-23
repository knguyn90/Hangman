using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingTests
{
    public class Car : FourWheelVehicle
    {
        public Car() : base("Car")
        {

        }

        public override void Brake()
        {
            Console.WriteLine("Car is braking");
        }

    }
}
