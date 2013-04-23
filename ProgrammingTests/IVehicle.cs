using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingTests
{
    public interface IVehicle
    {
        string Name { get; }
        void Accelerate();
        void Brake();
    }
}
