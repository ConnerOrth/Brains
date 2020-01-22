using Brains.Core.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Infrastructure.ActivationFunctions
{
    public class HyperTanh : IActivationFunction
    {
        public double CalculateOutput(double input)
        {
            // approximation is correct to 30 decimals
            if (input < -20.0)
            {
                return -1.0;
            }
            else if (input > 20.0)
            {
                return 1.0;
            }
            return Math.Tanh(input);
        }

        public double CalculateSlope(double output)
        {
            return 1 - output * output;
        }
    }
}
