using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingTests
{
    public abstract class AbstractBaseVehicle : IVehicle
    {
        public string Name { get; private set; }

        protected AbstractBaseVehicle(string name)
        {
            Name = name;
        }

        public abstract void Accelerate();
        public abstract void Brake();
    }
}
