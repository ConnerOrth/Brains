using Brains.Core.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Infrastructure.ActivationFunctions
{
    public class Step : IActivationFunction
    {
        private readonly double treshold;

        public Step(double treshold)
        {
            this.treshold = treshold;
        }

        public double CalculateOutput(double input)
        {
            return Convert.ToDouble(input > treshold);
        }

        public double CalculateSlope(double output)
        {
            throw new NotImplementedException();
        }
    }
}
