using Brains.Core.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Infrastructure.ActivationFunctions
{
    public class ReLu : IActivationFunction
    {
        public double CalculateOutput(double input)
        {
            return input >= 0 ? input : input / 100;
        }
        public double CalculateSlope(double output)
        {
            return output >= 0 ? 1 : 0.1;
        }
    }
}
