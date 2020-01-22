using Brains.Core.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Infrastructure.ActivationFunctions
{
    public class Sigmoid : IActivationFunction
    {
        private double _coeficient;

        public Sigmoid(double coeficient)
        {
            _coeficient = coeficient;
        }

        public double CalculateOutput(double input)
        {
            return 1 / (1 + Math.Exp(-input * _coeficient));
        }

        public double CalculateSlope(double input)
        {
            return input * (1 - input);
        }
    }
}
