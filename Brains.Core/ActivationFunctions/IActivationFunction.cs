using System;
using System.Collections.Generic;
using System.Text;

namespace Brains.Core.ActivationFunctions
{
    public interface IActivationFunction
    {
        double CalculateOutput(double input);
        double CalculateSlope(double output);
    }
}
