using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingTests
{
    public class FourWheelVehicle : AbstractBaseVehicle
    {
        public FourWheelVehicle(string name)
            : base(name)
        {

        }

        public override void Accelerate()
        {
            Console.WriteLine("Four wheel vehicle is accelerating");
        }

        public override void Brake()
        {
            Console.WriteLine("Four wheel vehicle is braking");
        }
    }
}
